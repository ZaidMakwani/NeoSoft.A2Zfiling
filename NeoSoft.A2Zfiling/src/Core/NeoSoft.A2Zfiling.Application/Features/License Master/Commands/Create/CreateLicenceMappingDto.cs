using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.License_Master.Commands.Create
{
    public class CreateLicenceMappingDto
    {
        public int LicenceMasterId { get; set; }   
        public int LicenseId { get; set; }
        public int LicenseTypeId { get; set; }
        public string? LicenseName { get; set; }       
        public string? Classification { get; set; }
        public string Visibilities { get; set; }
        public bool Validity { get; set; }
        public string Workflow {  get; set; }
        public int ZoneId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public int MunicipalId { get; set; }
        public int IndustryId { get; set; }
        public int CompanyId { get; set; }
        public string StandardRate { get; set; }      
        public string StandardTAT { get; set; }       
        public string FastTrackRate { get; set; }    
        public string FastTrackTAT { get; set; }
        public bool IsActive { get; set; }  
        public bool IsDeleted { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
