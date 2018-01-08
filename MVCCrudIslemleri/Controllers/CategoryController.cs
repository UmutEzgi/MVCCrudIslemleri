using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCrudIslemleri.Repositories.Abstracts;
using MVCCrudIslemleri.Models;
using MVCCrudIslemleri.Data.Entities;
using MVCCrudIslemleri.Validations;
using MVCCrudIslemleri.Validations.CategoryValidations;

namespace MVCCrudIslemleri.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryRepository _categoryRepo;


        public CategoryController(IUnitOfWork unitOfWork,ICategoryRepository categoryRepo) : base(unitOfWork)
        {
            _categoryRepo = categoryRepo;
        }

        // GET: Category
        public ActionResult List()
        {
            
            var model = _categoryRepo.GetAll();
            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }

        #region ValidationYontem1
        //[HttpPost]
        //public ActionResult Add(CategoryPostViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Category c = new Category();
        //        c.Name = model.Name;

        //        _unitOfWork.GetRepo<Category>().Add(c);
        //        _unitOfWork.Commit();
        //    }

        //    return View();
        //}
        #endregion

        [HttpPost][ValidateAntiForgeryToken]
        public ActionResult Add(Category model)
        {
            var validator = new CategoryAddValidator(_categoryRepo).Validate(model);

            if (validator.IsValid)
            {
                _unitOfWork.GetRepo<Category>().Add(model);
                bool IsSuccess = _unitOfWork.Commit();
                ViewBag.IsSuccess = IsSuccess;
                ViewBag.Message = IsSuccess ? "Başarılı" : "Tekrar Deneyiniz";
            }

            validator.Errors.ToList().ForEach(a =>
            {
                ModelState.AddModelError(a.PropertyName, a.ErrorMessage);
            });


            return View();
        }



        public ActionResult Edit(int id)
        {
            var model = _unitOfWork.GetRepo<Category>().GetObject(x => x.Id == id);
            return View(model);
        }

        class Test
        {

        }

        [HttpPost][ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            var validator = new CategoryEditValidator(_categoryRepo).Validate(model);
            

            if (validator.IsValid)
            {
                _unitOfWork.GetRepo<Category>().Update(model);
                bool IsSuccess = _unitOfWork.Commit();

                ViewBag.IsSuccess = IsSuccess;
                ViewBag.Message = IsSuccess ? "Güncelleme Başarılı" : "Tekrar Deneyiniz";
            }

            validator.Errors.ToList().ForEach(a =>
            {
                ModelState.AddModelError(a.PropertyName, a.ErrorMessage);
            });


            return View(model);
        }

        public ActionResult Delete(int id)
        {
            _unitOfWork.GetRepo<Category>().Delete(id);
           bool isSuccess =  _unitOfWork.Commit(); 

            TempData["Message"] = isSuccess ? "Başarılı" : "Silme işleminin tekrar deneyiniz";

            

            return RedirectToAction("List");
           
        }
    }
}