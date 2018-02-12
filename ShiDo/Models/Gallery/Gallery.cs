using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShiDo.Models.Gallery
{
    public class Gallery
    {
        public int GalleryId { get; set; }
        public string GalleryName { get; set; }

        public ICollection<Picture> Photos { get; set; }
    }
}