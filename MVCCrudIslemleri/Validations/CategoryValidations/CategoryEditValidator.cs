using MVCCrudIslemleri.Data.Entities;
using MVCCrudIslemleri.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;

namespace MVCCrudIslemleri.Validations.CategoryValidations
{
    public class CategoryEditValidator:CategoryValidator
    {
        public CategoryEditValidator(ICategoryRepository catRepo) : base(catRepo)
        {
           
        }

        public override void InitConfig()
        {
            base.InitConfig();
            RuleFor(x => x).Must(HasSameCategory).WithMessage("Aynı isimde kategori mevcuttur.");
        }

        public bool HasSameCategory(Category model)
        {
            
            var data = _catRepo.Where(x => x.Name == model.Name && x.Id != model.Id).ToList();

            if (data == null)
            {
                return true;
            }

            return false;
        }
    }
}