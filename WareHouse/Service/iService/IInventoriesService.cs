using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using WareHouse.Model;

namespace WareHouse
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IInventoriesService" in both code and config file together.
    [ServiceContract]
    public interface IInventoriesService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "findall", ResponseFormat = WebMessageFormat.Json)]
        List<Inventory> finddAll();



        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "create",
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool create(Inventory inventory);


        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "edit",
           ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool edit(Inventory inventory);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "delelte",
           ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool delete(Inventory inventory);



        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "StockIn",
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool StockIn(Inventory inventory);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "StockOut",
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool StockOut(Inventory inventory);



    }
}
