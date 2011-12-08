using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace YoutubeDesktop
{
    public class YoutubeWeb
    {
        public static Dictionary<string, object> pars = new Dictionary<string, object>();

        public static Boolean AskForTokenFromKey(String tmpKey)
        {
            try
            {
                String postData =
                    @"code=" + tmpKey + "&" +
                    @"client_id=" + Globals.ClientId + "&" +
                    @"client_secret=" + Globals.ClientSecret + "&" +
                    @"redirect_uri=urn:ietf:wg:oauth:2.0:oob&" +
                    @"grant_type=authorization_code";

                Byte[] postBytes = Encoding.UTF8.GetBytes(postData);
                String address = "https://accounts.google.com/o/oauth2/token";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(address));
                request.Method = "POST";
                request.KeepAlive = true;
                request.ProtocolVersion = HttpVersion.Version10;

                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = postBytes.Length;
                Stream requestStream = (Stream)request.GetRequestStream();
                requestStream.Write(postBytes, 0, postBytes.Length);
                requestStream.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                String text = (new StreamReader(response.GetResponseStream())).ReadToEnd();

                pars = (Dictionary<string, object>)JavascriptUtils.DeserializeJson(text);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error asking for token ... ", ex);
            }            
        }

        public enum WebMethod
        {
            POST,
            GET,
            DELETE
        }

        public class Data
        {
            public String data = null;
            public bool usesData = false;

            public Data(String data, bool usesData){
                this.data = data;
                this.usesData = usesData;
            }

            public static Data Empty
            {
                get
                {
                    return new Data(null, false);
                }
            }
        }

        public static string CallApiMethod(
                WebMethod method,
                Uri uri,
                Dictionary<string, string> headers, 
                bool needsKey, 
                Data data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            request.KeepAlive = true;
            request.ProtocolVersion = HttpVersion.Version11;

            //request.Headers.Add("Authorization", (string)pars["access_token"]);
            request.Headers.Add("Authorization", "Bearer " + (string)pars["access_token"]);
            if (needsKey)
            {
                request.Headers.Add("X-GData-Key", "key=" + Globals.DevKey);
            }

            if (data != null && data.usesData)
            {
                Byte[] brutes = Encoding.UTF8.GetBytes(data.data);
                
                request.ContentLength = brutes.Length;
                Stream requestStream = (Stream)request.GetRequestStream();
                requestStream.Write(brutes, 0, brutes.Length);
                requestStream.Close();                
            }
                        
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                String text = (new StreamReader(response.GetResponseStream())).ReadToEnd();

                return text;
            }
            catch (Exception e)
            {
                throw new Exception("Invalid request.", e);
            }                       
        }

    }
}
