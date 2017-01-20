namespace Chromamboo.Providers.Presentation
{
    using Notification;

    public interface IPresentationProvider 
    {
        void MarkAsInconclusive();
        string Name { get; }
    }
}