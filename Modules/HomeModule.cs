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
                Client newClient = new Client(Request.Form["client-name"], Request.Form["client-stylist"]);
                newClient.Save();
                List<Stylist> allStylists = Stylist.GetAll();
                return View["index.cshtml", allStylists];
            };

            Get["/stylists/{id}"] = parameters => {
                Stylist currentStylist = Stylist.Find(parameters.id);
                return View["stylist.cshtml", currentStylist];
            };

            Get["/clients/{id}"] = parameters => {
                Client currentClient = Client.Find(parameters.id);
                int currentStylistId = currentClient.GetClientStylistId();
                Stylist currentStylist = Stylist.Find(currentStylistId);
                Dictionary<string, object> model = new Dictionary<string, object>(){{"client", currentClient}, {"stylist", currentStylist}};
                return View["client.cshtml", currentClient];
            };

        }
    }
}
