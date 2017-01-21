using Chromamboo.Providers.Notification;

namespace Chromamboo
{
    public interface ITriggerBuilder
    {
        ITriggerProvider Build(dynamic trigger);
    }
}