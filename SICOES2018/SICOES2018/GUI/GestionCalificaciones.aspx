<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mstrpgAdmin.Master" AutoEventWireup="true" CodeBehind="GestionCalificaciones.aspx.cs" Inherits="SICOES2018.GUI.GestionCalificaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>Gestión de calificaciones</h2>

    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <div class="w3-row">
            <h4>APLICACIÓN DE CALIFICACIONES</h4>
        </div>
        <hr style="margin: 5px" />
        <asp:UpdatePanel ID="upCalif" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

                <div class="w3-row w3-padding">
                    <div class="w3-col m4">
                        <asp:Label ID="lbPeriodoCalif" runat="server" Text="Periodo escolar" Font-Bold="true" CssClass="w3-margin-left"></asp:Label>
                        <asp:DropDownList ID="ddlPeriodoCalif" runat="server" CssClass="w3-input w3-margin-left w3-margin-bottom" OnSelectedIndexChanged="ddlPeriodoCalif_SelectedIndexChanged" AppendDataBoundItems="true" AutoPostBack="true" Width="90%"></asp:DropDownList>
                    </div>

                    <div class="w3-col m4">
                        <asp:Label ID="lbGrupoAsig" runat="server" Text="Grupo - Asignatura" Font-Bold="true" CssClass="w3-margin-left"></asp:Label>
                        <asp:DropDownList ID="ddlGrupoAsig" runat="server" CssClass="w3-input w3-margin-left w3-margin-bottom" OnSelectedIndexChanged="ddlGrupoAsig_SelectedIndexChanged" AppendDataBoundItems="true" AutoPostBack="true" Width="90%"></asp:DropDownList>
                    </div>

                    <div class="w3-col m4">
                        <asp:Label ID="lbMomento" runat="server" Text="Momento de calificacion" Font-Bold="true" CssClass="w3-margin-left"></asp:Label>
                        <asp:DropDownList ID="ddlMomento" runat="server" CssClass="w3-input w3-margin-left w3-margin-bottom" OnSelectedIndexChanged="ddlMomento_SelectedIndexChanged" AppendDataBoundItems="true" AutoPostBack="true" Width="90%"></asp:DropDownList>
                    </div>
                </div>

            </ContentTemplate>
            <Triggers>
<%--                <asp:AsyncPostBackTrigger ControlID="ddlCicloGrupo" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddlPeriodoGrupo" EventName="SelectedIndexChanged" />--%>
            </Triggers>
        </asp:UpdatePanel>
    </div>




</asp:Content>
