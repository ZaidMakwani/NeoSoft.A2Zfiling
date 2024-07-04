using MediatR;
using Microsoft.AspNetCore.Http;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Userdetails.Command.CreateUserDetails
{
    public class CreateUserDetailsCommand:IRequest<Response<CreateUserDetailsDto>>
    {
        public string CompanyName { get; set; }

        public string CompanyAddress { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        [ForeignKey("Industry")]
        public int IndustryId { get; set; }

        [ForeignKey("State")]
        public int StateId { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }

        [ForeignKey("MunicipalCorp")]
        public int MunicipalId { get; set; }

        [ForeignKey("DocumentMasters")]
        public List<int> DocumentMasterId { get; set; }

        public List<string> FileCollection { get; set; }

        //public List<string> FileType { get; set; }

    }
}
