using NeoSoft.A2Zfiling.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Domain.Entities
{
<<<<<<<< HEAD:NeoSoft.A2Zfiling/src/Core/NeoSoft.A2Zfiling.Domain/Entities/Company.cs
    public class Company : AuditableEntity
========
    public class Role:AuditableEntity
>>>>>>>> origin/development:NeoSoft.A2Zfiling/src/Core/NeoSoft.A2Zfiling.Domain/Entities/Role.cs
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string ShortName { get; set; }
        public bool IsActive { get; set; }

    }
}
