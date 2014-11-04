using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MenuControl.Control
{
    [System.ComponentModel.DefaultBindingProperty("DataSource")]
    public partial class MenuControl : UserControl
    {
        public IEnumerable<CustomMenuItem> DataSource
        {
            get
            {
                return (IEnumerable<CustomMenuItem>)this.DataListMenu.DataSource;
            }
            set
            {
                this.DataListMenu.DataSource = value;
            }
        }

        public Color FontColour { get; set; }

        public string FontFamily { get; set; }


        public override void DataBind()
        {
            this.DataListMenu.DataBind();
            base.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            foreach (var item in this.DataSource)
            {
                item.FontColor = this.FontColour;

            }

            this.DataListMenu.Style.Add("font-family", this.FontFamily);
            this.DataBind();
        }
    }
}