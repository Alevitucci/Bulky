
using Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulkyWeb.DataAccess.Data;


namespace Bulky.DataAccess.Repository.IRepository
{
    public class ProductImageRepository : Repository<ProductImage>, IProductImageRepository
    {

        private readonly ApplicationDbContext _db;
        public ProductImageRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ProductImage obj)
        {
            _db.ProductImages.Update(obj);
        }
    }
}
