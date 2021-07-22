using System.Collections.Generic;
using System.Linq;

namespace TekupMiniProject.Models.Repositories
{
    public class ProductRepository : IRepository<Product>
    {

        private IList<Product> Products;
        public ProductRepository()
        {
            this.Products = new List<Product>()
            {
                new Product
                {
                    Id =1,
                    Reference = "EL1110",
                    Description = "Imprimante Jet d'encre ...",
                },
                new Product
                {
                     Id = 2,
                     Reference = "EL1110",
                     Description = "Imprimante Jet d'encre ..."
                },
                new Product
                {
                    Id = 3,
                     Reference = "EL1110",
                     Description = "Imprimante Jet d'encre ..."
                },

            };
        }

        public IList<Product> FindAll()
        {
            return Products;
        }

        public Product FindById(int Id)
        {
            return Products.Single(b => b.Id == Id);
        }

        public void Create(Product element)
        {
            element.Id = Products.Max(b => b.Id) + 1;
            Products.Add(element);
        }

        public void Update(int id, Product element)
        {
            var ancienProduct = FindById(id);
            Products.Remove(ancienProduct);
            Products.Add(element);
        }

        public void Delete(int id)
        {
            var produit = FindById(id);
            Products.Remove(produit);
        }
    }
}
