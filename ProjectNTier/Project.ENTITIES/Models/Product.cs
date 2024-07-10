using System.ComponentModel.DataAnnotations.Schema;

namespace Project.ENTITIES.Models;

public class Product:BaseEntity
{
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    
    [ForeignKey("Category")]
    public int? CategoryID { get; set; }
    
    //Relational Properties 
    public virtual Category Category { get; set; }
    public virtual List<OrderDetail> OrderDetails { get; set; }
}