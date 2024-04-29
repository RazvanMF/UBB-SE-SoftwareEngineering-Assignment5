using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Models;
using NamespaceGPT.Data.Repositories.Interfaces;

namespace NamespaceGPT.Business.Services
{
    public class UserActivityService : IUserActivityService
    {
        private readonly IUserActivityRepository userActivityRepository;

        public UserActivityService(IUserActivityRepository userActivityRepository)
        {
            this.userActivityRepository = userActivityRepository ?? throw new ArgumentNullException(nameof(userActivityRepository));
        }

        public int AddUserActivity(UserActivity userActivity)
        {
            return userActivityRepository.AddUserActivity(userActivity);
        }

        public bool DeleteUserActivity(int id)
        {
            return userActivityRepository.DeleteUserActivity(id);
        }

        public IEnumerable<UserActivity> GetAllUserActivities()
        {
            return userActivityRepository.GetAllUserActivities();
        }

        public IEnumerable<UserActivity> GetUserActivitiesOfUser(int userId)
        {
            return userActivityRepository.GetUserActivitiesOfUser(userId);
        }

        public bool UpdateUserActivity(int id, UserActivity userActivity)
        {
            return userActivityRepository.UpdateUserActivity(id, userActivity);
        }
    }
}
