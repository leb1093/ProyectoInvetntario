<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebLogin.aspx.cs" Inherits="ApliciacionInventario.WebLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<%--    <title></title>
    <link href="CSS/DemoCSS.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 44%;
        }
        .auto-style2 {
            width: 233px;
        }
        .auto-style3 {
            height: 17px;
        }
        .auto-style4 {
            color: #FF0000;
        }
        .auto-style7 {
            color: #0101F7;
            text-align: center;
        }
    </style>--%>
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />


</head>
<body style="background-image: url(https://propertyoneglobalgroup.com/wp-content/uploads/elementor/thumbs/AdobeStock_180379978-odpnnqhfjv62yibwcn2mcwrvnzqd6lcsv99k0x11kw.jpeg);
    background-repeat: no-repeat;
  background-attachment: fixed;
  background-position: center;">
<%--    <form id="form1" runat="server">
    <div>
        <table class="auto-style1" style="background-color: #FFFFCC">
            <tr>
                <td class="auto-style2" rowspan="8">
                    <asp:Image ID="Image1" runat="server" Height="235px" Width="231px" ImageUrl="~/Images/login1.png" />
                </td>
                <td class="auto-style7" colspan="2">
    <span style="text-align: left; background-color: #FFFFCC;" class="tituloForm">Ubicacion y operatividad de Luces de Emergencia</span></td>
            </tr>
            <tr>
                <td class="auto-style4" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="labelContenido">Ingrese Usuario</td>
                <td>
                    <asp:TextBox ID="txtUsuario" runat="server" Height="23px" Width="156px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labelContenido">Ingrese Password</td>
                <td>
                    <asp:TextBox ID="txtPass" runat="server" Height="23px" Width="156px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnRegistrar" runat="server" Height="24px" Text="Registrar Usuario" Width="166px" CssClass="boton2" OnClick="btnRegistrar_Click" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="10pt" ForeColor="Red" CssClass="labelErrores"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>--%>

     
    <section class="vh-100 gradient-custom">
        <div class="container py-5 h-100">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                    <div class="card bg-dark text-white" style="border-radius: 1rem;">
                        <div class="card-body p-5 text-center">

                            <div class="mb-md-5 mt-md-4 pb-5">
                                <form id="form1" runat="server">
                                    <h2 class="fw-bold mb-2 text-uppercase">Inicie Sesion</h2>
                                    <p class="text-white-50 mb-5">Por favor ingrese su usuario y contraseña asignado!</p>

                                    <div class="row form-outline form-white mb-4">
                                        <%--<input type="email" id="typeEmailX" class="form-control form-control-lg" />--%>
                                        
                                        <asp:Label ID="Label1" runat="server" Text="Usuario:" CssClass=""></asp:Label>
                                        <asp:TextBox ID="txtUsuario" runat="server" class="form-control form-control-lg" BackColor="#212529" BorderColor="White" BorderStyle="Outset" ForeColor="White"></asp:TextBox>

                                    </div>

                                    <div class="row form-outline form-white mb-4">
                                        <%--<input type="password" id="typePasswordX" class="form-control form-control-lg" />--%>
                                        <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
                                        <asp:TextBox ID="txtPass" runat="server" class="form-control form-control-lg" TextMode="Password" BackColor="#212529" BorderColor="White" BorderStyle="Outset" EnableTheming="True" ForeColor="White">Contraseña</asp:TextBox>
                                        <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="10pt" ForeColor="Red" CssClass="labelErrores"></asp:Label>
                                    </div>

                                    <p class="small mb-5 pb-lg-2"><a class="text-white-50" href="#!">Olvido su contraseña?</a></p>
                                    <asp:Button ID="btnRegistrar" runat="server" Text="Ingresar" CssClass="btn btn-outline-light btn-lg px-5" OnClick="btnRegistrar_Click" />
                                    <%--<button class="btn btn-outline-light btn-lg px-5" type="submit">Ingresar</button>--%>
                                </form>

                            </div>

                            <div>
                                <p class="mb-0">
                                    Si no cuenta con un usuario, comunicarse con el administrador
                                </p>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

</body>
    </html>