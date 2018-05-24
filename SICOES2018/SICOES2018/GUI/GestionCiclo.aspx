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
                        <asp:RequiredFieldValidator ID="rqNomCiclo" runat="server" ErrorMessage="¡Ingrese un nombre!" ControlToValidate="txtNomCiclo" ForeColor="Red" Font-Size="Small" Height="10px" ValidationGroup="vlgrCiclo"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtNomCiclo" runat="server" CssClass="w3-input w3-margin-bottom" placeholder="Ciclo escolar 20XX - 20XX"></asp:TextBox>
                        <asp:Button ID="btnAddCiclo" runat="server" Text="Crear ciclo escolar" CssClass="w3-button w3-amber w3-hover-blue w3-margin" Width="93%" OnClick="btnAddCiclo_Click" ValidationGroup="vlgrCiclo"/>
                        <asp:Button ID="btnModCiclo" runat="server" Text="Modificar información del ciclo escolar" CssClass="w3-button w3-amber w3-hover-blue w3-margin" Width="93%" Visible="false" OnClick="btnModCiclo_Click" ValidationGroup="vlgrCiclo" />
                    </div>
                    <div class="w3-padding w3-col m6">
                        <asp:Label ID="lbFechaInicio" runat="server" Text="Inicio del ciclo" Font-Bold="true"></asp:Label>
                        <asp:RequiredFieldValidator ID="rqFechaInicio" runat="server" ErrorMessage="¡Ingrese una fecha!" ControlToValidate="txtFechaInicioCiclo" ForeColor="Red" Font-Size="Small" Height="10px" ValidationGroup="vlgrCiclo"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtFechaInicioCiclo" runat="server" CssClass="w3-input w3-margin-bottom" TextMode="Date"></asp:TextBox>
                        <asp:Label ID="lbFechaFin" runat="server" Text="Fin del ciclo" Font-Bold="true"></asp:Label>
                        <asp:RequiredFieldValidator ID="rqFechaFin" runat="server" ErrorMessage="¡Ingrese una fecha!" ControlToValidate="txtFechaFinCiclo" ForeColor="Red" Font-Size="Small" Height="10px" ValidationGroup="vlgrCiclo"></asp:RequiredFieldValidator>
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
                <asp:UpdatePanel ID="upPeriodo1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="w3-row w3-padding">
                            <asp:Label ID="lbCicloAddPer1" runat="server" Text="Selecciona un ciclo escolar" Font-Bold="true"></asp:Label>
                            <asp:DropDownList ID="ddlCicloEscolarAddPeriodoA" runat="server" CssClass="w3-input" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlCicloEscolarAddPeriodoA_SelectedIndexChanged" Width="100%"></asp:DropDownList>
                        </div>
                        <div class="w3-row w3-padding">
                            <div class="w3-col m6">
                                <asp:Label ID="lbFechaInicioPer1" runat="server" Text="Inicio del periodo" Font-Bold="true" CssClass="w3-left"></asp:Label>
                                <asp:RequiredFieldValidator ID="rqFechaInicioPer1" runat="server" ErrorMessage="¡Ingrese una fecha!" ControlToValidate="txtFechaInicioPer1" ForeColor="Red" Font-Size="Small" Height="10px" CssClass="w3-left w3-margin-bottom" ValidationGroup="vlgrPer1"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtFechaInicioPer1" runat="server" CssClass="w3-input w3-margin-bottom w3-left" TextMode="Date" Width="90%"></asp:TextBox>
                            </div>
                            <div class="w3-col m6">
                                <asp:Label ID="lbFechaFinPer1" runat="server" Text="Final del periodo" Font-Bold="true" CssClass="w3-right"></asp:Label>
                                <asp:RequiredFieldValidator ID="rqFechaFinPer1" runat="server" ErrorMessage="¡Ingrese una fecha!" ControlToValidate="txtFechaFinPer1" ForeColor="Red" Font-Size="Small" Height="10px" CssClass="w3-right w3-margin-bottom" ValidationGroup="vlgrPer1"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtFechaFinPer1" runat="server" CssClass="w3-input w3-margin-bottom w3-right" TextMode="Date" Width="90%"></asp:TextBox>
                            </div>
                        </div>
                        <div class="w3-row w3-padding">
                            <asp:Button ID="btnAddPer1" runat="server" Text="Agregar periodo escolar" CssClass="w3-button w3-amber w3-hover-blue" Width="100%" Visible="true" OnClick="btnAddPer1_Click" ValidationGroup="vlgrPer1"/>
                            <asp:Button ID="btnModPer1" runat="server" Text="Modificar periodo escolar" CssClass="w3-button w3-amber w3-hover-blue" Width="100%" Visible="false" OnClick="btnModPer1_Click" ValidationGroup="vlgrPer1"/>
                        </div>
                        <div class="w3-row w3-padding">
                            <asp:Label ID="lbPer1Reg" runat="server" Text="Periodos escolares registrados" Font-Bold="true"></asp:Label>
                            <div class="w3-responsive">
                                <asp:GridView ID="gvPer1" runat="server" AutoGenerateColumns="False" CellPadding="6" EnableViewState="false"
                                    CssClass="w3-table w3-striped w3-border" GridLines="None" ShowHeaderWhenEmpty="True" AllowPaging="true" PageSize="5" OnPageIndexChanging="gvPer1_PageIndexChanging" OnRowCommand="gvPer1_RowCommand" DataKeyNames="IDPeriodo">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("IDPeriodo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Nombre">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Nombre") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ciclo escolar">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("NombreCiclo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-success btn-sm" Text="<i class='fa fa-eye w3-large'></i>" CausesValidation="False" CommandName="SelectPeriodo" Visible="true" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAddPer1" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnModPer1" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ddlCicloEscolarAddPeriodoA" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>

        <div class="w3-col m6">
            <div class="w3-container w3-card w3-white w3-animate-right w3-right" style="width: 98%">
                <h4>SEGUNDO PERIODO</h4>
                <hr style="margin: 5px" />
                <asp:UpdatePanel ID="upPeriodo2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="w3-row w3-padding">
                            <asp:Label ID="lbCicloAddPer2" runat="server" Text="Selecciona un ciclo escolar" Font-Bold="true"></asp:Label>
                            <asp:DropDownList ID="ddlCicloEscolarAddPeriodoB" runat="server" CssClass="w3-input" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlCicloEscolarAddPeriodoB_SelectedIndexChanged" Width="100%"></asp:DropDownList>
                        </div>
                        <div class="w3-row w3-padding">
                            <div class="w3-col m6">
                                <asp:Label ID="lbFechaInicioPer2" runat="server" Text="Inicio del periodo" Font-Bold="true" CssClass="w3-left"></asp:Label>
                                <asp:RequiredFieldValidator ID="rqFechaInicioPer2" runat="server" ErrorMessage="¡Ingrese una fecha!" ControlToValidate="txtFechaInicioPer2" ForeColor="Red" Font-Size="Small" Height="10px" CssClass="w3-left w3-margin-bottom" ValidationGroup="vlgrPer2"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtFechaInicioPer2" runat="server" CssClass="w3-input w3-margin-bottom w3-left" TextMode="Date" Width="90%"></asp:TextBox>
                            </div>
                            <div class="w3-col m6">
                                <asp:Label ID="lbFechaFinPer2" runat="server" Text="Final del periodo" Font-Bold="true" CssClass="w3-right"></asp:Label>
                                <asp:RequiredFieldValidator ID="rqFechaFinPer2" runat="server" ErrorMessage="¡Ingrese una fecha!" ControlToValidate="txtFechaFinPer2" ForeColor="Red" Font-Size="Small" Height="10px" CssClass="w3-right w3-margin-bottom" ValidationGroup="vlgrPer2"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtFechaFinPer2" runat="server" CssClass="w3-input w3-margin-bottom w3-right" TextMode="Date" Width="90%"></asp:TextBox>
                            </div>
                        </div>
                        <div class="w3-row w3-padding">
                            <asp:Button ID="btnAddPer2" runat="server" Text="Agregar periodo escolar" CssClass="w3-button w3-amber w3-hover-blue" Width="100%" Visible="true" OnClick="btnAddPer2_Click" ValidationGroup="vlgrPer2"/>
                            <asp:Button ID="btnModPer2" runat="server" Text="Modificar periodo escolar" CssClass="w3-button w3-amber w3-hover-blue" Width="100%" Visible="false" OnClick="btnModPer2_Click" ValidationGroup="vlgrPer2"/>
                        </div>
                        <div class="w3-row w3-padding">
                            <asp:Label ID="lbPer2Reg" runat="server" Text="Periodos escolares registrados" Font-Bold="true"></asp:Label>
                            <div class="w3-responsive">
                                <asp:GridView ID="gvPer2" runat="server" AutoGenerateColumns="False" CellPadding="6" EnableViewState="false"
                                    CssClass="w3-table w3-striped w3-border" GridLines="None" ShowHeaderWhenEmpty="True" AllowPaging="true" PageSize="5" OnPageIndexChanging="gvPer2_PageIndexChanging" OnRowCommand="gvPer2_RowCommand" DataKeyNames="IDPeriodo">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("IDPeriodo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Nombre">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Nombre") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ciclo escolar">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("NombreCiclo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-success btn-sm" Text="<i class='fa fa-eye w3-large'></i>" CausesValidation="False" CommandName="SelectPeriodo" Visible="true" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAddPer2" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnModPer2" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ddlCicloEscolarAddPeriodoB" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
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
                timer: 1500
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
