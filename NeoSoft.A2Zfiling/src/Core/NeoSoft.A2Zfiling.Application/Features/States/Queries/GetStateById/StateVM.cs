﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.States.Queries.GetStateById
{
    public class StateVM
    {

        public int StateId { get; set; }
        public string StateName { get; set; }
        public bool IsActive { get; set; }

    }
}