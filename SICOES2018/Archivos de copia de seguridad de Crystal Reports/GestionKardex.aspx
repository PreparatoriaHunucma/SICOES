<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mstrpgAdmin.Master" AutoEventWireup="true" CodeBehind="GestionKardex.aspx.cs" Inherits="SICOES2018.GUI.GestionKardex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>Generar lista de asistencia</h2>

    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <div class="w3-row">
            <h4>GENERAR KARDEX</h4>
        </div>
        <hr style="margin: 5px" />
        <asp:UpdatePanel ID="upGrupos" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="w3-row w3-padding">
                    <div class="w3-col m4">
                        <asp:Label ID="lbPeriodo" runat="server" Text="Periodo escolar" Font-Bold="true" CssClass="w3-margin-left"></asp:Label>
                        <asp:DropDownList ID="ddlPeriodo" runat="server" CssClass="w3-input w3-margin-left w3-margin-bottom" OnSelectedIndexChanged="ddlPeriodo_SelectedIndexChanged" AppendDataBoundItems="true" AutoPostBack="true" Width="90%"></asp:DropDownList>
                    </div>

                    <div class="w3-col m4">
                        <asp:Label ID="lbGrupo" runat="server" Text="Grupo" Font-Bold="true" CssClass="w3-margin-left"></asp:Label>
                        <asp:DropDownList ID="ddlGrupo" runat="server" CssClass="w3-input w3-margin-left w3-margin-bottom" OnSelectedIndexChanged="ddlGrupo_SelectedIndexChanged" AppendDataBoundItems="true" AutoPostBack="true" Width="90%"></asp:DropDownList>
                    </div>
                </div>
                <div class="w3-row w3-padding">
                    <div class="w3-col m12">
                        <asp:Label ID="lbAlumnosReg" runat="server" Text="Alumnos del grupo" Font-Bold="true"></asp:Label>
                        <div class="w3-responsive">
                            <asp:GridView ID="gvAlumnos" runat="server" AutoGenerateColumns="False" CellPadding="6"
                                CssClass="w3-table w3-striped w3-border" Style="min-height: 288px" GridLines="None" ShowHeaderWhenEmpty="True" AllowPaging="true" PageSize="30" OnPageIndexChanging="gvAlumnos_PageIndexChanging" OnRowCommand="gvAlumnos_RowCommand" DataKeyNames="IDAlumno">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("IDAlumno") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Alumno">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Alumno") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:ButtonField HeaderText="Kardex" ButtonType="Link" ControlStyle-CssClass="btn btn-success btn-sm" Text="<i class='fa fa-file-alt w3-large'></i>" CausesValidation="False" CommandName="SelectAlum1" Visible="true" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>

            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlPeriodo" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddlGrupo" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
