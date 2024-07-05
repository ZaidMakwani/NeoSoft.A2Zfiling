using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.ContactUsFeatures.Query.GetAllMessagees
{
    public class GetAllMessagesListDTO
    {
        public int Id { get; set; }
        public string YourName { get; set; }

        public string YourEmail { get; set; }

        public string Message { get; set; }
    }
}
