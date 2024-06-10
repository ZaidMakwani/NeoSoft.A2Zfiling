﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Categories.Command.CreateCategory
{
    public class CreateCategoryDto
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string ShortName { get; set; }

        public bool IsActive { get; set; }
    }
}
