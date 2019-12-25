using MVCMusicStore2019.Models;
using MVCMusicStore2019.Models.MusicStores;
using MVCMusicStore2019.Repository;
using MVCMusicStore2019.ViewModels.MusicStores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.Controllers
{
    public class MusicIndexController : Controller
    {
        private readonly IEntityRepository<Album> _Service;
        private readonly IEntityRepository<PopularHotList> _phlService;
        public MusicIndexController(IEntityRepository<Album>service, 
            IEntityRepository<PopularHotList> phlService)
        {
            this._Service = service;
            this._phlService = phlService;
        }
        /// <summary>
        /// 取最后5条新增的Album数据
        /// </summary>
        /// <returns></returns>
        public JsonResult GetPics()
        {
            var entityList = _Service.GetAll();//获取Album所有的数据
            var picList = entityList
                .OrderByDescending(x => x.IssueTime)  //按出品日期倒序排序
               .Select(y => y.UrlString)//选择URLString一列数据
                .Skip(10)//结果的第0条数据
                .Take(15)//取5条数据
                .ToList();
            return Json(picList);
        }
      
        // GET: MusicIndex
        public ActionResult Index()
        {
            var boCollection = _Service.GetAll().OrderBy(x => x.Name);
            var vmCollention = new List<AlbumDisplayViewModel>();
            var count = 0;
            foreach (var item in boCollection)
            {
                AlbumDisplayViewModel vm = new AlbumDisplayViewModel(item);
                //vm.MapToModel(item);
                vm.OrderNumber = (++count).ToString();
                vmCollention.Add(vm);

            }
            ViewBag.Title = "专辑";
            return View(vmCollention); ;
        }

        /// <summary>
        /// 获取Album表中的Id，Name
        /// </summary>
        /// <returns></returns>
        public JsonResult GetMusicAlbums()
        {
            var entityList = _Service.GetAll().ToList();
            var jsonResult = entityList
                .OrderByDescending(x => x.IssueTime) //发行日期倒序排序
                .Select(result => new          //使用集合索引器方式选择目标列
                {
                    result.Id,
                    result.Name,
                    result.Price,
                    result.UrlString
                })
                .Skip(0).Take(10)   //取第0~10条数据
                .ToList();
                return Json(jsonResult);
        }

        public ActionResult Detail(Guid id)
        {
            var entity = _Service.GetAll().Single(x => x.Id == id);  //根据传入形参ID值查询Album表获取一条数据
            AlbumDisplayViewModel vm = new AlbumDisplayViewModel(entity);
            return View(vm);
      }


        /// <summary>
        /// 点赞实现
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult AddCTR(Guid id)
        {
            var result = false;
            var entity = _phlService.GetSingleById(id);
            if(entity==null)
            {
                PopularHotList bo = new PopularHotList();
                bo.Id = id;
                bo.Album = _phlService.GetSingleRelevance<Album>(id);
                bo.AlbumId = id;
                bo.CTR += 1;
                _phlService.AddAndSave(bo);
                result = true;
            }
            else
            {
                entity.CTR += 1;
                _phlService.Edit(entity);
                result = true;
            }
            return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
}