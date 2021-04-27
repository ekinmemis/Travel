using Core;
using Core.Domain.Main;

namespace Services.ContactServices
{
    /// <summary>
    /// Defines the <see cref="IContactService" />.
    /// </summary>
    public interface IContactService
    {
        /// <summary>
        /// The GetAllContact.
        /// </summary>
        /// <param name="title">The title<see cref="string"/>.</param>
        /// <param name="pageIndex">The pageIndex<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <returns>The <see cref="IPagedList{Contact}"/>.</returns>
        IPagedList<Contact> GetAllContact(string title = "", int pageIndex = 1, int pageSize = int.MaxValue);

        /// <summary>
        /// The GetContactById.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Contact"/>.</returns>
        Contact GetContactById(int id);

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="contact">The contact<see cref="Contact"/>.</param>
        void Insert(Contact contact);

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="contact">The contact<see cref="Contact"/>.</param>
        void Update(Contact contact);

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        void Delete(int id);

        /// <summary>
        /// The GetActiveContact.
        /// </summary>
        /// <returns>The <see cref="Contact"/>.</returns>
        Contact GetActiveContact();
    }
}
