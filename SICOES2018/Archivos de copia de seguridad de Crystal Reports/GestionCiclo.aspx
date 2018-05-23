<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mstrpgAdmin.Master" AutoEventWireup="true" CodeBehind="GestionCiclo.aspx.cs" Inherits="SICOES2018.GUI.GestionCiclo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>Gestión del ciclo escolar</h2>
    <%--DATOS GENERALES--%>
    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <div class="w3-row">
            <h4>DATOS DEL CICLO ESCOLAR</h4>
            <hr style="margin: 5px" />
        </div>
        <asp:UpdatePanel ID="upCiclos" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="w3-row">
                    <div class="w3-padding w3-col m6">
                        <asp:Label ID="lbNomCiclo" runat="server" Text="Nombre del ciclo escolar" Font-Bold="true"></asp:Label>
                        <asp:RequiredFieldValidator ID="rqNomCiclo" runat="server" ErrorMessage="¡Ingrese un nombre!" ControlToValidate="txtNomCiclo" ForeColor="Red" Font-Size="Small" Height="10px"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtNomCiclo" runat="server" CssClass="w3-input w3-margin-bottom" placeholder="Ciclo escolar 20XX - 20XX"></asp:TextBox>
                        <asp:Button ID="btnAddCiclo" runat="server" Text="Crear ciclo escolar" CssClass="w3-button w3-amber w3-hover-blue w3-margin" Width="93%" OnClick="btnAddCiclo_Click" />
                        <asp:Button ID="btnModCiclo" runat="server" Text="Modificar información del ciclo escolar" CssClass="w3-button w3-amber w3-hover-blue w3-margin" Width="93%" Visible="false" OnClick="btnModCiclo_Click" />
                    </div>
                    <div class="w3-padding w3-col m6">
                        <asp:Label ID="lbFechaInicio" runat="server" Text="Inicio del ciclo" Font-Bold="true"></asp:Label>
                        <asp:RequiredFieldValidator ID="rqFechaInicio" runat="server" ErrorMessage="¡Ingrese una fecha!" ControlToValidate="txtFechaInicioCiclo" ForeColor="Red" Font-Size="Small" Height="10px"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtFechaInicioCiclo" runat="server" CssClass="w3-input w3-margin-bottom" TextMode="Date"></asp:TextBox>
                        <asp:Label ID="lbFechaFin" runat="server" Text="Fin del ciclo" Font-Bold="true"></asp:Label>
                        <asp:RequiredFieldValidator ID="rqFechaFin" runat="server" ErrorMessage="¡Ingrese una fecha!" ControlToValidate="txtFechaFinCiclo" ForeColor="Red" Font-Size="Small" Height="10px"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtFechaFinCiclo" runat="server" CssClass="w3-input w3-margin-bottom" TextMode="Date"></asp:TextBox>
                        <asp:CheckBox ID="checkStatusCiclo" runat="server" Text="  Estado del ciclo escolar" Font-Bold="true" />
                    </div>
                </div>
                <div class="w3-row">
                    <div class="w3-col m12 w3-padding">
                        <asp:Label ID="lbCiclosRegistrados" runat="server" Text="Ciclos escolares registrados" Font-Bold="true"></asp:Label>
                        <div class="w3-responsive">
                            <asp:GridView ID="gvCiclos" runat="server" AutoGenerateColumns="False" CellPadding="6"
                                CssClass="w3-table w3-striped w3-border" GridLines="None" ShowHeaderWhenEmpty="True" AllowPaging="true" PageSize="5" OnPageIndexChanging="gvCiclos_PageIndexChanging" OnRowCommand="gvCiclos_RowCommand" DataKeyNames="IDCicloEscolar">
                                <Columns>

                                    <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("IDCicloEscolar") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Nombre") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha de inicio">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("FechaInicio") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha de finalización">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("FechaFin") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Estado">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Estado") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-success btn-sm" Text="<i class='fa fa-eye w3-large'></i>" CausesValidation="False" CommandName="SelectCiclo" Visible="true" />
                                </Columns>
                            </asp:GridView>

                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAddCiclo" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnModCiclo" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div class="w3-row">
        <div class="w3-col m6">
            <div class="w3-container w3-card w3-white w3-animate-right w3-left" style="width: 98%">
                <h4>PRIMER PERIODO</h4>
                <hr style="margin: 5px" />
                <div class="w3-row w3-padding">
                    <asp:Label ID="lbCicloAddPer1" runat="server" Text="Selecciona un ciclo escolar" Font-Bold="true"></asp:Label>
                    <asp:DropDownList ID="ddlCicloEscolarAddPeriodoA" runat="server" CssClass="w3-input" OnSelectedIndexChanged="ddlCicloEscolarAddPeriodoA_SelectedIndexChanged" Width="100%"></asp:DropDownList>
                </div>
                <div class="w3-row w3-padding">
                    <asp:Label ID="lbNomPer1" runat="server" Text="Nombre del periodo escolar" Font-Bold="true"></asp:Label>
                    <asp:RequiredFieldValidator ID="rqNombrePer1" runat="server" ErrorMessage="¡Ingrese una nombre!" ControlToValidate="txtNombrePer1" ForeColor="Red" Font-Size="Small" Height="10px"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtNombrePer1" runat="server" CssClass="w3-input"></asp:TextBox>
                </div>
                <div class="w3-row w3-padding">
                    <div class="w3-col m6">
                        <asp:Label ID="lbFechaInicioPer1" runat="server" Text="Inicio del periodo" Font-Bold="true" CssClass="w3-left"></asp:Label>
                        <asp:RequiredFieldValidator ID="rqFechaInicioPer1" runat="server" ErrorMessage="¡Ingrese una fecha!" ControlToValidate="txtFechaInicioPer1" ForeColor="Red" Font-Size="Small" Height="10px" CssClass="w3-left"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtFechaInicioPer1" runat="server" CssClass="w3-input w3-margin-bottom w3-left" TextMode="Date" Width="90%"></asp:TextBox>
                    </div>
                    <div class="w3-col m6">
                        <asp:Label ID="lbFechaFinPer1" runat="server" Text="Final del periodo" Font-Bold="true" CssClass="w3-right"></asp:Label>
                        <asp:RequiredFieldValidator ID="rqFechaFinPer1" runat="server" ErrorMessage="¡Ingrese una fecha!" ControlToValidate="txtFechaFinPer1" ForeColor="Red" Font-Size="Small" Height="10px" CssClass="w3-right"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtFechaFinPer1" runat="server" CssClass="w3-input w3-margin-bottom w3-right" TextMode="Date" Width="90%"></asp:TextBox>
                    </div>

                </div>
                <div class="w3-row w3-padding">
                    <asp:Button ID="Button2" runat="server" Text="Modificar información del ciclo escolar" CssClass="w3-button w3-amber w3-hover-blue w3-margin" Width="93%" Visible="false" OnClick="btnModCiclo_Click" />
                    <asp:Button ID="Button1" runat="server" Text="Modificar información del ciclo escolar" CssClass="w3-button w3-amber w3-hover-blue w3-margin" Width="100%" Visible="false" OnClick="btnModCiclo_Click" />
                </div>
            </div>
        </div>
        <div class="w3-col m6">

            <div class="w3-container w3-card w3-white w3-animate-right w3-right" style="width: 98%">
                hasdh
            </div>
        </div>
    </div>

    <%--SCRIPTS DE ALERTAS--%>
    <script type="text/javascript">
        function successalert() {
            swal({
                title: '¡Ciclo escolar registrado!',
                text: 'El ciclo escolar ha sido registrado con éxito',
                type: 'success',
                showConfirmButton: false,
                timer: 1500
            });
        }

        function modifsuccessalert() {
            swal({
                title: '¡Información modificada!',
                text: 'La información del ciclo escolar se modificó correctamente',
                type: 'success',
                showConfirmButton: false,
                timer: 2000
            });
        }

        function bajasuccessalert() {
            swal({
                title: '¡Alumno dado de baja!',
                text: 'El alumno ha sido dado de baja correctamente',
                type: 'success',
                showConfirmButton: false,
                timer: 2000
            });
        }


        function erroralert() {
            swal({
                title: 'Oh oh',
                text: 'Hubo un problema al guardar la información',
                type: 'error'
            });
        }



        function fotosuccessalert() {
            swal({
                title: 'Foto guardada',
                text: 'Continua con el registro del alumno',
                type: 'success',
                showConfirmButton: false,
                timer: 1500

            });
        }

    </script>
</asp:Content>
