<%@ Page Language="C#"  MasterPageFile="~/DemoMaster.master" AutoEventWireup="true" CodeBehind="LucesAto.aspx.cs" Inherits="ApliciacionInventario.Ato.LucesAto" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

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
        .auto-style3 {
            height: 31px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--Boton ( o link button ) para mostrar el modal de insercion PopMant del nuevo registro--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnPrev"  />
            <asp:PostBackTrigger ControlID="btnPrev2"  />
        </Triggers>
        <ContentTemplate >
       
            <%--Aqui va el diseño del formulario--%>
<div class="tituloForm">
                  MANTENIMIENTO DE LUCES EMERGENCIA ATO</div>
   
              <%--Boton ( o link button ) para mostrar el modal de insercion PopMant del nuevo registro--%>
            <br />
            <asp:Button ID="btnNuevo" class="btn btn-primary" runat="server" Text="Nueva Luz Emergencia" OnClick="btnNuevo_Click" />
            <br />
            <br />
            <%--El grid view para el listado de proveedores, con la primera columna de tipo Button, con el CommanName (recomendado) Editar
                   y con un icono asociado a la accion de editar--%>
            <table class="auto-style5">
                <tr>
                    <td class="labelContenido">Ingrese área:</td>
                    <td>
                        <asp:TextBox ID="txtFiltro" runat="server" Width="300px"></asp:TextBox>
                        <asp:ImageButton ID="btnFiltrar" runat="server" ImageUrl="~/Images/Buscar.png" OnClick="btnFiltrar_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11">Seleccione estado:</td>
                    <td>
                        <asp:DropDownList ID="cboConsultaEst" runat="server" AutoPostBack="True" Width="300px" OnSelectedIndexChanged="cboConsultaEst_SelectedIndexChanged" >
                                <asp:ListItem Value="0">--Filtre por los estados del equipo--</asp:ListItem>
                                <asp:ListItem>OPERATIVO</asp:ListItem>
                                <asp:ListItem>INOPERATIVO</asp:ListItem>
                                <asp:ListItem>CAMBIO DE BATERIA</asp:ListItem>
                         </asp:DropDownList>
                        
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11">Seleccione Tipo de tecnologia:</td>
                    <td>
                        <asp:DropDownList ID="cboConsultaTipo" runat="server" AutoPostBack="True" Width="300px" OnSelectedIndexChanged="cboConsultaTipo_SelectedIndexChanged"  >
                                <asp:ListItem Value="0">--Filtre por el tipo del equipo--</asp:ListItem>
                                <asp:ListItem>LED</asp:ListItem>
                                <asp:ListItem>HALOGENO</asp:ListItem>
                         </asp:DropDownList>
                        
                    </td>
                </tr>
                 <tr>
                    
                    <td>
                        <asp:Button ID="btnDescargar" class="btn btn-success" runat="server" Text="Descargar Excel" OnClick="btnDescargar_Click" />
                    </td>
            </table>
            <br />
            <asp:GridView ID="grvLuces" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1494px" OnRowCommand="grvLuces_RowCommand" ShowHeaderWhenEmpty="True" AllowPaging="True" OnPageIndexChanging="grvLuces_PageIndexChanging" PageSize="15">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/Editar.png" Text="Editar" CommandName="Editar" />
                    <asp:BoundField DataField="id" HeaderText="Id" />
                    <asp:BoundField DataField="piso" HeaderText="Piso" />
                    <asp:BoundField DataField="area" HeaderText="Area" />
                    <asp:BoundField DataField="marca" HeaderText="Marca"  />
                    <asp:BoundField DataField="modelo" HeaderText="Modelo" ItemStyle-CssClass="d-md-none d-lg-block"  HeaderStyle-CssClass="d-md-none d-lg-block" />
                    <asp:BoundField DataField="estado" HeaderText="Estado" />
                    <asp:BoundField DataField="tipo" HeaderText="Tipo"  ItemStyle-CssClass="d-md-none d-lg-block"  HeaderStyle-CssClass="d-md-none d-lg-block" />
                    <asp:BoundField DataField="obs" HeaderText="Observacion" />
                    <asp:BoundField DataField="nom_activo" HeaderText="Activo?"  ItemStyle-CssClass="d-md-none d-lg-block "  HeaderStyle-CssClass="d-md-none d-lg-block " />
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
           <asp:LinkButton Text="" ID = "btnPopup" runat="server" />
            <%--El modalpoput extender : vease el TargetControl que apunta al linkbutton y el popuconttol ID que apunhta al panel--%> 

      <ajaxToolkit:ModalPopupExtender ID="PopMant" runat="server" BackgroundCssClass="FondoAplicacion"
        TargetControlID="btnPopup" PopupControlID="Panel1">
     </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" CssClass="CajaDialogo" align="center" Style="display:table; background-color: white" Width="700">
          
            <table style="border: Solid 3px #284775; height: 308px;"
                cellpadding="0" cellspacing="0" >
                <tr style="background-color: #284775">
                    <td colspan="2" style="height: 10%; color: White; font-weight: bold; font-size: larger"
                        align="center">
                        Nueva Luz Emergencia</td>
                </tr>
                <tr>
                    <td align="right" style="width: 45%" class="labelContenido">
                        &nbsp;</td>
                      <td align="left">
                          &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="auto-style1">
                        Piso :</td>
                    <td align="left" class="auto-style2">
                        <asp:TextBox ID="txtPiso" runat="server" Width="100px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">
                        Area :
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtArea" runat="server" Width="450px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">
                        Equipo :
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="cboEquipo" runat="server" AutoPostBack="True" Width="449px" OnSelectedIndexChanged="cboEquipo_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
               
                     <tr>
                         <td align="right" class="auto-style3">Estado :</td>
                         <td align="left" class="auto-style3">
                             <asp:DropDownList ID="cboEstado" runat="server" AutoPostBack="True" Width="449px" OnSelectedIndexChanged="cboEstado_SelectedIndexChanged">
                                 <asp:ListItem Value="0">--Seleccione el estado actual del equipo--</asp:ListItem>
                                 <asp:ListItem>OPERATIVO</asp:ListItem>
                                 <asp:ListItem>INOPERATIVO</asp:ListItem>
                                 <asp:ListItem>CAMBIO DE BATERIA</asp:ListItem>
                             </asp:DropDownList>
                         </td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">Observacion :</td>
                    <td align="left">
                        <asp:TextBox ID="txtObs" runat="server" Height="16px" Width="443px" />
                    </td>
                </tr>
                <tr>
                        <td align="right" class="labelContenido">Imagen : </td>
                        <td align="left" class="auto-style3" >
                            
                            <asp:Image ID="ImageUpload" runat="server" Style="max-height:200px;"/>
                            <asp:FileUpload ID="btnUpload" runat="server" class="col-12"/>
                            <asp:Button ID="btnPrev" runat="server"  Text="Cargar Foto" OnClick="btnPrev_Click" class="col-3" />
                            
                        </td>
                    </tr>

              
                     <tr>
                         <td align="right" class="labelContenido">Activo? : </td>
                         <td align="left">
                             <asp:CheckBox ID="chkActivo" runat="server" />
                         </td>
                     </tr>
                     <tr>
                         <td colspan="2">
                             <asp:Label ID="lblMensajeIns" runat="server" CssClass="labelErrores" Width="400px"></asp:Label>
                         </td>
                     </tr>
                     <tr>
                         <td class="auto-style1">
                             &nbsp;</td>
                         <td class="auto-style1">
                             <asp:Button ID="btnGrabar" runat="server" Text="Grabar" Width="100px" OnClick="btnGrabar_Click" />
                             <asp:Button ID="btnCancelar" runat="server"  Text="Cancelar" Width="100px" />
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
           <asp:LinkButton Text="" ID = "btnPopup2" runat="server" />
            <%--El modalpoput extender : vease el TargetControl que apunta al linkbutton y el popuconttol ID que apunhta al panel--%> 
      <ajaxToolkit:ModalPopupExtender ID="PopMant2" runat="server" BackgroundCssClass="FondoAplicacion"  
        TargetControlID="btnPopup2" PopupControlID="Panel2"  >
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="Panel2" runat="server" CssClass="CajaDialogo" align="center" Style="display:table; background-color: white" Width="700">
           <table style="border: Solid 3px #284775; height: 308px;"
                cellpadding="0" cellspacing="0" >
                <tr style="background-color: #284775">
                    <td colspan="2" style="height: 10%; color: White; font-weight: bold; font-size: larger"
                        align="center">
                        Actualizar Luz Emergencia</td>
                </tr>
                <tr>
                    <td align="right" style="width: 45%" class="labelContenido">
                        &nbsp;</td>
                      <td align="left">
                          &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido" style="width: 45%">ID:</td>
                    <td align="left">
                        <asp:TextBox ID="txtid" runat="server" Width="50px" ReadOnly="True" />
                    </td>
                </tr>
                 <tr>
                    <td align="right" class="auto-style1">
                        Piso :</td>
                    <td align="left" class="auto-style2">
                        <asp:TextBox ID="txtPiso2" runat="server" Width="100px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">
                        Area :
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtArea2" runat="server" Width="450px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">
                        Equipo :
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="cboEquipo2" runat="server" AutoPostBack="True" Width="449px" OnSelectedIndexChanged="cboEquipo2_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
               
                     <tr>
                         <td align="right" class="labelContenido">Estado :</td>
                         <td align="left">
                             <asp:DropDownList ID="cboEstado2" runat="server" AutoPostBack="True" Width="449px" OnSelectedIndexChanged="cboEstado2_SelectedIndexChanged">
                                 <asp:ListItem Value="0">--Seleccione el estado actual del equipo--</asp:ListItem>
                                 <asp:ListItem>OPERATIVO</asp:ListItem>
                                 <asp:ListItem>INOPERATIVO</asp:ListItem>
                                 <asp:ListItem>CAMBIO DE BATERIA</asp:ListItem>
                             </asp:DropDownList>
                         </td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">Observacion :</td>
                    <td align="left">
                        <asp:TextBox ID="txtObs2" runat="server" Height="16px" Width="443px" />
                    </td>
                </tr>

               <tr>
                        <td align="right" class="labelContenido">Imagen : </td>
                        <td align="left" class="auto-style3" >
                            
                            <asp:Image ID="ImageUpload2" runat="server" Style="max-height:200px;"/>
                            <asp:FileUpload ID="btnUpload2" runat="server" class="col-12"/>
                            <asp:Button ID="btnPrev2" runat="server"  Text="Cargar Foto"  class="col-3" OnClick="btnPrev2_Click" />
                            
                        </td>
                    </tr>
              
                     <tr>
                         <td align="right" class="labelContenido">Activo? : </td>
                         <td align="left">
                             <asp:CheckBox ID="chkActivo2" runat="server" />
                         </td>
                     </tr>
                     <tr>
                         <td colspan="2">
                             <asp:Label ID="lblMensajeAct" runat="server" CssClass="labelErrores" Width="400px"></asp:Label>
                         </td>
                     </tr>
                     <tr>
                         <td class="auto-style1">
                             &nbsp;</td>
                         <td class="auto-style1">
                             <asp:Button ID="btnGrabar2" runat="server" Text="Grabar" Width="100px" OnClick="btnGrabar2_Click" />
                             &nbsp;<asp:Button ID="btnEliminar" runat="server" Text="Eliminar" Width="100px" />
&nbsp;<asp:Button ID="btnCancelar2" runat="server"  Text="Cancelar" Width="100px" />
                         </td>
                     </tr>
              
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
              
            </table>
                        
        </asp:Panel>

            <%--Este es el panel  que contiene los mensajes de error--%>
              <asp:LinkButton ID="lnkMensaje" runat="server" ></asp:LinkButton>
               <ajaxToolkit:ModalPopupExtender ID="mpeMensaje" runat="server" TargetControlID="lnkMensaje" 
                    PopupControlID="pnlMensaje" BackgroundCssClass="FondoAplicacion" OkControlID="btnAceptar" 
                     />
<asp:Panel ID="pnlMensaje" runat="server" CssClass="CajaDialogo" Style="display: normal; background-color:white" Width="300"> 
                    <table border="0" width="300px" style="margin: 0px; padding: 0px; background-color:#284775 ; 
                        color: #FFFFFF;"> 
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
                        <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor ="Black" /> 
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
