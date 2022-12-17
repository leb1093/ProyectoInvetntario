<%@ Page Language="C#" MasterPageFile="~/DemoMaster.master" AutoEventWireup="true" CodeBehind="MenuPrincipal.aspx.cs" Inherits="ApliciacionInventario.MenuPrincipal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            width: 14px;
        }

        .auto-style3 {
            font-size: x-large;
            color: #0101F7;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <section class="h-100 gradient-form" style="background-color: #eee;">
        <div class="container py-5 h-100">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col-xl-10">
                    <div class="card rounded-3 text-black">
                        <div class="row g-0">
                            <div class="col-lg-6">
                                <div class="card-body p-md-5 mx-md-4">

                                    <div class="text-center">
                                        <%--<img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/lotus.webp"
                                            style="width: 185px;" alt="logo">--%>
                                        <h1 class="mt-1 mb-5 pb-1">Bienvenido 
                                            <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                                        </h1>
                                    </div>
                                    <h4>Seleccione su opcion a trabajar:</h4>
                                    <div style="padding-left: 30px">
                                        <form>
                                            <asp:Label ID="lblUsuario2" runat="server" Text="Usuario"></asp:Label>

                                            <div style="padding-left: 40px">
                                                <div class="form-outline mb-4">                                                    
                                                    <asp:Button style="width: 130px" class="btn btn-primary btn-block fa-lg gradient-custom-2 mb-3" ID="btnUsuarios" runat="server" Text="Usuarios" OnClick="btnUsuarios_Click" />
                                                </div>
                                            </div>
                                            <asp:Label ID="lblGraficas" runat="server" Text="Graficas"></asp:Label>

                                            <div style="padding-left: 40px">
                                                <div class="form-outline mb-4">                                                    
                                                    <asp:Button style="width: 130px" class="btn btn-primary btn-block fa-lg gradient-custom-2 mb-3" ID="Button1" runat="server" Text="Graficas" OnClick="btnGraficas_Click" />
                                                </div>
                                            </div>

                                            <p>Modelos de luces de emergencia</p>

                                            <div style="padding-left: 40px">
                                                <div class="form-outline mb-4">                                                    
                                                    <asp:Button style="width: 130px" class="btn btn-primary btn-block fa-lg gradient-custom-2 mb-3" ID="btnModelos" runat="server" Text="Modelos" OnClick="btnModelos_Click" />
                                                </div>
                                            </div>
                                            <p>Areas :</p>
                                            <div style="padding-left: 40px">
                                                <div class="form-outline mb-4">
                                                    <asp:Button style="width: 130px" class="btn btn-primary btn-block fa-lg gradient-custom-2 mb-3" ID="btnHangar" runat="server" Text="Hangar" OnClick="btnHangar_Click" />
                                                </div>
                                                <div class="form-outline mb-4" style="margin-top:-30px">
                                                    <asp:Button style="width: 130px" class="btn btn-primary btn-block fa-lg gradient-custom-2 mb-3" ID="btnATO" runat="server" Text="ATO" OnClick="btnATO_Click" />
                                                </div>
                                                <div class="form-outline mb-4" style="margin-top:-30px">
                                                    <asp:Button style="width: 130px" class="btn btn-primary btn-block fa-lg gradient-custom-2 mb-3" ID="btnPlazaLat" runat="server" Text="Plaza Latam" OnClick="btnPlazaLat_Click" />
                                                </div>
                                            </div>

                                            <div class="text-center pt-1 mb-5 pb-1">

                                                <a class="text-muted" href="#!">No encuentras tu opción?</a>
                                            </div>

                                            <div class="d-flex align-items-center justify-content-center pb-4">
                                                <asp:Button class="btn btn-outline-danger" ID="btnLogout" runat="server" Text="Log Out" OnClick="btnLogout_Click" />
                                            </div>

                                        </form>
                                    </div>

                                </div>
                            </div>
                            <div class="col-lg-6 d-flex align-items-center gradient-custom-2">
                                <div class="text-white px-3 py-4 p-md-5 mx-md-4">
                                    <h4 class="mb-4">We are more than just a company</h4>
                                    <p class="small mb-0">
                                        Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
                  tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                  exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <%--    <p class="auto-style3">
        <strong>MENU PRINCIPAL - Inventario </strong>FM
    </p>
    <p>
        &nbsp;
    </p>
    <table class="auto-style1">
        <tr>
            <td class="auto-style2" rowspan="3">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Logo.png" Width="350px" />
            </td>
            <td>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Modelos/ModeloLuces.aspx" CssClass="tituloForm">Modelos</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Hangar/MenuHangar.aspx" CssClass="tituloForm">Hangar</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Ato/MenuAto.aspx" CssClass="tituloForm">ATO</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/PlazaLatam/MenuPlazaLatam.aspx" CssClass="tituloForm">Plaza Latam</asp:HyperLink>
            </td>
        </tr>
    </table>--%>
</asp:Content>
