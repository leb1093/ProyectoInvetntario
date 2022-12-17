<%@ Page Language="C#"  MasterPageFile="~/DemoMaster.master" AutoEventWireup="true" CodeBehind="MenuPlazaLatam.aspx.cs" Inherits="ApliciacionInventario.PlazaLatam.MenuPlazaLatam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tituloForm">
        Luces Emergencia Plaza Latam<tr>
            <td width ="180px">
                <asp:Image ID="Image1" runat="server" Height="285px" 
                    ImageUrl="~/Images/plazaLatam.png" Width="248px" />
            </td>
            <td>
                 
                <asp:TreeView ID="TreeView1" runat="server" CssClass="labelContenido" ImageSet="Arrows">
                    <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                    <Nodes>
                        <asp:TreeNode Text="Mantenimiento" Value="Nuevo nodo">
                            <asp:TreeNode NavigateUrl="~/PlazaLatam/LucesPlazaLatam.aspx" Text="Lista de luces en Plaza Latam" Value="Proveedor"></asp:TreeNode>
                            <asp:TreeNode Text="Graficas" Value="Graficas"></asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode NavigateUrl="~/MenuPrincipal.aspx" Text="Retornar" Value="Retornar"></asp:TreeNode>
                    </Nodes>
                    <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                    <ParentNodeStyle Font-Bold="False" />
                    <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
                </asp:TreeView>
                 
            </td>
        </tr>
    </table>


</asp:Content>