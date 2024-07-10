using Project.BLL.DTOs.Category;

namespace Project.BLL.DTOs.Product;

public class ProductGetDto
{
    public int ID { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int? CategoryID { get; set; }
 
    public CategoryGetDto Category { get; set; }

    
}