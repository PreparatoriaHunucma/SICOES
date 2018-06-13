<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mstrpgAdmin.Master" AutoEventWireup="true" CodeBehind="GestionCalificaciones.aspx.cs" Inherits="SICOES2018.GUI.GestionCalificaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>Gestión de calificaciones</h2>

    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <div class="w3-row">
            <h4>APLICACIÓN DE CALIFICACIONES</h4>
        </div>
        <hr style="margin: 5px" />

        <div class="w3-row w3-padding">
            <div class="w3-col m4">
                <div class="w3-row">
                    <asp:Label ID="lbPeriodoCalif" runat="server" Text="Periodo escolar" Font-Bold="true" CssClass="w3-margin-left"></asp:Label>
                    <asp:DropDownList ID="ddlPeriodoCalif" runat="server" CssClass="w3-input w3-margin-left w3-margin-bottom" OnSelectedIndexChanged="ddlPeriodoCalif_SelectedIndexChanged" AppendDataBoundItems="true" AutoPostBack="true" Width="90%"></asp:DropDownList>
                </div>

                <div class="w3-row">
                    <asp:Label ID="lbMomento" runat="server" Text="Momento de calificacion" Font-Bold="true" CssClass="w3-margin-left"></asp:Label>
                    <asp:DropDownList ID="ddlMomento" runat="server" CssClass="w3-input w3-margin-left w3-margin-bottom" OnSelectedIndexChanged="ddlMomento_SelectedIndexChanged" AppendDataBoundItems="true" AutoPostBack="true" Width="90%"></asp:DropDownList>
                </div>
            </div>
            <div class="w3-col m8">
                <div class="w3-row">
                    <asp:Label ID="lbGrupo" runat="server" Text="Grupo" Font-Bold="true" CssClass="w3-margin-left"></asp:Label>
                    <asp:DropDownList ID="ddlGrupo" runat="server" CssClass="w3-input w3-margin-left w3-margin-bottom" OnSelectedIndexChanged="ddlGrupoAsig_SelectedIndexChanged" AppendDataBoundItems="true" AutoPostBack="true" Width="90%"></asp:DropDownList>
                </div>

                <div class="w3-row">
                    <asp:Label ID="lbAsig" runat="server" Text="Asignatura" Font-Bold="true" CssClass="w3-margin-left"></asp:Label>
                    <asp:DropDownList ID="ddlAsig" runat="server" CssClass="w3-input w3-margin-left w3-margin-bottom" OnSelectedIndexChanged="ddlAsig_SelectedIndexChanged" AppendDataBoundItems="true" AutoPostBack="true" Width="90%"></asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="w3-row w3-padding">
            <div id="tablacalif"></div>
        </div>

        <script type="text/javascript">
            function tablacalificaciones() {
                configuracion = {
                    data: <%= ObtenerRegistros()%>,
                    colWidths: [0.1, 500, 100, 100],
                    colHeaders: ['IDCalificacion', 'Alumno', 'Calificación', 'Inasistencias'],
                    columns: [
                        { data: 'IDCalificacion', readOnly: true },
                        { data: 'Alumno', readOnly: true },
                        { data: 'Calificacion', type: 'numeric', format: '0.00' },
                        { data: 'Inasistencias', type: 'numeric', format: '0' }
                    ],
                    afterCreateRow: function (index, numberOfRows) {
                        DatosPersonas.splice(index, numberOfRows);
                    },
                    afterChange: function (registrosModificados, accionesHandsontable) {
                        if (accionesHandsontable != 'loadData') {
                            //Leer todos los registros modificados
                            registrosModificados.forEach(function (elemento) {
                                //console.log(elemento);
                                var fila = tblExcel.getData()[elemento[0]];
                                console.log(fila);
                                $.ajax({
                                    type: "POST",
                                    url: '<%= ResolveUrl("GestionCalificaciones.aspx/ModificarRegistro") %>',
                                    data: JSON.stringify({ tblExcel: [fila] }),
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    success: function (respuesta) { console.log("Informacion actualizada:" + respues.d); },
                                    failure: function (respuesta) { console.log("Hay una falla:" + respuesta.d); }
                                });
                            });
                        }
                    }
                };
                tblExcel = new Handsontable(document.getElementById('tablacalif'), configuracion);
                tblExcel.render();
            }
        </script>
    </div>






</asp:Content>
