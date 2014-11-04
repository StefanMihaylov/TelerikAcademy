using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileBg
{
    public partial class WebForm : System.Web.UI.Page
    {
        private static IList<Produser> producers = InitializeProduces();

        private List<Extra> extras = new List<Extra> 
        {
            new Extra("GPS"),
            new Extra("ABS"),
            new Extra("Airbags"),
            new Extra("Parktronic"),
        };

        private string[] engines = new string[] { "disel", "gasoline", "electric", "hybrid" };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }

            this.ProducersDropDownList.DataSource = producers;
            this.ModelsDropDownList.DataSource = producers.First().Models;
            this.ExtrasCheckBoxList.DataSource = extras;
            this.EngineRadioButtonList.DataSource = engines;
            this.Page.DataBind();
        }

        protected void ProducersDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = this.ProducersDropDownList.SelectedIndex;
            this.ModelsDropDownList.DataSource = producers[index].Models;
            this.ModelsDropDownList.DataBind();
        }

        private static IList<Produser> InitializeProduces()
        {
            var producers = new List<Produser>();

            producers.Add(new Produser()
            {
                Name = "Opel",
                Models = new List<Model>()
                {
                    new Model() { Name = "Astra" },
                    new Model() { Name = "Corsa" },
                    new Model() { Name = "Kadett" },
                    new Model() { Name = "Omega" },
                    new Model() { Name = "Tigra" },
                    new Model() { Name = "Vectra" }
                }
            });

            producers.Add(new Produser()
            {
                Name = "Lada",
                Models = new List<Model>()
                {
                    new Model() { Name = "2101" },
                    new Model() { Name = "2103" },
                    new Model() { Name = "2105" },
                    new Model() { Name = "2107" },
                    new Model() { Name = "2121-Niva" }
                }
            });

            producers.Add(new Produser()
            {
                Name = "Skoda",
                Models = new List<Model>()
                {
                    new Model() { Name = "Fabia" },
                    new Model() { Name = "Favourit" },
                    new Model() { Name = "Forman" },
                    new Model() { Name = "Felicia" },
                    new Model() { Name = "Octavia" }
                }
            });

            return producers;
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            var resultText = "<strong>Summary:</strong> ";
            resultText += string.Format("<strong>Producer:</strong> {0}, ", this.ProducersDropDownList.SelectedItem);
            resultText += string.Format("<strong>Model:</strong> {0}, ", this.ModelsDropDownList.SelectedItem);

            var selectedExtras = new List<string>();
            foreach (ListItem item in this.ExtrasCheckBoxList.Items)
            {
                if (item.Selected)
                {
                    selectedExtras.Add(item.Text);
                }
            }

            resultText += string.Format("<strong>Extras:</strong> {0}, ", string.Join(", ", selectedExtras));

            resultText += string.Format("<strong>Engine:</strong> {0}, ", this.EngineRadioButtonList.SelectedItem);
            this.result.Text = resultText;
        }
    }
}