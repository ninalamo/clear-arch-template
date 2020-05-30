using Core.Application.Notifications.Models;
using System.Threading.Tasks;

namespace Core.Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
    }
}


