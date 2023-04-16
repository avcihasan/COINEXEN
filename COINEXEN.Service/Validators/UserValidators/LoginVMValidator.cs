using COINEXEN.Core.ViewModels.UserVMs;
using FluentValidation;

namespace COINEXEN.Service.Validators.UserValidators
{
    public class LoginVMValidator : AbstractValidator<LoginVM>
    {
        public LoginVMValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                    .WithMessage("{PropertyName} boş geçilemez")
                .NotNull()
                    .WithMessage("{PropertyName} boş geçilemez")
                .MinimumLength(3)
                    .WithMessage("{PropertyName} en az 3 karakter olmalı")
                .MaximumLength(20)
                    .WithMessage("{PropertyName} en fazla 20 karakter olmalı");
            RuleFor(x => x.Password)
                .NotEmpty()
                    .WithMessage("{PropertyName} boş geçilemez")
                .NotNull()
                    .WithMessage("{PropertyName} boş geçilemez");
        }
    }
}
