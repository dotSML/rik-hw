using api.Application.DTOs;
using api.Application.Mappers;
using api.Application.Services;
using api.Domain.Enums;
using api.Domain.Models;
using api.Domain.Repositories;
using api.Domain.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Tests.UnitTests.Domain.Services
{
    public class AttendeeServiceTests
    {
        private readonly AttendeeService _attendeeService;
        private readonly Mock<IAttendeeRepository> _mockRepository;
        private readonly Mock<IEventService> _mockEventService;
        private readonly Mock<IPaymentMethodService> _mockPaymentMethodsService;

        public AttendeeServiceTests()
        {
            _mockRepository = new Mock<IAttendeeRepository>();
            _mockPaymentMethodsService = new Mock<IPaymentMethodService>();
            _mockEventService = new Mock<IEventService>();
            _attendeeService = new AttendeeService(_mockRepository.Object, _mockEventService.Object);
        }

        [Fact]
        public async Task CreateAttendeeAsync_ShouldReturnNewAttendeeId()
        {
            var paymentMethodId = Guid.NewGuid();
            // Arrange
            var createAttendeeDto = new CreateAttendeeDto
            {
                FirstName = "John",
                LastName = "Doe",
                PersonalIdCode = "39610222727",
                PaymentMethodId = paymentMethodId,
                EventId = Guid.NewGuid(),
                Type = AttendeeType.NaturalPerson,
            };
            var newAttendee = new NaturalPersonAttendee(createAttendeeDto.EventId, createAttendeeDto.FirstName, createAttendeeDto.LastName, createAttendeeDto.PersonalIdCode, paymentMethodId, "Additional Info", Guid.NewGuid(), null, null);

            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<Attendee>())).ReturnsAsync(newAttendee);

            // Act
            var result = await _attendeeService.CreateAttendeeAsync(createAttendeeDto);

            // Assert
            Assert.NotEqual(Guid.Empty, result);
            _mockRepository.Verify(repo => repo.AddAsync(It.Is<NaturalPersonAttendee>(a =>
                a.FirstName == createAttendeeDto.FirstName && a.EventId == createAttendeeDto.EventId)), Times.Once);
        }

        [Fact]
        public async Task GetAttendeesForEventAsync_ShouldReturnAttendees_WhenEventExists()
        {
            // Arrange
            var eventId = Guid.NewGuid();
            var attendees = new List<NaturalPersonAttendee>
            {
                new NaturalPersonAttendee(eventId, "John", "Doe", "123456789", Guid.NewGuid(), "Additional Info", Guid.NewGuid(), null, null),
                new NaturalPersonAttendee(eventId, "Jane", "Doe", "987654321", Guid.NewGuid(), "Additional Info", Guid.NewGuid(), null, null)
            };

            _mockEventService.Setup(service => service.GetEventByIdAsync(eventId)).ReturnsAsync(new EventDto { Id = eventId });
            _mockRepository.Setup(repo => repo.GetByEventIdAsync(eventId)).ReturnsAsync(attendees);

            // Act
            var result = await _attendeeService.GetAttendeesForEventAsync(eventId);

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(attendees.Count, result.Count());
            _mockRepository.Verify(repo => repo.GetByEventIdAsync(eventId), Times.Once);
        }

        [Fact]
        public async Task GetAttendeesForEventAsync_ShouldReturnNull_WhenEventDoesNotExist()
        {
            // Arrange
            var eventId = Guid.NewGuid();
            _mockEventService.Setup(service => service.GetEventByIdAsync(eventId)).ReturnsAsync((EventDto)null);

            // Act
            var result = await _attendeeService.GetAttendeesForEventAsync(eventId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnAttendeeDto_WhenAttendeeExists()
        {
            // Arrange
            var attendeeId = Guid.NewGuid();
            var attendee = new NaturalPersonAttendee(Guid.NewGuid(), "John", "Doe", "123456789", Guid.NewGuid(), "Additional Info", attendeeId, null, null);

            _mockRepository.Setup(repo => repo.GetByIdAsync(attendeeId)).ReturnsAsync(attendee);

            // Act
            var result = await _attendeeService.GetByIdAsync(attendeeId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(attendeeId, result.Id);
            Assert.Equal("John", result.FirstName);
        }

        [Fact]
        public async Task UpdateByIdAsync_ShouldUpdateAndReturnUpdatedAttendeeDto()
        {
            // Arrange
            var attendeeId = Guid.NewGuid();
            var updateAttendeeDto = new UpdateAttendeeDto { FirstName = "Jane" };
            var attendee = new NaturalPersonAttendee(attendeeId, "John", "Doe", "123456789", Guid.NewGuid(), "Additional Info", attendeeId, null, null);

            _mockRepository.Setup(repo => repo.GetByIdAsync(attendeeId)).ReturnsAsync(attendee);
            _mockRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Attendee>()));

            // Act
            var result = await _attendeeService.UpdateByIdAsync(attendeeId, updateAttendeeDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(attendeeId, result.Id);
            Assert.Equal(updateAttendeeDto.FirstName, result.FirstName);
            _mockRepository.Verify(repo => repo.UpdateAsync(It.Is<NaturalPersonAttendee>(a =>
                a.AttendeeId == attendeeId && a.FirstName == updateAttendeeDto.FirstName)), Times.Once);
        }

        [Fact]
        public async Task DeleteByIdAsync_ShouldReturnTrue_WhenDeletionSucceeds()
        {
            // Arrange
            var attendeeId = Guid.NewGuid();
            _mockRepository.Setup(repo => repo.DeleteAsync(attendeeId)).ReturnsAsync(true);

            // Act
            var result = await _attendeeService.DeleteByIdAsync(attendeeId);

            // Assert
            Assert.True(result);
            _mockRepository.Verify(repo => repo.DeleteAsync(attendeeId), Times.Once);
        }

        [Fact]
        public async Task DeleteByIdAsync_ShouldReturnFalse_WhenDeletionFails()
        {
            // Arrange
            var attendeeId = Guid.NewGuid();
            _mockRepository.Setup(repo => repo.DeleteAsync(attendeeId)).ReturnsAsync(false);

            // Act
            var result = await _attendeeService.DeleteByIdAsync(attendeeId);

            // Assert
            Assert.False(result);
        }
    }
}