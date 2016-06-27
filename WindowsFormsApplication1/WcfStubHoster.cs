using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Linq;
using WindowsFormsApplication1.WebserviceHoster;

namespace WindowsFormsApplication1
{
    public class WcfStubHoster
    {
        private List<IWebservice> _servicehosts;

        public WcfStubHoster()
        {
            _servicehosts = new List<IWebservice>();

            //register all servicehosts
            _servicehosts.Add(new WebService<CodaWebServiceStub>(new Uri("http://localhost:1001/")));

        }

        public void Start(ServiceNaam serviceEnum)
        {
            var serviceHost = _servicehosts.First(x => x.ServiceNaam == serviceEnum);

            try
            {
                switch (serviceHost.Status)
                {
                    
                    case CommunicationState.Opening:
                    case CommunicationState.Opened:
                        //do nothing
                        break;
                    case CommunicationState.Closing:
                    case CommunicationState.Closed:
                    case CommunicationState.Created:
                        serviceHost.Start();
                        break;
                    case CommunicationState.Faulted:
                    default:
                        serviceHost.Start();
                        break;
                }

            }
            catch (Exception)
            {
                //todo: catch exception already opened (das positief, misshcien)?
                //todo: check if already in use and trykill?
                throw;
            }
        }

        public void Stop(ServiceNaam serviceEnum)
        {
            var serviceHost = _servicehosts.First(x => x.ServiceNaam == serviceEnum);
            serviceHost.Stop();
        }

        public void StopAll()
        {
            try
            {
                foreach (var s in _servicehosts)
                {
                    s.Stop();
                }
            }
            catch (Exception)
            {
                //todo
                throw new NotImplementedException();
            }
        }
    }
}