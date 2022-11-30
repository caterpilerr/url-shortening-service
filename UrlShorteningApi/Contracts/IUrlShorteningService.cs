using System.Threading.Tasks;

namespace UrlShorteningApi.Contracts;

public interface IUrlShorteningService
{
    public Task<string> CreateShortening(string url);

    public Task<string> GetUrl(string urlShortening);
}