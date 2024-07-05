using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.ContactUsFeatures.Query.GetMessagesById
{
    public class GetContactUsByIdQuery:IRequest<Response<GetContactUsByIdDto>>
    {
        public int Id { get; set; }
    }
}
