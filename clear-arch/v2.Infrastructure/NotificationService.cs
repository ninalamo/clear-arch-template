using Core.Application.Common.Interfaces;
using Core.Application.Notifications.Models;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(MessageDto message)
        {
            return Task.CompletedTask;
        }
    }
}