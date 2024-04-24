using System;
using System.Collections.Generic;

namespace ProjetSessionBackend.Core.Models.Entities;

public partial class Client
{
    public int ClientId { get; set; }

    public int? PersonId { get; set; }

    public int? UserId { get; set; }

    public string? Address { get; set; }

    public string? CardName { get; set; }

    public string? CardNumber { get; set; }

    public string? Cvv { get; set; }

    public string? ExpiryDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Person? Person { get; set; }

    public virtual User? User { get; set; }
}
