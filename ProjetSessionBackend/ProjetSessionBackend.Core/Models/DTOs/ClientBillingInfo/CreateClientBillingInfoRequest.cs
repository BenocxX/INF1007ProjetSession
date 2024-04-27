namespace ProjetSessionBackend.Core.Models.DTOs.ClientBillingInfo;

public class CreateClientBillingInfoRequest
{
    public string Address { get; set; }
    public string CardName { get; set; }
    public string CardNumber { get; set; }
    public string ExpiryDate { get; set; }
    public string CVV { get; set; }
    public int UserId { get; set; }
}