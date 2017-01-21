namespace Chromamboo.Providers.Presentation.Contracts
{
    public interface IPresentationProvider 
    {
        string Name { get; }

        void MarkAsInconclusive();
    }
}