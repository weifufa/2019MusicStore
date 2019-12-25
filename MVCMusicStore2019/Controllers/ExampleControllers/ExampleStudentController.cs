using MVCMusicStore2019.Models;
using MVCMusicStore2019.ViewModels.ExamleDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.Controllers.ExampleControllers
{
    public class ExampleStudentController : Controller
    {
        // GET: ExampleStudent
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(StudentViewModel model)
        {
            if (ModelState.IsValid)//如果ModelState字典(Model绑定的字典)是真值
            {
                Student bo = new Student
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    Gender = model.Gender,
                    UserName = model.UserName,
                    NiName = model.NiName,
                    Birthday = model.Birthday,
                    Age = model.Age,
                    Password=model.Password,
                    ConfirmPassword=model.ConfirmPassword,
                    Email=model.Email,
                    Contribution=model.Contribution,
                    CreaTine=model.CreaTine,
                    DataStatus=model.DataStatus                    
                    //待会再写
                };
                return View(model);
            }
            return View(model);
        }
        public ActionResult jQueryValidation()
        {
            return View();
        }
    }
}