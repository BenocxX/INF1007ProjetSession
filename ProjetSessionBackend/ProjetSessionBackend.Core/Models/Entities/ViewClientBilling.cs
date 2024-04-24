using System;
using System.Collections.Generic;

namespace ProjetSessionBackend.Core.Models.Entities;

public partial class ViewClientBilling
{
    public int? ClientId { get; set; }

    public string? CardName { get; set; }

    public string? CardNumber { get; set; }

    public string? ExpiryDate { get; set; }

    public string? Cvv { get; set; }
}
