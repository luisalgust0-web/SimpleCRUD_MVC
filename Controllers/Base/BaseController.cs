using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;

namespace SimpleCRUD_MVC.Controllers.Base
{
    public class BaseController : Controller
    {
        public void Alert(AlertType alertType,string message)
        {
            switch (alertType)
            {
                case AlertType.sucess:
                    TempData["AlertType"] = "alert-success";
                    TempData["AlertMessage"] = message;
                    break;
                case AlertType.error:
                    TempData["AlertType"] = "alert-warning";
                    TempData["AlertMessage"] = message;
                    break;
            }
            
        }
    }

    public enum AlertType
    {
        sucess = 0,
        error = 1
    }
}
