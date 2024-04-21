using System;
using System.Collections.Generic;

namespace ProjetSessionBackend.Core;

public partial class Order
{
    public int OrderId { get; set; }

    public int? ClientId { get; set; }

    public decimal? TpsValue { get; set; }

    public decimal? TvqValue { get; set; }

    public decimal? Subtotal { get; set; }

    public decimal? Total { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Client? Client { get; set; }
}
