namespace Project.BLL.DTOs.Product;

public class ProductUpdateDto
{
    public int ID { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int? CategoryID { get; set; }
}