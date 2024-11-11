using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NailWarehouse.Models;
using NailWarehouse.Models.Interfaces;
using Xunit;

namespace NailWarehouse.Memory.Tests
{
    /// <summary>
    /// Тесты для <see cref="MemoryNailStorage"/>
    /// </summary>
    public class MemoryNailStorageTests
    {
        private readonly INailStorage nailStorage;

        /// <summary>
        /// Конструтор 
        /// </summary>
        public MemoryNailStorageTests()
        {
            nailStorage = new MemoryNailStorage();
        }

        /// <summary>
        /// Добавление в хранилище
        /// </summary>
        [Fact]
        public async Task AddAsyncShouldReturnNail()
        {
            // Arrange
            var model = DataGenerator.GetDefaultNail();

            // Act
            var result = await nailStorage.AddAsync(model);

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeEquivalentTo(new
                {
                    model.Id,
                    model.Material,
                });
        }

        /// <summary>
        /// Удаление из хранилища
        /// </summary>
        [Fact]
        public async Task DeleteAsyncShouldReturnTrue()
        {
            // Arrange
            var model = DataGenerator.GetDefaultNail();

            // Act
            await nailStorage.AddAsync(model);
            var result = await nailStorage.DeleteAsync(model.Id);

            var nailList = await nailStorage.GetAllAsync();
            var tryGetModel = nailList.FirstOrDefault(x => x.Id == model.Id);

            // Assert
            result.Should().BeTrue();
            tryGetModel.Should().BeNull();
        }

        /// <summary>
        /// Изменение данных в хранилище
        /// </summary>
        [Fact]
        public async Task EditAsyncShouldUpdateStorageData()
        {
            // Arrange
            var model = DataGenerator.GetDefaultNail();
            var oldModelPrice = model.Price;
            var editedModel = new Nail()
            {
                Id = model.Id,
                Name = $"Name{Guid.NewGuid()}",
                Length = model.Length + 1.0M,
                Material = Material.Copper,
                Count = model.Count + 10,
                MinCount = model.MinCount + 1,
                Price = model.Price + 1000.0M
            };

            // Act
            await nailStorage.AddAsync(model);
            await nailStorage.EditAsync(editedModel);
            var nailList = await nailStorage.GetAllAsync();
            var result = nailList.FirstOrDefault(x => x.Id == editedModel.Id);

            // Assert
            result?.Should().NotBeNull();
            result?.Id.Should().Be(model.Id);
            result?.Price.Should().NotBe(oldModelPrice);
        }

        /// <summary>
        /// При пустом списке нет ошибок
        /// </summary>
        [Fact]
        public async Task GetAllAsyncShouldNotThrow()
        {
            // Act
            Func<Task> act = () => nailStorage.GetAllAsync();

            // Assert
            await act.Should().NotThrowAsync();
        }

        /// <summary>
        /// Получает пустой список
        /// </summary>
        [Fact]
        public async Task GetAllAsyncShouldReturnEmpty()
        {
            // Act
            var result = await nailStorage.GetAllAsync();

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeEmpty();
        }

    }
}
