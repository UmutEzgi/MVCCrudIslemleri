using FluentValidation;
using MVCCrudIslemleri.Data.Entities;
using MVCCrudIslemleri.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCrudIslemleri.Validations.CategoryValidations
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        protected ICategoryRepository _catRepo;

        public CategoryValidator(ICategoryRepository catRepo)
        {
            _catRepo = catRepo;
            InitConfig();
        }

        public virtual void InitConfig()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("50 karakterden fazla yazamazsınız");
            RuleFor(x => x.Description).MaximumLength(200).WithMessage("200 karakter sınırı vardır");
        }
    }
}