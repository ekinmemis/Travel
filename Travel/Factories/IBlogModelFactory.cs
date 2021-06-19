using Core.Domain.Main;

using Travel.Models.Blog;

namespace Travel.Factories
{
    public partial interface IBlogModelFactory
    {
        void PrepareBlogModel(BlogModel model, Blog blogPost, bool prepareComments);

        BlogListModel PrepareBlogListModel(BlogPagingFilteringModel command);
    }
}