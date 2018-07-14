<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mstrpgAdmin.Master" AutoEventWireup="true" CodeBehind="CredencialAlumnos.aspx.cs" Inherits="SICOES2018.GUI.CredencialAlumnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="w3-row">
        <div class="w3-col m8">
            <h2>Credenciales De Alumnos</h2>
        </div>
    </div>

    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right w3-col m8">
         <div class="w3-row">
             <p>Seleccione a los alumnos cuyas credenciales desea generar presionando el boton situado del lado derecho de cada fila, estas aparecerán en la lista situada a la derecha. 
                 <br />
                 <br />
                 Para crear las credenciales presione en el boton "Generar"</p>
                </div>
        </div>
     <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right w3-margin-left w3-col m3">
        <asp:ListBox runat="server" ID="ListaMaestros" Width="200px" Height="115px">
            

        </asp:ListBox>
        <asp:Label runat="server" ID="lista" Text=" " visible =" false">


        </asp:Label>
        </div>

     <div class="w3-row">

        <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right w3-col m11">
                        <div class="w3-padding w3-col m12">
    <asp:GridView ID="gvAlumnos" runat="server" AutoGenerateColumns="False" CellPadding="6"
                                                CssClass="w3-table w3-striped w3-border" Style="min-height: 288px" GridLines="None" ShowHeaderWhenEmpty="True" AllowPaging="true" PageSize="5" OnPageIndexChanging="gvAlumnos_PageIndexChanging" OnRowCommand="gvAlumnos_RowCommand" DataKeyNames="IDAlumno">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("IDAlumno") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Nombre">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("NomAlumno") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Primer apellido">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("ApePatAlumno") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Segundo apellido">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("ApeMatAlumno") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                  <%--  <asp:TemplateField HeaderText="Fecha de Nacimiento">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("FechaNacAlumno") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Nombre del tutor">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("NomTutorAlumno") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Telefono del tutor">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("TelTutorAlumno") %>'></asp:Label>
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
