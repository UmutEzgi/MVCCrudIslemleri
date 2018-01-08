using MVCCrudIslemleri.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;

namespace MVCCrudIslemleri.Validations.CategoryValidations
{
    public class CategoryAddValidator : CategoryValidator
    {
        public CategoryAddValidator(ICategoryRepository catRepo) : base(catRepo)
        {
           
        }

        public override void InitConfig()
        {
            base.InitConfig();
            RuleFor(x => x.Name).Must(UniqeNameCheck).WithMessage("Aynı isimde kategori mevcuttur.");
        }

        public bool UniqeNameCheck(string name)
        {
            var data = _catRepo.Where(x => x.Name == name).FirstOrDefault();

            if (data == null)
            {
                return true;
            }

            return false;
        }

    }
}