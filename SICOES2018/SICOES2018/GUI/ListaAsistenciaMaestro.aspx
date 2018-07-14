<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mstrpgAdmin.Master" AutoEventWireup="true" CodeBehind="ListaAsistenciaMaestro.aspx.cs" Inherits="SICOES2018.GUI.ListaAsistenciaMaestro" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>Lista de asistencia</h2>

    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <div class="w3-row">
            <h4>GENERAR LISTA DE ASISTENCIA</h4>
        </div>
        <hr style="margin: 5px" />
        <asp:UpdatePanel ID="upGrupos" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="w3-row w3-padding">
                    <div class="w3-col m4">
                        <asp:Label ID="lbPeriodo" runat="server" Text="Periodo escolar" Font-Bold="true" CssClass="w3-margin-left"></asp:Label>
                        <asp:DropDownList ID="ddlPeriodo" runat="server" CssClass="w3-input w3-margin-left w3-margin-bottom" OnSelectedIndexChanged="ddlPeriodo_SelectedIndexChanged" AppendDataBoundItems="true" AutoPostBack="true" Width="90%"></asp:DropDownList>
                    </div>

                    <div class="w3-col m4">
                        <asp:Label ID="lbGrupo" runat="server" Text="Grupo" Font-Bold="true" CssClass="w3-margin-left"></asp:Label>
                        <asp:DropDownList ID="ddlGrupo" runat="server" CssClass="w3-input w3-margin-left w3-margin-bottom" OnSelectedIndexChanged="ddlGrupo_SelectedIndexChanged" AppendDataBoundItems="true" AutoPostBack="true" Width="90%"></asp:DropDownList>
                    </div>

                    <div class="w3-col m4">
                        <asp:Label ID="lbAsig" runat="server" Text="Asignatura" Font-Bold="true" CssClass="w3-margin-left"></asp:Label>
                        <asp:DropDownList ID="ddlAsig" runat="server" CssClass="w3-input w3-margin-left w3-margin-bottom" OnSelectedIndexChanged="ddlAsig_SelectedIndexChanged" AppendDataBoundItems="true" AutoPostBack="true" Width="90%"></asp:DropDownList>
                    </div>
                </div>
<%--                <div class="w3-row">
                    <asp:Button runat="server" ID="Generar" OnClick="Generar_Click" />
                </div>--%>
                <div class="w3-row w3-padding">
                    <CR:CrystalReportViewer ID="ListaDeAsistencia" runat="server" AutoDataBind="true" ToolPanelView="None" />
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlPeriodo" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddlGrupo" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddlAsig" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>

    </div>

</asp:Content>
