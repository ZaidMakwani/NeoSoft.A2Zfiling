using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Domain.Entities
{
    public class ServiceRequest
    {
        public int Id { get; set; }

        [Required]
        public string AboutUs { get; set; }
    }
}
