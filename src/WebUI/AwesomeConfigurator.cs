﻿using System.Web.Mvc;
using Omu.Awesome.Mvc;
using Resources;

namespace WebUI
{
    public static class AwesomeConfigurator
    {
        public static void Configure()
        {
            ModelMetadataProviders.Current = new AwesomeModelMetadataProvider();

            Settings.PopupForm.ClientSideValidation = false;
            Settings.Lookup.Interactive = true;
            Settings.GetText = GetTranslate;
        }

        private static string GetTranslate(string type, string key)
        {
            if (type == "Confirm" && key == "Title") return "";
            if (type == "PopupForm" && key == "Title") return "";
            if (type == "Lookup" && key == "Title") return "";
            switch (key)
            {
                case "Cancel": return Mui.Cancel;
                case "Yes": return Mui.Yes;
                case "No": return Mui.No;
                case "More": return Mui.more;
            }
            return null;
        }
    }
}