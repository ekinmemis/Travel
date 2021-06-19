using Core;
using Core.Domain.Main;

using Services.BlogServices;
using Services.SliderServices;

using System;
using System.Collections.Generic;
using System.Linq;

using Travel.Configurations;
using Travel.Models.Blog;

namespace Travel.Factories
{
    public partial class BlogModelFactory : IBlogModelFactory
    {
        private readonly IBlogService _blogService;

        private readonly ISliderService _sliderService;

        public BlogModelFactory(IBlogService blogService, ISliderService sliderService)
        {
            _blogService = blogService;
            _sliderService = sliderService;
        }

        public virtual void PrepareBlogModel(BlogModel model, Blog blog, bool prepareComments)
        {
            model.Id = blog.Id;
            model.CreateDate = blog.CreateDate;
            model.UpdateDate = blog.UpdateDate;
            model.Title1 = blog.Title1;
            model.Image1 = blog.Image1;
            model.Image1Definition = blog.Image1Definition;
            model.Definition1 = blog.Definition1;
            model.Definition2 = blog.Definition2;
            model.Image2 = blog.Image2;
            model.Image2Definition = blog.Image2Definition;
            model.Definition3 = blog.Definition3;
            model.Title2 = blog.Title2;
            model.Definition4 = blog.Definition4;
            model.Li1 = blog.Li1;
            model.Li2 = blog.Li2;
            model.Li3 = blog.Li3;
            model.Definition5 = blog.Definition5;
            model.Title3 = blog.Title3;
            model.Definition6 = blog.Definition6;
            model.Note1 = blog.Note1;
            model.Title4 = blog.Title4;
            model.Definition7 = blog.Definition7;
            model.Note2 = blog.Note2;
            model.Ol1 = blog.Ol1;
            model.Ol2 = blog.Ol1;
            model.Ol3 = blog.Ol1;
            model.Definition8 = blog.Definition8;
            model.CategoryId = blog.CategoryId;
            model.IsActive = blog.IsActive;
        }

        public virtual BlogListModel PrepareBlogListModel(BlogPagingFilteringModel command)
        {
            var model = new BlogListModel();

            if (command.PageSize <= 0) command.PageSize = 5;
            if (command.PageNumber <= 0) command.PageNumber = 1;

            IPagedList<Blog> blogPosts = _blogService.GetAllBlogs(command.SearchName, command.CategoryId, command.PageNumber - 1, command.PageSize);

            model.Sliders = _sliderService.GetAll();

            model.PagingFilteringContext.LoadPagedList(blogPosts);

            model.BlogPosts = blogPosts.Select(x =>
            {
                var blogPostModel = new BlogModel();
                PrepareBlogModel(blogPostModel, x, false);
                return blogPostModel;
            }).ToList();


            return model;
        }
    }
}
