namespace ProjetSessionBackend.Core.Models.Entities;

public enum OrderStatus
{
    Open = 0,
    Preparing = 1,
    PickUp = 2,
    Shipped = 3,
    Payed = 4,
    Archived = 5
}

public enum PaymentMethod
{
    Credit = 0,
    Debit = 1,
    Cash = 2
}

public class Order
{
    public int OrderId { get; set; }
    public OrderStatus Status { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public decimal Tps { get; set; }
    public decimal Tvq { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Total { get; set; }
    
    public int ClientBillingInfoId { get; set; }
    public ClientBillingInfo ClientBillingInfo { get; set; }
}