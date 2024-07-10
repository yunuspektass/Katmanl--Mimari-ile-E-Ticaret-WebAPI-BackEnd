namespace Project.ENTITIES.Models;

public class AppUserProfile:BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
   
    // Relational Properties 
}