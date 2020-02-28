using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Script.Serialization;

namespace WareHouse_Client.Models
{
    public class ProductServiceClient
    {
        private string BASE_URL = "http://localhost:50521/ProductService.svc";
        public List<Product> findAll()
        {
            try
            {
                var webClient = new WebClient();
                var json = webClient.DownloadString(BASE_URL + "findall");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<Product>>(json);
            } catch
            {
                return null;
            }
        }

        public bool  create(Product product)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Product));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, product);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                webClient.UploadString(BASE_URL + " create ", " POST ", data);
                return true;
               
            }
            catch
            {
                return false;
            }
        }


        public bool edit(Product product)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Product));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, product);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                webClient.UploadString(BASE_URL + " edit ", " PUT ", data);
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool delete(Product product)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Product));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, product);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                webClient.UploadString(BASE_URL + " delete ", " DELETE ", data);
                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}