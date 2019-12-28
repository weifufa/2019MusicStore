using MVCMusicStore2019.Models.MusicStores;
using MVCMusicStore2019.Repository;
using MVCMusicStore2019.ViewModels.MusicStores;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.Controllers.MusicStores
{
    public class AlbumController : Controller
    {
        private readonly IEntityRepository<Album> _Service;
        public AlbumController(IEntityRepository<Album> service)
        {
            this._Service = service;
        }

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
            return View(vmCollention);
        }
   

            /// <summary>
            /// 流派（Genre）下拉菜单内容数据集
            /// </summary>
            /// <returns></returns>
        public JsonResult GetGenreList()
        {
            var entityList = _Service.GetRelevance<Genre>().ToList(); //流派数据集
            var vmList = new List<GenreViewModel>();//音乐专辑的VM
            foreach(var item in entityList)
            {
                var boVM = new GenreViewModel(item);
                vmList.Add(boVM);

            }
            return Json(vmList);
        }

        public JsonResult GetArtistList()
        {
            var entityList = _Service.GetRelevance<Artist>().ToList(); //流派数据集
            var vmList = new List<ArtistViewModel>();//音乐专辑的VM
            foreach (var item in entityList)
            {
                var boVM = new ArtistViewModel(item);
                vmList.Add(boVM);

            }
            return Json(vmList);
        }
        public JsonResult GetAlbumTypeList()
        {
            var entityList = _Service.GetRelevance<AlbumType>().ToList(); //流派数据集
            var vmList = new List<AlbumTypeViewModel>();//音乐专辑的VM
            foreach (var item in entityList)
            {
                var boVM = new AlbumTypeViewModel(item);
                vmList.Add(boVM);

            }
            return Json(vmList);
        }
        public ActionResult CreatOrEdit(string id = null)//string id=null:允许形参id不传值
        {
            bool isNew = false;//判断当前操作是新增，还是修改；默认：新增
            Guid Id;
            var vm = new AlbumViewModel();
            if (!String.IsNullOrEmpty(id))
            {
                isNew = true;
                Id = Guid.Parse(id);
                var entity = _Service.GetSingleById(Id);
                vm = new AlbumViewModel(entity);
                ViewBag.Operation = "修改";
            }
            else
            {
                ViewBag.Operation = "新建";
                //ViewBag.isNew = isNew;
            }
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//组织伪造方法攻击
        public ActionResult CreatOrEdit(AlbumViewModel model)
        {
            if (ModelState.IsValid)
            {
                Album entity = new Album
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    GenreId=model.GenreId,
                    ArtistId=model.ArtistId,
                    AlbumTypeId=model.AlbumTypeId,
                    Price=model.Price,
                    IssueUser=model.IssueUser,
                    LanguageClassification=model.LanguageClassification,
                    IssueTime = model.IssueTime,
                    UrlString =model.UrlString,                 
                };
                //var minDate = DateTime.Parse("1900-1-1");
                //var maxDate = DateTime.Now;
                //if(model.IssueTime<minDate||model.IssueTime>maxDate)
                //{
                //    model.IssueTime = maxDate;
                //}
                //else
                //{
                //    model.IssueTime = minDate;
                //}
                if(model.GenreId!=Guid.Empty)
                {
                    entity.Genre = _Service.GetSingleRelevance<Genre>(model.GenreId);
                    entity.GenreId = model.GenreId;
                }

                if (model.AlbumTypeId != Guid.Empty)
                {
                    entity.AlbumType = _Service.GetSingleRelevance<AlbumType>(model.AlbumTypeId);
                    entity.AlbumTypeId = model.AlbumTypeId;
                }
                if (model.ArtistId != Guid.Empty)
                {
                    entity.Artist = _Service.GetSingleRelevance<Artist>(model.ArtistId);
                    entity.ArtistId = model.ArtistId;
                }
                if (model.Id != Guid.Empty) //(model.Id != null)  
                {
                    var vm = new AlbumViewModel();
                    _Service.Edit(entity);
                    ViewBag.Message = "修改成功";//待商榷
                }
                else
                {
                    entity.Id = Guid.NewGuid();
                    _Service.AddAndSave(entity);
                    ViewBag.Message = "新增成功";
                }
                return RedirectToAction("Index");

            }
            return View(model);
        }
        public ActionResult Delete(Guid id)
        {
            if (id != null)
            {
                if (_Service.Delete(id))
                {
                    ViewBag.Message = "删除成功！";

                }
                else
                {
                    ViewBag.Message = "删除失败";
                }
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "请正确选择需要删除的记录";
            }
            return View();
        }
        /// <summary>
        /// 图片上传功能实现
        /// </summary>
        /// <param name="imgFile"></param>
        /// <returns></returns>
        public JsonResult UploadImgFile(HttpPostedFileBase imgFile)
        {
            if(imgFile.ContentLength==0)
            {
                return Json(new
                {
                    upStatus = false,
                upMessage="请选择上传图片"
                },"text/html");
            }
            //生成图片文件名
            var timeStampString = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-ffff", DateTimeFormatInfo.InvariantInfo);
            var result = "Album_" + timeStampString;

            int starIndex = imgFile.FileName.IndexOf(".");
            var suffix = imgFile.FileName.Substring(starIndex, imgFile.FileName.Length - starIndex);
            var fileName = Path.Combine(Request.MapPath("~/Models/Pics"), Path.GetFileName(result + suffix));
            try
            {
                imgFile.SaveAs(fileName);
                return Json(new
                {
                    imgUrlString = result + suffix,
                    upStatus = true,
                    upMessage="图片上传成功!"
                });
            }catch(Exception e)
            {
                return Json(new
                {
                    upStatus = false,
                    upMessage = "图片上传失败！"
                }, "json/html");
            }
        }
    }
}