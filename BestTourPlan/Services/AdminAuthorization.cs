using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;
using System;
using System.Linq;

namespace BestTourPlan.Services
{
    public class AdminAuthorization : IControllerModelConvention
    {
        private readonly string area;
        private readonly string policy;

        public AdminAuthorization(string area, string policy)
        {
            this.area = area;
            this.policy = policy;
        }

        public void Apply(ControllerModel controller)
        {
            if (controller.Attributes.Any(x =>
                 x is AreaAttribute && (x as AreaAttribute)
                 .RouteValue.Equals(area, StringComparison.OrdinalIgnoreCase)) ||
                    controller.RouteValues.Any(v => 
                    v.Key.Equals("area", StringComparison.OrdinalIgnoreCase) &&
                    v.Value.Equals(area, StringComparison.OrdinalIgnoreCase)))
                    {
                        controller.Filters.Add(new AuthorizeFilter(policy));
             }
        }
    }
}
