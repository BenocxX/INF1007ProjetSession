using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetSessionBackend.Core.Models.Entities;

public partial class User
{
    [Key]
    public int id { get; set; }
    
    public int? Name { get; set; }
}
