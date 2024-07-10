namespace Project.BLL.DTOs.Product;

public class ProductCreateDto
{
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int? CategoryID { get; set; }

}