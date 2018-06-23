<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mstrpgAdmin.Master" AutoEventWireup="true" CodeBehind="GestionPlantel.aspx.cs" Inherits="SICOES2018.GUI.GestionPlantel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <div class="w3-row">
             <div class="w3-col m4">
                        <h4>INFORMACIÓN DEL PLANTEL</h4>
                    </div>
            <div "w3-padding w3-col m6">
                <%--NOMBRE DEL PLANTEL--%>
                <div class="w3-row" style="margin-bottom: -20px">
                            <asp:Label ID="lbNomPlan" runat="server" Text="Nombre de la escuela" Font-Bold="true"></asp:Label>
                            <asp:RequiredFieldValidator ID="reqNomAlum" runat="server" ControlToValidate="txtNomPlan" ErrorMessage="¡Ingrese el nombre de la Escuela!" ViewStateMode="Inherit" ForeColor="Red" Font-Size="Small" Height="10px" ValidationGroup="vlgrDatos"></asp:RequiredFieldValidator>
                            <br />
                            <asp:TextBox runat="server" CssClass="w3-input" ID="txtNomPlan" type="text" Width="30%"/>
                            <br />
                        </div>
                <%--CLAVE--%>
                <div class="w3-row" style="margin-bottom: -20px">
                            <asp:Label ID="lbClave" runat="server" Text="Clave de la Escuela" Font-Bold="true"></asp:Label>
                            <br />
                            <asp:TextBox runat="server" CssClass="w3-input" ID="txtClave" type="text" Width="30%" /><br />
                        </div>
                <%--Correo--%>
                 <div class="w3-row" style="margin-bottom: -20px">
                            <asp:Label ID="lbCorreo" runat="server" Text="Correo Electrónico" Font-Bold="true"></asp:Label>
                            <br />
                            <asp:TextBox runat="server" CssClass="w3-input" ID="txtCorreo" type="text" Width="30%" /><br />
                        </div>
                                </div>
            <%--DIRECCIÓN--%>
            <asp:UpdatePanel ID="upDatosDir" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <hr style="margin: 5px" />
                        <div class="w3-row">
                            <div class="w3-col m3">
                                <asp:Label ID="lbCalleAlum" runat="server" Text="Calle" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:TextBox runat="server" CssClass="w3-input" ID="txtCallAlum" type="text" Style="width: 200px" /><br />
                            </div>
                            <div class="w3-col m3">
                                <asp:Label ID="lbNumAlum" runat="server" Text="Número" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:TextBox runat="server" CssClass="w3-input" ID="txtNumAlum" type="text" Style="width: 200px" /><br />
                            </div>
                            <div class="w3-col m3">
                                <asp:Label ID="lbColAlum" runat="server" Text="Colonia" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:TextBox runat="server" CssClass="w3-input" ID="txtColAlum" type="text" Style="width: 200px" /><br />
                            </div>
                            <div class="w3-col m3">
                                <asp:Label ID="lbCPAlum" runat="server" Text="Código Postal" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:TextBox runat="server" CssClass="w3-input" ID="txtCPAlum" type="text" Style="width: 200px" /><br />
                            </div>
                        </div>
                        <div class="w3-row">
                            <div class="w3-col m3">
                                <asp:Label ID="lbPaisAlum" runat="server" Text="País" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:DropDownList CssClass="w3-dropdown-click w3-input" ID="ddlPaisAlum" Style="width: 175px" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlPaisAlum_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                <a style="cursor: pointer" title="Agregar un país" onclick="document.getElementById('modalAddPais').style.display = 'block'">&nbsp&nbsp<i class="fa fa-plus-circle w3-xlarge"></i></a>
                            </div>
                            <div class="w3-col m3">
                                <asp:Label ID="lbEstadoAlum" runat="server" Text="Estado" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:DropDownList CssClass="w3-dropdown-click w3-input" ID="ddlEstadoAlum" Style="width: 175px" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlEstadoAlum_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                <a style="cursor: pointer" title="Agregar un estado" onclick="document.getElementById('modalAddEstado').style.display = 'block'">&nbsp&nbsp<i class="fa fa-plus-circle w3-xlarge"></i></a>
                            </div>
                            <div class="w3-col m3">
                                <asp:Label ID="lbMunicipioAlum" runat="server" Text="Municipio" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:DropDownList CssClass="w3-dropdown-click w3-input" ID="ddlMunicipioAlum" Style="width: 175px" runat="server" AppendDataBoundItems="true" AutoPostBack="true"></asp:DropDownList>
                                <a style="cursor: pointer" onclick="document.getElementById('modalAddMunicipio').style.display = 'block'" title="Agregar un municipio">&nbsp&nbsp<i class="fa fa-plus-circle w3-xlarge"></i></a>
                            </div>
                            <div class="w3-col m3">
                                <asp:Label ID="lbTelAlum" runat="server" Text="Teléfono" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:TextBox runat="server" CssClass="w3-input" ID="txtTelAlum" TextMode="Number" onkeypress="return this.value.length<=9" Style="width: 200px" /><br />
                            </div>
                        </div>
                
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlPaisAlum" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddlEstadoAlum" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
             <%--BOTON PARA MODIFICAR EL PLANTEL--%>
    
        <asp:UpdatePanel ID="upBotones" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
     <div class="w3-row">
                     <asp:Button CssClass="w3-margin-right w3-third w3-button w3-amber w3-hover-blue w3-round" ID="btnModifAlumno" runat="server" Text="Modificar Información" OnClick="btnModifAlumno_Click" CausesValidation="true" Width="31%" />
         
                </div>
                <br />
                 </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnModifAlumno" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
            </div>
        </div>

             <%--DEPARTAMENTOS--%>

    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
    <asp:UpdatePanel ID="UpDepartamentos" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
     
          <div class="w3-row">
                        <h4>DEPARTAMENTOS</h4>
                     <div class="w3-row">
                            <div class="w3-col m3">
                                <asp:Label ID="lblDepartamentos" runat="server" Text="Departamentos" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:DropDownList CssClass="w3-dropdown-click w3-input" ID="ddlDepartamentos" Style="width: 175px" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                <a style="cursor: pointer" title="Agregar un departamento" onclick="document.getElementById('modalAddDepartamento').style.display = 'block'">&nbsp&nbsp<i class="fa fa-plus-circle w3-xlarge"></i></a>
                            </div>
                        <div class="w3-col m3">
                                <asp:Label ID="lblEncargado" runat="server" Text="Encargado Actual" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:DropDownList CssClass="w3-dropdown-click w3-input" ID="ddlEncargado" Style="width: 175px" runat="server" AppendDataBoundItems="true" AutoPostBack="true"></asp:DropDownList>
                            </div>
                          <div class="w3-col m3">
                                <asp:Label ID="lblDocentes" runat="server" Text="Lista de Docentes" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:DropDownList CssClass="w3-dropdown-click w3-input" ID="ddlDocentes" Style="width: 175px" runat="server" AppendDataBoundItems="true" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>

               <%--BOTON PARA MODIFICAR ENCARGADOS--%>
    <br />
        <asp:UpdatePanel ID="UpBotonEncargado" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
     <div class="w3-row">
                     <asp:Button CssClass="w3-margin-right w3-third w3-button w3-amber w3-hover-blue w3-round" ID="btnModifEncargado" runat="server" Text="Modificar Encargado" OnClick="btnModifEncargado_Click" CausesValidation="true" Width="31%" />
                </div>
                <br />
                 </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnModifEncargado" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
              </div>
         </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
         </div>
                 
   
      <%--MODAL PARA AGREGAR UN PAIS--%>
    <div id="modalAddPais" class="w3-modal">
        <div class="w3-modal-content w3-animate-top w3-card-4 w3-round">
            <header class="w3-container w3-blue w3-round" style="height: 50px">
                <h3 class="w3-display-topleft w3-margin-left">Países</h3>
                <span onclick="document.getElementById('modalAddPais').style.display='none'"
                    class="w3-button w3-display-topright w3-hover-amber w3-round">&times;</span>
            </header>
            <div class="w3-container" style="min-height: 300px; max-height: 300px">
                <asp:UpdatePanel ID="upModalPais" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="w3-row w3-padding-16">
                            <div class="w3-col m6">
                                <asp:Label ID="lbAddPais" runat="server" Text="Ingresa el nombre del país" Font-Bold="true"></asp:Label>
                                <asp:RequiredFieldValidator ID="rqNombrePais" runat="server" ControlToValidate="txtAddPais" ErrorMessage="¡Ingrese el nombre del país!" ViewStateMode="Inherit" ForeColor="Red" Font-Size="Small" Height="10px" ValidationGroup="vlgrDatosAddPais"></asp:RequiredFieldValidator>
                                <asp:TextBox CssClass="w3-input w3-margin" ID="txtAddPais" Width="80%" runat="server"></asp:TextBox>
                            </div>
                            <div class="w3-col m6">
                                <b>
                                    <asp:Label ID="lbVerPais" runat="server" Text="Países registrados"></asp:Label>
                                </b>
                                <div class="w3-responsive">

                                    <asp:GridView ID="gvAddPais" runat="server" AutoGenerateColumns="False" CellPadding="6" OnRowCancelingEdit="gvAddPais_RowCancelingEdit"
                                        OnRowEditing="gvAddPais_RowEditing" OnRowUpdating="gvAddPais_RowUpdating" CssClass="w3-table w3-striped w3-border" Style="min-height: 212px" GridLines="None" ShowHeaderWhenEmpty="True" AllowPaging="true" PageSize="3" OnPageIndexChanging="gvAddPais_PageIndexChanging" EnableViewState="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("IDPais") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nombre">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Nombre") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txt_Name" CssClass="w3-input" Style="min-height: 20px; max-height: 20px" runat="server" Text='<%#Eval("Nombre") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btn_Edit" runat="server" CommandName="Edit" ToolTip="Editar el nombre del país"><i class="fa fa-pencil-alt"></i></asp:LinkButton>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="btn_Update" runat="server" Text="Update" CommandName="Update" CausesValidation="false" ToolTip="Aplicar cambios">  <i class="fa fa-check"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel" ToolTip="Descartar cambios"> <i class="fa fa-times"></i></asp:LinkButton>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <div class="w3-row">
                            <asp:Button ID="btnAddNewPais" runat="server" Text="Agregar país" CssClass="w3-padding w3-button w3-blue w3-hover-amber w3-display-bottommiddle" OnClick="btnAddNewPais_Click" Style="width: 300px" ValidationGroup="vlgrDatosAddPais" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <%--MODAL PARA AGREGAR UN ESTADO--%>
    <div id="modalAddEstado" class="w3-modal">
        <div class="w3-modal-content w3-animate-top w3-card-4 w3-round">
            <header class="w3-container w3-blue w3-round" style="height: 50px">
                <h3 class="w3-display-topleft w3-margin-left">Estados</h3>
                <span onclick="document.getElementById('modalAddEstado').style.display='none'"
                    class="w3-button w3-display-topright w3-hover-amber w3-round">&times;</span>
            </header>
            <div class="w3-container" style="min-height: 300px; max-height: 300px">
                <asp:UpdatePanel ID="upModalEstado" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="w3-row w3-padding-16">
                            <div class="w3-col m6">
                                <asp:Label ID="lbAddEstado" runat="server" Text="Selecciona un país y escribe el nombre del estado" Font-Bold="true"></asp:Label>
                                <asp:DropDownList CssClass="w3-dropdown-click w3-input w3-margin" ID="ddlPaisAddEstado" Style="width: 80%" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlPaisAddEstado_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rqNombreEstado" runat="server" ControlToValidate="txtAddPais" ErrorMessage="¡Ingrese el nombre del estado!" ViewStateMode="Inherit" ForeColor="Red" Font-Size="Small" Height="10px" ValidationGroup="vlgrDatosAddEstado"></asp:RequiredFieldValidator>
                                <asp:TextBox CssClass="w3-input w3-margin" ID="txtAddEstado" Width="80%" runat="server"></asp:TextBox>
                            </div>
                            <div class="w3-col m6">
                                <asp:Label ID="lbVerEstado" runat="server" Text="Estados registrados" Font-Bold="true"></asp:Label>
                                <div class="w3-responsive">
                                    <asp:GridView ID="gvAddEstado" runat="server" AutoGenerateColumns="False" CellPadding="6" OnRowCancelingEdit="gvAddEstado_RowCancelingEdit"
                                        OnRowEditing="gvAddEstado_RowEditing" OnRowUpdating="gvAddEstado_RowUpdating" CssClass="w3-table w3-striped w3-border" Style="min-height: 212px" GridLines="None" ShowHeaderWhenEmpty="True" AllowPaging="true" PageSize="3" OnPageIndexChanging="gvAddEstado_PageIndexChanging" EnableViewState="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_IDAddEstado" runat="server" Text='<%#Eval("IDEstado") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nombre">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_NameAddEstado" runat="server" Text='<%#Eval("Nombre") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txt_NameAddEstado" CssClass="w3-input" Style="min-height: 20px; max-height: 20px" runat="server" Text='<%#Eval("Nombre") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btn_EditEstado" runat="server" CommandName="Edit" CausesValidation="false"><i class="fa fa-pencil-alt"></i></asp:LinkButton>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="btn_UpdateEstado" runat="server" Text="Update" CommandName="Update" CausesValidation="false">  <i class="fa fa-check"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="btn_CancelEstado" runat="server" Text="Cancel" CommandName="Cancel"> <i class="fa fa-times"></i></asp:LinkButton>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <div class="w3-row">
                            <asp:Button ID="btnAddEstado" runat="server" Text="Agregar estado" CssClass="w3-padding w3-button w3-blue w3-hover-amber w3-display-bottommiddle" OnClick="btnAddEstado_Click" Style="width: 300px" CausesValidation="false" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlPaisAddEstado" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>

            </div>
        </div>
    </div>
    <%--MODAL PARA AGREGAR UN MUNICIPIO--%>
    <div id="modalAddMunicipio" class="w3-modal">
        <div class="w3-modal-content w3-animate-top w3-card-4 w3-round">
            <header class="w3-container w3-blue w3-round" style="height: 50px">
                <h3 class="w3-display-topleft w3-margin-left">Municipios</h3>
                <span onclick="document.getElementById('modalAddMunicipio').style.display='none'"
                    class="w3-button w3-display-topright w3-hover-amber w3-round">&times;</span>
            </header>
            <div class="w3-container" style="min-height: 300px; max-height: 300px">
                <asp:UpdatePanel ID="upModalMunicipio" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="w3-row w3-padding-16">
                            <div class="w3-col m6">
                                <asp:Label ID="lbAddMunicipio" runat="server" Text="Selecciona un país y un estado, despues escribe el nombre del municipio" Font-Bold="true"></asp:Label>
                                <asp:DropDownList CssClass="w3-dropdown-click w3-input w3-margin" ID="ddlPaisAddMunicipio" Style="width: 80%" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlPaisAddMunicipio_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                <asp:DropDownList CssClass="w3-dropdown-click w3-input w3-margin-left" ID="ddlEstadoAddMunicipio" Style="width: 80%" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlEstadoAddMunicipio_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rqNombreMunicipio" runat="server" ControlToValidate="txtAddPais" ErrorMessage="¡Ingrese el nombre del municipio!" ViewStateMode="Inherit" ForeColor="Red" Font-Size="Small" Height="10px" ValidationGroup="vlgrDatosAddMunicipio"></asp:RequiredFieldValidator>
                                <asp:TextBox CssClass="w3-input w3-margin" ID="txtAddMunicipio" Width="80%" runat="server"></asp:TextBox>
                            </div>
                            <div class="w3-col m6">
                                <asp:Label ID="lbMuniReg" runat="server" Text="Municipios registrados" Font-Bold="true"></asp:Label>
                                <div class="w3-responsive">
                                    <asp:GridView ID="gvAddMunicipio" runat="server" CssClass="w3-table w3-striped w3-border" Style="min-height: 212px" AutoGenerateColumns="False" GridLines="None" ShowHeaderWhenEmpty="True" AllowPaging="true" PageSize="3" OnPageIndexChanging="gvAddMunicipio_PageIndexChanging" OnRowCancelingEdit="gvAddMunicipio_RowCancelingEdit" OnRowEditing="gvAddMunicipio_RowEditing" OnRowUpdating="gvAddMunicipio_RowUpdating">
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_IDAddMuni" runat="server" Text='<%#Eval("IDMunicipio") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nombre">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_NameAddMuni" runat="server" Text='<%#Eval("Nombre") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txt_NameAddMuni" CssClass="w3-input" Style="min-height: 20px; max-height: 20px" runat="server" Text='<%#Eval("Nombre") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btn_EditMuni" runat="server" CommandName="Edit" CausesValidation="false"><i class="fa fa-pencil-alt"></i></asp:LinkButton>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="btn_UpdateMuni" runat="server" Text="Update" CommandName="Update" CausesValidation="false">  <i class="fa fa-check"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="btn_CancelMuni" runat="server" Text="Cancel" CommandName="Cancel"> <i class="fa fa-times"></i></asp:LinkButton>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <div class="w3-row">
                            <asp:Button ID="btnAddMunicipio" runat="server" Text="Agregar municipio" CssClass="w3-padding w3-button w3-blue w3-hover-amber w3-display-bottommiddle" OnClick="btnAddMunicipio_Click" Style="width: 300px" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlPaisAddMunicipio" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlEstadoAddMunicipio" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <%--MODAL PARA AGREGAR UN DEPARTAMENTO--%>
    <div id="modalAddDepartamento" class="w3-modal">
        <div class="w3-modal-content w3-animate-top w3-card-4 w3-round">
            <header class="w3-container w3-blue w3-round" style="height: 50px">
                <h3 class="w3-display-topleft w3-margin-left">Países</h3>
                <span onclick="document.getElementById('modalAddDepartamento').style.display='none'"
                    class="w3-button w3-display-topright w3-hover-amber w3-round">&times;</span>
            </header>
            <div class="w3-container" style="min-height: 300px; max-height: 300px">
                <asp:UpdatePanel ID="UpModalDepartamento" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="w3-row w3-padding-16">
                            <div class="w3-col m6">
                                <asp:Label ID="lbAddDepartamento" runat="server" Text="Ingresa el nombre del Departamento" Font-Bold="true"></asp:Label>
                                <asp:RequiredFieldValidator ID="rqNombreDepartamento" runat="server" ControlToValidate="txtAddDepartamento" ErrorMessage="¡Ingrese el nombre del departamento!" ViewStateMode="Inherit" ForeColor="Red" Font-Size="Small" Height="10px" ValidationGroup="vlgrDatosAddDepartamento"></asp:RequiredFieldValidator>
                                <asp:TextBox CssClass="w3-input w3-margin" ID="txtAddDepartamento" Width="80%" runat="server"></asp:TextBox>
                            </div>
                            <div class="w3-col m6">
                                <b>
                                    <asp:Label ID="lbVerDepartamento" runat="server" Text="Departamentos registrados"></asp:Label>
                                </b>
                                <div class="w3-responsive">

                                    <asp:GridView ID="gvAddDepartamento" runat="server" AutoGenerateColumns="False" CellPadding="6" OnRowCancelingEdit="gvAddDepartamento_RowCancelingEdit"
                                        OnRowEditing="gvAddDepartamento_RowEditing" OnRowUpdating="gvAddDepartamento_RowUpdating" CssClass="w3-table w3-striped w3-border" Style="min-height: 212px" GridLines="None" ShowHeaderWhenEmpty="True" AllowPaging="true" PageSize="3" OnPageIndexChanging="gvAddDepartamento_PageIndexChanging" EnableViewState="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("IDDepartamentos") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nombre">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("NombreDep") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txt_Name" CssClass="w3-input" Style="min-height: 20px; max-height: 20px" runat="server" Text='<%#Eval("NombreDep") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btn_Edit" runat="server" CommandName="Edit" ToolTip="Editar el nombre del departamento"><i class="fa fa-pencil-alt"></i></asp:LinkButton>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="btn_Update" runat="server" Text="Update" CommandName="Update" CausesValidation="false" ToolTip="Aplicar cambios">  <i class="fa fa-check"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel" ToolTip="Descartar cambios"> <i class="fa fa-times"></i></asp:LinkButton>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <div class="w3-row">
                            <asp:Button ID="btnAddNewDepartamento" runat="server" Text="Agregar Departamento" CssClass="w3-padding w3-button w3-blue w3-hover-amber w3-display-bottommiddle" OnClick="btnAddNewDepartamento_Click" Style="width: 300px" ValidationGroup="vlgrDatosAddDepartamento" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <script>
        function modifsuccessalert() {
            swal({
                title: '¡Información modificada!',
                text: 'La información del plantel se modificó con éxito',
                type: 'success',
                showConfirmButton: false,
                timer: 2000
            });
        }
    </script>
   
</asp:Content>
