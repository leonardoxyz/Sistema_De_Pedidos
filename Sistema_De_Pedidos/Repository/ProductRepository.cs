using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sistema_De_Pedidos.Data;
using Sistema_De_Pedidos.Models;

namespace Sistema_De_Pedidos.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly BaseContext _baseContext;
        public ProductRepository(BaseContext baseContext) { 
            _baseContext = baseContext;
        }
        public List<ProductModel> GetAll()
        {
            return _baseContext.Products.ToList();
        }
        public ProductModel Add(ProductModel product)
        {
            //adicionar ao banco - context
            _baseContext.Products.Add(product);
            _baseContext.SaveChanges();
            return product;
        }

        public ProductModel ListByGuid(Guid id)
        {
            return _baseContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public ProductModel Update(ProductModel product)
        {
            ProductModel productDB = ListByGuid(product.Id);

            if (productDB == null)
            {
                throw new System.Exception("Produto não cadastrado no Banco de Dados!");
            }

            if (string.IsNullOrWhiteSpace(product.productName))
            {
                throw new System.Exception("O Produto não contém um nome válido!");
            }

            if (product.productQuantity <= 0 || product.productValue <= 0)
            {
                throw new System.Exception("A quantidade e o valor do produto devem ser maiores que zero!");
            }

            productDB.productName = product.productName;
            productDB.productQuantity = product.productQuantity;
            productDB.productValue = product.productValue;

            try
            {
                _baseContext.Products.Update(productDB);
                _baseContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new System.Exception("O objeto foi atualizado por outra thread!", ex);
            }

            if (string.IsNullOrWhiteSpace(productDB.productName) || productDB.productQuantity <= 0 || productDB.productValue <= 0)
            {
                throw new System.Exception("O Produto contém valores inválidos!");
            }

            return productDB;
        }

        public bool Delete(Guid id)
        {
            ProductModel productDB = ListByGuid(id);

            if (productDB == null)
            {
                throw new System.Exception("Houve um erro ao deletar este produto!");
            }

            _baseContext.Products.Remove(productDB);
            _baseContext.SaveChanges();
            return true;
        }
    }
}
