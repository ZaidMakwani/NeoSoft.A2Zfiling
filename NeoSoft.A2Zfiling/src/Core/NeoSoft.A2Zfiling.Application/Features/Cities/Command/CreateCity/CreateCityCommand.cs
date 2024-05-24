using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Cities.Command.CreateCity
{
    public class CreateCityCommand:IRequest<Response<CreateCityDto>>
    {
        public string CityName { get; set; }
    }
}
