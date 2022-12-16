using AspnetFramework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspnetFramework.Customization
{
    public class PersonneBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            var nom = request.QueryString["nom"];
            var invite = request.QueryString.GetValues("invite") != null;
            return new Personne { Nom = nom, Invite = invite };
        }
    }
}