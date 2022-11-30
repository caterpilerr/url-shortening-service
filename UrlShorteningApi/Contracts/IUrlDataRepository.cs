using System.Threading.Tasks;
using UrlShorteningApi.Data.Entities;

namespace UrlShorteningApi.Contracts;

public interface IUrlDataRepository
{
    public Task AddUrlData(UrlData data);

    public Task<UrlData> GetUrlData(int id);
}