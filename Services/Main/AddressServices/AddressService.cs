using Core;
using Core.Domain.Main;
using Data.EfRepository;
using System.Linq;

namespace Services.AddressServices
{
    /// <summary>
    /// Defines the <see cref="AddressService" />.
    /// </summary>
    public class AddressService : IAddressService
    {
        #region Fields
        /// <summary>
        /// Defines the _addressRepository.
        /// </summary>
        private readonly IRepository<Address> _addressRepository;
        #endregion

        #region Constructor
        public AddressService()
        {
            _addressRepository = new Repository<Address>();
        }
        #endregion

        #region Methods

        /// <summary>
        /// The GetAllAddress.
        /// </summary>
        /// <param name="title">The title<see cref="string"/>.</param>
        /// <param name="pageIndex">The pageIndex<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <returns>The <see cref="IPagedList{Address}"/>.</returns>
        public IPagedList<Address> GetAllAddress(string title = "", int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _addressRepository.Table;

            if (!string.IsNullOrEmpty(title))
                query = query.Where(a => a.Title.Contains(title));

            query = query.OrderBy(o => o.Id);

            var addresss = new PagedList<Address>(query, pageIndex, pageSize);

            return addresss;
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        public void Delete(int id)
        {
            var address = _addressRepository.GetById(id);

            _addressRepository.Delete(address);
        }

        /// <summary>
        /// The GetAddressById.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Address"/>.</returns>
        public Address GetAddressById(int id)
        {
            return _addressRepository.GetById(id);
        }

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="address">The address<see cref="Address"/>.</param>
        public void Insert(Address address)
        {
            _addressRepository.Insert(address);
        }

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="address">The address<see cref="Address"/>.</param>
        public void Update(Address address)
        {
            _addressRepository.Update(address);
        }
        #endregion


    }
}
