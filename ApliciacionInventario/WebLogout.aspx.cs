﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApliciacionInventario
{
    public partial class WebLogout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFinSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebLogin.aspx");
        }
    }
}