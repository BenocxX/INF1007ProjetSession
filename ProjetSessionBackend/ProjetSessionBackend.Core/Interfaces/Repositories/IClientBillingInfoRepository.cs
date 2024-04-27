using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Core.Interfaces.Repositories;

public interface IClientBillingInfoRepository
{
    public Task<IEnumerable<ClientBillingInfo>> GetAll();
    public Task<ClientBillingInfo?> GetById(int id);
    public Task<ClientBillingInfo> Create(ClientBillingInfo clientBillingInfo);
    public Task<ClientBillingInfo?> Delete(int id);
}