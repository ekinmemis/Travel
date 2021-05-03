using Core.Domain.Main;
using Services.SliderServices;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Travel.Configurations;
using Travel.Models.Slider;

namespace Travel.Controllers
{
    /// <summary>
    /// Defines the <see cref="SliderController" />.
    /// </summary>
    public class SliderController : Controller
    {
        /// <summary>
        /// Defines the _sliderService.
        /// </summary>
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        /// <summary>
        /// The Index.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        /// <summary>
        /// The List.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult List()
        {
            return View(new SliderListModel());
        }

        /// <summary>
        /// The List.
        /// </summary>
        /// <param name="model">The model<see cref="SliderListModel"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
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

        /// <summary>
        /// The Create.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Create()
        {
            return View(new SliderModel());
        }

        /// <summary>
        /// The Create.
        /// </summary>
        /// <param name="model">The model<see cref="SliderModel"/>.</param>
        /// <param name="image">The image<see cref="HttpPostedFileBase"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
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

        /// <summary>
        /// The Edit.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
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

        /// <summary>
        /// The Edit.
        /// </summary>
        /// <param name="model">The model<see cref="SliderModel"/>.</param>
        /// <param name="image">The image<see cref="HttpPostedFileBase"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
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

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
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