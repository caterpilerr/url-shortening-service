using System.Threading.Tasks;
using UrlShorteningApi.Contracts;
using UrlShorteningApi.Data.Entities;
using UrlShorteningApi.Utilities;

namespace UrlShorteningApi.Services;

public class UrlShorteningService : IUrlShorteningService
{
    private readonly IUrlDataRepository _urlDataRepository;

    public UrlShorteningService(IUrlDataRepository urlDataRepository)
    {
        _urlDataRepository = urlDataRepository;
    }

    public async Task<string> CreateShortening(string url)
    {
        var urlData = new UrlData
        {
            OriginalUrl = url
        };

        await _urlDataRepository.AddUrlData(urlData);

        return Base62Helper.Encode(urlData.Id);
    }

    public async Task<string> GetUrl(string urlShortening)
    {
        var id = Base62Helper.Decode(urlShortening);
        var data = await _urlDataRepository.GetUrlData(id);

        return data?.OriginalUrl;
    }
}