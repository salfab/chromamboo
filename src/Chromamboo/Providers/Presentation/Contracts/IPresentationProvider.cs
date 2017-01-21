namespace Chromamboo.Providers.Presentation.Contracts
{
    public interface IPresentationProvider 
    {
        void MarkAsInconclusive();
        string Name { get; }
    }
}