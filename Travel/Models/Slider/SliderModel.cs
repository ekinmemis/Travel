using System;

namespace Travel.Models.Slider
{
    /// <summary>
    /// Defines the <see cref="SliderModel" />.
    /// </summary>
    public class SliderModel
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Image.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsActive.
        /// </summary>
        public bool IsActive { get; set; }
    }
}
