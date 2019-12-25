using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.Controllers.ExampleControllers
{
    public class ExampleGenrice
    {
        public IList<StudentDemo> GetAll()
        {
            List<StudentDemo> stuList = new List<StudentDemo>();
            StudentDemo stu1 = new StudentDemo { Id = 1, Name = "赵三", ClassName = "2018软件技术1班" };
            StudentDemo stu2 = new StudentDemo { Id = 2, Name = "李四", ClassName = "2018软件技术1班" };
            StudentDemo stu3 = new StudentDemo { Id = 1, Name = "王五", ClassName = "2018软件技术1班" };
            stuList.Add(stu1);
            stuList.Add(stu2);
            stuList.Add(stu3);
            return stuList;

        }
    }
    //不要使用该用例方式编写代码，因为它违反编码规范
   

    public class ExampleLINQLambdaController : Controller
    {
        // GET: ExampleLINQLambda
        public ActionResult Index()
        {
            ExampleGenrice genriceList = new ExampleGenrice();            
            var list = genriceList.GetAll();
            //当前我们对list这个集合进行LINQ简单查询
            var linqLint1 = from x in list
                            select x;
            //SQL条件精确查询:select * from 表名 where 条件
            var linqLint2 = from x in list
                            where x.Name == "钱四"
                            select x;
            //SQL条件模糊查询：select * from 表名 where 条件 like '%软件%'
            var linqLint3 = from x in list
                            where x.ClassName.Contains("软件")
                            select x;
            //SQL排序：select * from 表名 oder by Name(按名字降序排序) desc
            var linqLint4 = from x in list
                            orderby x.Name descending
                            select x;
            //SQL计数：select count(*) from list
            var linqLint5 = (from x in list
                             select x).Count();
            //SQL联接：select * from x inner join on y where x.Id=y.Id
            var linqLint6 = from x in list
                            join y in list on x.Id equals y.Id
                            select x;
            //SQL分组查询+子查询(select count(*) from list group by ClassName) into #tmp
            var LinqList7 = from x in list
                            group x by x.ClassName into y
                            select new
                            {
                                y.Key,
                                count = y.Count()
                            };
            //SQL取一条数据：select top 1 * from list
            var LinqList8 = (from x in list
                             select x)
                             .FirstOrDefault();

            //SQL取10条数据：select top 10 * from list
            var LinqList9 = (from x in list
                             select x)
                             .Take(10);

            //SQL取16条~第30条数据
            var LinqList10 = (from x in list
                              select x)
                             .Skip(15).Take(30);
            return View();
        }
    }
    public class ExampleLambdaLambdaController : Controller
    {
        public ActionResult Index()
        {
            ExampleGenrice genriceList = new ExampleGenrice();
            var stuList = genriceList.GetAll();
            //模糊查询
            IEnumerable<StudentDemo> list1 = stuList.Where(x=>x.ClassName.Contains("软件"));
            //精确查询
            IEnumerable<StudentDemo> list2 = stuList.Where(k => k.Name == "王五");
            //获取符合条件的单条数据
            StudentDemo stu1 = stuList.Where(k => k.Name == "王五").FirstOrDefault();
            return null;
        }
    }
}