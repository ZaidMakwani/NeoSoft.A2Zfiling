using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Domain.Entities
{
    public class MunicipalCorporation
    {
        [Key]
        public int MunicipalId { get; set; }
        public string MunicipalName { get; set; }
        public bool IsActive { get; set; }
    }
}
