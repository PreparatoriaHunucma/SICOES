<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mstrpgAdmin.Master" AutoEventWireup="true" CodeBehind="GenerarConstanciaLaboral.aspx.cs" Inherits="SICOES2018.GUI.GenerarConstanciaLaboral" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <asp:UpdatePanel ID="upDatosGen" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
              <div class="w3-row">
        <div class="w3-col m8">
            <h2>Constancia Laboral</h2>
        </div>
        <div class=" w3-col m4 w3-padding-16">
            <input class="w3-button w3-amber w3-hover-blue  w3-right" type="button" onclick="document.getElementById('modalAlumnos').style.display = 'block'" value="Ver registros de empleados" />
        </div>
    </div>
                    <div class ="w3-row">
                        <h6>Seleccione del registro al colaborador que se le emitira la constancia y presione el boton "Generar"</h6>
                    </div>
                     <div class ="w3-row">
                        <asp:Label ID="lbNomEmp" runat="server" Text="Nombre(s)" Font-Bold="true"></asp:Label>
                            <br />
                            <asp:TextBox runat="server" CssClass="w3-input" ID="txtNomEmp" type="text" Style="width: 400px" />
                            <br />
                        </div>
                        <div class="w3-row" style="margin-bottom: -20px">
                            <asp:Label ID="lbApePatEmp" runat="server" Text="Primer Apellido" Font-Bold="true"></asp:Label>
                            <br />
                            <asp:TextBox runat="server" CssClass="w3-input" ID="txtApePatEmp" type="text" Style="width: 400px" /><br />
                        </div>
                        <div class="w3-row">
                            <asp:Label ID="lbApeMatEmp" runat="server" Text="Segundo Apellido" Font-Bold="true"></asp:Label>
                            <br />
                            <asp:TextBox runat="server" CssClass="w3-input" ID="txtApeMatEmp" type="text" Style="width: 400px" /><br />
                        </div>
                    </div>

                     </ContentTemplate>
            <Triggers>

            </Triggers>
        </asp:UpdatePanel>
    </div>

    <%--MODAL PARA VER A LOS MAESTROS--%>
    <div id="modalAlumnos" class="w3-modal">
        <div class="w3-modal-content w3-animate-top w3-card-4 w3-round" style="width: 1000px; margin-top: -70px">
            <header class="w3-container w3-blue w3-round" style="height: 50px">
                <h3 class="w3-display-topleft w3-margin-left">Empleados</h3>
                <span onclick="document.getElementById('modalAlumnos').style.display='none'"
                    class="w3-button w3-display-topright w3-hover-amber w3-round">&times;</span>
            </header>
            <div class="w3-container" style="min-height: 480px; max-height: 480px">
                <asp:UpdatePanel ID="upAlumnos" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="w3-row w3-margin-top">
                            <div class="w3-col m12">
                                <asp:Label ID="lbMaestros" runat="server" Text="Seleccione de la lista que tipo de empleado que desea vizualizar y posteriormente presione en el icono de la derecha para ver su información" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:DropDownList CssClass="w3-dropdown-click w3-input w3-margin" ID="ddlMaestrosReg" Style="width: 20%" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlAlumnosReg_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Text="Activo" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Inactivo" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="w3-row ">
                            <div class="w3-col m12">
                                <b>
                                    <asp:Label ID="lbAlumnosReg" runat="server" Text="Alumnos registrados"></asp:Label>
                                </b>
                                <div class="w3-responsive">
                                    <asp:GridView ID="gvAlumnos" runat="server" AutoGenerateColumns="False" CellPadding="6"
                                        CssClass="w3-table w3-striped w3-border" Style="min-height: 288px" GridLines="None" ShowHeaderWhenEmpty="True" AllowPaging="true" PageSize="5" OnPageIndexChanging="gvAlumnos_PageIndexChanging" OnRowCommand="gvAlumnos_RowCommand" DataKeyNames="IDMaestro">
                                        <Columns>

                                            <asp:TemplateField HeaderText="ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("IDMaestro") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nombre">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("NomMaestro") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Primer apellido">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("ApePatMaestro") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Segundo apellido">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("ApeMatMaestro") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--  <asp:TemplateField HeaderText="Fecha de Nacimiento">
                                                      <ItemTemplate>
                                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("FechaNacAlumno") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Usuario">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Usuario") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Estatus">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("StatusMaestro") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-success btn-sm" Text="<i class='fa fa-eye w3-large'></i>" CausesValidation="False" CommandName="SelectAlum" Visible="true" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlMaestrosReg" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

     <%--BOTON PARA REGISTRAR AL EMPLEADO--%>

                <div class="w3-row w3-animate-right">
                     <asp:UpdatePanel ID="upBotones" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                    <asp:Button CssClass="w3-button w3-amber w3-hover-blue w3-round " ID="btnAgregarAlumno" runat="server" Text="Generar Constancia" OnClick="btnAgregarEmp_Click" CausesValidation="true" Style="width: 100%" ValidationGroup="vlgrDatosEmp" />
                </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAgregarAlumno" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
                </div>

    <script type="text/javascript">
        function successalert() {
            swal({
                title: 'Personal registrado!',
                text: 'El maestro ha sido registrado correctamente',
                type: 'success',
                showConfirmButton: false,
                timer: 1500
            });
        }

        function erroralert() {
            swal({
                title: 'Oh oh',
                text: 'Primero seleccione a un empleado',
                type: 'error'
            });
        }

    </script>
</asp:Content>
