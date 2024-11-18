using api.Application.DTOs;
using api.Application.Mappers;
using api.Application.Services;
using api.Domain.Models;
using api.Domain.Repositories;
using Moq;
using Xunit;

namespace Tests.UnitTests.Domain.Services
{
    public class EventServiceTests
    {
        private readonly EventService _eventService;
        private readonly Mock<IEventRepository> _mockRepository;

        public EventServiceTests()
        {
            _mockRepository = new Mock<IEventRepository>();
            _eventService = new EventService(_mockRepository.Object);
        }

        [Fact]
        public async Task CreateEventAsync_ShouldReturnNewEventId()
        {
            // Arrange
            var createEventDto = new CreateEventDto { Name = "Test Event", Date = DateTime.UtcNow.AddDays(1) };

            // Act
            var result = await _eventService.CreateEventAsync(createEventDto);

            // Assert
            Assert.NotEqual(Guid.Empty, result);
        }

        [Fact]
        public async Task GetEventByIdAsync_ShouldReturnEvent_WhenEventExists()
        {
            // Arrange
            var mockEvent =
            new
            {
                Id = Guid.NewGuid(),
                Name = "Test Event",
                Date = DateTime.UtcNow.AddDays(1),
                AdditionalInfo = "Test Additional Info",
                Location = "Test Location"

            };

            var createEventDto = new CreateEventDto { Name = mockEvent.Name, Date = mockEvent.Date };
            var eventId = await _eventService.CreateEventAsync(createEventDto);
            _mockRepository.Setup(x => x.GetByIdAsync(eventId)).ReturnsAsync(new Event(mockEvent.Name, mockEvent.Date, mockEvent.AdditionalInfo, mockEvent.Location, mockEvent.Id));

            // Act
            var result = await _eventService.GetEventByIdAsync(eventId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createEventDto.Name, result.Name);
        }

        [Fact]
        public async Task GetAllEventsAsync_ShouldReturnAllEvents()
        {
            // Arrange
            var createEventDto = new CreateEventDto { Name = "Test Event", Date = DateTime.UtcNow.AddDays(1) };
            await _eventService.CreateEventAsync(createEventDto);
            _mockRepository.Setup(x => x.GetAllAsync(null)).ReturnsAsync(new List<Event> { createEventDto.ToModel() });

            // Act
            var events = await _eventService.GetAllEventsAsync(null);

            // Assert
            Assert.NotEmpty(events);
        }
    }
}