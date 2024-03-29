﻿using AutoMapper;

using Core.Domain.Categories;
using Core.Domain.Main;

using Travel.Models.About;
using Travel.Models.Blog;
using Travel.Models.Category;
using Travel.Models.Contact;
using Travel.Models.Slider;

namespace Travel.Configurations
{
    /// <summary>
    /// Defines the <see cref="AutoMapperConfiguration" />.
    /// </summary>
    public static class AutoMapperConfiguration
    {
        /// <summary>
        /// The Init.
        /// </summary>
        public static void Init()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<About, AboutModel>();
                cfg.CreateMap<AboutModel, About>().IgnoreAllVirtual();

                cfg.CreateMap<Category, CategoryModel>();
                cfg.CreateMap<CategoryModel, Category>().IgnoreAllVirtual();

                cfg.CreateMap<About, AboutModel>();
                cfg.CreateMap<AboutModel, About>().IgnoreAllVirtual();

                cfg.CreateMap<Contact, ContactModel>();
                cfg.CreateMap<ContactModel, Contact>().IgnoreAllVirtual();

                cfg.CreateMap<Slider, SliderModel>();
                cfg.CreateMap<SliderModel, Slider>().IgnoreAllVirtual();

                cfg.CreateMap<Blog, BlogModel>();
                cfg.CreateMap<BlogModel, Blog>().IgnoreAllVirtual();
            });

            Mapper = MapperConfiguration.CreateMapper();
        }

        /// <summary>
        /// Gets the Mapper.
        /// </summary>
        public static IMapper Mapper { get; private set; }

        /// <summary>
        /// Gets the MapperConfiguration.
        /// </summary>
        public static MapperConfiguration MapperConfiguration { get; private set; }
    }
}
