using System;
using System.Collections.Generic;

namespace ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Core;

public partial class User
{
    public int UserId { get; set; }

    public int? PersonId { get; set; }
    
    public int? RoleId { get; set; }
    
    public string? Password { get; set; }
    
    public string? PasswordSalt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Person? Person { get; set; }
    
    public virtual Role? Role { get; set; }
}
