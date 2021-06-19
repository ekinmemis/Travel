using Core.Domain.Main;

using Services.ContactServices;

using System.Web;
using System.Web.Mvc;

using Travel.Configurations;
using Travel.Models.Contact;

namespace Travel.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new ContactListModel());
        }

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

        public ActionResult Create()
        {
            return View(new ContactModel());
        }

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
