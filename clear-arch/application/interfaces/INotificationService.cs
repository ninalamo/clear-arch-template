using application.notifications.models;
using System.Threading.Tasks;

namespace application.interfaces
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}