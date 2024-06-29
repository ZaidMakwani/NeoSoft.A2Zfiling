using NeoSoft.A2Zfiling.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Domain.Entities
{
    public class UserDetail:AuditableEntity
    {
        public int UserDetailId { get; set; }

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

        public List<DocumentMaster> DocumentMasters { get; set; }
        public List<DocumentDetail> DocumentDetails{ get; set; }

        public bool IsActive { get; set; }
    }
}
