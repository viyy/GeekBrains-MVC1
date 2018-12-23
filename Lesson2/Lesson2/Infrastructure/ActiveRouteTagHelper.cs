﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebStore.Infrastructure
{
    [HtmlTargetElement(Attributes = "is-active-route")]
    public class ActiveRouteTagHelper : TagHelper
    {
        private IDictionary<string, string> _routeValues;

        [HtmlAttributeName("asp-action")] public string Action { get; set; }

        [HtmlAttributeName("asp-controller")] public string Controller { get; set; }

        [HtmlAttributeName("asp-all-route-data", DictionaryAttributePrefix ="asp-route-")]

        public IDictionary<string, string> RouteValues
        {
            get => _routeValues ?? (_routeValues = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase));
            set => _routeValues = value;
        }

        [HtmlAttributeNotBound] [ViewContext] public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput
            output)
        {
            base.Process(context, output);
            bool ignoreAction =
                context.AllAttributes.TryGetAttribute("ignore-action", out _);
            if (ShouldBeActive(ignoreAction))
            {
                MakeActive(output);
            }
            output.Attributes.RemoveAll("is-active-route");
        }


        private bool ShouldBeActive(bool ignoreAction)
        {
            var currentController =
                ViewContext.RouteData.Values["Controller"].ToString();
            var currentAction =
                ViewContext.RouteData.Values["Action"].ToString();
            if (!string.IsNullOrWhiteSpace(Controller) &&
                !string.Equals(Controller, currentController,
                    StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }
            if (!ignoreAction && !string.IsNullOrWhiteSpace(Action) &&
                !string.Equals(Action, currentAction,
                    StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }
            foreach (var routeValue in RouteValues)
            {
                if (!ViewContext.RouteData.Values.ContainsKey(routeValue.Key) ||
                    ViewContext.RouteData.Values[routeValue.Key].ToString() !=
                    routeValue.Value)
                {
                    return false;
                }
            }
            return true;
        }


        private static void MakeActive(TagHelperOutput output)
        {
            var classAttr = output.Attributes.FirstOrDefault(a => a.Name == "class");
            if (classAttr == null)
            {
                classAttr = new TagHelperAttribute("class", "active");
                output.Attributes.Add(classAttr);
            }
            else if (classAttr.Value == null || classAttr.Value.ToString().IndexOf("active", StringComparison.Ordinal) < 0)
            {
                output.Attributes.SetAttribute("class", classAttr.Value == null
                    ? "active"
                    : classAttr.Value + " active");
            }
        }
    }
}