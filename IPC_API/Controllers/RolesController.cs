using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using IPC_API.Models;

namespace IPC_API.Controllers
{
    public class RolesController : ApiController
    {
        private IPCDatabaseEntities db = new IPCDatabaseEntities();

        // GET: api/Roles
        public IHttpActionResult GetRoles()
        {
            List<RolesModel> ModelList = db.Roles.Select(r => new RolesModel()
            {
                ID = r.ID,
                RoleName = r.RoleName
            }).ToList();

            return Ok(ModelList);
        }

        // GET: api/Roles/id
        [ResponseType(typeof(Role))]
        public IHttpActionResult GetRole(Guid id)
        {
            Role role = db.Roles.Find(id);
            if (role == null)
                return NotFound();
            RolesModel Model = new RolesModel() { ID = role.ID, RoleName = role.RoleName };
            return Ok(Model);
        }

        // PUT: api/Roles/id
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRole(Guid id, RolesModel role)
        {
            Role roleObj = db.Roles.FirstOrDefault(r => r.ID == id);
            
            if (roleObj == null)
                return BadRequest();

            roleObj.RoleName = role.RoleName;
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.OK);
        }

        // POST: api/Roles
        [ResponseType(typeof(Role))]
        public IHttpActionResult PostRole(RolesModel role)
        {
            Role roleObj = new Role()
            {
                ID = Guid.NewGuid(),
                RoleName = role.RoleName
            };
            try
            {
                db.Roles.Add(roleObj);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(roleObj.ID);
        }

        // DELETE: api/Roles/id
        public IHttpActionResult DeleteRole(Guid id)
        {
            Role role = db.Roles.Find(id);
            if (role == null)
            {
                return NotFound();
            }

            db.Roles.Remove(role);
            db.SaveChanges();

            return Ok();
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