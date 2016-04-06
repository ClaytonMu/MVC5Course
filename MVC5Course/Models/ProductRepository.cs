using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        public Product Find(int id)
        {
            return this.All().Where(p => p.ProductId == id).FirstOrDefault();
        }

        public override IQueryable<Product> All()
        {
            return base.All().Where(p => p.IsDelete == false);
        }

        public override void Delete(Product entity)
        {
            entity.IsDelete = true;
        }
    }

	public  interface IProductRepository : IRepository<Product>
	{

	}
}