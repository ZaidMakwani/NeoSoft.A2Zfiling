using MediatR;
using NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Commands.UpdateCompany;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.ContentService.Command.Edit
{
    public class ContentServiceEditCommand : IRequest<Response<ContentServiceEditDTO>>
    {
        public int Id { get; set; }

        
        public string AboutUs { get; set; }
    }
}
