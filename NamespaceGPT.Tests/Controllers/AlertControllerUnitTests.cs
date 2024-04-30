using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using NamespaceGPT.Api.Controllers;
using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Business.Services;
using NamespaceGPT.Data.Models;
using NamespaceGPT.Data.Repositories.Interfaces;
using NamespaceGPT.Data.Repositories;
using NamespaceGPT.Common.ConfigurationManager;

namespace NamespaceGPT.UnitTesting.Controllers
{
    [TestClass]
    public class AlertControllerUnitTests
    {
        private int initialAlertCount = 0;
        private User? testUser;
        private Marketplace? testMarketplace;
        private List<IAlert> testAlerts = new List<IAlert>();

        private IConfigurationManager configurationManager = new ConfigurationManager();
        private IAlertRepository? alertRepository;
        private IAlertService? alertService;
        private AlertController? alertController;
        private Product? testProduct;

        [TestInitialize]
        public void Initialize()
        {
            alertRepository = new AlertRepository(configurationManager);
            alertService = new AlertService(alertRepository);
            alertController = new AlertController(alertService);
            ProductController productController = new ProductController(new ProductService(new ProductRepository(configurationManager)));
            UserController userController = new UserController(new UserService(new UserRepository(configurationManager)));
            MarketplaceController marketplaceController = new MarketplaceController(new MarketplaceService(new MarketplaceRepository(configurationManager)));

            testProduct = new Product
            {
                Name = "AlertTestProduct",
                Category = "generics",
                Description = "Product used for testing alerts",
                Brand = "CelebrationOfCapitalism",
                ImageURL = "https://i0.wp.com/www.thewebdesigncompany.eu/wp-content/uploads/2020/04/WHAT-IS-lorem-ipsum.jpg?fit=960%2C720&ssl=1",
                Attributes = new Dictionary<string, string> { { "comments", "no" }, { "foreign_keys", "no" } }
            };

            testUser = new User
            {
                Username = "test_user",
                Password = "test_user"
            };

            testMarketplace = new Marketplace
            {
                Name = "test_marketplace",
                Websiteurl = "https://www.test.marketplace",
                CountryOfOrigin = "testing_country"
            };

            int addedProductID = productController.AddProduct(testProduct);
            testProduct.Id = addedProductID;

            int addedUserId = userController.AddUser(testUser);
            testUser.Id = addedUserId;

            int addedMarketplaceID = marketplaceController.Addmarketplace(testMarketplace);
            testMarketplace.Id = addedMarketplaceID;

            initialAlertCount = alertRepository.GetAllAlerts().Count();
        }

        [TestMethod]
        public void TestAddAlerts_SuccessfulAdd_ReturnsAlertID()
        {
            Debug.Assert(testProduct != null);
            Debug.Assert(alertController != null);
            Debug.Assert(testUser != null);
            Debug.Assert(testMarketplace != null);

            IAlert priceDropAlert = new PriceDropAlert
            {
                NewPrice = 100,
                OldPrice = 150,
                ProductId = testProduct.Id,
                UserId = testUser.Id,

                // this does nothing afaik
                IAlert = null,
                IAlert1 = null
            };

            IAlert newProductAlert = new NewProductAlert
            {
                UserId = testUser.Id,
                ProductId = testProduct.Id,
                IAlert = null
            };

            IAlert backInStockAlert = new BackInStockAlert
            {
                UserId = testUser.Id,
                ProductId = testProduct.Id,
                MarketplaceId = testMarketplace.Id,
                IAlert = null,
                IAlert1 = null
            };

            int resultID = alertController.AddAlert(backInStockAlert);
            backInStockAlert.Id = resultID;

            resultID = alertController.AddAlert(newProductAlert);
            newProductAlert.Id = resultID;

            resultID = alertController.AddAlert(priceDropAlert);
            priceDropAlert.Id = resultID;

            testAlerts.Add(backInStockAlert);
            testAlerts.Add(newProductAlert);
            testAlerts.Add(priceDropAlert);

            List<IAlert> alerts = alertController.GetAllAlerts().ToList();
            Debug.Assert(alerts.Contains(backInStockAlert));
            Debug.Assert(alerts.Contains(newProductAlert));
            Debug.Assert(alerts.Contains(priceDropAlert));

            foreach (var alert in alerts)
            {
                try
                {
                    alert.Notify();
                }
                catch
                {
                }
            }
        }

        [TestMethod]
        public void TestAddAlert_Failure_ThrowsException()
        {
            try
            {
                alertController.AddAlert(null);
                Debug.Assert(false);
            }
            catch
            {
            }
        }

        [TestMethod]
        public void TestGetAlerts_SuccessfulGet_ReturnsAlerts()
        {
            try
            {
                alertController.GetAlert(42);
                Debug.Assert(false);
            }
            catch
            {
            }

            List<IAlert> alerts = alertController.GetAllAlerts().ToList();
            Debug.Assert(alerts.Count() > 0);

            foreach (IAlert alert in alerts)
            {
                Debug.Assert(alerts.Contains(alert));
            }
        }

        [TestMethod]
        public void TestDeleteAlert_SuccessfulDelete_ReturnsBooleanStateTrue()
        {
            Debug.Assert(alertController != null);
            List<IAlert> deleteAlerts = new List<IAlert>();

            IAlert priceDropAlert = new PriceDropAlert
            {
                NewPrice = 100,
                OldPrice = 150,
                ProductId = testProduct.Id,
                UserId = testUser.Id,

                // this does nothing afaik
                IAlert = null,
                IAlert1 = null
            };

            IAlert newProductAlert = new NewProductAlert
            {
                UserId = testUser.Id,
                ProductId = testProduct.Id,
                IAlert = null
            };

            IAlert backInStockAlert = new BackInStockAlert
            {
                UserId = testUser.Id,
                ProductId = testProduct.Id,
                MarketplaceId = testMarketplace.Id,
                IAlert = null,
                IAlert1 = null
            };

            int resultID = alertController.AddAlert(backInStockAlert);
            backInStockAlert.Id = resultID;

            resultID = alertController.AddAlert(newProductAlert);
            newProductAlert.Id = resultID;

            resultID = alertController.AddAlert(priceDropAlert);
            priceDropAlert.Id = resultID;

            deleteAlerts.Add(backInStockAlert);
            deleteAlerts.Add(newProductAlert);
            deleteAlerts.Add(priceDropAlert);

            foreach (IAlert alert in deleteAlerts)
            {
                int idToDelete = alert.Id;
                bool deleteState = alertController.DeleteAlert(idToDelete, alert);
                Assert.IsTrue(deleteState);
                Debug.Assert(!(alertController.GetAllAlerts().Contains(alert)));
            }
        }

        [TestMethod]
        public void TestDeleteAlert_FailureDelete_ReturnsBooleanStateFalse()
        {
            Debug.Assert(alertController != null);
            int idToDelete = -1;
            bool deleteState = alertController.DeleteAlert(idToDelete, new NewProductAlert());
            Assert.IsFalse(deleteState);

            try
            {
                alertController.DeleteAlert(idToDelete, null);
                Debug.Assert(false);
            }
            catch
            {
            }
        }

        [TestMethod]
        public void TestDeleteAlert_Failure_ThrowsException()
        {
            try
            {
                alertController.DeleteAlert(1, null);
                Debug.Assert(false);
            }
            catch
            {
            }
        }

        [TestMethod]
        public void TestUpdateAlert_SuccessfulUpdate_ReturnsBooleanStateTrue()
        {
            Debug.Assert(alertController != null);
            List<IAlert> deleteAlerts = new List<IAlert>();

            PriceDropAlert priceDropAlert = new PriceDropAlert
            {
                NewPrice = 100,
                OldPrice = 150,
                ProductId = testProduct.Id,
                UserId = testUser.Id,

                // this does nothing afaik
                IAlert = null,
                IAlert1 = null
            };

            NewProductAlert newProductAlert = new NewProductAlert
            {
                UserId = testUser.Id,
                ProductId = testProduct.Id,
                IAlert = null
            };

            BackInStockAlert backInStockAlert = new BackInStockAlert
            {
                UserId = testUser.Id,
                ProductId = testProduct.Id,
                MarketplaceId = testMarketplace.Id,
                IAlert = null,
                IAlert1 = null
            };

            int resultID = alertController.AddAlert(backInStockAlert);
            backInStockAlert.Id = resultID;

            resultID = alertController.AddAlert(newProductAlert);
            newProductAlert.Id = resultID;

            resultID = alertController.AddAlert(priceDropAlert);
            priceDropAlert.Id = resultID;

            deleteAlerts.Add(backInStockAlert);
            deleteAlerts.Add(newProductAlert);
            deleteAlerts.Add(priceDropAlert);

            backInStockAlert.ProductId = 1;
            newProductAlert.ProductId = 1;
            priceDropAlert.NewPrice = priceDropAlert.OldPrice;

            List<IAlert> alerts = alertController.GetAllAlerts().ToList();

            foreach (IAlert alert in deleteAlerts)
            {
                Debug.Assert(!alerts.Contains(alert));
                alertController.UpdateAlert(alert.Id, alert);
            }

            alerts = alertController.GetAllAlerts().ToList();

            foreach (IAlert alert in deleteAlerts)
            {
                Debug.Assert(alerts.Contains(alert));
            }

            foreach (IAlert alert in deleteAlerts)
            {
                int idToDelete = alert.Id;
                bool deleteState = alertController.DeleteAlert(idToDelete, alert);
                Assert.IsTrue(deleteState);
                Debug.Assert(!(alertController.GetAllAlerts().Contains(alert)));
            }
        }

        [TestMethod]
        public void TestUpdateAlert_FailedUpdate_ReturnsBooleanStateFalse()
        {
            Debug.Assert(alertController != null);
            NewProductAlert newProductAlert = new NewProductAlert
            {
                UserId = testUser.Id,
                ProductId = testProduct.Id,
                IAlert = null,
                Id = 0
            };

            Debug.Assert(!alertController.UpdateAlert(newProductAlert.Id, newProductAlert));
        }

        [TestMethod]
        public void TestUpdateAlert_Failure_ThrowsException()
        {
            try
            {
                alertController.UpdateAlert(1, null);
                Debug.Assert(false);
            }
            catch
            {
            }
        }

        [TestMethod]
        public void TestGetAllAlertsByProductId()
        {
            Debug.Assert(alertController != null);
            IAlert newProductAlert = new NewProductAlert
            {
                UserId = testUser.Id,
                ProductId = testProduct.Id,
                IAlert = null
            };

            int resultID = alertController.AddAlert(newProductAlert);
            newProductAlert.Id = resultID;

            List<IAlert> alerts = alertController.GetAllProductAlerts(testProduct.Id).ToList();

            Debug.Assert(alerts.Contains(newProductAlert));
            Debug.Assert(alerts.Count() > 0);

            alertController.DeleteAlert(newProductAlert.Id, newProductAlert);
        }

        [TestMethod]
        public void TestGetAllAlertsByUserId()
        {
            Debug.Assert(alertController != null);
            IAlert newProductAlert = new NewProductAlert
            {
                UserId = testUser.Id,
                ProductId = testProduct.Id,
                IAlert = null
            };

            int resultID = alertController.AddAlert(newProductAlert);
            newProductAlert.Id = resultID;

            List<IAlert> alerts = alertController.GetAllUserAlerts(testUser.Id).ToList();

            Debug.Assert(alerts.Contains(newProductAlert));
            Debug.Assert(alerts.Count() > 0);

            alertController.DeleteAlert(newProductAlert.Id, newProductAlert);
        }

        [TestCleanup]
        public void RestoreAlertData()
        {
            Debug.Assert(alertController != null);

            foreach (IAlert alert in testAlerts)
            {
                int idToDelete = alert.Id;
                bool deleteState = alertController.DeleteAlert(idToDelete, alert);
                Assert.IsTrue(deleteState);
                Debug.Assert(!(alertController.GetAllAlerts().Contains(alert)));
            }
        }
    }
}