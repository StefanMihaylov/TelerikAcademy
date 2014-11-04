using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleChat
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            var db = new ChatDbContext();
            var result = db.Messages.OrderByDescending(m => m.PostDate)
                                    .Take(100)
                                    .OrderBy(m => m.PostDate)
                                    .ToList();

            this.ListVewMessages.DataSource = result;
            this.ListVewMessages.DataBind();
        }


        protected void ButtonSend_Click(object sender, EventArgs e)
        {
            var text = this.TextBoxNewMessage.Text;
            var user = this.TextBoxUserName.Text;
            this.TextBoxNewMessage.Text = "";
            if (!string.IsNullOrWhiteSpace(text))
            {
                var db = new ChatDbContext();

                var newMessage = new Message()
                {
                    PostDate = DateTime.Now,
                    Username = user == "" ? "Anonymous" : user,
                    Content = text
                };

                db.Messages.Add(newMessage);
                db.SaveChanges();
            }
        }
    }
}