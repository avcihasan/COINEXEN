using COINEXEN.Core.ViewModels.UserVMs;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace COINEXEN.Service.Validators.UserValidators
{
    public class RegisterVMValidator:AbstractValidator<RegisterVM>
    {
        public RegisterVMValidator()
        {
            RuleFor(x=>x.Name)
                .NotEmpty()
                    .WithMessage("{PropertyName} boş geçilemez")
                .NotNull()
                    .WithMessage("{PropertyName} boş geçilemez")
                .MinimumLength(3)
                    .WithMessage("{PropertyName} en az 3 karakter olmalı")
                .MaximumLength(20)
                    .WithMessage("{PropertyName} en fazla 20 karakter olmalı");

            RuleFor(x => x.Surname)
                .NotEmpty()
                    .WithMessage("{PropertyName} boş geçilemez")
                .NotNull()
                    .WithMessage("{PropertyName} boş geçilemez")
                .MinimumLength(3)
                    .WithMessage("{PropertyName} en az 3 karakter olmalı")
                .MaximumLength(20)
                    .WithMessage("{PropertyName} en fazla 20 karakter olmalı");

            RuleFor(x => x.UserName)
                .NotEmpty()
                    .WithMessage("{PropertyName} boş geçilemez")
                .NotNull()
                    .WithMessage("{PropertyName} boş geçilemez")
                .MinimumLength(3)
                    .WithMessage("{PropertyName} en az 3 karakter olmalı")
                .MaximumLength(20)
                    .WithMessage("{PropertyName} en fazla 20 karakter olmalı");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                    .WithMessage("{PropertyName} boş geçilemez")
                .NotNull()
                    .WithMessage("{PropertyName} boş geçilemez")
                .Length(10)
                    .WithMessage("{PropertyName} 10 karakerli olmalı");

            RuleFor(x => x.Birthday)
                .NotEmpty()
                    .WithMessage("{PropertyName} boş geçilemez")
                .NotNull()
                    .WithMessage("{PropertyName} boş geçilemez")
                .GreaterThan(1900)
                    .WithMessage("{PropertyName} 1900dan büyük olmalıdır")
                .LessThan(2023)
                    .WithMessage("{PropertyName} 2023dan küçük olmalıdır");


            RuleFor(x => x.City)
                .NotEmpty()
                    .WithMessage("{PropertyName} boş geçilemez")
                .NotNull()
                    .WithMessage("{PropertyName} boş geçilemez");


            RuleFor(x => x.Gender)
                .NotEmpty()
                    .WithMessage("{PropertyName} boş geçilemez")
                .NotNull()
                    .WithMessage("{PropertyName} boş geçilemez");


            RuleFor(x => x.Password)
                .NotEmpty()
                    .WithMessage("{PropertyName} boş geçilemez")
                .NotNull()
                    .WithMessage("{PropertyName} boş geçilemez")
                .MinimumLength(3)
                    .WithMessage("{PropertyName} en az 5 karakter olmalı")
                .MaximumLength(20)
                    .WithMessage("{PropertyName} en fazla 20 karakter olmalı");

            RuleFor(x => x.Password)
                .NotEmpty()
                    .WithMessage("{PropertyName} boş geçilemez")
                .NotNull()
                    .WithMessage("{PropertyName} boş geçilemez")
                .Equal(x => x.Password)
                    .WithMessage("Şifreler eşleşmiyor");

        }
    }
}
