using COINEXEN.Core.ViewModels.MessageVMs;
using FluentValidation;

namespace COINEXEN.Service.Validators.MessageValidators
{
    public class SetMessageVMValidator : AbstractValidator<SetMessageVM>
    {
        public SetMessageVMValidator()
        {
            RuleFor(x => x.Details)
                 .NotEmpty()
                    .WithMessage("{PropertyName} boş geçilemez")
                .NotNull()
                    .WithMessage("{PropertyName} boş geçilemez")
                .MinimumLength(10)
                    .WithMessage("{PropertyName} en az 10 karakter olmalı")
                .MaximumLength(250)
                    .WithMessage("{PropertyName} en fazla 250 karakter olmalı");

            //RuleFor(x => x.PhoneNumber);
            //RuleFor(x => x.EMail);


            RuleFor(x => x.Name)
                .MinimumLength(3)
                    .WithMessage("{PropertyName} en az 3 karakter olmalı")
                .MaximumLength(20)
                    .WithMessage("{PropertyName} en fazla 20 karakter olmalı");

            RuleFor(x => x.Surname)
                .MinimumLength(3)
                    .WithMessage("{PropertyName} en az 3 karakter olmalı")
                .MaximumLength(20)
                    .WithMessage("{PropertyName} en fazla 20 karakter olmalı");

            RuleFor(x => x.City)
                .NotEmpty()
                    .WithMessage("{PropertyName} boş geçilemez")
                .NotNull()
                    .WithMessage("{PropertyName} boş geçilemez");


            RuleFor(x => x.TopicTitle)
                .NotEmpty()
                    .WithMessage("{PropertyName} boş geçilemez")
                .NotNull()
                    .WithMessage("{PropertyName} boş geçilemez");
        }
    }
}
