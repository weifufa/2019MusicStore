using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.Controllers.ExampleControllers
{
    public class StudentDemo
    {
      public int Id { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }

    }
    
    public class ExampleTransferParameterController : Controller
    {
        public ActionResult StuList()
        {
            List<StudentDemo> l = new List<StudentDemo>();
            StudentDemo stu1 = new StudentDemo { Id = 1, Name = "赵三", ClassName = "2018软件技术1班" };
            StudentDemo stu2 = new StudentDemo { Id = 2, Name = "李四", ClassName = "2018软件技术1班" };
            StudentDemo stu3 = new StudentDemo { Id = 1, Name = "王五", ClassName = "2018软件技术1班" };
            l.Add(stu1);
            l.Add(stu2);
            l.Add(stu3);
            return View(l);

        }
        // GET: ExampleTransferParameter
        public ActionResult Index()
        {
            return View(); 
        }
        public ActionResult JumpSite()
        {
            return new RedirectResult("https://163.com");
        }
        public void NotReturn() { }
        public EmptyResult NullResult1()
        {
            return null;
        }
        public ActionResult NullResult2()
        {
            return null;

        }

    }
}