using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_De_Pedidos.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string productName { get; set; }
        public int productQuantity { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal productValue { get; set; }

    }
}
