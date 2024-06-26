﻿using FluentValidation;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Helper;

namespace NeoSoft.A2Zfiling.Application.Features.Categories.Commands.StoredProcedure
{
    public class StoredProcedureCommandValidator: AbstractValidator<StoredProcedureCommand>
    {
        private readonly IMessageRepository _messageRepository;
        public StoredProcedureCommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;

            RuleFor(p => p.Name)
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
