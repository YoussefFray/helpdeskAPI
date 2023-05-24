using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Models;

[Table("User")]
public partial class User
{
    [Key]
    [Column("User_ID")]
    public int UserId { get; set; }

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

    [InverseProperty("User")]
    public virtual ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();
}
