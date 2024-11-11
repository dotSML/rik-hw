﻿using api.Application.DTOs;
using api.Domain.Entities;

namespace api.Application.Mappers
{
    public static class EventMapper
    {
        public static Event ToEntity(this EventDto dto)
        {
            return new Event(dto.Name, dto.Date, dto.Location, dto.AdditionalInfo);
        }


        public static EventDto ToDto(this Event entity)
        {
            return new EventDto
            {
                EventId = entity.EventId,
                Name = entity.Name,
                Date = entity.Date,
                Location = entity.Location,
                AdditionalInfo = entity.AdditionalInfo,
                
            };
        }
    }
}