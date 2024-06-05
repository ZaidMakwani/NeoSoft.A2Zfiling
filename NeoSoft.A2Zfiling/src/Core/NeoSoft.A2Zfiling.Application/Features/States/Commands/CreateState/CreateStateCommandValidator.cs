using FluentValidation;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Helper;

namespace NeoSoft.A2Zfiling.Application.Features.States.Commands.CreateState
{
    public class CreateStateCommandValidator : AbstractValidator<CreateStateCommand>
    {
        private readonly IMessageRepository _messageRepository;
        public CreateStateCommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;

            RuleFor(p => p.StateName)
                .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
                .NotNull()
                .MaximumLength(20).WithMessage(GetMessage("2", ApplicationConstants.LANG_ENG));
        }

        private string GetMessage(string Code, string Lang)
        {
            return _messageRepository.GetMessage(Code, Lang).Result.MessageContent.ToString();
        }
    }
}
