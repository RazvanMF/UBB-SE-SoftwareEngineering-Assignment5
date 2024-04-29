using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Models;
using NamespaceGPT.Data.Repositories.Interfaces;

namespace NamespaceGPT.Business.Services
{
    public class FavouriteProductService : IFavouriteProductService
    {
        private readonly IFavouriteProductRepository favouriteProductRepository;

        public FavouriteProductService(IFavouriteProductRepository favouriteProductRepository)
        {
            this.favouriteProductRepository = favouriteProductRepository ?? throw new ArgumentNullException(nameof(favouriteProductRepository));
        }

        public int AddFavouriteProduct(FavouriteProduct favouriteProduct)
        {
            return favouriteProductRepository.AddFavouriteProduct(favouriteProduct);
        }

        public bool DeleteFavouriteProductFromUser(FavouriteProduct favouriteProduct)
        {
            return favouriteProductRepository.DeleteFavouriteProductFromUser(favouriteProduct);
        }

        public IEnumerable<FavouriteProduct> GetAllFavouriteProducts()
        {
            return favouriteProductRepository.GetAllFavouriteProducts();
        }

        public IEnumerable<FavouriteProduct> GetAllFavouriteProductsOfUser(int userId)
        {
            return favouriteProductRepository.GetAllFavouriteProductsOfUser(userId);
        }

        public IEnumerable<int> GetAllUserIdsWhoMarkedProductAsFavourite(int productId)
        {
            return favouriteProductRepository.GetAllUserIdsWhoMarkedProductAsFavourite(productId);
        }

        public FavouriteProduct? GetFavouriteProduct(int id)
        {
            return favouriteProductRepository.GetFavouriteProduct(id);
        }
    }
}
