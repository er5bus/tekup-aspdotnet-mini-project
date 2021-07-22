using System.Collections.Generic;

namespace TekupMiniProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public List<Picture> Pictures { get; set; }
    }
}
