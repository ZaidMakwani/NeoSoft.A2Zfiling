﻿using NeoSoft.A2Zfiling.Application.Responses;
using MediatR;

namespace NeoSoft.A2Zfiling.Application.Features.Categories.Commands.StoredProcedure
{
    public class StoredProcedureCommand: IRequest<Response<StoredProcedureDto>>
    {
        public string Name { get; set; }
    }
}
