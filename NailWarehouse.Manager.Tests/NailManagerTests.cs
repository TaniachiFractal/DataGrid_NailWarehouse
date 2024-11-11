using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NailWarehouse.Models;
using NailWarehouse.Models.Interfaces;
using Xunit;

namespace NailWarehouse.Manager.Tests
{
    public class NailManagerTests
    {
        private readonly INailManager nailManager;
        private readonly Mock<INailStorage> storageMock;
        private readonly Mock<ILogger> loggerMock;
        /// <summary>
        /// 3 стандартных гвоздя <see cref="DataGenerator.GetDefaultNail"/>
        /// </summary>
        private readonly Task<IReadOnlyCollection<Nail>> filledDefaultNailList;

        /// <summary>
        /// Конструктор <see cref="NailManagerTests"/>
        /// </summary>
        public NailManagerTests()
        {
            storageMock = new Mock<INailStorage>();

            loggerMock = new Mock<ILogger>();
            loggerMock.Setup(x => x.Log(LogLevel.Information,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()
                ));

            nailManager = new NailManager(storageMock.Object, loggerMock.Object);

            filledDefaultNailList = Task.FromResult<IReadOnlyCollection<Nail>>(
                new List<Nail>
                {
                    DataGenerator.GetDefaultNail(),
                    DataGenerator.GetDefaultNail(),
                    DataGenerator.GetDefaultNail(),
                }
                );
        }

        /// <summary>
        /// Добавление в хранилище
        /// </summary>
        [Fact]
        public async Task AddAsyncShouldWork()
        {
            // Arrange
            var model = DataGenerator.GetDefaultNail();

            storageMock.Setup(x => x.AddAsync(It.IsAny<Nail>()))
                .ReturnsAsync(model);

            // Act
            var result = await nailManager.AddAsync(model);

            #region Assert

            result.Should()
                .NotBeNull()
                .And.Be(model);

            storageMock.Verify(x => x.AddAsync(It.Is<Nail>(y => y.Id == model.Id)),
                Times.Once);
            storageMock.VerifyNoOtherCalls();

            loggerMock.Verify(x => x.Log(LogLevel.Information, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(), null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);
            loggerMock.VerifyNoOtherCalls();

            #endregion
        }

        /// <summary>
        /// Удаление из хранилища
        /// </summary>
        [Fact]
        public async Task DeleteAsyncShouldWork()
        {
            // Arrange
            var model = DataGenerator.GetDefaultNail();

            storageMock.Setup(x => x.DeleteAsync(It.IsAny<Guid>()))
                .ReturnsAsync(true);

            // Act
            var result = await nailManager.DeleteAsync(model.Id);

            #region Assert

            result.Should()
                .Be(true);

            storageMock.Verify(x => x.DeleteAsync(It.Is<Guid>(y => y == model.Id)),
                Times.Once);
            storageMock.VerifyNoOtherCalls();

            loggerMock.Verify(x => x.Log(LogLevel.Information, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(), null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);
            loggerMock.VerifyNoOtherCalls();

            #endregion
        }

        /// <summary>
        /// Изменение данных в хранилище
        /// </summary>
        [Fact]
        public async Task EditAsyncShouldWork()
        {
            // Arrange
            var model = DataGenerator.GetDefaultNail();
            storageMock.Setup(x => x.EditAsync(It.IsAny<Nail>()));

            // Act
            await nailManager.EditAsync(model);

            #region Assert

            storageMock.Verify(x => x.EditAsync(It.Is<Nail>(y => y.Id == model.Id)),
                Times.Once);
            storageMock.VerifyNoOtherCalls();

            loggerMock.Verify(x => x.Log(LogLevel.Information, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(), null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);
            loggerMock.VerifyNoOtherCalls();

            #endregion
        }

        /// <summary>
        /// Получение данных из хранилища; Данных нет
        /// </summary>
        [Fact]
        public async Task GetAllAsyncShouldReturnEmpty()
        {
            // Arrange
            storageMock.Setup(x => x.GetAllAsync());

            // Act
            var result = await nailManager.GetAllAsync();

            // Assert
            result.Should().BeNull();

            storageMock.Verify(x => x.GetAllAsync(), Times.Once);
            storageMock.VerifyNoOtherCalls();

            loggerMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Получить 3 стандартных гвоздя из хранилища
        /// </summary>
        [Fact]
        public async Task GetAllAsyncShouldReturn3Nails()
        {
            // Arrange
            storageMock.Setup(x => x.GetAllAsync())
                .Returns(filledDefaultNailList);

            // Act
            var result = await nailManager.GetAllAsync();

            // Assert
            result.Count.Should().Be(3);

            storageMock.Verify(x => x.GetAllAsync(), Times.Once);
            storageMock.VerifyNoOtherCalls();

            loggerMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Получение вычисляемых данных; Три стандартных гвоздя; см. <see cref="DataGenerator.GetDefaultNail"/>
        /// </summary>
        [Fact]
        public async Task GetStatsAsync3DefaultNails()
        {
            // Arrange
            storageMock.Setup(x => x.GetAllAsync())
                .Returns(filledDefaultNailList);

            // Act
            var result = await nailManager.GetStatsAsync();

            // Assert
            result.Should().BeEquivalentTo(new
            {
                FullCount = 3M,
                FullSummaryNoTax = 3000.0M,
                FullSummaryWithTax = 3600.00M,
            });

            storageMock.Verify(x => x.GetAllAsync(), Times.Once);
            storageMock.VerifyNoOtherCalls();

            loggerMock.VerifyNoOtherCalls();

        }
    }

}
