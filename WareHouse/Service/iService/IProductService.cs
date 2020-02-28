using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using WareHouse.Model;

namespace WareHouse
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductService" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {

        [OperationContract]
        [WebInvoke(Method ="GET", UriTemplate = "findall", ResponseFormat = WebMessageFormat.Json)]
        List<Product> finddAll();

 

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "create",
            ResponseFormat =  WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool create(Product product);


        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "edit",
           ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool edit(Product product);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "delelte",
           ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool delete(Product product);





    }
}
