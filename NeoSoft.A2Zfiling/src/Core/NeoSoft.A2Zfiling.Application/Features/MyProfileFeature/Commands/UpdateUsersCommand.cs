﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoSoft.A2Zfiling.Application.Responses;

namespace NeoSoft.A2Zfiling.Application.Features.MyProfileFeature.Commands
{
    public class UpdateUsersCommand : IRequest<Response<UpdateUsersDto>>/*: IRequest<Response<UpdateUsersDto>>*/
    {
        public string? AppUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public long ContactNumber { get; set; }
        public string Address { get; set; }
    }
}