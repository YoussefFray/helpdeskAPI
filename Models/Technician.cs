using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Models;

[Table("Technician")]
public partial class Technician
{
    [Key]
    [Column("Technician_ID")]
    public int TechnicianId { get; set; }

    [Column("First_Name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? FirstName { get; set; }

    [Column("Last_Name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? LastName { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Password { get; set; }

    [InverseProperty("Technician")]
    public virtual ICollection<ActionCorrective> ActionCorrectives { get; set; } = new List<ActionCorrective>();
}
