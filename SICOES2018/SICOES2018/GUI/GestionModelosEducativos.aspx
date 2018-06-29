<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mstrpgAdmin.Master" AutoEventWireup="true" CodeBehind="GestionModelosEducativos.aspx.cs" Inherits="SICOES2018.GUI.GestionModelosEducativos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <%--DATOS GENERALES--%>
    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <asp:UpdatePanel ID="upBotones" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="w3-row">
                    <div class="w3-col m4">
                        <h4>Plan de estudios</h4>
                    </div>
                </div>
                <hr style="margin: 5px" />
                <div class="w3-row">
                    <h6>Cree un nuevo plan educativo, tambien puede consultar los planes que ya existen en el sistema</h6>
                    <h6>Para modificar o eliminar algun plan seleccionelo de la lista desplegable y presione el boton correspondiente</h6>
                    <%--DATOS--%>
                    <div class="w3-padding w3-col m4">
                        <div class="w3-row">
                            <asp:Label ID="lbNomPlan" runat="server" Text="Nombre del plan" Font-Bold="true"></asp:Label>
                            <asp:RequiredFieldValidator ID="reqNomAlum" runat="server" ControlToValidate="txtNomPlan" ErrorMessage="¡Ingrese el nombre del plan!" ViewStateMode="Inherit" ForeColor="Red" Font-Size="Small" Height="10px" ValidationGroup="vlgrDatos"></asp:RequiredFieldValidator>
                            <asp:TextBox runat="server" CssClass="w3-input" ID="txtNomPlan" type="text" />
                        </div>


                    </div>
                    <div class="w3-padding w3-col m4">
                        <asp:Label ID="lbPlanGrupo" runat="server" Text="Planes de estudios ya registrados" Font-Bold="true"></asp:Label>
                        <br />
                        <br />
                        <asp:DropDownList ID="ddlPlan" runat="server" CssClass="w3-input w3-margin-bottom" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlPlan_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                </div>

            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlPlan" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div class="w3-row w3-animate-right">
        <div class="w3-row">
            <asp:Button CssClass="w3-button w3-amber w3-hover-blue w3-round" ID="btnAgregarAlumno" runat="server" Text="Agregar Nuevo Plan" OnClick="btnAgregarAlumno_Click" ValidationGroup="vlgrDatos" Style="width: 25%" />

            <asp:Button CssClass="w3-button w3-amber w3-hover-blue w3-round w3-margin-left" ID="btnModifPlan" runat="server" Text="Modificar Plan" OnClick="btnModifPlan_Click" ValidationGroup="vlgrDatos" Style="width: 25%"/>

            <asp:Button CssClass="w3-button w3-amber w3-hover-blue w3-round w3-margin-left" ID="btnElimfPlan" runat="server" Text="Eliminar Plan" OnClick="btnElimfPlan_Click" ValidationGroup="vlgrDatos" Style="width: 25%"/>
        </div>
    </div>


    <script src="../Scripts/sweetalert2.all.js"></script>
    <script type="text/javascript">
        function successalert() {
            swal({
                title: '¡Plan registrado!',
                text: 'El plan ha sido registrado correctamente',
                type: 'success',
                showConfirmButton: false,
                timer: 2000
            });
        }
        function updatealert() {
            swal({
                title: '¡Plan modificado!',
                text: 'El plan ha sido modificado correctamente',
                type: 'success',
                showConfirmButton: false,
                timer: 2000
            });
        }
        function deletealert() {
            swal({
                title: '¡Plan eliminado!',
                text: 'El plan ha sido eliminado correctamente',
                type: 'success',
                showConfirmButton: false,
                timer: 2000
            });
        }
    </script>
</asp:Content>
