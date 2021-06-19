using Core.Domain.Main;

using Services.SliderServices;

using System.IO;
using System.Web;
using System.Web.Mvc;

using Travel.Configurations;
using Travel.Models.Slider;

namespace Travel.Controllers
{
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new SliderListModel());
        }

        [HttpPost]
        public ActionResult List(SliderListModel model)
        {
            var sliders = _sliderService.GetAllSlider(
                title: model.SearchName,
                pageIndex: model.PageIndex,
                pageSize: model.PageSize);

            return Json(new
            {
                draw = model.Draw,
                recordsFiltered = 0,
                recordsTotal = sliders.TotalCount,
                data = sliders
            });
        }

        public ActionResult Create()
        {
            return View(new SliderModel());
        }

        [HttpPost]
        public ActionResult Create(SliderModel model, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                Slider slider = model.MapTo<SliderModel, Slider>();

                if (image != null)
                {
                    string imagee = Path.GetFileName(image.FileName);
                    string path = "~/Content/travel/images/" + imagee;
                    Request.Files[0].SaveAs(Server.MapPath(path));
                    slider.Image = image.FileName;
                }



                _sliderService.Insert(slider);
            }

            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var slider = _sliderService.GetSliderById(id);

            if (slider == null || slider.Deleted)
                return RedirectToAction("List");

            var model = new SliderModel()
            {
                Id = slider.Id,
                Image = slider.Image,
                IsActive = slider.IsActive,
                Title = slider.Title
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(SliderModel model, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                var slider = _sliderService.GetSliderById(model.Id);

                if (slider == null || slider.Deleted)
                    return RedirectToAction("List");
                if (image != null)
                {
                    string imagee = Path.GetFileName(image.FileName);
                    string path = "~/Content/travel/images/" + imagee;
                    Request.Files[0].SaveAs(Server.MapPath(path));
                    slider.Image = image.FileName;
                }

                slider.Id = model.Id;
                slider.IsActive = model.IsActive;
                slider.Title = model.Title;

                _sliderService.Update(slider);
            }

            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            var slider = _sliderService.GetSliderById(id);

            if (slider == null)
                return Json("ERR");

            slider.Deleted = true;

            _sliderService.Update(slider);

            return RedirectToAction("List");
        }
    }
}
