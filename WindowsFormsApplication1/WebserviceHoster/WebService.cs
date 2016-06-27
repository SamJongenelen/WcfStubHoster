using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.WebserviceHoster
{
    public class WebService<T> : IWebservice where T : class
    {
        private ServiceHost _serviceHost;
        private Uri _webserviceUrl;
        
        public WebService(Uri serviceUri)
        {
            _webserviceUrl = serviceUri;
                                  
            _serviceHost = new ServiceHost(typeof(T), _webserviceUrl);

            var smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            _serviceHost.Description.Behaviors.Add(smb);
            // Add MEX endpoint
            _serviceHost.AddServiceEndpoint(
              ServiceMetadataBehavior.MexContractName,
              MetadataExchangeBindings.CreateMexHttpBinding(),
              "mex"
            );

        }

        public void Start()
        {
            try
            {
                _serviceHost.Open();
            }
            catch (Exception e)
            {
                throw new Exception("iets mis met connection", e);
            }

        }

        public void Stop()
        {
            _serviceHost.Close();
        }



        private void getServiceNaam()
        {

        }

        public CommunicationState Status
        {
            get
            {
                return _serviceHost.State;
            }
        }

        public ServiceNaam ServiceNaam
        {
            get
            {
                if (typeof(T) == typeof(CodaWebServiceStub))
                {
                    return ServiceNaam.Coda;
                }
                return ServiceNaam.Anders;
            }
        }
    }
}
