using Nancy;
using System;
using System.Collections.Generic;
using HairSalonCRM.Objects;

namespace HairSalonCRM
{
    public class HomeModule: NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => {
                List<Stylist> allStylists = Stylist.GetAll();
                return View["index.cshtml", allStylists];
            };

            Post["/stylists/new"] = _ => {
                Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
                newStylist.Save();
                List<Stylist> allStylists = Stylist.GetAll();
                return View["index.cshtml", allStylists];
            };

            Post["/clients/new"] = _ => {
                Client newClient = new Client(Request.Form["client-name"]);
                newClient.Save();
                List<Stylist> allStylists = Stylist.GetAll();
                return View["index.cshtml", allStylists];
            };

        }
    }
}
