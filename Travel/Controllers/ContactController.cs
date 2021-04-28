using Core.Domain.Main;
using Services.ContactServices;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Travel.Configurations;
using Travel.Models.Contact;

namespace Travel.Controllers
{
    /// <summary>
    /// Defines the <see cref="ContactController" />.
    /// </summary>
    public class ContactController : Controller
    {
        /// <summary>
        /// Defines the _contactService.
        /// </summary>
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
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
            return View(new ContactListModel());
        }

        /// <summary>
        /// The List.
        /// </summary>
        /// <param name="model">The model<see cref="ContactListModel"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public ActionResult List(ContactListModel model)
        {
            var contacts = _contactService.GetAllContact(
                title: model.SearchName,
                pageIndex: model.PageIndex,
                pageSize: model.PageSize);

            return Json(new
            {
                draw = model.Draw,
                recordsFiltered = 0,
                recordsTotal = contacts.TotalCount,
                data = contacts
            });
        }

        /// <summary>
        /// The Create.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Create()
        {
            return View(new ContactModel());
        }

        /// <summary>
        /// The Create.
        /// </summary>
        /// <param name="model">The model<see cref="ContactModel"/>.</param>
        /// <param name="image">The image<see cref="HttpPostedFileBase"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public ActionResult Create(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                Contact contact = model.MapTo<ContactModel, Contact>();

                _contactService.Insert(contact);
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
            var contact = _contactService.GetContactById(id);

            if (contact == null || contact.Deleted)
                return RedirectToAction("List");

            var model = new ContactModel()
            {
                Id = contact.Id,
                Title = contact.Title,
                Definition = contact.Definition,
                EmailAddress = contact.EmailAddress,
                EmailSubject = contact.EmailSubject,
                IsActive = contact.IsActive,
                PhoneNumberSubject = contact.PhoneNumberSubject,
                PhoneNumberTitle = contact.PhoneNumberTitle,
                PostalAddressSubject = contact.PostalAddressSubject,
                PostalAdressTitle = contact.PostalAdressTitle
            };

            return View(model);
        }

        /// <summary>
        /// The Edit.
        /// </summary>
        /// <param name="model">The model<see cref="ContactModel"/>.</param>
        /// <param name="image">The image<see cref="HttpPostedFileBase"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public ActionResult Edit(ContactModel model, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                var contact = _contactService.GetContactById(model.Id);

                if (contact == null || contact.Deleted)
                    return RedirectToAction("List");

                contact.Id = model.Id;
                contact.Title = model.Title;
                contact.Definition = model.Definition;
                contact.EmailAddress = model.EmailAddress;
                contact.EmailSubject = model.EmailSubject;
                contact.IsActive = model.IsActive;
                contact.PhoneNumberSubject = model.PhoneNumberSubject;
                contact.PhoneNumberTitle = model.PhoneNumberTitle;
                contact.PostalAddressSubject = model.PostalAddressSubject;
                contact.PostalAdressTitle = model.PostalAdressTitle;

                _contactService.Update(contact);
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
            var contact = _contactService.GetContactById(id);

            if (contact == null)
                return Json("ERR");

            contact.Deleted = true;

            _contactService.Update(contact);

            return RedirectToAction("List");
        }
    }
}