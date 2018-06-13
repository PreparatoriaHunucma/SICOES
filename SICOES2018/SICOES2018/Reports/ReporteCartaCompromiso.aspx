<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mstrpgAdmin.Master" AutoEventWireup="true" CodeBehind="ReporteCartaCompromiso.aspx.cs" Inherits="SICOES2018.GUI.Prueba_de_carta" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="w3-col m8">  
  
      <%--  <asp:TextBox runat="server" Text="IDAlumno" ID="Alumno"></asp:TextBox>
        <asp:TextBox runat="server" Text ="IDDocumentos" ID="Documento"></asp:TextBox>--%>
            
  <%--  <asp:Button runat="server" Text="Soy un boton, presioname!" ID="ButtonReporte" OnClick="ButtonReporte_Click" />--%>
      
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server"   
            AutoDataBind="true" width="100%" ToolPanelView="None"/>  
        
    </div>  
</asp:Content>
