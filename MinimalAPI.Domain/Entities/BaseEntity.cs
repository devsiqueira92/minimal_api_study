using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MinimalAPI.Domain.Entities;

public class BaseEntity
{
    [Key]
    [Column("ID")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    [Column("DAT_CREATED_AT")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    [Column("DAT_UPDATED_AT")]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    [Column("FLG_IS_DELETED")]
    public bool IsDeleted { get; set; } = false;
}
