using FluentValidation;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;

using NeoSoft.A2Zfiling.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.CreateIndustry
{

    public class CreateIndustryCommandValidator : AbstractValidator<CreateIndustryCommand>
    {
        private readonly IMessageRepository _messageRepository;
        public CreateIndustryCommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;

            RuleFor(p => p.IndustryName)
                .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
                .NotNull()
                .MaximumLength(10).WithMessage(GetMessage("2", ApplicationConstants.LANG_ENG));
        }

        private string GetMessage(string Code, string Lang)
        {
            return _messageRepository.GetMessage(Code, Lang).Result.MessageContent.ToString();
        }
    }
}
