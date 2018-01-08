using FluentValidation;
using MVCCrudIslemleri.Data.Entities;
using MVCCrudIslemleri.Repositories.Abstracts;
using MVCCrudIslemleri.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCrudIslemleri.Validations.CustomBaseValidator
{
    public abstract class BaseValidator<T>:AbstractValidator<T> where T:EntityBase,new()
    {
        protected IRepository<T> _baseRepo;

        public BaseValidator(IRepository<T> baseRepo)
        {
            _baseRepo = baseRepo;
            InitConfig();
        }

        public abstract void InitConfig();
    }
}