<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mstrpgAdmin.Master" AutoEventWireup="true" CodeBehind="Mensajes.aspx.cs" Inherits="SICOES2018.GUI.Mensajes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>Mensajes</h2>
    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <div class="w3-row">
            <h4>ENVIAR MENSAJES</h4>
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
                    <div class="w3-col m4">
                        <asp:Button ID="btnNewMsgTodos" runat="server" Text="Enviar mensaje general" CssClass="w3-padding w3-button w3-blue w3-hover-amber w3-right w3-margin-top" OnClick="btnNewMsgTodos_Click" Style="width: 300px" />
                    </div>

                </div>

                <div class="w3-row w3-padding">
                    <div class="w3-col m12">
                        <asp:Label ID="lbAlumnosReg" runat="server" Text="Alumnos del grupo" Font-Bold="true"></asp:Label>
                        <div class="w3-responsive">
                            <asp:GridView ID="gvAlumnos" runat="server" AutoGenerateColumns="False" CellPadding="6"
                                CssClass="w3-table w3-striped w3-border" GridLines="None" ShowHeaderWhenEmpty="True" AllowPaging="true" PageSize="30" OnPageIndexChanging="gvAlumnos_PageIndexChanging" OnRowCommand="gvAlumnos_RowCommand" DataKeyNames="IDAlumno">
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
                                    <asp:ButtonField HeaderText="Enviar mensaje" ButtonType="Link" ControlStyle-CssClass="btn btn-success btn-sm" Text="<i class='fa fa-envelope w3-large'></i>" CausesValidation="False" CommandName="SelectAlum1" Visible="true" />
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

    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <div class="w3-row">
            <h4>MENSAJES RECIBIDOS</h4>
        </div>
        <hr style="margin: 5px" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="w3-row w3-padding">
                    <div class="w3-col m12">
                        <asp:Label ID="lbgvMensajesMestro" runat="server" Text="Mensajes" Font-Bold="true"></asp:Label>
                        <div class="w3-responsive">
                            <asp:GridView ID="gvMensajes" runat="server" AutoGenerateColumns="False" CellPadding="6"
                                CssClass="w3-table w3-striped w3-border" GridLines="None" ShowHeaderWhenEmpty="True" AllowPaging="true" PageSize="30" OnPageIndexChanging="gvMensajes_PageIndexChanging" OnRowCommand="gvMensajes_RowCommand" DataKeyNames="IDMensaje">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("IDMensaje") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remitente">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Remitente") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Asunto">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Asunto") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Fecha") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:ButtonField HeaderText="Ver mensaje" ButtonType="Link" ControlStyle-CssClass="btn btn-success btn-sm" Text="<i class='fa fa-eye w3-large'></i>" CausesValidation="False" CommandName="SelectMsg" Visible="true" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>

            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>


    <asp:UpdatePanel ID="upModal" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <%--MODAL PARA DAR DE BAJA AL ALUMNO--%>
            <div id="modalNewMsg" class="w3-modal">
                <div class="w3-modal-content w3-animate-top w3-card-4 w3-round">
                    <header class="w3-container w3-blue w3-round" style="height: 50px">
                        <h3 class="w3-display-topleft w3-margin-left">Enviar mensaje al alumno</h3>
                        <span onclick="document.getElementById('modalNewMsg').style.display='none'"
                            class="w3-button w3-display-topright w3-hover-amber w3-round">&times;</span>
                    </header>
                    <div class="w3-container" style="min-height: 350px; max-height: 350px">
                        <div class="w3-row w3-padding">
                            <asp:Label ID="lbAsunto" runat="server" Text="Asunto" Font-Bold="true"></asp:Label><br />
                            <asp:TextBox runat="server" CssClass="w3-input w3-margin" ID="txtAsunto" Width="50%"></asp:TextBox>
                        </div>
                        <div class="w3-row w3-padding">
                            <asp:Label ID="lbMensaje" runat="server" Text="Mensaje:" Font-Bold="true" CssClass="w3-margin-bottom"></asp:Label><br />
                            <asp:TextBox CssClass="w3-input w3-margin" ID="txtMensaje" Width="100%" Style="max-width: 100%; min-width: 100%; max-height: 150px; min-height: 150px" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <div class="w3-row">
                            <asp:Button ID="btnEnviarMsg" runat="server" Text="Enviar mensaje" CssClass="w3-padding w3-button w3-blue w3-hover-amber w3-display-bottommiddle" OnClick="btnEnviarMsg_Click" Style="width: 300px" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnEnviarMsg" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="upModalGrupo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <%--MODAL PARA DAR DE BAJA AL ALUMNO--%>
            <div id="modalNewMsgGrupo" class="w3-modal">
                <div class="w3-modal-content w3-animate-top w3-card-4 w3-round">
                    <header class="w3-container w3-blue w3-round" style="height: 50px">
                        <h3 class="w3-display-topleft w3-margin-left">Enviar mensaje al grupo</h3>
                        <span onclick="document.getElementById('modalNewMsgGrupo').style.display='none'"
                            class="w3-button w3-display-topright w3-hover-amber w3-round">&times;</span>
                    </header>
                    <div class="w3-container" style="min-height: 350px; max-height: 350px">
                        <div class="w3-row w3-padding">
                            <asp:Label ID="lbAsuntoGrupo" runat="server" Text="Asunto" Font-Bold="true"></asp:Label><br />
                            <asp:TextBox runat="server" CssClass="w3-input w3-margin" ID="txtAsuntoGrupo" Width="50%"></asp:TextBox>
                        </div>
                        <div class="w3-row w3-padding">
                            <asp:Label ID="lbMensajeGrupo" runat="server" Text="Mensaje:" Font-Bold="true" CssClass="w3-margin-bottom"></asp:Label><br />
                            <asp:TextBox CssClass="w3-input w3-margin" ID="txtMensajeGrupo" Width="100%" Style="max-width: 100%; min-width: 100%; max-height: 150px; min-height: 150px" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <div class="w3-row">
                            <asp:Button ID="btnEnviarMsgGrupo" runat="server" Text="Enviar mensaje" CssClass="w3-padding w3-button w3-blue w3-hover-amber w3-display-bottommiddle" OnClick="btnEnviarMsgGrupo_Click" Style="width: 300px" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnEnviarMsgGrupo" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="upModalVerMsg" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <%--MODAL PARA DAR DE BAJA AL ALUMNO--%>
            <div id="modalVerMsg" class="w3-modal">
                <div class="w3-modal-content w3-animate-top w3-card-4 w3-round">
                    <header class="w3-container w3-blue w3-round" style="height: 50px">
                        <h3 class="w3-display-topleft w3-margin-left">Mensaje recibido</h3>
                        <span onclick="document.getElementById('modalVerMsg').style.display='none'"
                            class="w3-button w3-display-topright w3-hover-amber w3-round">&times;</span>
                    </header>
                    <div class="w3-container" style="min-height: 350px; max-height: 350px">
                        <div class="w3-row w3-padding">
                            <asp:Label ID="lbAsuntoVerMsg" runat="server" Text="Asunto" Font-Bold="true"></asp:Label><br />
                            <asp:TextBox runat="server" CssClass="w3-input w3-margin" ID="txtAsuntoVerMsg" Width="50%" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="w3-row w3-padding">
                            <asp:Label ID="lbMensajeVerMsg" runat="server" Text="Mensaje:" Font-Bold="true" CssClass="w3-margin-bottom"></asp:Label><br />
                            <asp:TextBox CssClass="w3-input w3-margin" ID="txtMensajeVerMsg" Width="100%" Style="max-width: 100%; min-width: 100%; max-height: 150px; min-height: 150px" runat="server" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>

    <script type="text/javascript">
        function OpenModalNewMsg() {
            document.getElementById('modalNewMsg').style.display = 'block'
        }
        function OpenModalNewMsgGrupo() {
            document.getElementById('modalNewMsgGrupo').style.display = 'block'
        }
        function OpenModalVerMsg() {
            document.getElementById('modalVerMsg').style.display = 'block'
        }

    </script>
    <script type="text/javascript">
        function successalert() {
            swal({
                title: '¡Mensaje enviado!',
                text: 'El mensaje ha sido enviado correctamente',
                type: 'success',
                showConfirmButton: false,
                timer: 2000
            });
        }
    </script>
</asp:Content>
