<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mstrpgAdmin.Master" AutoEventWireup="true" CodeBehind="GestionCalificaciones.aspx.cs" Inherits="SICOES2018.GUI.GestionCalificaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>Gestión de calificaciones</h2>

    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <div class="w3-row">
            <h4>APLICACIÓN DE CALIFICACIONES</h4>
        </div>
        <hr style="margin: 5px" />

        <asp:HiddenField runat="server" ID="txtVal1" />
        <asp:HiddenField runat="server" ID="txtValFechas1" />
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
        <div class="w3-row">
            <div class="w3-col m4 w3-padding">
                <asp:Button OnClick="btnConcentradoParcial_Click" CssClass=" w3-third w3-button w3-amber w3-hover-blue w3-right" ID="btnConcentradoParcial" runat="server" Text="Imprimir concentrado del reporte" CausesValidation="true" Width="100%" AutoPostBack="false" />
            </div>
            <div class="w3-col m4 w3-padding">
                <asp:Button OnClick="btnConcentradoFinal_Click" CssClass=" w3-third w3-button w3-amber w3-hover-blue w3-right" ID="btnConcentradoFinal" runat="server" Text="Imprimir concentrado final" CausesValidation="true" Width="100%" AutoPostBack="false" />
            </div>
        </div>

        <script type="text/javascript">
            configuracion;
            function tablacalificaciones() {
                if (document.getElementById('<%=txtValFechas1.ClientID%>').value == 1) {
                    configuracion = {
                        data: <%= ObtenerRegistros()%>,
                        colWidths: [100, 0.1, 0.1, 500, 100, 100],
                        colHeaders: ['Foto', 'IDAlumno', 'IDCalificacion', 'Alumno', 'Calificación', 'Inasistencias'],
                        columns: [
                            { data: 'FotoTabla', renderer: 'html', readOnly: true },
                            { data: 'IDAlumno', readOnly: true },
                            { data: 'IDCalificacion', readOnly: true },
                            { data: 'Alumno', readOnly: true },
                            { data: 'Calificacion', type: 'numeric', format: '0' },
                            { data: 'Inasistencias', type: 'numeric', format: '0' }
                        ],
                        beforeChange: function (changes, source) {
                            for (var i = changes.length - 1; i >= 0; i--) {
                                // gently don't accept the word "foo" (remove the change at index i)
                                if (changes[i][3] > document.getElementById('<%=txtVal1.ClientID%>').value) {
                                    changes.splice(i, 1);
                                }
                                // if any of pasted cells contains the word "nuke", reject the whole paste
                                else if (changes[i][3] === 'nuke') {
                                    return false;
                                }
                            }
                        },
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
                }
                if (document.getElementById('<%=txtValFechas1.ClientID%>').value == 0) {
                    configuracion = {
                        data: <%= ObtenerRegistros()%>,
                        colWidths: [0.1, 100, 0.1, 500, 100, 100],
                        colHeaders: ['IDAlumno', 'Foto', 'IDCalificacion', 'Alumno', 'Calificación', 'Inasistencias'],
                        columns: [
                            { data: 'IDAlumno', readOnly: true },
                            { data: 'FotoTabla', renderer: 'html', readOnly: true },
                            { data: 'IDCalificacion', readOnly: true },
                            { data: 'Alumno', readOnly: true },
                            { data: 'Calificacion', readOnly: true, type: 'numeric', format: '0' },
                            { data: 'Inasistencias', readOnly: true, type: 'numeric', format: '0' }
                        ],
                        beforeChange: function (changes, source) {
                            for (var i = changes.length - 1; i >= 0; i--) {
                                // gently don't accept the word "foo" (remove the change at index i)
                                if (changes[i][3] > document.getElementById('<%=txtVal1.ClientID%>').value) {
                                    changes.splice(i, 1);
                                }
                                // if any of pasted cells contains the word "nuke", reject the whole paste
                                else if (changes[i][3] === 'nuke') {
                                    return false;
                                }
                            }
                        },
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
                }

                tblExcel = new Handsontable(document.getElementById('tablacalif'), configuracion);
                tblExcel.render();

            }
        </script>
    </div>
</asp:Content>
