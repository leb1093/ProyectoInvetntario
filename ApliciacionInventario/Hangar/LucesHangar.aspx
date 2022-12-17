<%@ Page Language="C#" MasterPageFile="~/DemoMaster.master" AutoEventWireup="true" CodeBehind="LucesHangar.aspx.cs" Inherits="ApliciacionInventario.Hangar.LucesHangar" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

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
            width: 458px;
        }
        .auto-style4 {
            height: 23px;
            width: 458px;
        }
        .auto-style5 {
            font-family: Verdana;
            font-size: 10pt;
            color: #993366;
            height: 23px;
            width: 552px;
        }
        .auto-style6 {
            height: 10%;
        }
        .auto-style7 {
            width: 45%;
            height: 22px;
        }
        .auto-style8 {
            width: 458px;
            height: 22px;
        }
        .auto-style9 {
            width: 45%;
            height: 20px;
        }
        .auto-style10 {
            height: 20px;
        }
        .auto-style11 {
            color: black;
        }
    </style>

        <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
        <script type="text/javascript">

            // Load the Visualization API and the corechart package.
            google.charts.load('current', { 'packages': ['corechart'] });

            // Set a callback to run when the Google Visualization API is loaded.
            google.charts.setOnLoadCallback(drawChart);

            // Callback that creates and populates a data table,
            // instantiates the pie chart, passes in the data and
            // draws it.
            function drawChart() {

                // Create the data table.
                var data = new google.visualization.DataTable();
                data.addColumn('string', 'Topping');
                data.addColumn('number', 'Slices');
                data.addRows([
                    ['Mushrooms', 3],
                    ['Onions', 1],
                    ['Olives', 1],
                    ['Zucchini', 1],
                    ['Pepperoni', 2]
                ]);

                // Set chart options
                var options = {
                    'title': 'How Much Pizza I Ate Last Night',
                    'width': 400,
                    'height': 300
                };

                // Instantiate and draw our chart, passing in some options.
                var chart = new google.visualization.PieChart(document.getElementById('chart_div'));
                chart.draw(data, options);
            }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--Boton ( o link button ) para mostrar el modal de insercion PopMant del nuevo registro--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnPrev"  />
            <asp:PostBackTrigger ControlID="btnPrev2"  />
        </Triggers>
        <ContentTemplate>

            <%--Aqui va el diseño del formulario--%>
            <div >
                <h2>MANTENIMIENTO DE LUCES EMERGENCIA HANGAR</h2>
            </div>

            <%--Boton ( o link button ) para mostrar el modal de insercion PopMant del nuevo registro--%>
            <br />
            <asp:Button ID="btnNuevo" class="btn btn-primary" runat="server" Text="Nueva Luz Emergencia" OnClick="btnNuevo_Click" />
            <br />
            <br />
            <%--El grid view para el listado de proveedores, con la primera columna de tipo Button, con el CommanName (recomendado) Editar
                   y con un icono asociado a la accion de editar--%>
            <table class="auto-style5">
                <tr>
                    <td style="color:black">Ingrese área:</td>
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
                </tr>
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
            <asp:Chart ID="Chart1" runat="server" Palette="Chocolate" hidden>
                <series>
                    <asp:Series Name="Series1">
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </chartareas>
            </asp:Chart>
            <asp:Chart ID="Chart2" runat="server" hidden>
                <Series>
                    <asp:Series Name="Series1">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <asp:Chart ID="Chart3" runat="server" Palette="SeaGreen" hidden>
                <Series>
                    <asp:Series Name="Series1">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <div id="chart_div" hidden></div >
            <br />
            <br />
            <asp:LinkButton Text="" ID="btnPopup" runat="server" />
            <%--El modalpoput extender : vease el TargetControl que apunta al linkbutton y el popuconttol ID que apunhta al panel--%>

            <ajaxToolkit:ModalPopupExtender ID="PopMant" runat="server" BackgroundCssClass="FondoAplicacion"
                TargetControlID="btnPopup" PopupControlID="Panel1">
            </ajaxToolkit:ModalPopupExtender>
            <asp:Panel ID="Panel1" runat="server" CssClass="CajaDialogo" align="center" Style="display: table; background-color: white" Width="700">

                <table style="border: Solid 3px #284775; height: 308px;"
                    cellpadding="0" cellspacing="0">
                    <tr style="background-color: #284775">
                        <td colspan="2" style="color: White; font-weight: bold; font-size: larger"
                            align="center" class="auto-style6">Nueva Luz Emergencia</td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style7"></td>
                        <td align="left" class="auto-style8"></td>
                    </tr>
                    <tr>
                        <td align="right" class="labelContenido">Piso :</td>
                        <td align="left" class="auto-style4">
                            <asp:TextBox ID="txtPiso" runat="server" Width="100px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="labelContenido">Area :
                        </td>
                        <td align="left" class="auto-style3">
                            <asp:TextBox ID="txtArea" runat="server" Width="450px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="labelContenido">Equipo :
                        </td>
                        <td align="left" class="auto-style3">
                            <asp:DropDownList ID="cboEquipo" runat="server" AutoPostBack="True" Width="449px" OnSelectedIndexChanged="cboEquipo_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" class="labelContenido">Estado :</td>
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
                        <td align="left" class="auto-style3">
                            <asp:TextBox ID="txtObs" runat="server" Height="23px" Width="443px" />
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
                        <td align="left" class="auto-style3">
                            <asp:CheckBox ID="chkActivo" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblMensajeIns" runat="server" CssClass="labelErrores" Width="400px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style5">
                            <asp:Button ID="btnGrabar" runat="server" Text="Grabar" Width="100px" OnClick="btnGrabar_Click" />
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="100px" OnClick="btnCancelar_Click" />
                        </td>
                    </tr>

                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style5">&nbsp;</td>
                    </tr>

                </table>

            </asp:Panel>

            <%-- Aqui va el popup de Edicion con su codigo--%>
            <%--el link button o cualquiero otro control para el manejo del modal--%>
            <asp:LinkButton Text="" ID="btnPopup2" runat="server" />
            <%--El modalpoput extender : vease el TargetControl que apunta al linkbutton y el popuconttol ID que apunhta al panel--%>
            <ajaxToolkit:ModalPopupExtender ID="PopMant2" runat="server" BackgroundCssClass="white"
                TargetControlID="btnPopup2" PopupControlID="Panel2">
            </ajaxToolkit:ModalPopupExtender>
            <asp:Panel ID="Panel2" runat="server" CssClass="CajaDialogo" align="center" Style="display: table;  background-color: white" Width="700">
                <table style="border: Solid 3px ; background-color: white; height: 308px;"
                    cellpadding="0" cellspacing="0">
                    <tr style="background-color: #284775">
                        <td colspan="2" style="height: 10%; color: white; font-weight: bold; font-size: larger"
                            align="center">Actualizar Luz Emergencia</td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style9"></td>
                        <td align="left" class="auto-style10"></td>
                    </tr>
                    <tr>
                        <td align="right" class="labelContenido" style="width: 45%">ID:</td>
                        <td align="left">
                            <asp:TextBox ID="txtid" runat="server" Width="50px" ReadOnly="True" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="labelContenido">Piso :</td>
                        <td align="left" class="auto-style2">
                            <asp:TextBox ID="txtPiso2" runat="server" Width="100px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="labelContenido">Area :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtArea2" runat="server" Width="450px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="labelContenido">Equipo :
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
                            <asp:TextBox ID="txtObs2" runat="server" Height="21px" Width="443px" />
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
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style1">
                            <asp:Button ID="btnGrabar2" runat="server" Text="Grabar" Width="100px" OnClick="btnGrabar2_Click" />
                            &nbsp;<asp:Button ID="btnEliminar" runat="server" Text="Eliminar" Width="100px" />
                            &nbsp;<asp:Button ID="btnCancelar2" runat="server" Text="Cancelar" Width="100px" />
                        </td>
                    </tr>

                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style1">&nbsp;</td>
                    </tr>

                </table>

            </asp:Panel>

            <%--Este es el panel  que contiene los mensajes de error--%>
            <asp:LinkButton ID="lnkMensaje" runat="server"></asp:LinkButton>
            <ajaxToolkit:ModalPopupExtender ID="mpeMensaje" runat="server" TargetControlID="lnkMensaje"
                PopupControlID="pnlMensaje" BackgroundCssClass="FondoAplicacion" OkControlID="btnAceptar" />
            <asp:Panel ID="pnlMensaje" runat="server" CssClass="CajaDialogo" Style="display: normal; background-color:white" Width="300">
                <table border="0" width="300px" style="margin: 0px; padding: 0px; background-color: #284775; color: #FFFFFF;">
                    <tr >
                        <td align="center" class="auto-style2" >
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



<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        console.log("ready!");
    });
    
    //function readURL(input) {
    //    if (input.files && input.files[0]) {
    //        var reader = new FileReader();

    //        reader.onload = function (e) {
    //            $('#ImageUpload').attr('src', e.target.result);
    //        }

    //        reader.readAsDataURL(input.files[0]);
    //    }
    //};

    $("#btnUpload").change(function () {
            debugger
            readURL(this);
        });
</script>

</asp:Content>


