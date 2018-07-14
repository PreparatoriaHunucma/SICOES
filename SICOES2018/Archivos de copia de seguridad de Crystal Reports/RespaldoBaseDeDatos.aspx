<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mstrpgAdmin.Master" AutoEventWireup="true" CodeBehind="RespaldoBaseDeDatos.aspx.cs" Inherits="SICOES2018.GUI.RespaldoBaseDeDatos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <div class="w3-row">
             <div class="w3-col m4">
                        <h4>RESPALDAR BASE DE DATOS</h4>
             </div>
             <div class="w3-row">
                 <h6>Realize un respaldo de la base de datos. Presione el boton y luego descargue el archivo generado</h6>
                 <br />
                 <br />
                 <br />
                 <br />
                  <br />
                 <br />
                 <br />
                 <br />
                 <asp:Button ID="btnBackup" runat="server" Text="Respaldar" OnClick="btnBackup_Click" CssClass="w3-padding w3-button w3-blue w3-hover-amber w3-display-middle" Style="width: 300px" /> 
                 <asp:Label runat="server" ID="bdok" CssClass="w3-padding w3-display-bottommiddle"></asp:Label>
             </div>
                     
          
        </div>  
      </div>


    <script>

        function respaldosuccessalert() {
            swal({
                title: '¡Exito!',
                text: 'La base de datos ha sido respaldada con exito',
                type: 'success',
                showConfirmButton: false,
                timer: 2000
            });
        }

        function erroralert() {
            swal({
                title: 'Oh oh',
                text: 'Hubo un problema al guardar la información, verifica los datos',
                type: 'error'
            });
        }

    </script>
   
                
</asp:Content>
