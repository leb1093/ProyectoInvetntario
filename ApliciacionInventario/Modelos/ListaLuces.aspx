<%@ Page Language="C#" MasterPageFile="~/DemoMaster.master" AutoEventWireup="true" CodeBehind="ListaLuces.aspx.cs" Inherits="ApliciacionInventario.Modelos.ListaLuces" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            font-family: Verdana;
            font-size: 10pt;
            color: #993366;
            height: 23px;
        }

        .auto-style2 {
            height: 23px;
        }

        .auto-style5 {
            font-family: Verdana;
            font-size: 10pt;
            color: #993366;
            height: 22px;
        }

        .auto-style13 {
            font-family: Verdana;
            font-size: 10pt;
            color: #993366;
            width: 45%;
            height: 26px;
        }

        .auto-style14 {
            height: 26px;
        }

        .auto-style15 {
            font-family: Verdana;
            font-size: 10pt;
            color: #993366;
            height: 42px;
            width: 37%;
        }

        .auto-style16 {
            height: 42px;
            width: 385px;
        }

        .auto-style17 {
            font-family: Verdana;
            font-size: 10pt;
            color: #993366;
            height: 58px;
        }

        .auto-style18 {
            height: 58px;
        }

        .auto-style20 {
            height: 244px;
            width: 690px;
        }
        .auto-style21 {
            font-family: Verdana;
            font-size: 10pt;
            color: #993366;
            height: 40px;
        }
        .auto-style22 {
            height: 40px;
        }
        .auto-style23 {
            width: 385px;
        }
        .auto-style24 {
            height: 23px;
            width: 385px;
        }
        .auto-style25 {
            height: 58px;
            width: 385px;
        }
        .auto-style26 {
            font-family: Verdana;
            font-size: 10pt;
            color: #993366;
            height: 23px;
            width: 385px;
        }
        .auto-style27 {
            width: 37%;
        }
        .auto-style28 {
            font-family: Verdana;
            font-size: 10pt;
            color: #993366;
            height: 23px;
            width: 37%;
        }
        .auto-style29 {
            font-family: Verdana;
            font-size: 10pt;
            color: #993366;
            height: 58px;
            width: 37%;
        }
        .auto-style30 {
            margin-top: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--INDISPENSABLE PARA EL AJAX--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <%--Aqui va el diseño del formulario--%>
            <div class="tituloForm">
                MANTENIMIENTO DE MODELOS
            </div>

            <%--Boton ( o link button ) para mostrar el modal de insercion PopMant del nuevo registro--%>
            <br />
            <asp:Button ID="btnNuevo" class="btn btn-primary" runat="server" Text="Nuevo Modelo" OnClick="btnNuevo_Click" />
            <br />
            <br />
            <%--El grid view para el listado de proveedores, con la primera columna de tipo Button, con el CommanName (recomendado) Editar
                   y con un icono asociado a la accion de editar--%>
            <table class="auto-style5">
                <tr>
                    <td class="labelContenido">Ingrese Marca:</td>
                    <td>
                        <asp:TextBox ID="txtFiltro" runat="server" Width="300px"></asp:TextBox>
                        <asp:ImageButton ID="btnFiltrar" runat="server" ImageUrl="~/Images/Buscar.png" OnClick="btnFiltrar_Click" Style="width: 16px" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:GridView ID="grvModelo" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1494px" OnRowCommand="grvModelo_RowCommand" ShowHeaderWhenEmpty="True" AllowPaging="True" PageSize="15"  CssClass="auto-style30"  OnPageIndexChanging="grvModelo_PageIndexChanging" >
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/Editar.png" Text="Editar" CommandName="Editar" />
                    <asp:BoundField DataField="id" HeaderText="Id" />
                    <asp:BoundField DataField="marca" HeaderText="Marca" />
                    <asp:BoundField DataField="modelo" HeaderText="Modelo" />
                    <asp:BoundField DataField="tipo" HeaderText="Tipo" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <br />
            <br />
            <asp:LinkButton Text="" ID="btnPopup" runat="server" />
            <%--El modalpoput extender : vease el TargetControl que apunta al linkbutton y el popuconttol ID que apunhta al panel--%>

            <ajaxToolkit:ModalPopupExtender ID="PopMant" runat="server" BackgroundCssClass="FondoAplicacion"
                TargetControlID="btnPopup" PopupControlID="Panel1">
            </ajaxToolkit:ModalPopupExtender>
            <asp:Panel ID="Panel1" runat="server" CssClass="CajaDialogo" align="center" Style="display: table; background-color: white" Width="700">

                <table style="border: Solid 3px #284775;"
                    cellpadding="0" cellspacing="0" class="auto-style20">
                    <tr style="background-color: #284775">
                        <td colspan="2" style="height: 10%; color: White; font-weight: bold; font-size: larger"
                            align="center">Nuevo Modelo de Luz de Emergencia</td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style13"></td>
                        <td align="left" class="auto-style14"></td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style21">Marca :</td>
                        <td align="left" class="auto-style22">
                            <asp:TextBox ID="txtMarcaLuz" runat="server" Width="251px" Height="17px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style21">Modelo :
                        </td>
                        <td align="left" class="auto-style22">
                            <asp:TextBox ID="txtModeloLuz" runat="server" Height="17px" Width="251px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style17">Tipo :
                        </td>
                        <td align="left" class="auto-style18">
                            <asp:DropDownList ID="cboTipo" runat="server" Height="21px" Width="217px" OnSelectedIndexChanged="cboTipo_SelectedIndexChanged">
                                <asp:ListItem Value="0">--Seleccione el tipo de Luz--</asp:ListItem>
                                <asp:ListItem>LED</asp:ListItem>
                                <asp:ListItem>HALOGENO</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>


                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblMensajeIns" runat="server" CssClass="labelErrores" Width="400px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style1">
                            <asp:Button ID="btnGrabar" runat="server" Text="Grabar" Width="100px" OnClick="btnGrabar_Click" />
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="100px" />
                        </td>
                    </tr>

                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style1">&nbsp;</td>
                    </tr>

                </table>

            </asp:Panel>

            <%-- Aqui va el popup de Edicion con su codigo--%>
            <%--el link button o cualquiero otro control para el manejo del modal--%>
            <asp:LinkButton Text="" ID="btnPopup2" runat="server" />
            <%--El modalpoput extender : vease el TargetControl que apunta al linkbutton y el popuconttol ID que apunhta al panel--%>
            <ajaxToolkit:ModalPopupExtender ID="PopMant2" runat="server" BackgroundCssClass="FondoAplicacion"
                TargetControlID="btnPopup2" PopupControlID="Panel2">
            </ajaxToolkit:ModalPopupExtender>
            <asp:Panel ID="Panel2" runat="server" CssClass="CajaDialogo" align="center" Style="display: table; background-color: white" Width="700">
                <table style="border: Solid 3px #284775; height: 308px;"
                    cellpadding="0" cellspacing="0">
                    <tr style="background-color: #284775">
                        <td colspan="2" style="height: 10%; color: White; font-weight: bold; font-size: larger"
                            align="center">Actualizar Modelode Luz de Emergencia</td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style27">&nbsp;</td>
                        <td align="left" class="auto-style23">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style27">ID :</td>
                        <td align="left" class="auto-style23">
                            <asp:TextBox ID="txtId" runat="server" Width="50px" ReadOnly="True" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style28">Marca :</td>
                        <td align="left" class="auto-style24">
                            <asp:TextBox ID="txtMarca2" runat="server" Width="251px" Height="17px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style15">Modelo :
                        </td>
                        <td align="left" class="auto-style16">
                            <asp:TextBox ID="txtModelo2" runat="server" Height="17px" Width="251px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style29">Tipo :
                        </td>
                        <td align="left" class="auto-style25">
                            <asp:DropDownList ID="cboTipo2" runat="server" Height="30px" Width="184px" OnSelectedIndexChanged="cboTipo2_SelectedIndexChanged">
                                <asp:ListItem Value="0">--Seleccione el tipo de Luz--</asp:ListItem>
                                <asp:ListItem>LED</asp:ListItem>
                                <asp:ListItem>HALOGENO</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblMensajeAct" runat="server" CssClass="labelErrores" Width="400px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style28">&nbsp;</td>
                        <td class="auto-style26">
                            <asp:Button ID="btnGrabar2" runat="server" Text="Grabar" Width="100px" OnClick="btnGrabar2_Click" />
                            &nbsp;<asp:Button ID="btnEliminar" runat="server" Text="Eliminar" Width="100px" />
                            &nbsp;<asp:Button ID="btnCancelar2" runat="server" Text="Cancelar" Width="100px" />
                        </td>
                    </tr>

                    <tr>
                        <td class="auto-style28">&nbsp;</td>
                        <td class="auto-style26">&nbsp;</td>
                    </tr>

                </table>

            </asp:Panel>

            <%--Este es el panel  que contiene los mensajes de error--%>
            <asp:LinkButton ID="lnkMensaje" runat="server"></asp:LinkButton>
            <ajaxToolkit:ModalPopupExtender ID="mpeMensaje" runat="server" TargetControlID="lnkMensaje"
                PopupControlID="pnlMensaje" BackgroundCssClass="FondoAplicacion" OkControlID="btnAceptar" />
            <asp:Panel ID="pnlMensaje" runat="server" CssClass="CajaDialogo" Style="display: normal;background-color: white" Width="300">
                <table border="0" width="300px" style="margin: 0px; padding: 0px; background-color: #284775; color: #FFFFFF;">
                    <tr>
                        <td align="center" class="auto-style2">
                            <asp:Label ID="lblTitulo" runat="server" Text="Mensaje" />
                        </td>
                        <td width="12%" class="auto-style2">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Cancelar.png" Style="vertical-align: top;"
                                ImageAlign="Right" />
                        </td>
                    </tr>

                </table>
                <div>
                    <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Black" />
                </div>
                <div>
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" />
                </div>
            </asp:Panel>



        </ContentTemplate>

    </asp:UpdatePanel>
    <%--El modalpoput extender : vease el TargetControl que apunta al linkbutton y el popuconttol ID que apunhta al panel--%>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UpdatePanel1">
        <%--<ProgressTemplate >
            <div class="overlay"  />
            <div class ="overlayContent" >
            <h2>  Procesando....</h2> 
                <p>
                    &nbsp;</p>
                <img src ="../Images/indicator.gif" alt ="Loading" border="0"/>
                </div> 
        </ProgressTemplate>--%>
    </asp:UpdateProgress>
</asp:Content>
