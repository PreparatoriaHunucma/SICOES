<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pruebasinmaster.aspx.cs" Inherits="SICOES2018.GUI.pruebasinmaster" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <div>  
  
        <asp:TextBox runat="server" Text="IDAlumno" ID="Alumno"></asp:TextBox>
        <asp:TextBox runat="server" Text ="IDDocumentos" ID="Documento"></asp:TextBox>
            
    <asp:Button runat="server" Text="Soy un boton, presioname!" ID="ButtonReporte" OnClick="ButtonReporte_Click" />
      
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server"   
            AutoDataBind="true" PrintMode="ActiveX" />  
                 
    </div>  
        </div>
    </form>
</body>
</html>
