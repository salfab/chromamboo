using Newtonsoft.Json.Linq;

namespace Chromamboo.Providers.Notification.Factories.Contracts
{
    public interface INotificationProviderFactory
    {
        string Name { get; }
        INotificationProvider Create(dynamic settings);
    }
}