using NeoSoft.A2Zfiling.Application.Responses;
using MediatR;

namespace NeoSoft.A2Zfiling.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand: IRequest<Response<CreateCategoryDto>>
    {
        public string Name { get; set; }
    }
}
