namespace ForumSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    [Authorize]
    public abstract class AdminController : Controller
    {
    }
}