using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Models;
using NamespaceGPT.Data.Repositories.Interfaces;

namespace NamespaceGPT.Business.Services
{
    public class ListingService : IListingService
    {
        private readonly IListingRepository listingRepository;

        public ListingService(IListingRepository listingRepository)
        {
            this.listingRepository = listingRepository ?? throw new ArgumentNullException(nameof(listingRepository));
        }

        public int AddListing(Listing listing)
        {
            return listingRepository.AddListing(listing);
        }

        public bool DeleteListing(int id)
        {
            return listingRepository.DeleteListing(id);
        }

        public IEnumerable<Listing> GetAllListings()
        {
            return listingRepository.GetAllListings();
        }

        public IEnumerable<Listing> GetAllListingsOfProduct(int productId)
        {
            return listingRepository.GetAllListingsOfProduct(productId);
        }

        public Listing? GetListing(int id)
        {
            return listingRepository.GetListing(id);
        }

        public bool UpdateListing(int id, Listing listing)
        {
            return listingRepository.UpdateListing(id, listing);
        }
    }
}
