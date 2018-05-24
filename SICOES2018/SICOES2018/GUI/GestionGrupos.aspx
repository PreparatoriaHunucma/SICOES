<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mstrpgAdmin.Master" AutoEventWireup="true" CodeBehind="GestionGrupos.aspx.cs" Inherits="SICOES2018.GUI.GestionGrupos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>Gestión de grupos</h2>
    <div class="w3-row">
        <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
            <h4>DATOS DEL GRUPO</h4>
            <hr style="margin: 5px" />
            <asp:UpdatePanel ID="upGrupos" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="w3-row">
                        <div class="w3-padding w3-col m6">
                            <%--                            <asp:Label ID="lbNomCiclo" runat="server" Text="Nombre del ciclo escolar" Font-Bold="true"></asp:Label>
                            <asp:RequiredFieldValidator ID="rqNomCiclo" runat="server" ErrorMessage="¡Ingrese un nombre!" ControlToValidate="txtNomCiclo" ForeColor="Red" Font-Size="Small" Height="10px" ValidationGroup="vlgrCiclo"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtNomCiclo" runat="server" CssClass="w3-input w3-margin-bottom" placeholder="Ciclo escolar 20XX - 20XX"></asp:TextBox>
                            <asp:Button ID="btnAddCiclo" runat="server" Text="Crear ciclo escolar" CssClass="w3-button w3-amber w3-hover-blue w3-margin" Width="93%" OnClick="btnAddCiclo_Click" ValidationGroup="vlgrCiclo" />
                            <asp:Button ID="btnModCiclo" runat="server" Text="Modificar información del ciclo escolar" CssClass="w3-button w3-amber w3-hover-blue w3-margin" Width="93%" Visible="false" OnClick="btnModCiclo_Click" ValidationGroup="vlgrCiclo" />--%>
                            <asp:Label ID="lbCicloGrupo" runat="server" Text="Ciclo escolar" Font-Bold="true"></asp:Label>
                            <asp:DropDownList ID="ddlCicloGrupo" runat="server" CssClass="w3-input"></asp:DropDownList>
                            <asp:Label ID="lbPeriodoGrupo" runat="server" Text="Periodo escolar" Font-Bold="true" CssClass="w3-margin-left"></asp:Label>
                            <asp:DropDownList ID="ddlPeriodoGrupo" runat="server" CssClass="w3-input w3-margin-left w3-margin-bottom"></asp:DropDownList>
                            <asp:Label ID="lbSemestreGrupo" runat="server" Text="Semestre escolar" Font-Bold="true"></asp:Label>
                            <asp:DropDownList ID="ddlSemestreGrupo" runat="server" CssClass="w3-input w3-margin-bottom"></asp:DropDownList>
                            <asp:Label ID="lbPlanGrupo" runat="server" Text="Plan de estudios" Font-Bold="true"></asp:Label>
                            <asp:DropDownList ID="ddlPlanGrupo" runat="server" CssClass="w3-input"></asp:DropDownList>
                        </div>
                        <div class="w3-padding w3-col m6">
                            <%--                            <asp:Label ID="lbFechaInicio" runat="server" Text="Inicio del ciclo" Font-Bold="true"></asp:Label>
                            <asp:RequiredFieldValidator ID="rqFechaInicio" runat="server" ErrorMessage="¡Ingrese una fecha!" ControlToValidate="txtFechaInicioCiclo" ForeColor="Red" Font-Size="Small" Height="10px" ValidationGroup="vlgrCiclo"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtFechaInicioCiclo" runat="server" CssClass="w3-input w3-margin-bottom" TextMode="Date"></asp:TextBox>
                            <asp:Label ID="lbFechaFin" runat="server" Text="Fin del ciclo" Font-Bold="true"></asp:Label>
                            <asp:RequiredFieldValidator ID="rqFechaFin" runat="server" ErrorMessage="¡Ingrese una fecha!" ControlToValidate="txtFechaFinCiclo" ForeColor="Red" Font-Size="Small" Height="10px" ValidationGroup="vlgrCiclo"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtFechaFinCiclo" runat="server" CssClass="w3-input w3-margin-bottom" TextMode="Date"></asp:TextBox>
                            <asp:CheckBox ID="checkStatusCiclo" runat="server" Text="  Estado del ciclo escolar" Font-Bold="true" />--%>
                        </div>
                    </div>
                    <div class="w3-row">
                        <div class="w3-col m12 w3-padding">
                            <%--                            <asp:Label ID="lbCiclosRegistrados" runat="server" Text="Ciclos escolares registrados" Font-Bold="true"></asp:Label>
                            <div class="w3-responsive">
                                <asp:GridView ID="gvCiclos" runat="server" AutoGenerateColumns="False" CellPadding="6"
                                    CssClass="w3-table w3-striped w3-border" GridLines="None" ShowHeaderWhenEmpty="True" AllowPaging="true" PageSize="5" OnPageIndexChanging="gvCiclos_PageIndexChanging" OnRowCommand="gvCiclos_RowCommand" DataKeyNames="IDCicloEscolar">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("IDCicloEscolar") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Nombre">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Nombre") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha de inicio">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("FechaInicio") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha de finalización">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("FechaFin") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Estado">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Estado") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-success btn-sm" Text="<i class='fa fa-eye w3-large'></i>" CausesValidation="False" CommandName="SelectCiclo" Visible="true" />
                                    </Columns>
                                </asp:GridView>
                            </div>--%>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <%--                    <asp:AsyncPostBackTrigger ControlID="btnAddCiclo" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnModCiclo" EventName="Click" />--%>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>


</asp:Content>
