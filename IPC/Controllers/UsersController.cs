using System;
using System.Web.Mvc;
using System.Web.Security;
using IPC.DAL;
using IPC.Models;
using IPC.Utilities;

namespace IPC.Controllers
{
    public class UsersController : Controller
    {
        private UserRepository _UserRep = new UserRepository();
        private RolesRepository _RoleRep = new RolesRepository();
        // GET: Users
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Roles = _RoleRep.GetRoles();
            return View(_UserRep.GetUsers());
        }

        [HttpGet]
        [Authorize]
        public ActionResult Details(Guid id)
        {
            var user = _UserRep.GetUserByID(id);
            ViewBag.RoleID = new SelectList(_RoleRep.GetRoles(), "ID", "RoleName", user.RoleID);
            return View(user);
        }
        
        [HttpGet]
        [Authorize]
        public ActionResult Edit(Guid id)
        {
            var user = _UserRep.GetUserByID(id);
            ViewBag.RoleID = new SelectList(_RoleRep.GetRoles(),"ID", "RoleName", user.RoleID);
            return View(user);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                bool success = _UserRep.EditUser(user.ID, user);
                if(success)
                    return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(_RoleRep.GetRoles(), "ID", "RoleName", user.RoleID);
            return View(user);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(Guid id)
        {
            _UserRep.DeleteUser(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            //if account is already login, redirect to home page 
            if (Request.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM loginVM)
        {
            var user = _UserRep.FindUser(loginVM);
            if (user != null)
            {
                //valid login password, reset access faild counter and create FormAuthentication Cookie
                Response.Cookies.Add(SecurityUtilities.CreateAuthenticationCookie(user.FullName, user.ID.ToString()));

                //redirect to home page
                return RedirectToAction("Index", "Home");
            }
            else
                ModelState.AddModelError("LoginError", "Invalid credentials, please try again.");
            // If we got this far, something failed, redisplay form
            return View(user);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            //if account is already login, redirect to home page 
            if (Request.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            ViewBag.RoleID = new SelectList(_RoleRep.GetRoles(), "ID", "RoleName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {

            var ResponseUser = _UserRep.CreateUser(user);
            if (ResponseUser != null)
            {
                //Registeration succeeded, Sign in this account 
                Response.Cookies.Add(SecurityUtilities.CreateAuthenticationCookie(ResponseUser.FullName, ResponseUser.ID.ToString()));

                // Redirect to Dashboard
                return RedirectToAction("Index", "Home");
            }
            else
                ModelState.AddModelError("EmailExists", "Email exists, try another one.");
            ViewBag.RoleID = new SelectList(_RoleRep.GetRoles(), "ID", "RoleName",user.RoleID);
            return View(user);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
