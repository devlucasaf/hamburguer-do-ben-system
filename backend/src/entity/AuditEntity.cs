using System.ComponentModel.DataAnnotations;

namespace HamburguerDoBenSystem.Backend.src.entity;

public abstract class AuditEntity 
{
    [Key]
    public long         Id          { get; set; }
    public DateTime     CreatedAt   { get; set; }
    public DateTime?    UpdatedAt   { get; set; }
}