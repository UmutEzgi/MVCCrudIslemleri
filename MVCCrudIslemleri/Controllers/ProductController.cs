using MVCCrudIslemleri.Data.Context;
using MVCCrudIslemleri.Data.Entities;
using MVCCrudIslemleri.Repositories.Abstracts;
using MVCCrudIslemleri.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCrudIslemleri.Controllers
{
    public class ProductController : BaseController
    {

        public ProductController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}