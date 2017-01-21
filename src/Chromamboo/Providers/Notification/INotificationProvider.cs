namespace Chromamboo.Providers.Notification
{
    internal interface INotificationProvider<T> : INotificationProvider
    {
        void Register(T param);
    }

    public interface INotificationProvider
    {
    }
}