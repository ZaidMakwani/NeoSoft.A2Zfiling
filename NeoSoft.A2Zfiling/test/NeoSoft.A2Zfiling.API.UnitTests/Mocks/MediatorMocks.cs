
using NeoSoft.A2Zfiling.Application.Responses;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NeoSoft.A2Zfiling.API.UnitTests.Mocks
{
    public class MediatorMocks
    {
        public static Mock<IMediator> GetMediator()
        {
            var mockMediator = new Mock<IMediator>();

            return mockMediator;
        }
    }
}
