using ClassLibrary1;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartFridge
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        class Program
        {
            static void Main(string[] args)
            {
                Program p = new Program();

                //få denne til å gå en gang per time - triggere, hva har vi?
                //thread
                //TimeSpan ts = new TimeSpan(0, 0, 2);
                for (int i = 0; i < 10; i++)
                {
                    int counter = 0;
                    do
                    {
                        counter++;
                        p.GetStuff();
                        Thread.Sleep(100);
                    } while (counter < 100);
                }
                return;
            }

            public int GetStuff()
            {
                //http://jsonviewer.stack.hu/
                //create the httpwebrequest
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://andre.bergersen.dk/PowerPriceAPI/PowerPrice?zone=NO3&date=2022-05-13");



                //the usual stuff. run the request, parse your json
                try
                {
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "GET";
                    httpWebRequest.UserAgent = "Prem";
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();



                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        JObject jObj = JObject.Parse(result);
                        JToken data = jObj.SelectToken("{0}");
                        int noK_per_kWh = data.Value<int>("noK_per_kWh");//key name - getting key.value
                        int valid_from = data.Value<int>("valid_from");
                        int valid_to = data.Value<int>("valid_to");


                        DBLayer dbl = new DBLayer();
                        dbl.InsertValuesToDB(noK_per_kWh, valid_from, valid_to, DateTime.Now, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour);
                        //inn i db

                    }
                    return 0;
                }
                catch (Exception ex)
                {

                }
                return 0;
            }
        }
    }

}
