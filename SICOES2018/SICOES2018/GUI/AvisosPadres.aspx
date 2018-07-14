<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mstrpgAdmin.Master" AutoEventWireup="true" CodeBehind="AvisosPadres.aspx.cs" Inherits="SICOES2018.GUI.AvisosPadres" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <h2>Avisos para padres y tutores</h2>

    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <div class="w3-row">
            <h4>GENERAR AVISOS</h4>
        </div>
        <hr style="margin: 5px" />
        <asp:UpdatePanel ID="upAvisos" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="w3-row w3-padding">
                    <asp:Label ID="lbPeriodo" runat="server" Text="Por medio de la presente se le informa que..." Font-Bold="true" CssClass="w3-margin-left"></asp:Label>
                    <asp:RequiredFieldValidator ID="reqNomAlum" runat="server" ControlToValidate="txtAviso" ErrorMessage="¡Ingrese un texto para el aviso!" ViewStateMode="Inherit" ForeColor="Red" Font-Size="Small" Height="10px" ValidationGroup="vlgrDatos"></asp:RequiredFieldValidator>

                    <asp:TextBox CssClass="w3-input w3-margin" ID="txtAviso" Width="100%" Style="max-width: 100%; min-width: 100%; max-height: 100px; min-height: 100px" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="w3-row">
                    <asp:Button runat="server" Text="Generar Aviso" ID="Generar" CssClass="w3-padding w3-button w3-amber w3-hover-blue w3-round w3-right" OnClick="Generar_Click" ValidationGroup="vlgrDatos" />
                </div>
                <div class="w3-row">
                    <asp:Label ID="Label1" runat="server" Text="Ejemplo:" Font-Bold="true" CssClass="w3-margin-left"></asp:Label>
                    <asp:Image ID="Image1" runat="server" ImageUrl="http://sicoes-001-site1.dtempurl.com/Logos/Captura%20de%20pantalla%20(7).png" />
                </div>
                <div class="w3-row w3-padding">
                    <CR:CrystalReportViewer ID="AvisoPadres" runat="server" AutoDataBind="true" ToolPanelView="None" />
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Generar" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>

    </div>

</asp:Content>
