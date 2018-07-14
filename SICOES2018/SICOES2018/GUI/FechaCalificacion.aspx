<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mstrpgAdmin.Master" AutoEventWireup="true" CodeBehind="FechaCalificacion.aspx.cs" Inherits="SICOES2018.GUI.FechaCalificacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>Control de captura de calificaciones</h2>

    <div class="w3-row">
        <div class="w3-col m12">
            <div class="w3-container w3-card w3-white w3-animate-right w3-left" style="width: 98%">
                <h4>FECHAS DE CAPTURA DE CALIFICACIONES</h4>
                <hr style="margin: 5px" />
                <asp:UpdatePanel ID="upFechas" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="w3-row w3-padding">
                            <asp:Label ID="lbPeriodo" runat="server" Text="Selecciona un periodo" Font-Bold="true"></asp:Label>
                            <asp:DropDownList ID="ddlPeriodo" runat="server" CssClass="w3-input" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlPeriodo_SelectedIndexChanged" Width="100%"></asp:DropDownList>
                        </div>
                        <div class="w3-row w3-padding">
                            <div class="w3-col m6">
                                <asp:Label ID="lbFechaInicioMom1" runat="server" Text="Inicio del primer momento" Font-Bold="true" CssClass="w3-left"></asp:Label>
                                <asp:RequiredFieldValidator ID="rqFechaInicioMom1" runat="server" ErrorMessage="¡Ingrese una fecha!" ControlToValidate="txtFechaInicioMom1" ForeColor="Red" Font-Size="Small" Height="10px" CssClass="w3-left w3-margin-bottom" ValidationGroup="vlgrPer1"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtFechaInicioMom1" runat="server" CssClass="w3-input w3-margin-bottom w3-left" TextMode="Date" Width="90%"></asp:TextBox>
                            </div>
                            <div class="w3-col m6">
                                <asp:Label ID="lbFechaFinMom1" runat="server" Text="Final del primer momento" Font-Bold="true" CssClass="w3-right"></asp:Label>
                                <asp:RequiredFieldValidator ID="rqFechaFinMom1" runat="server" ErrorMessage="¡Ingrese una fecha!" ControlToValidate="txtFechaFinMom1" ForeColor="Red" Font-Size="Small" Height="10px" CssClass="w3-right w3-margin-bottom" ValidationGroup="vlgrPer1"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtFechaFinMom1" runat="server" CssClass="w3-input w3-margin-bottom w3-right" TextMode="Date" Width="90%"></asp:TextBox>
                            </div>
                        </div>
                        <div class="w3-row w3-padding">
                            <div class="w3-col m6">
                                <asp:Label ID="lbFechaInicioMom2" runat="server" Text="Inicio del segundo momento" Font-Bold="true" CssClass="w3-left"></asp:Label>
                                <asp:RequiredFieldValidator ID="rqFechaInicioMom2" runat="server" ErrorMessage="¡Ingrese una fecha!" ControlToValidate="txtFechaInicioMom2" ForeColor="Red" Font-Size="Small" Height="10px" CssClass="w3-left w3-margin-bottom" ValidationGroup="vlgrPer1"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtFechaInicioMom2" runat="server" CssClass="w3-input w3-margin-bottom w3-left" TextMode="Date" Width="90%"></asp:TextBox>
                            </div>
                            <div class="w3-col m6">
                                <asp:Label ID="lbFechaFinMom2" runat="server" Text="Final del segundo momento" Font-Bold="true" CssClass="w3-right"></asp:Label>
                                <asp:RequiredFieldValidator ID="rqFechaFinMom2" runat="server" ErrorMessage="¡Ingrese una fecha!" ControlToValidate="txtFechaFinMom2" ForeColor="Red" Font-Size="Small" Height="10px" CssClass="w3-right w3-margin-bottom" ValidationGroup="vlgrPer1"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtFechaFinMom2" runat="server" CssClass="w3-input w3-margin-bottom w3-right" TextMode="Date" Width="90%"></asp:TextBox>
                            </div>
                        </div>
                        <div class="w3-row w3-padding">
                            <div class="w3-col m6">
                                <asp:Label ID="lbFechaInicioMom3" runat="server" Text="Inicio del tercer momento" Font-Bold="true" CssClass="w3-left"></asp:Label>
                                <asp:RequiredFieldValidator ID="rqFechaInicioMom3" runat="server" ErrorMessage="¡Ingrese una fecha!" ControlToValidate="txtFechaInicioMom3" ForeColor="Red" Font-Size="Small" Height="10px" CssClass="w3-left w3-margin-bottom" ValidationGroup="vlgrPer1"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtFechaInicioMom3" runat="server" CssClass="w3-input w3-margin-bottom w3-left" TextMode="Date" Width="90%"></asp:TextBox>
                            </div>
                            <div class="w3-col m6">
                                <asp:Label ID="lbFechaFinMom3" runat="server" Text="Final del tercer momento" Font-Bold="true" CssClass="w3-right"></asp:Label>
                                <asp:RequiredFieldValidator ID="rqFechaFinMom3" runat="server" ErrorMessage="¡Ingrese una fecha!" ControlToValidate="txtFechaFinMom3" ForeColor="Red" Font-Size="Small" Height="10px" CssClass="w3-right w3-margin-bottom" ValidationGroup="vlgrPer1"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtFechaFinMom3" runat="server" CssClass="w3-input w3-margin-bottom w3-right" TextMode="Date" Width="90%"></asp:TextBox>
                            </div>
                        </div>

                        <div class="w3-row w3-padding">
                            <asp:Button ID="btnMod" runat="server" Text="Modificar fechas" CssClass="w3-button w3-amber w3-hover-blue" Width="100%" OnClick="btnMod_Click" ValidationGroup="vlgrPer1" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnMod" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ddlPeriodo" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function modifsuccessalert() {
            swal({
                title: '¡Información modificada!',
                text: 'La información se modificó con éxito',
                type: 'success',
                showConfirmButton: false,
                timer: 2000
            });
        }
    </script>

</asp:Content>
