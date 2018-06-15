<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mstrpgAdmin.Master" AutoEventWireup="true" CodeBehind="GestionGrupos.aspx.cs" Inherits="SICOES2018.GUI.GestionGrupos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>Gestión de grupos</h2>
    <div class="w3-row">
        <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
            <h4>DATOS DEL GRUPO</h4>
            <hr style="margin: 5px" />
            <asp:UpdatePanel ID="upGrupos" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="w3-row">
                        <div class="w3-padding w3-col m6">
                            <asp:Label ID="lbCicloGrupo" runat="server" Text="Ciclo escolar" Font-Bold="true"></asp:Label>
                            <asp:DropDownList ID="ddlCicloGrupo" runat="server" CssClass="w3-input" OnSelectedIndexChanged="ddlCicloGrupo_SelectedIndexChanged" AppendDataBoundItems="true" AutoPostBack="true"></asp:DropDownList>

                            <asp:Label ID="lbPeriodoGrupo" runat="server" Text="Periodo escolar" Font-Bold="true" CssClass="w3-margin-left"></asp:Label>
                            <asp:DropDownList ID="ddlPeriodoGrupo" runat="server" CssClass="w3-input w3-margin-left w3-margin-bottom" OnSelectedIndexChanged="ddlPeriodoGrupo_SelectedIndexChanged" AppendDataBoundItems="true" AutoPostBack="true"></asp:DropDownList>

                            <asp:Label ID="lbSemestreGrupo" runat="server" Text="Semestre escolar" Font-Bold="true"></asp:Label>
                            <asp:DropDownList ID="ddlSemestreGrupo" runat="server" CssClass="w3-input w3-margin-bottom" AppendDataBoundItems="true" AutoPostBack="true"></asp:DropDownList>

                            <asp:Label ID="lbPlanGrupo" runat="server" Text="Plan de estudios" Font-Bold="true"></asp:Label>
                            <asp:DropDownList ID="ddlPlanGrupo" runat="server" CssClass="w3-input w3-margin-bottom" AppendDataBoundItems="true" AutoPostBack="true"></asp:DropDownList>

                            <asp:Label ID="lbNomGrupo" runat="server" Text="Nombre del grupo" Font-Bold="true"></asp:Label>
                            <asp:RequiredFieldValidator ID="rqNomGrupo" runat="server" ErrorMessage="¡Ingrese un nombre!" ControlToValidate="txtNomGrupo" ForeColor="Red" Font-Size="Small" Height="10px" ValidationGroup="vlgrGrupo"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtNomGrupo" runat="server" CssClass="w3-input w3-margin-bottom" placeholder="1A"></asp:TextBox>

                            <asp:Button ID="btnAddGrupo" runat="server" Text="Crear grupo" CssClass="w3-button w3-amber w3-hover-blue w3-margin" Width="93%" OnClick="btnAddGrupo_Click" ValidationGroup="vlgrGrupo" />
                            <asp:Button ID="btnModGrupo" runat="server" Text="Modificar información del grupo" CssClass="w3-button w3-amber w3-hover-blue w3-margin" Width="93%" Visible="false" OnClick="btnModGrupo_Click" ValidationGroup="vlgrGrupo" />
                        </div>

                        <div class="w3-padding w3-col m6">
                            <asp:Label ID="lbGruposReg" runat="server" Text="Grupos" Font-Bold="true" CssClass="w3-margin-bottom"></asp:Label>
                            <asp:GridView ID="gvGrupos" runat="server" AutoGenerateColumns="False" CellPadding="6"
                                CssClass="w3-table w3-striped w3-border" GridLines="None" ShowHeaderWhenEmpty="True" AllowPaging="true" PageSize="6" OnPageIndexChanging="gvGrupos_PageIndexChanging" OnRowCommand="gvGrupos_RowCommand" DataKeyNames="IDGrupo">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("IDGrupo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("NombreGrupo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ciclo y periodo">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("CicloPeriodo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Plan de estudios">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("PlanEstudio") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-success btn-sm" Text="<i class='fa fa-eye w3-large'></i>" CausesValidation="False" CommandName="SelectGrupo" Visible="true" />
                                </Columns>
                            </asp:GridView>
                            <%--                            <asp:Label ID="lbFechaInicio" runat="server" Text="Inicio del ciclo" Font-Bold="true"></asp:Label>
                            <asp:RequiredFieldValidator ID="rqFechaInicio" runat="server" ErrorMessage="¡Ingrese una fecha!" ControlToValidate="txtFechaInicioCiclo" ForeColor="Red" Font-Size="Small" Height="10px" ValidationGroup="vlgrCiclo"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtFechaInicioCiclo" runat="server" CssClass="w3-input w3-margin-bottom" TextMode="Date"></asp:TextBox>
                            <asp:Label ID="lbFechaFin" runat="server" Text="Fin del ciclo" Font-Bold="true"></asp:Label>
                            <asp:RequiredFieldValidator ID="rqFechaFin" runat="server" ErrorMessage="¡Ingrese una fecha!" ControlToValidate="txtFechaFinCiclo" ForeColor="Red" Font-Size="Small" Height="10px" ValidationGroup="vlgrCiclo"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtFechaFinCiclo" runat="server" CssClass="w3-input w3-margin-bottom" TextMode="Date"></asp:TextBox>
                            <asp:CheckBox ID="checkStatusCiclo" runat="server" Text="  Estado del ciclo escolar" Font-Bold="true" />--%>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlCicloGrupo" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="ddlPeriodoGrupo" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <script type="text/javascript">
        function successalert() {
            swal({
                title: '¡Grupo registrado!',
                text: 'El grupo ha sido registrado con éxito',
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
        function per1successalert() {
            swal({
                title: '¡Periodo escolar registrado!',
                text: 'El periodo escolar ha sido registrado con éxito',
                type: 'success',
                showConfirmButton: false,
                timer: 2000
            });
        }
        function dateper1erroralert() {
            swal({
                title: 'Oh oh',
                text: 'La fecha de inicio no puede ser anterior a la del ciclo escolar, favor de verificar la información',
                type: 'error'
            });
        }
    </script>


</asp:Content>
