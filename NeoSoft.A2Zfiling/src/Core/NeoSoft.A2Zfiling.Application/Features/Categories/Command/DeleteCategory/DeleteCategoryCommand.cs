using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Categories.Command.DeleteCategory
{
    public class DeleteCategoryCommand:IRequest<Response<DeleteCategoryDto>>
    {
        public int CategoryId { get; set; }
    }
}
