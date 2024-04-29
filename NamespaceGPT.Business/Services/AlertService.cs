using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Models;
using NamespaceGPT.Data.Repositories.Interfaces;

namespace NamespaceGPT.Business.Services
{
    public class AlertService : IAlertService
    {
        private readonly IAlertRepository alertRepository;

        public AlertService(IAlertRepository alertRepository)
        {
            this.alertRepository = alertRepository ?? throw new ArgumentNullException(nameof(alertRepository));
        }

        public int AddAlert(IAlert alert)
        {
            return alertRepository.AddAlert(alert);
        }

        public bool DeleteAlert(int id, IAlert alert)
        {
            return alertRepository.DeleteAlert(id, alert);
        }

        public IAlert? GetAlert(int alertId)
        {
            return alertRepository.GetAlert(alertId);
        }

        public IEnumerable<IAlert> GetAllAlerts()
        {
            return alertRepository.GetAllAlerts();
        }

        public IEnumerable<IAlert> GetAllProductAlerts(int productId)
        {
            return alertRepository.GetAllProductAlerts(productId);
        }

        public IEnumerable<IAlert> GetAllUserAlerts(int userId)
        {
            return alertRepository.GetAllUserAlerts(userId);
        }

        public bool UpdateAlert(int id, IAlert alert)
        {
            return alertRepository.UpdateAlert(id, alert);
        }
    }
}
