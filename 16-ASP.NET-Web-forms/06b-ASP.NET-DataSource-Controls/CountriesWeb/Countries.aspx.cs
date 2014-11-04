using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CountriesWeb
{
    public partial class Countries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.ContinentListBox.SelectedIndex = 0;
                //this.CountriesGridView.SelectedIndex = 0;                
            }
        }

        protected void ButtonInsertTown_Click(object sender, EventArgs e)
        {
            this.TownsListView.InsertItemPosition = InsertItemPosition.FirstItem;
        }

        protected void TownsListView_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            this.TownsListView.InsertItemPosition = InsertItemPosition.None;
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var context = new CountriesDBEntities())
            {
                var country = new Country()
                {
                    Name = ViewState["Name"].ToString(),
                    Population = long.Parse(ViewState["Population"].ToString()),
                    Language = ViewState["Language"].ToString(),
                    ContinentId = int.Parse(ViewState["ContinentId"].ToString())
                };
                context.Countries.Add(country);
                context.SaveChanges();
                this.CountriesGridView.DataBind();

                ViewState["Name"] = "";
                ViewState["Population"] = "";
                ViewState["Language"] = "";
                ViewState["ContinentId"] = "";

                this.CountriesGridView.FooterRow.Visible = false;
            }
        }

        protected void CountryNameInsertTb_PreRender(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            ViewState["Name"] = tb.Text;
        }

        protected void CountryPopulationBind_PreRender(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            var text = tb.Text;
            if (!string.IsNullOrWhiteSpace(text))
            {
                try
                {
                    ViewState["Population"] = long.Parse(text);
                }
                catch (Exception)
                {

                }
            }
        }

        protected void LanguageId_PreRender(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            ViewState["Language"] = tb.Text;
        }

        protected void CountinentId_PreRender(object sender, EventArgs e)
        {
            var ddl = (DropDownList)sender;
            var selected = ddl.SelectedValue;
            if (!string.IsNullOrWhiteSpace(selected))
            {
                ViewState["ContinentId"] = int.Parse(selected);
            }
        }

        protected void ButtonCancelInsertCountry_Click(object sender, EventArgs e)
        {
            this.CountriesGridView.FooterRow.Visible = false;
        }

        protected void ButtonInsertCountry_Click(object sender, EventArgs e)
        {
            this.CountriesGridView.FooterRow.Visible = true;
        }
    }
}