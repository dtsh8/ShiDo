using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShiDo.Models.Gallery
{
    public class Picture
    {
        [Key]
        public int PictureId { get; set; }
        [DisplayName("Картинка")]
        public byte[] Image { get; set; }
        [DisplayName("Название картинки")]
        public string Name { get; set; }

        [DisplayName("Галерея")]
        public int GalleryId { get; set; }
        public Gallery Gallery { get; set; }
    }
}