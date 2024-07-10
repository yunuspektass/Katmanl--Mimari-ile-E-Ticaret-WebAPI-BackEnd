using System.ComponentModel.DataAnnotations.Schema;
using Project.ENTITIES.Enums;

namespace Project.ENTITIES.Models;

public abstract class BaseEntity:ISoftDeletable
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public DateTime CreatedDate { get; set;  }
    public DateTime? ModifiedDate { get; set;  }
    public  DateTime? DeletedDate { get; set; }
    public DataStatus Status { get; set; }
    
    public bool Deleted { get; set; }
    // public bool IsDeleted { get; set; }

    public BaseEntity()
    {
        CreatedDate = DateTime.UtcNow;
        ModifiedDate = DateTime.UtcNow;
        Status = DataStatus.Inserted; 
    }
    
    
    

}