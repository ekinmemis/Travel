using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Travel.Models.Blog
{
    public class BlogModel
    {
        public BlogModel()
        {
            this.Categories = new List<SelectListItem>();
        }
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Title1 { get; set; }
        public string Image1 { get; set; }
        public string Image1Definition { get; set; }
        public string Definition1 { get; set; }
        public string Definition2 { get; set; }
        public string Image2 { get; set; }
        public string Image2Definition { get; set; }
        public string Definition3 { get; set; }
        public string Title2 { get; set; }
        public string Definition4 { get; set; }
        public string Li1 { get; set; }
        public string Li2 { get; set; }
        public string Li3 { get; set; }
        public string Definition5 { get; set; }
        public string Title3 { get; set; }
        public string Definition6 { get; set; }
        public string Note1 { get; set; }
        public string Title4 { get; set; }
        public string Definition7 { get; set; }
        public string Note2 { get; set; }
        public string Ol1 { get; set; }
        public string Ol2 { get; set; }
        public string Ol3 { get; set; }
        public string Definition8 { get; set; }
        public int CategoryId { get; set; }
        public IList<SelectListItem> Categories { get; set; }
        public bool IsActive { get; set; }
    }
}
