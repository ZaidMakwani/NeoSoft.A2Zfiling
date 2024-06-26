﻿using AutoMapper;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Exceptions;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IDataProtector _protector;

        public DeleteEventCommandHandler(IEventRepository eventRepository, IDataProtectionProvider provider)
        {             
            _eventRepository = eventRepository;
            _protector = provider.CreateProtector("");
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var eventId = new Guid(_protector.Unprotect(request.EventId));
            var eventToDelete = await _eventRepository.GetByIdAsync(eventId);

            if (eventToDelete == null)
            {
                throw new NotFoundException(nameof(Event), eventId);
            }

            await _eventRepository.DeleteAsync(eventToDelete);           
            return Unit.Value;
        }
    }
}
