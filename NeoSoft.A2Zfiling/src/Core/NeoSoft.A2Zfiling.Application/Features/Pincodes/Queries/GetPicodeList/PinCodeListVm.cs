using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Pincodes.Queries.GetPicodeList
{
    public class PinCodeListVm
    {
        public int PinCodeId { get; set; }
        public long PinCodeNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
