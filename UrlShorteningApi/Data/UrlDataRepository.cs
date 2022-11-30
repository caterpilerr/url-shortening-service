using System.Threading.Tasks;
using UrlShorteningApi.Contracts;
using UrlShorteningApi.Data.Entities;

namespace UrlShorteningApi.Data;

public class UrlDataRepository : IUrlDataRepository
{
    private readonly AppContext _context;

    public UrlDataRepository(AppContext context)
    {
        _context = context;
    }

    public async Task AddUrlData(UrlData data)
    {
        _context.Add(data);
        
        await _context.SaveChangesAsync();
    }

    public async Task<UrlData> GetUrlData(int id)
    {
        return await _context.FindAsync<UrlData>(id);
    }
}