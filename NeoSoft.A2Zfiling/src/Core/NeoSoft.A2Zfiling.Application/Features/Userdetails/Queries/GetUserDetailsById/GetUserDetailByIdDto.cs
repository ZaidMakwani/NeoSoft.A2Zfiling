using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Userdetails.Queries.GetUserDetailsById
{
    public class GetUserDetailByIdDto
    {
        public int UserDetailId { get; set; }

        public string CompanyName { get; set; }

        public string CompanyAddress { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        public string Name { get; set; }

        [ForeignKey("Industry")]
        public int IndustryId { get; set; }
        public string IndustryName { get; set; }

        [ForeignKey("State")]
        public int StateId { get; set; }
        public string StateName { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }
        public string CityName { get; set; }

        [ForeignKey("MunicipalCorp")]
        public int MunicipalId { get; set; }
        public string MunicipalName { get; set; }

        public bool IsActive { get; set; }

        public List<DocumentDetailDto> DocumentDetails { get; set; }

    }

    public class DocumentDetailDto
    {
        public int DocumentDetailId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public DocumentMasterDto DocumentMaster { get; set; }
        public bool IsActive { get; set; }

    }

    public class DocumentMasterDto
    {
        public int DocumentMasterId { get; set; }
        public string DocumentName { get; set; }

        public bool IsActive { get; set; }
    }
}

