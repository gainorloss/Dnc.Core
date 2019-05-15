using Dnc.AspNetCore.Models;
using Dnc.Seedwork;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Dynamic;

namespace Dnc.AspNetCore.Controllers
{
    public class BaseController : ControllerBase
    {
        #region Protected members.
        protected readonly IUrlHelper _urlHelper;
        #endregion

        #region Ctor.
        protected BaseController(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }
        #endregion

        #region Methods for returning value.
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Ajax(HttpStatusCodes statusCode,
            object data = null,
            string msg = null)
        {
            var ajaxResult = new AjaxResult()
            {
                Status = statusCode == HttpStatusCodes.Ok,
                Code = statusCode,
                Msg = msg,
                Data = data
            };

            switch (statusCode)
            {
                case HttpStatusCodes.Ok:
                    return Ok(ajaxResult);
                case HttpStatusCodes.Unauthorized:
                    return Unauthorized(ajaxResult);
                case HttpStatusCodes.NotFound:
                    return NotFound(ajaxResult);
                case HttpStatusCodes.BadRequest:
                    return BadRequest(ajaxResult);
                default:
                    return Ok(ajaxResult);
            }
        }
        #endregion

        protected ExpandoObject ToHATEOAS<TViewModel>(TViewModel source, string name, string fields = null, string accept = "application/json")
            where TViewModel : Entity
        {
            var dynamicObject = source.ToDynamic(fields);
            if (accept.Equals("application/vnd-hateoas+json"))
                ((IDictionary<string, object>)dynamicObject).Add("links", CreateLinks(name, source.Id, fields));
            return dynamicObject;
        }

        protected IEnumerable<ExpandoObject> ToHATEOAS<TViewModel>(IEnumerable<TViewModel> sources, string name, string fields = null, string accept = "application/json")
            where TViewModel : Entity
        {
            if (accept.Equals("application/vnd-hateoas+json"))
            {
                var dynamicObjects = new List<ExpandoObject>();
                foreach (var source in sources)
                    dynamicObjects.Add(ToHATEOAS(source, name, fields));
                return dynamicObjects;
            }
            return sources.ToDynamic(fields);
        }

        private IEnumerable<LinkViewModel> CreateLinks(string name, long id, string fields = null)
        {
            var links = new List<LinkViewModel>();
            if (string.IsNullOrWhiteSpace(fields))
                links.Add(new LinkViewModel(_urlHelper.Link("Get", new { id }), "self", "GET"));
            else
                links.Add(new LinkViewModel(_urlHelper.Link("Get", new { id, fields }), "self", "GET"));

            links.Add(new LinkViewModel(_urlHelper.Link("Delete", new { id }), $"delete_{name.ToLowerInvariant()}", "DELETE"));

            links.Add(new LinkViewModel(_urlHelper.Link("Create", new { id }), $"create_{name.ToLowerInvariant()}", "POST"));

            return links;
        }
    }
}
