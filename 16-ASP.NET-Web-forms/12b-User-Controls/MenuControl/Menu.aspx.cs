using MenuControl.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MenuControl
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var links = new List<CustomMenuItem>();
            links.Add(new CustomMenuItem() { Name = "Hobbit", Url = "http://en.wikipedia.org/wiki/The_Hobbit:_An_Unexpected_Journey" });
            links.Add(new CustomMenuItem() { Name = "Lord of the Rings", Url = "http://en.wikipedia.org/wiki/The_Lord_of_the_Rings:_The_Fellowship_of_the_Ring" });
            links.Add(new CustomMenuItem() { Name = "Game of Thrones", Url = "http://en.wikipedia.org/wiki/Game_of_Thrones" });

            this.LinksMenu.DataSource = links.ToArray();
            this.DataBind();
        }
    }
}