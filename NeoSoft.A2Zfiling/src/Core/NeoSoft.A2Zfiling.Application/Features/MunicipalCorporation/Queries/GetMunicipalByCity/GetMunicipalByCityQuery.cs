using MediatR;
using NeoSoft.A2Zfiling.Application.Features.MunicipalCorporation.Queries.GetMunicipalList;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.MunicipalCorporation.Queries.GetMunicipalByCity
{
    public class GetMunicipalByCityQuery: IRequest<Response<IEnumerable<MunicipalListVM>>>
    {
        public int CityId { get; set; }
        //public int StateId { get; set; }
    }
}
