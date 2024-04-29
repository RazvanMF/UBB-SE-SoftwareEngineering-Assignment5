using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Models;

namespace NamespaceGPT.Api.Controllers
{
    public class MarketplaceController
    {
        private readonly IMarketplaceService marketplaceService;

        public MarketplaceController(IMarketplaceService marketplaceService)
        {
            this.marketplaceService = marketplaceService ?? throw new ArgumentNullException(nameof(marketplaceService));
        }

        public int Addmarketplace(Marketplace marketplace)
        {
            return marketplaceService.AddMarketplace(marketplace);
        }

        public bool Deletemarketplace(int id)
        {
            return marketplaceService.DeleteMarketplace(id);
        }

        public IEnumerable<Marketplace> GetAllMarketplaces()
        {
            return marketplaceService.GetAllMarketplaces();
        }

        public Marketplace? Getmarketplace(int id)
        {
            return marketplaceService.GetMarketplace(id);
        }

        public bool Updatemarketplace(int id, Marketplace marketplace)
        {
            return marketplaceService.UpdateMarketplace(id, marketplace);
        }
    }
}
