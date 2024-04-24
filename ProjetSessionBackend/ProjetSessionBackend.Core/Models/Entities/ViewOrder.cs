using System;
using System.Collections.Generic;

namespace ProjetSessionBackend.Core.Models.Entities;

public partial class ViewOrder
{
    public int? OrderId { get; set; }

    public int? ClientId { get; set; }

    public string? Fullname { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public decimal? TpsValue { get; set; }

    public decimal? TvqValue { get; set; }

    public decimal? Subtotal { get; set; }

    public decimal? Total { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
