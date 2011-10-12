using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace GenericRest.Extensions
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Safely routes a link to a specific area.
        /// </summary>
        public static IHtmlString ActionLink<TController>(this HtmlHelper htmlHelper, Expression<Action<TController>> action, string linkText, object routeValues) where TController : Controller
        {
            return ActionLink(htmlHelper, action, linkText, routeValues, null);
        }

        /// <summary>
        /// Safely routes a link to a specific area.
        /// </summary>
        public static IHtmlString ActionLink<TController>(this HtmlHelper htmlHelper, Expression<Action<TController>> action, string linkText, object routeValues, object htmlAttributes) where TController : Controller
        {
            var routingValues = Microsoft.Web.Mvc.Internal.ExpressionHelper.GetRouteValuesFromExpression(action);
            foreach (var dictionaryValue in new RouteValueDictionary(routeValues))
                routingValues.Add(dictionaryValue.Key, dictionaryValue.Value);
            return htmlHelper.RouteLink(linkText, routingValues, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }
    }
}