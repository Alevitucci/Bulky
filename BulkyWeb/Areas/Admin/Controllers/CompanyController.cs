﻿using Bulky.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bulky.Models.ViewModels;
using Bulky.Models;
using Bulky.Utility;
using Microsoft.AspNetCore.Authorization;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        

        public CompanyController(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
           
        }
        public IActionResult Index()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
           
            return View(objCompanyList);
        }

        public IActionResult Upsert(int? id)
        {
           
            if(id == null || id == 0)
            {
                return View(new Company());
            }
           else
            {
                
                Company companyObj = _unitOfWork.Company.Get(u=>u.Id == id);
                return View(companyObj);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Company CompanyObj)
        {
            

            if (ModelState.IsValid)
            {
               
              
                if (CompanyObj.Id == 0)
                {
                    _unitOfWork.Company.Add(CompanyObj);
                }
                else
                {
                    _unitOfWork.Company.Update(CompanyObj);
                }
                   
                _unitOfWork.Save();
                TempData["success"] = "Company created successfully";
                return RedirectToAction("Index");
            }

            return View(CompanyObj);

        }

        //[HttpPost]
        //public IActionResult Edit(Company obj)
        //{

        //    if (ModelState.IsValid)
        //    {
                
        //        _unitOfWork.Company.Update(obj);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Company updated successfully";
        //        return RedirectToAction("Index");
        //    }

        //    return View();

        //}

        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Company CompanyFromDb = _unitOfWork.Company.Get(u => u.Id == id);
        //    if (CompanyFromDb == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(CompanyFromDb);
        //}

        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeletePOST(int? id)
        //{

        //    Company? obj = _unitOfWork.Company.Get(u => u.Id == id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }

        //    _unitOfWork.Company.Remove(obj);
        //    _unitOfWork.Save();
        //    TempData["success"] = "Company deleted successfully";
        //    return RedirectToAction("Index");



        //}
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll(int id)
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = objCompanyList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var CompanyToBeDeleted = _unitOfWork.Company.Get(u => u.Id == id);
            if (CompanyToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

           


            _unitOfWork.Company.Remove(CompanyToBeDeleted);
            _unitOfWork.Save();

            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = objCompanyList });
        }
        #endregion

    }
}
