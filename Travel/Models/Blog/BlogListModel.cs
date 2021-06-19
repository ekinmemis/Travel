using System.Collections.Generic;

namespace Travel.Models.Blog
{
    public class BlogListModel : DataTableRequestModel
    {
        public BlogListModel()
        {
            PagingFilteringContext = new BlogPagingFilteringModel();
            BlogPosts = new List<BlogModel>();
            Sliders = new List<Core.Domain.Main.Slider>();
        }

        public string SearchName { get; set; }

        public int CategoryId { get; set; }

        public IList<Core.Domain.Main.Slider> Sliders { get; set; }

        public BlogPagingFilteringModel PagingFilteringContext { get; set; }

        public IList<BlogModel> BlogPosts { get; set; }
    }
}
