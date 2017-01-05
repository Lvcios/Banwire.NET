using BanwireWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BanwireWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Card card = new Card
            {
                address = "Calle 13 N° 34",
                cvv = "123",
                email = "lucio@banwire.com",
                exp_month = "12",
                exp_year = "20",
                method = "add",
                name = "Lucio Flores",
                number = "1472258336922581",
                phone = "5531521658",
                postal_code = "04600",
                user = "commerceUser"
            };

            return View(card);
        }

        [HttpPost]
        public ActionResult Index(Card model)
        {
            string endPoint = "https://cr.banwire.com/";
            string responseString = "";
            string data = model.ToHtmlQueryString();
            //method=add&user=commerceUser&number=1472258336922581&exp_month=12&exp_year=20&cvv=123&name=Lucio Flores&address=Calle 13 N&#176; 34&postal_code=04600&email=lucio@banwire.com&phone=5531521658
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(endPoint);
                Task<HttpResponseMessage> response = client.PostAsync("?action=card", new StringContent(data.ToString(), Encoding.UTF8, "application/x-www-form-urlencoded"));
                if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    responseString = response.Result.Content.ReadAsStringAsync().Result;
                }
            }

            ViewBag.ResponseString = responseString;
            return View();
        }

        public ActionResult OnDemandPayment()
        {
            OnDemandPayment payment = new OnDemandPayment
            {
                method = "payment",
                amount = 10,
                reference = "payment-demo-01",
                token = "crd.4PYjBFbd1qg9CD8huWVFQDdtsdassd",
                user = "pruebasbw"
            };
            return View(payment);
        }

        [HttpPost]
        public ActionResult OnDemandPayment(OnDemandPayment model)
        {

            string endPoint = "https://cr.banwire.com/";
            string responseString = "";
            string data = model.ToHtmlQueryString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(endPoint);
                Task<HttpResponseMessage> response = client.PostAsync("?action=card", new StringContent(data.ToString(), Encoding.UTF8, "application/x-www-form-urlencoded"));
                if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    responseString = response.Result.Content.ReadAsStringAsync().Result;
                }
            }

            ViewBag.ResponseString = responseString;

            return View();
        }

        
    }
}