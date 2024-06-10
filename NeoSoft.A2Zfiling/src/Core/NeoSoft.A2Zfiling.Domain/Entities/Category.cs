using NeoSoft.A2Zfiling.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Domain.Entities
{
    public class Category:AuditableEntity
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string ShortName { get; set; }

        public bool IsActive { get; set; }
    }
}
