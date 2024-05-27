using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Commands.DeleteCompany
{
    public class DeleteCompanyDto
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public bool IsActive { get; set; }
    }
}
