<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mstrpgAdmin.Master" AutoEventWireup="true" CodeBehind="FormatoPreinscripcion.aspx.cs" Inherits="SICOES2018.Reports.FormatoPreinscripcion1" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <CR:CrystalReportViewer ID="crvFormatoPreinscripcion" runat="server" AutoDataBind="true" ToolPanelView="None" />
</asp:Content>
