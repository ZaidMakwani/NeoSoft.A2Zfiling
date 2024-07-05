using MediatR;
using NeoSoft.A2Zfiling.Application.Features.AboutUs.Command.Edit;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.FAQFeatures.Command.Edit
{
    public class FAQEditCommand : IRequest<Response<FAQEditCommandDTO>>
    {
        public int Id { get; set; }
        public string FaqDescription { get; set; }
    }
}
