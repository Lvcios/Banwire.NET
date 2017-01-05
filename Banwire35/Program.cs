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
            //    address = "Calle 13 N° 34",
            //    cvv = "123",
            //    email = "lucio@banwire.com",
            //    exp_month = "12",
            //    exp_year = "20",
            //    method = "add",
            //    name = "Lucio Flores",
            //    number = "1472258336922581",
            //    phone = "5531521658",
            //    postal_code = "04600",
            //    user = "commerceUser"

            string endPoint = "https://cr.banwire.com/?action=card";
            var data = new NameValueCollection();
            data["user"] = "commerseUser";
            data["method"] = "add";

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
        }
    }

}
