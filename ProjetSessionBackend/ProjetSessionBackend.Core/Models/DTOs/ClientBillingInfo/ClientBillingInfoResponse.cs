namespace ProjetSessionBackend.Core.Models.DTOs.ClientBillingInfo;

public class ClientBillingInfoResponse : BaseEntityResponse
{
    public int ClientBillingInfoId { get; set; }
    public string Address { get; set; }
    public int UserId { get; set; }
}