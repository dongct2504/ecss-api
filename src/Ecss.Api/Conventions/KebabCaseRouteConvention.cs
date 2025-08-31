using Ecss.Common.Utils;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Ecss.Api.Conventions;

public class KebabCaseRouteConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        controller.ControllerName = StringHelpers.ToKebabCase(controller.ControllerName);
        foreach (var action in controller.Actions)
        {
            action.ActionName = StringHelpers.ToKebabCase(action.ActionName);
        }
    }
}
