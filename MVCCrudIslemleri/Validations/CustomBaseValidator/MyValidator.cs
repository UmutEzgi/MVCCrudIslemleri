using MVCCrudIslemleri.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCCrudIslemleri.Repositories.Concretes;
using MVCCrudIslemleri.Repositories.Abstracts;

namespace MVCCrudIslemleri.Validations.CustomBaseValidator
{
    public class MyValidator : BaseValidator<Category>
    {
        public MyValidator(IRepository<Category> baseRepo) : base(baseRepo)
        {
           
        }

        public override void InitConfig()
        {
            throw new NotImplementedException();
        }
    }

    public class My2Validator : MyValidator
    {
        public My2Validator(IRepository<Category> baseRepo) : base(baseRepo)
        {
        }

        public override void InitConfig()
        {
            base.InitConfig();
        }
    }
}