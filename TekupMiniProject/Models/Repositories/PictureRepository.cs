using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TekupMiniProject.Models.Repositories
{
    public class PictureRepository : IRepository<Product>
    {
        public IList<Picture> Pictures;

        public PictureRepository()
        {
            Pictures = new List<Picture>();
        }

        public List<Picture> Create(List<IFormFile> Files)
        {
            List<Picture> uploadedFiles = new List<Picture>();
            int id = Pictures.Count;
            if (Files != null && Files.Count > 0)
            {
                foreach (var item in Files)
                {
                    id++;
                    Picture photography = new Picture();
                    var guid = Guid.NewGuid().ToString();
                    var DirFilePath = "wwwroot/photography/";
                    var filePath = DirFilePath + guid + item.FileName;
                    var fileName = guid + item.FileName;
                    if (!Directory.Exists(DirFilePath))
                    {
                        Directory.CreateDirectory(DirFilePath);
                    }
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        item.CopyTo(stream);
                        photography.Id = id;
                        photography.Name = fileName;
                        photography.Path = filePath;
                        uploadedFiles.Add(photography);
                        Pictures.Add(photography);
                    }
                }
            }
            return uploadedFiles;

        }

        public void Delete(int Id)
        {
            var Picture = Pictures.Single(a => a.Id == Id);
            Pictures.Remove(Picture);
        }
    }
}
