namespace Travel.Models.Blog
{
    public partial class BlogPagingFilteringModel : BasePageableModel
    {
        public string SearchName { get; set; }

        public int CategoryId { get; set; }
    }
}