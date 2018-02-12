using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShiDo.Models.Gallery
{
    public class Picture
    {
        [Key]
        public int PictureId { get; set; }
        public byte[] Image { get; set; }
        public string Name { get; set; }

        public int GalleryId { get; set; }
        public Gallery Gallery { get; set; }
    }
}