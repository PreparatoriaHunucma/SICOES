<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mstrpgAlumno.Master" AutoEventWireup="true" CodeBehind="ConsultaCalificaciones.aspx.cs" Inherits="SICOES2018.GUI.ConsultaCalificaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>Consulta de calificaciones</h2>

    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <div class="w3-row">
            <h4>CALIFICACIONES</h4>
        </div>
        <hr style="margin: 5px" />
        <asp:UpdatePanel ID="upConCalif" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

                <div class="w3-row w3-padding">
                    <div class="w3-col m4">
                        <asp:Label ID="lbCiclo" runat="server" Text="Periodo escolar" Font-Bold="true" CssClass="w3-margin-left"></asp:Label>
                        <asp:DropDownList ID="ddlciclo" runat="server" CssClass="w3-input w3-margin-left w3-margin-bottom" OnSelectedIndexChanged="ddlciclo_SelectedIndexChanged" AppendDataBoundItems="true" AutoPostBack="true" Width="90%"></asp:DropDownList>
                    </div>

                    <div class="w3-col m4">
                        <asp:Label ID="lbGrupo" runat="server" Text="Grupo" Font-Bold="true" CssClass="w3-margin-left"></asp:Label>
                        <asp:DropDownList ID="ddlGrupo" runat="server" CssClass="w3-input w3-margin-left w3-margin-bottom" OnSelectedIndexChanged="ddlGrupo_SelectedIndexChanged" AppendDataBoundItems="true" AutoPostBack="true" Width="90%"></asp:DropDownList>
                    </div>
                </div>
                <div class="w3-row w3-padding">
                    <asp:GridView ID="gvConCalif" runat="server" CssClass="w3-table w3-striped w3-border" Style="min-height: 100%" AutoGenerateColumns="False" GridLines="None" ShowHeaderWhenEmpty="True" >
                        <Columns>
                            <asp:TemplateField HeaderText="Asignatura">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_NameAddEscPro" runat="server" Text='<%#Eval("NomAsig") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="1er Reporte">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_ClaveAddEscPro" runat="server" Text='<%#Eval("cal1") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="2do Reporte">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_ClaveAddEscPro" runat="server" Text='<%#Eval("cal2") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ordinario">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_ClaveAddEscPro" runat="server" Text='<%#Eval("cal3") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Promedio">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_ClaveAddEscPro" runat="server" Text='<%#Eval("cal4") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlciclo" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddlGrupo" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>

</asp:Content>
