<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mstrpgAdmin.Master" AutoEventWireup="true" CodeBehind="CredencialMaestros.aspx.cs" Inherits="SICOES2018.GUI.CredencialMaestros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="w3-row">
        <div class="w3-col m8">
            <h2>Credenciales De Personal</h2>
        </div>
    </div>

    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right w3-col m8">
         <div class="w3-row">
             <p>Seleccione a las personas cuyas credenciales desea generar presionando el boton situado del lado derecho de cada fila, estas aparecerán en la lista situada a la derecha. 
                 <br />
                 <br />
                 Para crear las credenciales presione en el boton "Generar"</p>
                </div>
        </div>
    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right w3-margin-left w3-col m3">
        <asp:ListBox runat="server" ID="ListaMaestros" Width="200px" Height="115px">
            

        </asp:ListBox>
        <asp:Label runat="server" ID="lista" Text=" " Visible="false" >


        </asp:Label>
        </div>
    <div class="w3-row">

        <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right w3-col m11">
                        <div class="w3-padding w3-col m12">
                            <asp:Label ID="lbAsigRegis" runat="server" Text="Asignaturas" Font-Bold="true" CssClass="w3-margin-bottom"></asp:Label>
                            <asp:GridView ID="gvAsignaturas" runat="server" AutoGenerateColumns="False" CellPadding="6"
                                CssClass="w3-table w3-striped w3-border" GridLines="None" ShowHeaderWhenEmpty="True" AllowPaging="true" PageSize="6" OnPageIndexChanging="gvAsignaturas_PageIndexChanging" OnRowCommand="gvAsignaturas_RowCommand" DataKeyNames="IDMaestro">
                                <Columns>
                                            <asp:TemplateField HeaderText="ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("IDMaestro") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nombre">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("NomMaestro") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Primer apellido">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("ApePatMaestro") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Segundo apellido">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("ApeMatMaestro") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--  <asp:TemplateField HeaderText="Fecha de Nacimiento">
                                                      <ItemTemplate>
                                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("FechaNacAlumno") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                            <%--<asp:TemplateField HeaderText="Usuario">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Usuario") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                           <%-- <asp:TemplateField HeaderText="Estatus">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("StatusMaestro") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-success btn-sm" Text="<i class='fa fa-eye w3-large'></i>" CausesValidation="False" CommandName="SelectAlum" Visible="true" />
                                        </Columns>
                            </asp:GridView>
                        </div>
            </div>
                    </div>
    <div class="w3-row">
         <asp:Button ID="btnConsulta" runat="server" Text="Generar" CssClass="w3-button w3-amber w3-hover-blue w3-margin w3-animate-right" Width="80%" OnClick="btnElimAsig_Click" ValidationGroup="vlgrAsig" />
    </div>
</asp:Content>
