using System;
using System.Buffers.Text;
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
        }

        [Fact]
        public async Task AddShouldWork()
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

            storageMock.Setup(x => x.AddAsync(It.IsAny<Nail>()))
                .ReturnsAsync(model);

            // Act
            var result = await nailManager.AddAsync(model);

            // Assert
            result.Should()
                .NotBeNull()
                .And.Be(model);

            storageMock.Verify(x => x.AddAsync(It.Is<Nail>(y => y.Id == model.Id)),
                Times.Once);

            storageMock.VerifyNoOtherCalls();

            loggerMock.Verify(x => x.Log(LogLevel.Information, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(), null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>())
            );
        }

    }
}
