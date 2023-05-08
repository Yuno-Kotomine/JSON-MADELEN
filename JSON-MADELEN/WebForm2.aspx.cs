using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;

namespace JSON_MADELEN
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelTempNow.Text = GetTemp().ToString();
            LabelWindsNow.Text = GetWinds().ToString();
            LabelWindsogNow.Text = GetWindOfGust().ToString();
            LabelLuftkNow.Text = GetLuftk().ToString();
            /// LabelAllNow.Text = GetAll().ToString();
        }

        public int GetTemp()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.met.no/weatherapi/nowcast/2.0/complete?lat=59.9333&lon=10.7166");
            double temp = 0;
            try
            {
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                httpWebRequest.UserAgent = "bolle";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    JObject jObj = JObject.Parse(result);                  
                    JToken data = jObj.SelectToken("properties.timeseries[0].data.instant.details");
                    temp = data.Value<double>("air_temperature");
                    return (int)temp;
                }
            }

            catch { Exception ex; }
            return 0;//returner ønsket verdi
        }

        ///-------------------------------------------------------------------------------------------------------------

        public int GetWinds()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.met.no/weatherapi/nowcast/2.0/complete?lat=59.9333&lon=10.7166");
            double winds = 0;
            try
            {
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                httpWebRequest.UserAgent = "bolle";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    JObject jObj = JObject.Parse(result);
                    JToken data = jObj.SelectToken("properties.timeseries[0].data.instant.details");
                    winds = data.Value<double>("wind_speed");
                    return (int)winds;
                }
            }
            catch { Exception ex; }
            return 0;//returner ønsket verdi

            ///-------------------------------------------------------------------------------------------------------------

        }
        public int GetWindOfGust()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.met.no/weatherapi/nowcast/2.0/complete?lat=59.9333&lon=10.7166");
            double windsog = 0;
            try
            {
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                httpWebRequest.UserAgent = "bolle";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    JObject jObj = JObject.Parse(result);
                    JToken data = jObj.SelectToken("properties.timeseries[0].data.instant.details");
                    windsog = data.Value<double>("wind_speed_Of_gust");
                    return (int)windsog;
                }
            }
            catch { Exception ex; }
            return 0;//returner ønsket verdi
        }

        public (int, int, double) GetAll()
        {
            int temp = GetTemp();
            int winds = GetWinds();
            double windsog = GetWindOfGust();

            return (temp, winds, windsog);
        }

        ///-------------------------------------------------------------------------------------------------------------
        public int GetLuftk()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.smartcitizen.me/v0/devices/14057");
           double luftk = 0;
            try
            {
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                httpWebRequest.UserAgent = "bolle";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    JObject jObj = JObject.Parse(result);
                    JToken data = jObj.SelectToken("data.sensors[8]");
                    luftk = data.Value<double>("value");
                    return (int)luftk;
                }
            }
            catch { Exception ex; }
            return 0;

        }
    }
}