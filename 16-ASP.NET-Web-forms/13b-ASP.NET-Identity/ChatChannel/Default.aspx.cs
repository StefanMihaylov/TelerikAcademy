using ChatChannel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace ChatChannel
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new AppDbContext();
            var result = db.Messages.OrderByDescending(m => m.PostDate)
                                    .Take(100)
                                    .OrderBy(m => m.PostDate)
                                    .ToList();

            this.ListVewMessages.DataSource = result;
            this.ListVewMessages.DataBind();
        }

        protected void ButtonSend_Click(object sender, EventArgs e)
        {
            var loggedUserId = HttpContext.Current.User.Identity.GetUserId();
            if (loggedUserId != null)
            {
                var text = this.TextBoxNewMessage.Text;
                this.TextBoxNewMessage.Text = "";
                if (!string.IsNullOrWhiteSpace(text))
                {
                    var db = new AppDbContext();

                    var newMessage = new Message()
                    {
                        PostDate = DateTime.Now,
                        AuthorId = loggedUserId,
                        Content = text
                    };

                    db.Messages.Add(newMessage);
                    db.SaveChanges();
                }
            }
        }
    }
}