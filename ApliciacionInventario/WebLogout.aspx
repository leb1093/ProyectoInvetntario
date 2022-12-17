<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebLogout.aspx.cs" Inherits="ApliciacionInventario.WebLogout" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS/DemoCSS.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 44%;
        }
        .auto-style2 {
            width: 233px;
        }
        .auto-style7 {
            color: #0101F7;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="auto-style1" style="background-color: #FFFFCC">
            <tr>
                <td class="auto-style2" rowspan="3">
                    <asp:Image ID="Image1" runat="server" Height="235px" Width="231px" ImageUrl="~/Images/logout2.jpg" />
                </td>
                <td class="auto-style7" colspan="2">
    <span style="text-align: left; background-color: #FFFFCC;" class="tituloForm">GRACIAS...VUELVA PRONTO</span></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="center">
                    <asp:Button ID="btnFinSesion" runat="server" Height="24px" Text="Fin de sesion" Width="166px" CssClass="borderRadius" OnClick="btnFinSesion_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="10pt" ForeColor="Red" CssClass="labelErrores"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>

