namespace Chromamboo.Providers.Notification
{
    internal interface INotificationProvider<T>
    {
        void Register(T param);
    }
}