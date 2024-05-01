using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Models;
using NamespaceGPT.Data.Repositories.Interfaces;

namespace NamespaceGPT.Business.Services
{
    public class MarketplaceService : IMarketplaceService
    {
        private readonly IMarketplaceRepository marketplaceRepository;

        public MarketplaceService(IMarketplaceRepository marketplaceRepository)
        {
            this.marketplaceRepository = marketplaceRepository ?? throw new ArgumentNullException(nameof(marketplaceRepository));
        }

        public int AddMarketplace(Marketplace marketplace)
        {
           return marketplaceRepository.AddMarketplace(marketplace);
        }

        public bool DeleteMarketplace(int id)
        {
            return marketplaceRepository.DeleteMarketplace(id);
        }

        public IEnumerable<Marketplace> GetAllMarketplaces()
        {
            return marketplaceRepository.GetAllMarketplaces();
        }

        public Marketplace? GetMarketplace(int id)
        {
            return marketplaceRepository.GetMarketplace(id);
        }

        public bool UpdateMarketplace(int id, Marketplace marketplace)
        {
            return marketplaceRepository.UpdateMarketplace(id, marketplace);
        }
    }
}
