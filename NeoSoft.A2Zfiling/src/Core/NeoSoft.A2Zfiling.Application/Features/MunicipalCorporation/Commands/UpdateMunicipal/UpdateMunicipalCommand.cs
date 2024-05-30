﻿using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Roles.Commands.UpdateMunicipal
{
    public class UpdateMunicipalCommand:IRequest<Response<MunicipalDto>>
    {
       
        public int MunicipalId { get; set;}
        public string MunicipalName { get; set;}
        public bool IsActive { get; set;}
      
        
    }
}