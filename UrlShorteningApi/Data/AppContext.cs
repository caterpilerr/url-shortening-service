using Microsoft.EntityFrameworkCore;
using UrlShorteningApi.Data.Entities;

namespace UrlShorteningApi.Data;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions<AppContext> options) : base(options)
    {
    }
    
    public  DbSet<UrlData> UrlHashes { get; set; }
}