using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Core.Models.DTOs.Order;

public class CreateOrderRequest
{
    public PaymentMethod PaymentMethod { get; set; }
    public decimal SubTotal { get; set; }
    
    public int ClientBillingInfoId { get; set; }
}
