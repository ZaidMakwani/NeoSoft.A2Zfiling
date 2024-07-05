using MediatR;
using NeoSoft.A2Zfiling.Application.Features.ContentService.Command.Edit;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.TermsAndConditions.Commands.Edit
{
    public class TermAndConitionEditCommand : IRequest<Response<TermAndConitionEditDTO>>
    {
        public int Id { get; set; }
        public string TermsDescrption { get; set; }
    }
}
