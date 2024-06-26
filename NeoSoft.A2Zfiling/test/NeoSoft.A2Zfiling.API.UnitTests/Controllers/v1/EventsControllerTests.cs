﻿using NeoSoft.A2Zfiling.Api.Controllers.v1;
using NeoSoft.A2Zfiling.API.UnitTests.Mocks;
using NeoSoft.A2Zfiling.Application.Features.Events.Commands.CreateEvent;
using NeoSoft.A2Zfiling.Application.Features.Events.Commands.Transaction;
using NeoSoft.A2Zfiling.Application.Features.Events.Commands.UpdateEvent;
using NeoSoft.A2Zfiling.Application.Features.Events.Queries.GetEventDetail;
using NeoSoft.A2Zfiling.Application.Features.Events.Queries.GetEventsList;
using NeoSoft.A2Zfiling.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace NeoSoft.A2Zfiling.API.UnitTests.Controllers.v1
{
    public class EventsControllerTests
    {
        private readonly Mock<IMediator> _mockMediator;
        public EventsControllerTests()
        {
            _mockMediator = MediatorMocks.GetMediator();
        }

        [Fact]
        public async Task Get_EventsList()
        {
            var controller = new EventsController(_mockMediator.Object);

            var result = await controller.GetAllEvents();

            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
            okObjectResult.Value.ShouldNotBeNull();
            okObjectResult.Value.ShouldBeOfType<Response<IEnumerable<EventListVm>>>();
        }

        [Fact]
        public async Task Get_Event_ById()
        {
            var controller = new EventsController(_mockMediator.Object);

            var result = await controller.GetEventById(Guid.NewGuid().ToString());

            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
            okObjectResult.Value.ShouldNotBeNull();
            okObjectResult.Value.ShouldBeOfType<Response<EventDetailVm>>();
        }

        [Fact]
        public async Task Export_Events()
        {
            var controller = new EventsController(_mockMediator.Object);

            var result = await controller.ExportEvents();

            result.ShouldBeOfType<FileContentResult>();
            result.ShouldNotBeNull();
            result.ContentType.ShouldBe("text/csv");
        }

        [Fact]
        public async Task Create_Event()
        {
            var controller = new EventsController(_mockMediator.Object);

            var result = await controller.Create(new CreateEventCommand());

            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
            okObjectResult.Value.ShouldNotBeNull();
            okObjectResult.Value.ShouldBeOfType<Response<Guid>>();
        }

        [Fact]
        public async Task Update_Event()
        {
            var controller = new EventsController(_mockMediator.Object);

            var result = await controller.Update(new UpdateEventCommand());

            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
            okObjectResult.Value.ShouldNotBeNull();
            okObjectResult.Value.ShouldBeOfType<Response<Guid>>();
        }

        [Fact]
        public async Task Delete_Event()
        {
            var controller = new EventsController(_mockMediator.Object);

            var result = await controller.Delete(Guid.NewGuid().ToString());

            result.ShouldBeOfType<NoContentResult>();
            var noContentResult = result as NoContentResult;
            noContentResult.StatusCode.ShouldBe(204);
        }

        [Fact]
        public async Task Transaction_Demo()
        {
            var controller = new EventsController(_mockMediator.Object);

            var result = await controller.TransactionDemo(new TransactionCommand());

            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
            okObjectResult.Value.ShouldNotBeNull();
            okObjectResult.Value.ShouldBeOfType<Response<Guid>>();
        }
    }
}
