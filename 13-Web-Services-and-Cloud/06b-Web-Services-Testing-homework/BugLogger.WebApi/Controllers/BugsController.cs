namespace BugLogger.WebApi.Controllers
{
    using BugLogger.Data;
    using BugLogger.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class BugsController : ApiController
    {
        private IBugLoggerData data;

        public BugsController()
            : this(new BugLoggerData(new BugLoggerDbContext()))
        {
        }

        public BugsController(IBugLoggerData data)
        {
            this.data = data;
        }

        public IQueryable<Bug> GetAll()
        {
            return this.data.Bugs.All();
        }

        public HttpResponseMessage PostBug(Bug bug)
        {
            if (string.IsNullOrWhiteSpace(bug.Text))
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "Bug text cannot be null or empty");
            }

            bug.LogDate = DateTime.Now;
            bug.Status = Status.Pending;

            this.data.Bugs.Add(bug);
            this.data.SaveChanges();

            var response = this.Request.CreateResponse(HttpStatusCode.Created, bug);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = bug.BugId }));

            return response;
        }

        public IQueryable<Bug> GetByDate(DateTime date)
        {
            return this.GetAll().Where(b => b.LogDate > date);
        }

        public IQueryable<Bug> GetByStatus(Status status)
        {
            return this.GetAll().Where(b => b.Status == status);
        }

        [HttpPut]
        public HttpResponseMessage PutBug(int id)
        {
            var bug = this.data.Bugs.Find(id);
            if (bug == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Bug Id");
            }

            bug.Status = Status.Fixed;
            this.data.SaveChanges();

            var response = this.Request.CreateResponse(HttpStatusCode.OK, bug);

            // response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = bug.BugId }));

            return response;
        }
    }
}
