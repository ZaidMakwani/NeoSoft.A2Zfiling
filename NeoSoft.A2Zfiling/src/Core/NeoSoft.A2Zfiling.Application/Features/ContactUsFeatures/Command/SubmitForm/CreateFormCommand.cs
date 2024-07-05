using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.ContactUsFeatures.Command.SubmitForm
{
    public class CreateFormCommand:IRequest<Response<CreateFormDTO>>
    {
        //public int Id { get; set; }
        public string YourName { get; set; }
        public string YourEmail { get; set; }
        public string Message { get; set; }
    }
}
