namespace Project.ENTITIES.Models;

public class AppUser:BaseEntity
{
    public string UserName { get; set; }
    public string Password { get; set; }
   
    
    // Relational Properties 
    public virtual List<Order> Orders { get; set; }
    
}