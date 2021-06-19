using System;

namespace Travel.Models.About
{
    public class AboutModel
    {
        public int Id { get; set; }

        public string Image { get; set; }

        public string Definition { get; set; }

        public string Title { get; set; }

        public DateTime CreateDate { get; set; }

        public string Note { get; set; }

        public bool IsActive { get; set; }

        public string ShortDefinition { get; set; }

        public string DateString { get; set; }
    }
}
