using MyApiProject.BusinesLayer.Abstract;
using MyApiProject.DataAccessLayer.Abstract;
using MyApiProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiProject.BusinesLayer.Concrete
{
    public class ProducManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProducManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void TDelete(int id)
        {
            _productDal.Delete(id);
        }

        public List<Product> TGetAll()
        {
           return _productDal.GetAll();
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id);
        }

        public void TInsert(Product entity)
        {
            _productDal.Insert(entity);
        }

        public void TUpdate(Product entity)
        {
           _productDal.Update(entity);
        }
    }
}
