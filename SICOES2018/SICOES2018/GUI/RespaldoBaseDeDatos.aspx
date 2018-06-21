<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mstrpgAdmin.Master" AutoEventWireup="true" CodeBehind="RespaldoBaseDeDatos.aspx.cs" Inherits="SICOES2018.GUI.RespaldoBaseDeDatos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="w3-col m8">  
  
        <p style="height: 35px; font-weight: bold; font-size: 16pt;  
                    font-family: Times New Roman; color: black">  
                    Realiza un respaldo de la base de datos presionando en el boton 
                </p>    
                <p >  
                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>  
                </p>  

                <p>  
                    <asp:Button ID="btnBackup" runat="server" Text="Backup DataBase" OnClick="btnBackup_Click" />  
                </p>  

    </div>  
   
                
</asp:Content>
