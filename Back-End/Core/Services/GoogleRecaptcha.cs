using Dietbox.ECommerce.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dietbox.ECommerce.Core.Services
{
    public class GoogleRecaptcha
    {

        private readonly string _googleRecaptchaAPI = "https://www.google.com/recaptcha/api/siteverify";
        private readonly string _secret = "6LfGW7olAAAAAC8ZDmdQ0aTE2mZkF0_ArOzekfYz";

        public GoogleRecaptcha()
        {

        }

        public bool Validate(string recaptchaToken)
        {
            WebRequest request = WebRequest.Create(_googleRecaptchaAPI);
            request.ContentType = "application/json; charset=utf-8";
            request.Method = "POST";

            GoogleRecaptchaData data = new()
            {
                secret = _secret,
                response = recaptchaToken
            };

            string json = JsonConvert.SerializeObject(data);
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] buffer = encoding.GetBytes(json);
            request.ContentLength = buffer.Length;
            Stream newStream = request.GetRequestStream(); //open connection
            newStream.Write(buffer, 0, buffer.Length); // Send the data.
            newStream.Close();

            WebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());
            string text = streamReader.ReadToEnd();

            GoogleRecaptchaResponse? googleRecaptchaResponse = JsonConvert.DeserializeObject<GoogleRecaptchaResponse>(text);
            streamReader.Dispose();

            return googleRecaptchaResponse is null ? false : googleRecaptchaResponse.success;
        }


        #region Models JSON

        private class GoogleRecaptchaData
        {
            public string secret { get; set; }
            public string response { get; set; }
        }

        private class GoogleRecaptchaResponse
        {
            public bool success { get; set; }

            public DateTime challenge_ts { get; set; }

            public string hostname { get; set; }


            [JsonProperty("error-codes")]
            public List<object> errorcodes { get; set; }


        }

        #endregion

    }
}
