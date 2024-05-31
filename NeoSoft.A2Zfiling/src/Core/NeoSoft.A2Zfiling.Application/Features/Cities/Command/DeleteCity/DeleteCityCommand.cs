﻿using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Cities.Command.DeleteCity
{
    public class DeleteCityCommand : IRequest<Response<DeleteCityDto>>
    {
        public int CityId { get; set; }
    }
}