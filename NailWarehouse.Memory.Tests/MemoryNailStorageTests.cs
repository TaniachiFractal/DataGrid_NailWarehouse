using System;
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

        [Fact]
        public void TryTest()
        {
            Assert.Contains("aa", "aa");
        }

        /// <summary>
        /// Конструтор 
        /// </summary>
        public MemoryNailStorageTests()
        {
            nailStorage = new MemoryNailStorage();
        }

        /// <summary>
        /// При пустом списке нет ошибок
        /// </summary>
        [Fact]
        public async Task GetAllShouldNotThrow()
        {
            // Arrange

            // Act
            Func<Task> act = () => nailStorage.GetAllAsync();

            // Assert
            await act.Should().NotThrowAsync();

        }

        /// <summary>
        /// Получает пустой список
        /// </summary>
        [Fact]
        public async Task GetAllShouldReturnEmpty()
        {
            // Arrange

            // Act
            var result = await nailStorage.GetAllAsync();

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeEmpty();

        }

        /// <summary>
        /// Добавление в хранилище
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task AddAsyncShouldReturnValue()
        {
            // Arrange
            var model = new Nail()
            {
                Id = Guid.NewGuid(),
                Name = $"Name{Guid.NewGuid()}",
                Length = 1.0M,
                Material = Material.Copper,
                Count = 10,
                MinCount = 1,
                Price = 100.0M
            };

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
    }
}
