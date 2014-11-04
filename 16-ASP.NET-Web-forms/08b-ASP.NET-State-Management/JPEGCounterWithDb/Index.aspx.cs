﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JPEGCounterWithDb
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new UserDbContext();
            UserCounter counter;

            if (!db.Counter.Any())
            {
                counter = new UserCounter() { Counter = 1 };
                db.Counter.Add(counter);
            }
            else
            {
                counter = db.Counter.First();
                counter.Counter++;
            }

            db.SaveChanges();

            Response.Clear();

            Bitmap generatedImage = new Bitmap(200, 200);
            using (generatedImage)
            {
                Graphics gr = Graphics.FromImage(generatedImage);
                using (gr)
                {
                    // Create string to draw.
                    string num = counter.Counter.ToString();

                    gr.FillRectangle(Brushes.Black, 0, 0, 200, 200);

                    // Create font and brush.
                    Font drawFont = new Font("Tahoma", 30);
                    SolidBrush drawBrush = new SolidBrush(Color.Yellow);

                    // Create point for upper-left corner of drawing.
                    PointF drawPoint = new PointF(50.0F, 60.0F);

                    gr.DrawString(num, drawFont, drawBrush, drawPoint);

                    // Set response header and write the image into response stream
                    Response.ContentType = "image/gif";
                    generatedImage.Save(Response.OutputStream, ImageFormat.Jpeg);
                }
            }
        }
    }
}