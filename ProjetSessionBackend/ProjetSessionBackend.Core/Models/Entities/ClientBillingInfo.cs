namespace ProjetSessionBackend.Core.Models.Entities;

public class ClientBillingInfo : BaseEntity
{
    public int ClientBillingInfoId { get; set; }
    public string Address { get; set; }
    public string CardName { get; set; }
    public string CardNumber { get; set; }
    public string ExpiryDate { get; set; }
    public string CVV { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }
}