<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mstrpgAdmin.Master" AutoEventWireup="true" CodeBehind="Reinscripcion.aspx.cs" Inherits="SICOES2018.GUI.Reinscripcion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="w3-row">
        <div class="w3-col m6">
            <div class="w3-container w3-card w3-white w3-animate-right w3-left" style="width: 98%">
                <h4>SELECCIONAR GRUPO A REINSCRIBIR</h4>
                <hr style="margin: 5px" />
                <asp:UpdatePanel ID="upGrupoRe" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="w3-row w3-padding">
                            <asp:Label ID="lbCicloRe" runat="server" Text="Selecciona un ciclo escolar" Font-Bold="true"></asp:Label>
                            <asp:DropDownList ID="ddlCicloEscolarRe" runat="server" CssClass="w3-input" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlCicloEscolarRe_SelectedIndexChanged" Width="100%"></asp:DropDownList>
                        </div>
                        <div class="w3-row w3-padding">
                            <asp:Label ID="lbPeriodoRe" runat="server" Text="Selecciona un periodo" Font-Bold="true"></asp:Label>
                            <asp:DropDownList ID="ddlPeriodoRe" runat="server" CssClass="w3-input" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlPeriodoRe_SelectedIndexChanged" Width="100%"></asp:DropDownList>
                        </div>
                        <div class="w3-row w3-padding">
                            <asp:Label ID="lbGrupoRe" runat="server" Text="Selecciona un grupo" Font-Bold="true"></asp:Label>
                            <asp:DropDownList ID="ddlGrupoRe" runat="server" CssClass="w3-input" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlGrupoRe_SelectedIndexChanged" Width="100%"></asp:DropDownList>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlCicloEscolarRe" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlPeriodoRe" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlGrupoRe" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="w3-col m6">
            <div class="w3-container w3-card w3-white w3-animate-right w3-right" style="width: 98%">
                <h4>SELECCIONAR GRUPO DESTINO</h4>
                <hr style="margin: 5px" />
                <asp:UpdatePanel ID="upGrupo" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="w3-row w3-padding">
                            <asp:Label ID="lbCiclo" runat="server" Text="Selecciona un ciclo escolar" Font-Bold="true"></asp:Label>
                            <asp:DropDownList ID="ddlCicloEscolar" runat="server" CssClass="w3-input" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlCicloEscolar_SelectedIndexChanged" Width="100%"></asp:DropDownList>
                        </div>
                        <div class="w3-row w3-padding">
                            <asp:Label ID="lbPeriodo" runat="server" Text="Selecciona un periodo" Font-Bold="true"></asp:Label>
                            <asp:DropDownList ID="ddlPeriodo" runat="server" CssClass="w3-input" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlPeriodo_SelectedIndexChanged" Width="100%"></asp:DropDownList>
                        </div>
                        <div class="w3-row w3-padding">
                            <asp:Label ID="lbGrupo" runat="server" Text="Selecciona un grupo" Font-Bold="true"></asp:Label>
                            <asp:DropDownList ID="ddlGrupo" runat="server" CssClass="w3-input" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlGrupo_SelectedIndexChanged" Width="100%"></asp:DropDownList>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlCicloEscolar" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlPeriodo" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlGrupo" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>

            </div>
        </div>
    </div>
    <div class="w3-row w3-margin-top">
        <div class="w3-col m12">
            <div class="w3-container w3-card w3-white w3-animate-right w3-left" style="width: 100%">
                <asp:Label ID="lbAlumnos" runat="server" Text="Alumnos del grupo" Font-Bold="true"></asp:Label>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="w3-responsive">
                            <asp:GridView ID="gvAlumnos" runat="server" AutoGenerateColumns="False" CellPadding="6"
                                CssClass="w3-table w3-striped w3-border" GridLines="None" ShowHeaderWhenEmpty="True" DataKeyNames="IDAlumno">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="IDAlumno" runat="server" Text='<%#Eval("IDAlumno") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Primer Apellido">
                                        <ItemTemplate>
                                            <asp:Label ID="AlumnoApePat" runat="server" Text='<%#Eval("ApePatAlumno") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Segundo Apellido">
                                        <ItemTemplate>
                                            <asp:Label ID="AlumnoApeMat" runat="server" Text='<%#Eval("ApeMatAlumno") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre">
                                        <ItemTemplate>
                                            <asp:Label ID="AlumnoNom" runat="server" Text='<%#Eval("NomAlumno") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Seleccionar">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chckSeleccion" runat="server" AutoPostBack="true" OnCheckedChanged="chckSeleccion_CheckedChanged" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="w3-row w3-padding w3-margin-top">
                            <asp:Button OnClick="btnReinscribir_Click" CssClass=" w3-button w3-amber w3-hover-blue" ID="btnReinscribir" runat="server" Text="Reinscribir grupo" CausesValidation="true" Width="100%" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnReinscribir" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function successalert() {
            swal({
                title: '¡Alumnos reinscritos!',
                text: 'Los alumnos han sido reinscritos exitosamente',
                type: 'success',
                showConfirmButton: false,
                timer: 2000
            });
        }
    </script>
    <script type="text/javascript">
        function erroralert() {
            swal({
                title: 'No se puede realizar el cambio',
                text: 'El alumno está en un semestre superior al que se quiere reinscribir',
                type: 'error'
            });
        }
    </script>


</asp:Content>
