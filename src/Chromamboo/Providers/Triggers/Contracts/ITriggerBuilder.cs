namespace Chromamboo.Providers.Triggers.Contracts
{
    public interface ITriggerBuilder
    {
        ITriggerProvider Build(dynamic trigger);
    }
}