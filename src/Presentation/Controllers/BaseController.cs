using Microsoft.AspNetCore.Mvc;

namespace FreelaFlowApi.Presentation.Controllers;
public class BaseController<Service> : ControllerBase
{
    protected readonly Service _mainService;

    public BaseController(Service service) =>
        this._mainService = service;

}