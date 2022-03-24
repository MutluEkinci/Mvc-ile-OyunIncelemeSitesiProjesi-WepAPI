using Newtonsoft.Json;
using OyunİncelemeSitesiProjesi.DAL;
using OyunİncelemeSitesiProjesi.Migrations;
using OyunİncelemeSitesiProjesi.Models;
using OyunİncelemeSitesiProjesi.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace OyunİncelemeSitesiProjesi.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminİletisimController : Controller
    {
        // GET: Adminİletisim

        public ActionResult Index()
        {
            //var apiUrl = "http://localhost:65191/api/%C4%B0letisim/";

            //Uri url = new Uri(apiUrl);
            //WebClient client = new WebClient();
            //client.Encoding = System.Text.Encoding.UTF8;

            //string json = client.DownloadString(url);

            //JavaScriptSerializer ser = new JavaScriptSerializer();
            //List<İletisim> iletisim = ser.Deserialize<List<İletisim>>(json);

            //return View(iletisim);

            HttpClient istemci = new HttpClient();
            string strResult = istemci.GetStringAsync("http://localhost:65191/api/%C4%B0letisim/").Result;

            List<İletisim> strJson = JsonConvert.DeserializeObject<List<İletisim>>(strResult);

            return View(strJson);
        }

        public ActionResult Delete(int id)
        {
            //İletisim iletisim = db.İletisimler.Find(id);
            //db.İletisimler.Remove(iletisim);
            //db.SaveChanges();
            //return RedirectToAction("Index");


            HttpClient istemci = new HttpClient();

            istemci.DeleteAsync("http://localhost:65191/api/%C4%B0letisim/" + id + "");

            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //var apiUrl = "http://localhost:65191/api/%C4%B0letisim/" + id + "";

            //Uri url = new Uri(apiUrl);
            //WebClient client = new WebClient();
            //client.Encoding = System.Text.Encoding.UTF8;

            //string json = client.DownloadString(url);

            //JavaScriptSerializer ser = new JavaScriptSerializer();
            ////İletisim iletisim = ser.Deserialize<İletisim>(json);


            HttpClient istemci = new HttpClient();
            string strResult = istemci.GetStringAsync("http://localhost:65191/api/%C4%B0letisim/" + id + "").Result;

            İletisim iletisim = JsonConvert.DeserializeObject<İletisim>(strResult);

            if (iletisim == null)
            {
                return HttpNotFound();
            }
            return View(iletisim);
        }
    }
}