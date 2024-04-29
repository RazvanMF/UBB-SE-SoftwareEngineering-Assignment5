using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Models;
using NamespaceGPT.Data.Repositories.Interfaces;

namespace NamespaceGPT.Business.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {
            this.saleRepository = saleRepository ?? throw new ArgumentNullException(nameof(saleRepository));
        }

        public int AddSale(Sale sale)
        {
            return saleRepository.AddSale(sale);
        }

        public bool DeleteSale(int id)
        {
            return saleRepository.DeleteSale(id);
        }

        public IEnumerable<Sale> GetAllPurchasesOfUser(int userId)
        {
            return saleRepository.GetAllPurchasesOfUser(userId);
        }

        public IEnumerable<Sale> GetAllSales()
        {
            return saleRepository.GetAllSales();
        }

        public IEnumerable<Sale> GetAllSalesOfListing(int listingId)
        {
            return saleRepository.GetAllSalesOfListing(listingId);
        }

        public Sale? GetSale(int id)
        {
            return saleRepository.GetSale(id);
        }

        public bool UpdateSale(int id, Sale sale)
        {
            return saleRepository.UpdateSale(id, sale);
        }
    }
}
