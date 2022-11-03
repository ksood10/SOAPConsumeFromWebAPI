using Microsoft.AspNetCore.Mvc;
using ServiceReference1;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DefaultController : ControllerBase
    {
        private const int CONSUMERID = 86338, NEXT = 0;
        private const string AUTH = "acmeco_3";

        [HttpGet(Name ="GetSOAPOrganizations")]
        public Organization[] Get(int consumer = CONSUMERID, string auth = AUTH,int next = NEXT)
        {
            var orgBody = new GetOrganizationRequestBody
            {
                iConsumerId = consumer,
                sAuthentication = auth,
                iNextID = next
            };
            var serviceSoapClient = new ServiceSoapClient(ServiceSoapClient.EndpointConfiguration.ServiceSoap);
            var response = serviceSoapClient.GetOrganization(orgBody.iConsumerId, orgBody.sAuthentication, ref orgBody.iNextID, out int errorCode,out string errorMessage);
            return response;
        }
     
    }
}