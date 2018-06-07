<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mstrpgAdmin.Master" AutoEventWireup="true" CodeBehind="GestionAsignaturas.aspx.cs" Inherits="SICOES2018.GUI.GestionAsignaturas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>Gestión de asignaturas</h2>
    <div class="w3-row">
        <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
            <h4>DATOS DE LA ASIGNATURA</h4>
            <hr style="margin: 5px" />
            <asp:UpdatePanel ID="upAsignatura" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="w3-row">
                        <div class="w3-padding w3-col m6">
                            <asp:Label ID="lbSemestreGrupo" runat="server" Text="Semestre escolar" Font-Bold="true"></asp:Label>
                            <asp:DropDownList ID="ddlSemestre" runat="server" CssClass="w3-input w3-margin-bottom" OnSelectedIndexChanged="ddlSemestre_SelectedIndexChanged" AppendDataBoundItems="true" AutoPostBack="true"></asp:DropDownList>

                            <asp:Label ID="lbPlanGrupo" runat="server" Text="Plan de estudios" Font-Bold="true"></asp:Label>
                            <asp:DropDownList ID="ddlPlan" runat="server" CssClass="w3-input w3-margin-bottom" AppendDataBoundItems="true" AutoPostBack="true"></asp:DropDownList>

                            <asp:Label ID="lbTipoAsig" runat="server" Text="Tipo de asignatura" Font-Bold="true"></asp:Label>
                            <asp:DropDownList ID="ddlTipoAsig" runat="server" CssClass="w3-input w3-margin-bottom" AppendDataBoundItems="true" AutoPostBack="true"></asp:DropDownList>

                            <asp:Label ID="lbModalidad" runat="server" Text="Modalidad" Font-Bold="true"></asp:Label>
                            <asp:DropDownList ID="ddlModalidad" runat="server" CssClass="w3-input w3-margin-bottom" AppendDataBoundItems="true" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <div class="w3-padding w3-col m6">
                            <asp:Label ID="lbNomAsig" runat="server" Text="Nombre de la asignatura" Font-Bold="true"></asp:Label>
                            <asp:RequiredFieldValidator ID="rqNomAsig" runat="server" ErrorMessage="¡Ingrese un nombre!" ControlToValidate="txtNomAsig" ForeColor="Red" Font-Size="Small" Height="10px" ValidationGroup="vlgrAsig"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtNomAsig" runat="server" CssClass="w3-input w3-margin-bottom" placeholder="Matemáticas"></asp:TextBox>

                            <div class="w3-row">
                                <div class="w3-col m6">
                                    <asp:Label ID="lbCreditos" runat="server" Text="Créditos de la asignatura" Font-Bold="true"></asp:Label>
                                    <asp:TextBox Width="90%" ID="txtCreditosAsig" runat="server" CssClass="w3-input w3-margin-bottom" TextMode="Number"></asp:TextBox>
                                </div>
                                <div class="w3-col m6">
                                    <asp:Label ID="lbDuracion" runat="server" Text="Duración total" Font-Bold="true"></asp:Label>
                                    <asp:TextBox Width="90%" ID="txtDuracion" runat="server" CssClass="w3-input w3-margin-bottom" TextMode="Number" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                            <div class="w3-row">
                                <div class="w3-col m6">
                                    <asp:Label ID="lbHorasPre" runat="server" Text="Horas presenciales" Font-Bold="true"></asp:Label>
                                    <asp:TextBox Width="90%" ID="txtHorasPre" runat="server" CssClass="w3-input w3-margin-bottom" TextMode="Number"></asp:TextBox>
                                </div>
                                <div class="w3-col m6">
                                    <asp:Label ID="lbHorasNoPre" runat="server" Text="Horas No Presenciales" Font-Bold="true"></asp:Label>
                                    <asp:TextBox Width="90%" ID="txtHorasNoPre" runat="server" CssClass="w3-input w3-margin-bottom" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <asp:Label ID="lbRequisitos" runat="server" Text="Requisitos" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txtRequisitos" runat="server" CssClass="w3-input w3-margin-bottom" placeholder=""></asp:TextBox>

                            <asp:Button ID="btnAddAsig" runat="server" Text="Crear asignatura" CssClass="w3-button w3-amber w3-hover-blue w3-margin" Width="93%" OnClick="btnAddAsig_Click" ValidationGroup="vlgrAsig" />

                            <asp:Button ID="btnModAsig" runat="server" Text="Modificar información de la asignatura" CssClass="w3-button w3-amber w3-hover-blue w3-margin" Width="93%" Visible="false" OnClick="btnModAsig_Click" ValidationGroup="vlgrAsig" />
                        </div>
                    </div>

                    <div class="w3-row">
                        <div class="w3-padding w3-col m12">
                            <asp:Label ID="lbAsigRegis" runat="server" Text="Asignaturas" Font-Bold="true" CssClass="w3-margin-bottom"></asp:Label>
                            <asp:GridView ID="gvAsignaturas" runat="server" AutoGenerateColumns="False" CellPadding="6"
                                CssClass="w3-table w3-striped w3-border" GridLines="None" ShowHeaderWhenEmpty="True" AllowPaging="true" PageSize="6" OnPageIndexChanging="gvAsignaturas_PageIndexChanging" OnRowCommand="gvAsignaturas_RowCommand" DataKeyNames="IDAsignatura">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("IDAsignatura") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("NomAsig") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Semestre">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Semestre") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Plan de estudios">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("PlanEstudio") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tipo de asignatura">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("TipoAsig") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Modalidad">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Modalidad") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-success btn-sm" Text="<i class='fa fa-eye w3-large'></i>" CausesValidation="False" CommandName="SelectAsig" Visible="true" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlSemestre" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <script src="../Scripts/sweetalert2.all.js"></script>
    <script type="text/javascript">
        function successalert() {
            swal({
                title: '¡Asignatura registrada!',
                text: 'La asignatura ha sido registrada correctamente',
                type: 'success',
                showConfirmButton: false,
                timer: 2000
            });
        }
        function modifsuccessalert() {
            swal({
                title: '¡Información modificada!',
                text: 'La información de la asignatura se modificó con éxito',
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
            function erroralert() {
                swal({
                    title: 'Oh oh',
                    text: 'Hubo un problema al guardar la información, verifica los datos',
                    type: 'error'
                });
            }
    </script>
</asp:Content>
