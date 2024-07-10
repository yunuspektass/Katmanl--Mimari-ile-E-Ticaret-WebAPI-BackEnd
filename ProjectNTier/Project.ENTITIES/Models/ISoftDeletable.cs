namespace Project.ENTITIES.Models;

public interface ISoftDeletable
{
    public bool Deleted { get; set; }
}