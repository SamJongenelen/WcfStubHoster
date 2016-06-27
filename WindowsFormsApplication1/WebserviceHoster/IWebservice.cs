using System.ServiceModel;

namespace WindowsFormsApplication1
{
    public interface IWebservice
    {
        ServiceNaam ServiceNaam { get; }
        CommunicationState Status { get; }

        void Start();
        void Stop();

    }
}