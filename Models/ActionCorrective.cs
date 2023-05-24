using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Models;

[Table("ActionCorrective")]
public partial class ActionCorrective
{
    [Key]
    [Column("Action_ID")]
    public int ActionId { get; set; }

    [Column("Complaint_ID")]
    public int? ComplaintId { get; set; }

    [Column("Technician_ID")]
    public int? TechnicianId { get; set; }

    [Unicode(false)]
    public string? Description { get; set; }

    [ForeignKey("ComplaintId")]
    [InverseProperty("ActionCorrectives")]
    public virtual Complaint? Complaint { get; set; }

    [ForeignKey("TechnicianId")]
    [InverseProperty("ActionCorrectives")]
    public virtual Technician? Technician { get; set; }
}
