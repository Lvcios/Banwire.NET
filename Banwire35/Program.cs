using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace Banwire35
{
    class Program
    {
        static void Main(string[] args)
        {
            string endPoint = "https://cr.banwire.com/?action=card";
            var data = new NameValueCollection();
            data["address"] = "Street 12 N°4";
            data["cvv"] = "162";
            data["email"] = "lucio@banwire.com";
            data["exp_month"] = "12";
            data["exp_year"] = "19";
            data["method"] = "add";
            data["name"] = "Lucio Flores";
            data["number"] = "5134422031476272";
            data["phone"] = "5531521658";
            data["postal_code"] = "04852";
            data["user"] = "pruebasbw";

            using (var wb = new WebClient())
            {
                var banwireresponse = wb.UploadValues(endPoint, "POST", data);
                Stream streamresponse = new MemoryStream(banwireresponse);
                string callbackstring;
                using (StreamReader reader = new StreamReader(streamresponse))
                {
                    callbackstring = reader.ReadLine();
                }

                Console.WriteLine(callbackstring);
                Console.ReadLine();
            }

            data = new NameValueCollection();
            data["method"] = "payment";
            data["user"] = "pruebasbw";
            data["reference"] = "commerce-reference-01";
            data["token"] = "crd.4PYjBFbd1qg9CD8huWVFQDdtaary"; //token example
            data["amount"] = "100";
            using (var wb = new WebClient())
            {
                var banwireresponse = wb.UploadValues(endPoint, "POST", data);
                Stream streamresponse = new MemoryStream(banwireresponse);
                string callbackstring;
                using (StreamReader reader = new StreamReader(streamresponse))
                {
                    callbackstring = reader.ReadLine();
                }

                Console.WriteLine(callbackstring);
                Console.ReadLine();
            }
            //on demand payment

        }
    }

}
