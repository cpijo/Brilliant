﻿using School.Entities.Fields;
using School.Services.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.UI.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class ClassesController : Controller
    {
        private IClassesRepository gradesRepository;
        public ClassesController(IClassesRepository gradesRepository)
        {
            this.gradesRepository = gradesRepository;
        }

        #region Get Grades
        [HttpGet]
        public ActionResult GetRecord()
        {
            List<Classes> model = gradesRepository.GetAll();
            return PartialView("_GetRecord", model);
        }
        #endregion
        #region Get Grades
        [HttpGet]
        public ActionResult SearchRecord()
        {
            List<Classes> model = gradesRepository.GetAll();
            return PartialView("_TableClass", model);
        }
        #endregion



        #region Add New Record
        [HttpPost]
        public ActionResult AddRecord(Classes model)
        {
            model = new Classes();
            return PartialView("_AddClass", model);
        }
        #endregion


        #region Save Student Results 
        [HttpPost]
        public ActionResult SaveRecord(Classes model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.ClassId))
                {
                    model.ClassId = Guid.NewGuid().ToString();
                }

                gradesRepository.Save(model);

                return Json(new { result = "true", message = "Data saved Successfully", title = "Request Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { result = "false", message = ex.Message, title = "Request Failed" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Add New Record
        [HttpPost]
        public ActionResult UpdateView(Classes model)
        {
            //model.oldClassId = model.ClassId;
            return PartialView("_UpdateClass", model);
        }
        #endregion

        #region Save Student Results 
        [HttpPost]
        public ActionResult Update(Classes model)
        {
            try
            {
                gradesRepository.Update(model);
                return Json(new { result = "true", message = "Data saved Successfully", title = "Request Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { result = "false", message = ex.Message, title = "Request Failed" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

    }
}


//convert min js to js online
//https://unminify.com/


//https://preview.themeforest.net/item/akkhor-school-management-admin-template/full_screen_preview/23687250?_ga=2.259416202.1022491944.1637416188-650806703.1637414851

//https://preschool.dreamguystech.com/html-template/add-department.html
//https://preschool.dreamguystech.com/html-template/teacher-details.html

//https://freehtml5.co/blog/free-html5-responsive-admin-dashboard-templates/

//https://colorlib.com/polygon/jeweler/data-table.html
//https://colorlib.com/polygon/jeweler/product-payment.html
//https://colorlib.com/polygon/jeweler/product-list.html#
//https://dashboardpack.com/live-demo-preview/?livedemo=1881

//https://webthemez.com/demo/bluebox-free-bootstrap-admin-template/index.html

//https://themeforest.net/item/admin-akkhor-school-management-system-psd/screenshots/19909875?index=25
//https://themeforest.net/item/akkhor-school-management-admin-template/23687250
