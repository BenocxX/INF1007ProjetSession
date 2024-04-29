using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Infrastructure.Repositories;

public class ClientBillingInfoRepository : BaseRepository, IClientBillingInfoRepository
{
    public ClientBillingInfoRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<ClientBillingInfo>> GetAll()
    {
        return await Db.ClientBillingInfos.ToListAsync();
    }

    public async Task<ClientBillingInfo?> GetById(int id)
    {
        return await Db.ClientBillingInfos.FindAsync(id);
    }

    public async Task<ClientBillingInfo?> GetByUserId(int userId)
    {
        return await Db.ClientBillingInfos.FirstOrDefaultAsync(c => c.UserId == userId);
    }

    public async Task<ClientBillingInfo> Create(ClientBillingInfo clientBillingInfo)
    {
        Db.ClientBillingInfos.Add(clientBillingInfo);
        await Db.SaveChangesAsync();
        return clientBillingInfo;
    }

    public async Task<ClientBillingInfo?> Delete(int id)
    {
        var clientBillingInfo = await Db.ClientBillingInfos.FindAsync(id);
        if (clientBillingInfo == null)
            return null;

        Db.ClientBillingInfos.Remove(clientBillingInfo);
        await Db.SaveChangesAsync();
        return clientBillingInfo;
    }
}