using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.AboutUs.Command.Edit
{
    public class AboutEditCommand:IRequest<Response<AboutEditCommandDTO>>
    {
        public int Id { get; set; }
        public string About { get; set; }
    }
}
