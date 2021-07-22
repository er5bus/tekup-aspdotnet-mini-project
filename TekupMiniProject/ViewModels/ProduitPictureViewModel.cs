using TekupMiniProject.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace TekupMiniProject.ViewModels
{
    public class ProductPictureViewModel
    {
        public int ProductId { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public List<IFormFile> PicturesToBeUploaded { get; set; }
        public List<Picture> Pictures { get; set; }
    }
}
