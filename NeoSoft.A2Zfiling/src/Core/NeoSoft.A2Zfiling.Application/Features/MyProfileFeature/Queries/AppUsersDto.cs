using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.MyProfileFeature.Queries
{
    public class AppUsersDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string Email{ get; set; }
        public long ContactNumber { get; set; }  
        public string PasswordCurr { get; set; }
    }
}
