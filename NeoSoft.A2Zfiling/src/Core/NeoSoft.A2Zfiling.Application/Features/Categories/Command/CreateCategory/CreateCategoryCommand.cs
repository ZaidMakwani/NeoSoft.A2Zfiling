using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Categories.Command.CreateCategory
{
    public class CreateCategoryCommand:IRequest<Response<CreateCategoryDto>>
    {
   

        public string CategoryName { get; set; }

        public string ShortName { get; set; }

     
    }
}
