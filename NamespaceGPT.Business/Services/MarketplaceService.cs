using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Models;
using NamespaceGPT.Data.Repositories.Interfaces;

namespace NamespaceGPT.Business.Services
{
    public class MarketplaceService : IMarketplaceService
    {
        private readonly IMarketplaceRepository marketplacerepository;

        public MarketplaceService(IMarketplaceRepository marketplacerepository)
        {
            this.marketplacerepository = marketplacerepository ?? throw new ArgumentNullException(nameof(marketplacerepository));
        }

        public int AddMarketplace(Marketplace marketplace)
        {
           return marketplacerepository.AddMarketplace(marketplace);
        }

        public bool DeleteMarketplace(int id)
        {
            return marketplacerepository.DeleteMarketplace(id);
        }

        public IEnumerable<Marketplace> GetAllMarketplaces()
        {
            return marketplacerepository.GetAllMarketplaces();
        }

        public Marketplace? GetMarketplace(int id)
        {
            return marketplacerepository.GetMarketplace(id);
        }

        public bool UpdateMarketplace(int id, Marketplace marketplace)
        {
            return marketplacerepository.UpdateMarketplace(id, marketplace);
        }
    }
}
