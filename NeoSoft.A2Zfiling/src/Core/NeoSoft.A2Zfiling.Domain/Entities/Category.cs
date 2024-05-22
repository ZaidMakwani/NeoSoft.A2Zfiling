using NeoSoft.A2Zfiling.Domain.Common;
using System;
using System.Collections.Generic;

namespace NeoSoft.A2Zfiling.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Event> Events { get; set; }

    }
}
