using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;

namespace DPHAlgorithmProject.code
{
    public static class Authorization
    {
        public static void GetToken()
        {
           
        
            //GetTokenResponse response = new GetTokenResponse();
            Newtonsoft.Json.Linq.JObject jsonObject = new Newtonsoft.Json.Linq.JObject();
            jsonObject.Add("Login", "kowalski");
            jsonObject.Add("DateTime", DateTime.Now.ToString());

            string token = null;
            try
            {
                //X509Certificate2 cert = FindCertificate();

                ////if (cert != null && cert.HasPrivateKey)
                ////{
                ////    RSACryptoServiceProvider privKey = (RSACryptoServiceProvider)cert.PrivateKey;

                ////    var enhCsp = new RSACryptoServiceProvider().CspKeyContainerInfo;
                ////    var cspParams = new CspParameters(enhCsp.ProviderType, enhCsp.ProviderName, privKey.CspKeyContainerInfo.KeyContainerName);

                ////    var newKey = new RSACryptoServiceProvider(cspParams);

                ////    token = Jose.JWT.Encode(jsonObject.ToString(), newKey, Jose.JweAlgorithm.RSA_OAEP_256, Jose.JweEncryption.A256GCM, Jose.JweCompression.DEF);
                ////}
                ////else
                //RSACryptoServiceProvider privKey = (RSACryptoServiceProvider)cert.PrivateKey;

                //var enhCsp = new RSACryptoServiceProvider().CspKeyContainerInfo;
                //var cspParams = new CspParameters(enhCsp.ProviderType, enhCsp.ProviderName, privKey.CspKeyContainerInfo.KeyContainerName);

                //var newKey = new RSACryptoServiceProvider(cspParams);

                //token = Jose.JWT.Encode(jsonObject.ToString(), newKey, Jose.JweAlgorithm.RSA_OAEP_256, Jose.JweEncryption.A256GCM, Jose.JweCompression.DEF);
                ////{
                ///
                var payload = new Dictionary<string, object>()
                    {
                    { "sub", "mr.x@contoso.com" },
                    { "exp", 1300819380 }
                    };

                    var secretKey = Encoding.UTF8.GetBytes("myawesomekey");

                    token = Jose.JWT.Encode(payload, secretKey, Jose.JwsAlgorithm.HS256);
                    //return token;
                //token = Jose.JWT.Encode(jsonObject.ToString(), null, Jose.JwsAlgorithm.ES256);
                var xa1 = "asdsad";
                //}

            }
            catch (Exception ex)
            {
                //messageData.LogMessage(ex);
                //throw new FaultException(ex.Message);
            }

            //if (_generateTokens == null)
            //    _generateTokens = new List<string>();
            //_generateTokens.Add(token);

            //response.Token = token;

            //messageData.LogMessage(InSystemLogMessageData.LogEndMessage + ObjectDumper.Dump(response));
            //return response;
        }




        public static X509Certificate2 GetX509Certificate(StoreName storeName, StoreLocation storeLocation, string thumbprint)
        {
            X509Certificate2 cert = null;
            X509Store store = new X509Store(storeName, storeLocation);

            try
            {
                store.Open(OpenFlags.ReadOnly);

                foreach (X509Certificate2 certificate in store.Certificates)
                {
                    if (certificate.Thumbprint.ToLower() == thumbprint.ToLower())
                    {
                        cert = certificate;
                        break;
                    }
                }
            }

            //    if (cert == null)
            //        messageData.LogMessage(string.Format("GetX509Certificate - not found certificate for configuration: storeLocation={0}, storeName={1}, thumbprint={2}",
            //            storeLocation, storeName, thumbprint));
            //}
            catch (Exception ex)
            {
                //messageData.LogMessage(ex);
            }
            finally
            {
                store.Close();
            }

            return cert;
        }

        public static X509Certificate2 FindCertificate()
        {
            X509Certificate2 cert = null;
            try
            {
                string certStoreName = ConfigurationManager.AppSettings["FerrytInSystemCertStoreName"];
                string certStoreLocation = ConfigurationManager.AppSettings["FerrytInSystemCertStoreLocation"];
                string certThumbprint = ConfigurationManager.AppSettings["FerrytInSystemCertThumbprint"];
                //string certStoreName = "certStoreName";
                //string certStoreLocation = "certStoreLocation";
                //string certThumbprint = "certThumbPrint";


                if (!string.IsNullOrEmpty(certStoreName) && !string.IsNullOrEmpty(certStoreLocation) && !string.IsNullOrEmpty(certThumbprint))
                {
                    StoreName storeName = (StoreName)Enum.Parse(typeof(StoreName), certStoreName);
                    StoreLocation storeLocation = (StoreLocation)Enum.Parse(typeof(StoreLocation), certStoreLocation);

                    //StoreName storeName = "aa";
                    //StoreLocation storeLocation = certStoreLocation;

                    cert = GetX509Certificate(storeName, storeLocation, certThumbprint);
                }
                else
                {
                    //messageData.LogMessage("FindCertificate - not found certificate configuration");
                }
            }
            catch (Exception ex)
            {
                //messageData.LogMessage(ex);
            }
            return cert;
        }
    }
}