using System.ComponentModel.DataAnnotations.Schema;

namespace NeoSoft.A2ZFiling.UI.ViewModels
{
    public class SubStatusVM
    {
        public int SubStatusId { get; set; }

        public string SubStatusName { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey("Status")]
        public int StatusId { get; set; }

        public string StatusName { get; set; }
    }
}
