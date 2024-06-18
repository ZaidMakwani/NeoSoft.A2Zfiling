using NeoSoft.A2Zfiling.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Domain.Entities
{
    public class LicenseMaster: AuditableEntity
    {
        [Key]
        public int LicenceMasterId { get; set; }
        [MaxLength(50)]
        public int LicenseTypeId { get; set; }
        [JsonIgnore]
        public LicenseType LicenseType { get; set; }
        public int LicenseId { get; set; }
        public License License {  get; set; }
        public string? LicenseName { get; set; }
        [MaxLength(50)]
        public string? Classification { get; set; }
        public Visibility Visibilities { get; set; }
        public bool Validity { get; set; }
        [MaxLength(20)]
        public string StandardRate { get; set; }
        [MaxLength(20)]
        public string StandardTAT {  get; set; }
        [MaxLength(20)]
        public string FastTrackRate { get; set; }
        [MaxLength(20)]
        public string FastTrackTAT { get;set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public int MunicipalId { get; set; }
        public virtual MunicipalCorp MunicipalCorp { get; set; }
        public int StateId { get; set; }
        public virtual State State { get; set; }
        public int ZoneId { get; set; }
        public virtual Zones Zones { get; set; }
        public int IndustryId { get; set; }
        public virtual Industry Industry { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        

    }
    
}
