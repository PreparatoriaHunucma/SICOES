<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mstrpgAdmin.Master" AutoEventWireup="true" CodeBehind="GestionConcentradoCalificaciones.aspx.cs" Inherits="SICOES2018.GUI.GestionConcentradoCalificaciones" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>Concentrado de calificaciones</h2>

    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <div class="w3-row">
            <h4>CONCENTRADO DE CALIFICACIONES</h4>
        </div>
        <hr style="margin: 5px" />
        <asp:UpdatePanel ID="upConCalif" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

                <div class="w3-row w3-padding">
                    <div class="w3-col m4">
                        <asp:Label ID="lbPeriodoCalif" runat="server" Text="Periodo escolar" Font-Bold="true" CssClass="w3-margin-left"></asp:Label>
                        <asp:DropDownList ID="ddlPeriodoCalif" runat="server" CssClass="w3-input w3-margin-left w3-margin-bottom" OnSelectedIndexChanged="ddlPeriodoCalif_SelectedIndexChanged" AppendDataBoundItems="true" AutoPostBack="true" Width="90%"></asp:DropDownList>
                    </div>

                    <div class="w3-col m4">
                        <asp:Label ID="lbGrupo" runat="server" Text="Grupo" Font-Bold="true" CssClass="w3-margin-left"></asp:Label>
                        <asp:DropDownList ID="ddlGrupo" runat="server" CssClass="w3-input w3-margin-left w3-margin-bottom" OnSelectedIndexChanged="ddlGrupo_SelectedIndexChanged" AppendDataBoundItems="true" AutoPostBack="true" Width="90%"></asp:DropDownList>
                    </div>

                    <div class="w3-col m4">
                        <asp:Label ID="lbAsignatura" runat="server" Text="Asignatura" Font-Bold="true" CssClass="w3-margin-left"></asp:Label>
                        <asp:DropDownList ID="ddlAsignatura" runat="server" CssClass="w3-input w3-margin-left w3-margin-bottom" OnSelectedIndexChanged="ddlAsignatura_SelectedIndexChanged" AppendDataBoundItems="true" AutoPostBack="true" Width="90%"></asp:DropDownList>
                    </div>
                </div>
                <div class="w3-row w3-padding">
                    
                    <asp:Button OnClick="btnImprimir_Click" CssClass=" w3-third w3-button w3-amber w3-hover-blue w3-right" ID="btnImprimir" runat="server" Text="Imprimir Concentrado" CausesValidation="true" Width="25%" AutoPostBack="false" />
                </div>
                <div class="w3-row w3-padding">
                    <asp:GridView ID="gvConCalif" runat="server" CssClass="w3-table w3-striped w3-border" Style="min-height: 100%" AutoGenerateColumns="False" GridLines="None" ShowHeaderWhenEmpty="True" AllowPaging="true" PageSize="30" OnPageIndexChanging="gvConCalif_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_IDAddEscPro" runat="server" Text='<%#Eval("IDAlumno") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_NameAddEscPro" runat="server" Text='<%#Eval("NomAlumno") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Matricula">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_ClaveAddEscPro" runat="server" Text='<%#Eval("Matricula") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="1er Reporte">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_ClaveAddEscPro" runat="server" Text='<%#Eval("Reporte1") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="2do Reporte">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_ClaveAddEscPro" runat="server" Text='<%#Eval("Reporte2") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="3er Reporte">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_ClaveAddEscPro" runat="server" Text='<%#Eval("Ordinario") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Inasistencias totales">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_ClaveAddEscPro" runat="server" Text='<%#Eval("Inasistencias") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlPeriodoCalif" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddlGrupo" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddlAsignatura" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>



</asp:Content>
