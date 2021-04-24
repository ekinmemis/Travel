namespace Travel.Models
{
    /// <summary>
    /// Defines the <see cref="DataTableRequestModel" />.
    /// </summary>
    public class DataTableRequestModel
    {
        /// <summary>
        /// Gets or sets the Draw.
        /// </summary>
        public string Draw { get; set; }

        /// <summary>
        /// Gets or sets the PageSize.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the PageIndex.
        /// </summary>
        public int PageIndex { get; set; }
    }
}
