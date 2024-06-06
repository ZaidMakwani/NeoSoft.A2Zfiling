using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Domain.Entities
{
    public class Token
    {
        [Key]
        public string TokenId { get; set; }

        public string TokenName { get; set; }
    }
}
