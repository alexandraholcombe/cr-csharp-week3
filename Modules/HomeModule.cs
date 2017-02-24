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

        }
    }
}
