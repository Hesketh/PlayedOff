using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayedOff.DataAccess.Entities;

public sealed class UserProfile
{
    [Key]
    [Required]
    [Column("USER_ID")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid UserId { get; set; }

    [Required]
    [Column("AZURE_OID")]
    public Guid AzureOid { get; set; }

    [Required]
    [MinLength(1)]
    [MaxLength(256)]
    [Column("DISPLAY_NAME")]
    public string DisplayName { get; set; } = null!;
}