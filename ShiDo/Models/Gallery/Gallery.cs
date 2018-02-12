using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ShiDo.Models.Gallery
{
    public class Gallery
    {
        [DisplayName("Галерея")]
        public int GalleryId { get; set; }
        [DisplayName("Название галереи")]
        public string GalleryName { get; set; }

        public ICollection<Picture> Photos { get; set; }
    }
}