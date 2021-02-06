using IPC_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace IPC_API.Controllers
{
    public class UsersController : ApiController
    {
        private IPCDatabaseEntities db = new IPCDatabaseEntities();

        // GET: api/Users
        public IHttpActionResult GetUsers()
        {
            List<UsersModel> ModelList = db.Users.Select(u => new UsersModel()
            {
                ID = u.ID,
                FullName = u.FullName,
                Age = u.Age,
                Email = u.Email,
                PW = u.PW,
                Img = u.Img,
                RoleID = u.RoleID
                
            }).ToList();

            return Ok(ModelList);
        }

        // GET: api/Users/id
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(Guid id)
        {
            User User = db.Users.Find(id);
            if (User == null)
                return NotFound();

            UsersModel Model = new UsersModel()
            {
                ID = User.ID,
                FullName = User.FullName,
                Age = User.Age,
                Email = User.Email,
                PW = User.PW,
                Img = User.Img,
                RoleID =User.RoleID
            };
            return Ok(Model);
        }

        // PUT: api/Users/id
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(Guid id, UsersModel User)
        {
            User UserObj = db.Users.FirstOrDefault(u => u.ID == id);

            if (UserObj == null)
                return NotFound();

            UserObj.ID = User.ID;
            UserObj.FullName = User.FullName;
            UserObj.Age = User.Age;
            UserObj.Email = User.Email.ToLower();
            UserObj.PW = User.PW;
            UserObj.Img = User.Img;
            UserObj.RoleID = User.RoleID;

            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(UsersModel User)
        {
            try
            {
                var em = db.Users.FirstOrDefault(u => u.Email==User.Email.ToLower());
                if (em == null)
                {
                    User.ID = Guid.NewGuid();
                    db.sp_InsertUser(User.ID, User.FullName, User.Age, User.Email.ToLower(), User.PW, User.Img, User.RoleID);
                    db.SaveChanges();
                }
                else
                {
                    return BadRequest();
                }
                
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(User);
        }

        // DELETE: api/Users/id
        public IHttpActionResult DeleteUser(Guid id)
        {
            User User = db.Users.Find(id);
            if (User == null)
            {
                return NotFound();
            }

            db.Users.Remove(User);
            db.SaveChanges();

            return Ok();
        }



        [ResponseType(typeof(User))]
        public IHttpActionResult FindUser(UsersModel userM)
        {
         
            var user = db.Users.FirstOrDefault(u => u.Email == userM.Email.ToLower());
            if (user != null)
            {
                if (string.Compare(userM.PW, user.PW) == 0)
                {
                    userM.ID = user.ID;
                    userM.FullName = user.FullName;
                    userM.Age = user.Age;
                    userM.Img = user.Img;
                    userM.RoleID = user.RoleID;
                    return Ok(userM);
                }
            }
            return NotFound();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}