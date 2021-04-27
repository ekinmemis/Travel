using System;

namespace Travel.Models.Contact
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Definition { get; set; }
        public string PhoneNumberTitle { get; set; }
        public string PhoneNumberSubject { get; set; }
        public string PostalAdressTitle { get; set; }
        public string PostalAddressSubject { get; set; }
        public string EmailAddress { get; set; }
        public string EmailSubject { get; set; }
        public bool IsActive { get; set; }
    }
}
