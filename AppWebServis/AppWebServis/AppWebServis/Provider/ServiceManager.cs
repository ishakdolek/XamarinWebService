using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AppWebServis.Model;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace AppWebServis.Provider
{
    public class ServiceManager
    {
        private string _url = "http://jsonplaceholder.typicode.com/comments/1";
        //private List<RootObject> _degeRootObjects = new List<RootObject>();

       private async Task<HttpClient> GetClient()
       {
            HttpClient client;
           try
           {
                client = new HttpClient();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            }
           catch (Exception)
           {
               throw;
           }
          
            return client;
        }

        public async Task<IEnumerable<RootObject>> GetAll()
        {
            var client = await GetClient();
          

            Task<string> contentsTask = client.GetStringAsync("http://xamarin.com"); // async method!

            // await! control returns to the caller and the task continues to run on another thread
            string contents = await contentsTask;

            var result = await client.GetStringAsync(_url);
            if (result!=null)
            {
                string msg = "veri çekilmedi";
            }
            var deger = JsonConvert.DeserializeObject<IEnumerable<RootObject>>(result);
            return deger;
        }

   //public async Task<IEnumerable<RootObject>> GetAll()
        //{
        //    var client = await GetClient();
        //    var result = await client.GetStringAsync(_url);
        //    var deger = JsonConvert.DeserializeObject<IEnumerable<RootObject>>(result);
        //    return deger;
        //}

    }
}
