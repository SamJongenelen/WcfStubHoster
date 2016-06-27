using System.ServiceModel;

namespace WindowsFormsApplication1
{
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface ICodaWebServiceContract
    {
        [OperationContract]
        string SendValue(string s);
    }
}