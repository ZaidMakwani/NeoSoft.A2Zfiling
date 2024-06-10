using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Licenses.Queries.LicenseList
{
    public class LicenseListDto
    {
        public int LicenseId { get; set; }
        [Required(ErrorMessage = "License name is required")]
        [MaxLength(500, ErrorMessage = "License name must be at most 500 characters long")]
        public string LicenseName { get; set; }

        [Required(ErrorMessage = "Short name is required")]
        [MaxLength(500, ErrorMessage = "Short name must be at most 500 characters long")]
        public string ShortName { get; set; }

        [Required(ErrorMessage = "Category ID is required")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public string CategoryName {  get; set; }

        [Required(ErrorMessage = "Short list value is required")]
        //public ShortList ShortList { get; set; }

        public string ShortList {  get; set; }

        public bool IsActive { get; set; }
    }
}
