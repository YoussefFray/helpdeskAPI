using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Models;

[Table("Complaint")]
public partial class Complaint
{
    [Key]
    [Column("Complaint_ID")]
    public int ComplaintId { get; set; }

    [Column("User_ID")]
    public int? UserId { get; set; }

    [Column("Unique_Code")]
    [StringLength(50)]
    [Unicode(false)]
    public string? UniqueCode { get; set; }

    [Unicode(false)]
    public string? Description { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    public bool? Approved { get; set; }

    [InverseProperty("Complaint")]
    public virtual ICollection<ActionCorrective> ActionCorrectives { get; set; } = new List<ActionCorrective>();

    [ForeignKey("UserId")]
    [InverseProperty("Complaints")]
    public virtual User? User { get; set; }
}
