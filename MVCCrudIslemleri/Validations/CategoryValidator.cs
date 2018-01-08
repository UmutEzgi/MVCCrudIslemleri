using FluentValidation;
using MVCCrudIslemleri.Data.Entities;
using MVCCrudIslemleri.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCrudIslemleri.Validations
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        private readonly ICategoryRepository _catRepo;

        public CategoryValidator(ICategoryRepository catRepo)
        {
            _catRepo = catRepo;
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("50 karakterden fazla yazamazsınız");
            RuleFor(x => x.Name).Must(UniqeNameCheck).WithMessage("Aynı isimde kategori mevcuttur.");
        }

        public bool UniqeNameCheck(string name)
        {
           var data =  _catRepo.Where(x => x.Name == name).FirstOrDefault();

            if (data==null)
            {
                return true;
            }

            return false;
        }
        

    }
}