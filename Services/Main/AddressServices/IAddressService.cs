using Core;
using Core.Domain.Main;

namespace Services.AddressServices
{
    /// <summary>
    /// Defines the <see cref="IAddressService" />.
    /// </summary>
    public interface IAddressService
    {
        #region Methods

        /// <summary>
        /// The GetAllAddress.
        /// </summary>
        /// <param name="title">The title<see cref="string"/>.</param>
        /// <param name="pageIndex">The pageIndex<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <returns>The <see cref="IPagedList{Address}"/>.</returns>
        IPagedList<Address> GetAllAddress(string title = "", int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// The GetAddressById.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Address"/>.</returns>
        Address GetAddressById(int id);

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="address">The address<see cref="Address"/>.</param>
        void Insert(Address address);

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="address">The address<see cref="Address"/>.</param>
        void Update(Address address);

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        void Delete(int id);

        #endregion

    }
}
