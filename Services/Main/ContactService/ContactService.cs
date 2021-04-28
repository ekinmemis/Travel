using Core;
using Core.Domain.Main;
using Data.EfRepository;
using System.Linq;

namespace Services.ContactServices
{
    /// <summary>
    /// Defines the <see cref="ContactService" />.
    /// </summary>
    public class ContactService : IContactService
    {
        /// <summary>
        /// Defines the _contactRepository.
        /// </summary>
        private readonly IRepository<Contact> _contactRepository;

        public ContactService(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        /// <summary>
        /// The GetAllContact.
        /// </summary>
        /// <param name="title">The title<see cref="string"/>.</param>
        /// <param name="pageIndex">The pageIndex<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <returns>The <see cref="IPagedList{Contact}"/>.</returns>
        public IPagedList<Contact> GetAllContact(string title = "", int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _contactRepository.Table.Where(f => f.Deleted != true);

            if (!string.IsNullOrEmpty(title))
                query = query.Where(a => a.Title.Contains(title));

            query = query.Where(x => x.Deleted == false).OrderBy(o => o.Id);

            var contacts = new PagedList<Contact>(query, pageIndex, pageSize);

            return contacts;
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        public void Delete(int id)
        {
            var contact = _contactRepository.GetById(id);

            _contactRepository.Delete(contact);
        }

        /// <summary>
        /// The GetContactById.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Contact"/>.</returns>
        public Contact GetContactById(int id)
        {
            return _contactRepository.GetById(id);
        }

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="contact">The contact<see cref="Contact"/>.</param>
        public void Insert(Contact contact)
        {
            _contactRepository.Insert(contact);
        }

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="contact">The contact<see cref="Contact"/>.</param>
        public void Update(Contact contact)
        {
            _contactRepository.Update(contact);
        }

        /// <summary>
        /// The GetActiveContact.
        /// </summary>
        /// <returns>The <see cref="Contact"/>.</returns>
        public Contact GetActiveContact()
        {
            return _contactRepository.Table.ToList().LastOrDefault(f => f.IsActive == true);
        }
    }
}