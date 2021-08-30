using CarShopAPI.API;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShopAPI.Controllers
{
    public abstract class ApiBaseController : ControllerBase
    {
        protected OkObjectResult ApiOk<T>(T Results) =>
            Ok(CustomResponse(Results));
        protected OkObjectResult ApiOk(string Message = "") =>
            Ok(CustomResponse(true, Message));
        protected NotFoundObjectResult ApiNotFound(string Message = "") =>
            NotFound(CustomResponse(false, Message));
        protected BadRequestObjectResult ApiBadRequest<T>(T Results, string Message = "") =>
            BadRequest(CustomResponse(Results, false, Message));

        #region métodos privados
        APIResponse<T> CustomResponse<T>(T Results, bool Secceed = true, string Message = "") =>
            new APIResponse<T>()
            {
                Results = Results,
                Succeed = Secceed,
                Message = Message
            };

        APIResponse<string> CustomResponse(bool Secceed = true, string Message = "") =>
            new APIResponse<string>()
            {
                Succeed = Secceed,
                Message = Message
            };
        #endregion
    }
}
