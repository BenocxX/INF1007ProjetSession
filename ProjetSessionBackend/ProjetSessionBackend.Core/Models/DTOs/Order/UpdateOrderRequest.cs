using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Core.Models.DTOs.Order;

public class UpdateOrderRequest
{
    public PaymentMethod PaymentMethod { get; set; }
    public OrderStatus Status { get; set; }
    public decimal Tps { get; set; }
    public decimal Tvq { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Total { get; set; }
    public int ClientBillingInfoId { get; set; }

}