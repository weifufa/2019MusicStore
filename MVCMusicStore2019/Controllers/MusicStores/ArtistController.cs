using MVCMusicStore2019.Models.MusicStores;
using MVCMusicStore2019.Repository;
using MVCMusicStore2019.ViewModels.MusicStores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.Controllers.MusicStores
{
    public class ArtistController : Controller
    {
        private readonly IEntityRepository<Artist> _Service;
        public ArtistController(IEntityRepository<Artist> service)
        {
            this._Service = service;
        }
        // GET: ExampbleArtist
        public ActionResult Index()
        {
            var boCollection = _Service.GetAll().OrderBy(x => x.Name);
            var vmCollention = new List<ArtistDisplayViewModel>();
            var count = 0;
            foreach(var item in boCollection)
            {
                ArtistDisplayViewModel vm = new ArtistDisplayViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description


                };
                vm.OrderNumber = (++count).ToString();
                vmCollention.Add(vm);

            }
            ViewBag.Title = "歌手";
            return View(vmCollention);
        }
    

        public ActionResult CreatOrEdit(string id = null)//string id=null:允许形参id不传值
        {
            bool isNew = false;//判断当前操作是新增，还是修改；默认：新增
            Guid Id;
            var vm = new ArtistViewModel();
            if (!String.IsNullOrEmpty(id))
            {
                isNew = true;
                Id = Guid.Parse(id);
                var entity = _Service.GetSingleById(Id);
                vm = new ArtistViewModel(entity);
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
        public ActionResult CreatOrEdit(ArtistViewModel model)
        {
            if (ModelState.IsValid)
            {
                Artist entity = new Artist
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description
                };
                if (model.Id != Guid.Empty)
                {
                    var vm = new ArtistViewModel();
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
    }
}