using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Banwire
{
    class Program
    {
        static void Main(string[] args)
        {
            Card _card = new Card { address = "Calle 13 N° 34", cvv = "162", email = "lucio@banwire.com",
                exp_month = "12", exp_year = "19", method = "add", name = "Lucio Flores", number = "5134422031476272",
                phone = "5531521658", postal_code = "04600", user = "pruebasbw" };

            string endPoint = "https://cr.banwire.com/";

            string data = _card.ToHtmlQueryString();
            //method=add&user=commerceUser&number=1472258336922581&exp_month=12&exp_year=20&cvv=123&name=Lucio Flores&address=Calle 13 N&#176; 34&postal_code=04600&email=lucio@banwire.com&phone=5531521658
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(endPoint);
                Task<HttpResponseMessage> response = client.PostAsync("?action=card", new StringContent(data.ToString(), Encoding.UTF8, "application/x-www-form-urlencoded"));
                if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseString = response.Result.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(responseString);
                }
                Console.ReadLine();
            }


            //on demand payment
            OnDemandPayment payment = new OnDemandPayment { method = "payment", amount = 10,
                reference = "payment-demo-01", token = "crd.4PYjBFbd1qg9CD8huWVFQDdtsdassd", user = "pruebasbw" };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(endPoint);
                Task<HttpResponseMessage> response = client.PostAsync("?action=card", new StringContent(payment.ToHtmlQueryString(), Encoding.UTF8, "application/x-www-form-urlencoded"));
                if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseString = response.Result.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(responseString);
                }
                Console.ReadLine();
            }
        }
    }
}
