using Sistema_De_Pedidos.Models;

namespace Sistema_De_Pedidos.Repository
{
    public interface IProductRepository
    {
        ProductModel ListByGuid(Guid id);
        List<ProductModel> GetAll();
        ProductModel Add(ProductModel product);
        ProductModel Update(ProductModel product);
        bool Delete(Guid id);
    }
}
