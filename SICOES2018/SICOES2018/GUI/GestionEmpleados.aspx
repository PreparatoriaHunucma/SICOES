<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mstrpgAdmin.Master" AutoEventWireup="true" CodeBehind="GestionEmpleados.aspx.cs" Inherits="SICOES2018.GUI.AltaUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="w3-row">
        <div class="w3-col m8">
            <h2>Gestión de empleados</h2>
        </div>
        <div class=" w3-col m4 w3-padding-16">
            <input class="w3-button w3-amber w3-hover-blue  w3-right" type="button" onclick="document.getElementById('modalAlumnos').style.display = 'block'" value="Ver registros de empleados" />
        </div>
    </div>

    <%--DATOS GENERALES--%>
    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <asp:UpdatePanel ID="upDatosGen" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="w3-row">
                    <h4>DATOS DEL EMPLEADO</h4>
                </div>
                <hr style="margin: 5px" />
                <div class="w3-row">
                    <div class="w3-padding w3-col m6">
                        <div class="w3-row" style="margin-bottom: -20px">
                            <asp:Label ID="lbNomEmp" runat="server" Text="Nombre(s)" Font-Bold="true"></asp:Label>
                            <asp:RequiredFieldValidator ID="reqNomEmp" runat="server" ControlToValidate="txtNomEmp" ErrorMessage="¡Ingrese el nombre del alumno!" ViewStateMode="Inherit" ForeColor="Red" Font-Size="Small" Height="10px" ValidationGroup="vlgrDatosEmp"></asp:RequiredFieldValidator>
                            <br />
                            <asp:TextBox runat="server" CssClass="w3-input" ID="txtNomEmp" type="text" Style="width: 400px" />
                            <br />
                        </div>
                        <div class="w3-row" style="margin-bottom: -20px">
                            <asp:Label ID="lbApePatEmp" runat="server" Text="Primer Apellido" Font-Bold="true"></asp:Label>
                            <br />
                            <asp:TextBox runat="server" CssClass="w3-input" ID="txtApePatEmp" type="text" Style="width: 400px" /><br />
                        </div>
                        <div class="w3-row" style="margin-bottom: -20px">
                            <asp:Label ID="lbApeMatEmp" runat="server" Text="Segundo Apellido" Font-Bold="true"></asp:Label>
                            <br />
                            <asp:TextBox runat="server" CssClass="w3-input" ID="txtApeMatEmp" type="text" Style="width: 400px" /><br />
                        </div>
                        <div class="w3-row" style="margin-bottom: -20px">
                            <asp:Label ID="lbCedula" runat="server" Text="Cédula Profesional" Font-Bold="true"></asp:Label>
                            <asp:RequiredFieldValidator ID="reqCedula" runat="server" ControlToValidate="txtCedula" ErrorMessage="¡Ingrese la Cédula profesional!" ViewStateMode="Inherit" ForeColor="Red" Font-Size="Small" Height="10px" ValidationGroup="vlgrDatosEmp"></asp:RequiredFieldValidator>
                            <br />
                            <asp:TextBox runat="server" CssClass="w3-input" ID="txtCedula" MaxLength="18" type="text" Style="width: 400px" /><br />
                        </div>
                        <div class="w3-row" style="margin-bottom: -20px">
                            <asp:Label ID="lbGradoEmp" runat="server" Text="Último Grado Académico" Font-Bold="true"></asp:Label>
                            <br />
                            <asp:TextBox runat="server" CssClass="w3-input" ID="txtGradoEmp" MaxLength="18" type="text" Style="width: 400px" /><br />
                        </div>
                        <div class="w3-row" style="margin-bottom: -20px">
                            <asp:Label ID="lbCurriculum" runat="server" Text="Curriculum" Font-Bold="true"></asp:Label>
                            <br />
                            <asp:FileUpload runat="server" CssClass="w3-input " ID="filecurriculum" MaxLength="18" type="file" Style="width: 400px" onchange="loadimagecurri(event)" />
                            <asp:Label runat="server" Visible="false" ID="curriculumok"></asp:Label>
                            </br>
                        <asp:Button ID="btnResubirCurriculum" runat="server" Text="Cambiar Curriculum" OnClick="btnResubir_Click" CssClass="w3-button w3-amber w3-hover-blue" Width="100%" CausesValidation="false" Visible="false" />
                            <br />
                            <br />
                        </div>
                    </div>
                    <div class="w3-padding w3-col m6">
                        <div class="w3-row w3-center">
                            <div class="w3-row">
                                <asp:Image ID="imgFotoEmp" runat="server" ImageUrl="../Resources/images/imgPerfil.jpg" Style="width: 270px; height: 270px" CssClass="w3-image" ToolTip="Imágen de perfil del alumno" />
                            </div>
                            <div class="w3-row">
                                <div class="w3-col m5">
                                    <div class="image-upload w3-right">
                                        <label onclick="showBrowseDialog()" style="cursor: pointer" title="Subír una imágen">
                                            <i class="fa fa-folder-open w3-xxlarge" style="pointer-events: none; cursor: pointer"></i>
                                        </label>
                                        <asp:FileUpload runat="server" ID="fotoEmp" name="fotoEmp" type="file" accept="image/*" onchange="loadimage(event)" Style="display: none" />
                                    </div>
                                </div>
                                <div class="w3-col m2" style="margin-top: -10px">
                                    <label class="w3-xxlarge">|</label>
                                </div>
                                <div class="w3-col m5">
                                    <div class="image-upload w3-left">
                                        <label style="cursor: pointer" title="Tomar una fotografía" onclick="document.getElementById('modalTomarFoto').style.display='block'">
                                            <i class="fa fa-camera-retro w3-xxlarge" style="pointer-events: none; cursor: pointer"></i>
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="w3-row">
                                <asp:Button ID="btnConfirmFoto" runat="server" Text="Confirmar Foto" OnClick="btnConfirmFoto_Click" CssClass="w3-button w3-amber w3-hover-blue" Width="100%" CausesValidation="false" Style="display: none" OnClientClick="guardarboton(event)" />
                            </div>
                            <div class="w3-row">
                                <asp:Button ID="btnConfirmCurriculum" runat="server" Text="Confirmar Curriculum" OnClick="btnConfirmCurriculum_Click" CssClass="w3-button w3-amber w3-hover-blue" Width="100%" CausesValidation="false" Style="display: none" OnClientClick="guardarbotoncurri(event)" />
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnConfirmFoto" />
                <asp:PostBackTrigger ControlID="btnConfirmCurriculum" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <%--DATOS DEL DOMICILIO Y CONTACTO--%>
    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <asp:UpdatePanel ID="upDatosDir" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="w3-row">
                    <h4>DIRECCIÓN E INFORMACIÓN DE CONTACTO</h4>
                </div>
                <hr style="margin: 5px" />
                <div class="w3-row">
                    <div class="w3-padding w3-col m12">
                        <div class="w3-row" style="margin-bottom: -20px">
                            <asp:Label ID="lbDireccEmp" runat="server" Text="Dirección" Font-Bold="true"></asp:Label>
                            <br />
                            <asp:TextBox runat="server" CssClass="w3-input" ID="txtDireccEmp" type="text" placeholder="Calle, cruzamientos, Número, Colonia y Código Postal" /><br />
                        </div>
                        <div class="w3-row" style="margin-bottom: -20px">
                            <div class="w3-col m3">
                                <asp:Label ID="lbPaisEmp" runat="server" Text="País" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:DropDownList CssClass="w3-dropdown-click w3-input" ID="ddlPaisEmp" Style="width: 175px" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlPaisEmp_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                <a style="cursor: pointer" title="Agregar un país" onclick="document.getElementById('modalAddPais').style.display = 'block'">&nbsp&nbsp<i class="fa fa-plus-circle w3-xlarge"></i></a>
                            </div>
                            <div class="w3-col m3">
                                <asp:Label ID="lbEstadoEmp" runat="server" Text="Estado" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:DropDownList CssClass="w3-dropdown-click w3-input" ID="ddlEstadoEmp" Style="width: 175px" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlEstadoEmp_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                <a style="cursor: pointer" title="Agregar un estado" onclick="document.getElementById('modalAddEstado').style.display = 'block'">&nbsp&nbsp<i class="fa fa-plus-circle w3-xlarge"></i></a>
                            </div>
                            <div class="w3-col m3">
                                <asp:Label ID="lbMunicipioEmp" runat="server" Text="Municipio" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:DropDownList CssClass="w3-dropdown-click w3-input" ID="ddlMunicipioEmp" Style="width: 175px" runat="server" AppendDataBoundItems="true" AutoPostBack="true"></asp:DropDownList>
                                <a style="cursor: pointer" onclick="document.getElementById('modalAddMunicipio').style.display = 'block'" title="Agregar un municipio">&nbsp&nbsp<i class="fa fa-plus-circle w3-xlarge"></i></a>
                            </div>
                            <div class="w3-col m3">
                                <b>
                                    <asp:Label ID="lbTelAlum" runat="server" Text="Teléfono de Contacto"></asp:Label>
                                </b>
                                <br />
                                <asp:TextBox runat="server" CssClass="w3-input" ID="txtTelAlum" TextMode="Number" onkeypress="return this.value.length<=9" Style="width: 200px" /><br />
                            </div>
                        </div>
                        <div class="w3-row" style="margin-bottom: -20px">
                            <b>
                                <asp:Label ID="lbCorreoEmp" runat="server" Text="Correo Electrónico"></asp:Label>
                            </b>
                            <br />
                            <asp:TextBox runat="server" CssClass="w3-input" ID="TxtCorreoEmp" type="email" /><br />
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlPaisEmp" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddlEstadoEmp" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <%--Permisos de Empleado--%>
    <div class="w3-row">
        <div class="w3-col m6">
            <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right" style="width: 90%">
                <asp:UpdatePanel ID="upDatosPermisos" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <h4>PERMISOS ADMINSTRATIVOS</h4>
                        <hr style="margin: 5px" />
                        <div class="w3-col m12">
                            <div class="w3-row">
                                <asp:CheckBox runat="server" CssClass="w3-check" ID="chckDirectivo" type="checkbox" Text=" Directivo" Font-Bold="true" OnCheckedChanged="chckDirectivo_CheckedChanged" AutoPostBack="true"/>
                                <br />
                                <asp:CheckBox runat="server" CssClass="w3-check" ID="chckSecretariaAdm" type="checkbox" Text=" Secretaría Académica" Font-Bold="true" OnCheckedChanged="chckSecretariaAdm_CheckedChanged" AutoPostBack="true"/>
                                <br />
                                <asp:CheckBox runat="server" CssClass="w3-check" ID="chckSecretariaAca" type="checkbox" Text=" Secretaría Administrativa" Font-Bold="true" OnCheckedChanged="chckSecretariaAca_CheckedChanged" AutoPostBack="true"/>
                                <br />
                                <asp:CheckBox runat="server" CssClass="w3-check" ID="chckControl" type="checkbox" Text=" Control Escolar" Font-Bold="true" OnCheckedChanged="chckControl_CheckedChanged" AutoPostBack="true"/>
                                <br />
                                <asp:CheckBox runat="server" CssClass="w3-check" ID="chckDocente" type="checkbox" Text=" Docente" Font-Bold="true" OnCheckedChanged="chckDocente_CheckedChanged" AutoPostBack="true"/>
                                <br />
                            </div>
                            <br />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="chckDirectivo" EventName="CheckedChanged" />
                        <asp:AsyncPostBackTrigger ControlID="chckSecretariaAdm" EventName="CheckedChanged" />
                        <asp:AsyncPostBackTrigger ControlID="chckSecretariaAca" EventName="CheckedChanged" />
                        <asp:AsyncPostBackTrigger ControlID="chckControl" EventName="CheckedChanged" />
                        <asp:AsyncPostBackTrigger ControlID="chckDocente" EventName="CheckedChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="w3-col m6">
            <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
                <asp:UpdatePanel ID="upDatosEstatus" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <h4>ESTATUS DEL PERSONAL</h4>
                        <hr style="margin: 5px" />
                        <div class="w3-col m12">
                            <div class="w3-row">
                                <asp:CheckBox runat="server" CssClass="w3-check" ID="ChckActivo" type="checkbox" Text=" Activo" Font-Bold="true" OnCheckedChanged="ChckActivo_CheckedChanged" AutoPostBack="true" />
                                <br />
                                <asp:CheckBox runat="server" CssClass="w3-check" ID="ChckInactivo" type="checkbox" Text=" Inactivo" Font-Bold="true" OnCheckedChanged="ChckInactivo_CheckedChanged" AutoPostBack="true" />
                            </div>
                            <br />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ChckActivo" EventName="CheckedChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ChckInactivo" EventName="CheckedChanged" />
                    </Triggers>
                </asp:UpdatePanel>

            </div>
        </div>
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
                <div class="w3-row w3-padding-16">
                    <asp:UpdatePanel ID="upAddPais" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="w3-col m6">
                                <b>
                                    <asp:Label ID="lbAddPais" runat="server" Text="Ingresa el nombre del país"></asp:Label>
                                </b>
                                <asp:Label ID="lbAdvAddPais" runat="server" Text="Label" Visible="false" ForeColor="Red" Font-Size="Small" Height="10px"></asp:Label>

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

                                            <asp:TemplateField HeaderText="ID">
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
                                                    <asp:LinkButton ID="btn_Edit" runat="server" CommandName="Edit"> <i class="fa fa-pencil-alt"></i></asp:LinkButton>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="btn_Update" runat="server" Text="Update" CommandName="Update" CausesValidation="false">  <i class="fa fa-check"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"> <i class="fa fa-times"></i></asp:LinkButton>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="w3-row">
                                <asp:Button ID="btnAddNewPais" runat="server" Text="Agregar país" CssClass="w3-padding w3-button w3-blue w3-hover-amber w3-display-bottommiddle" OnClick="btnAddNewPais_Click" Style="width: 300px" />
                            </div>
                        </ContentTemplate>
                        <Triggers>
                        </Triggers>
                    </asp:UpdatePanel>

                </div>
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
                <div class="w3-row w3-padding-16">
                    <asp:UpdatePanel ID="upAddEstado" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="w3-col m6">
                                <b>
                                    <asp:Label ID="lbAddEstado" runat="server" Text="Selecciona un país y escribe el nombre del estado"></asp:Label>
                                </b>
                                <asp:DropDownList CssClass="w3-dropdown-click w3-input w3-margin" ID="ddlPaisAddEstado" Style="width: 80%" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlPaisAddEstado_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                                <asp:Label ID="lbAdvEstado" runat="server" Text="Label" Visible="false" ForeColor="Red" Font-Size="Small" Height="10px"></asp:Label>
                                <asp:TextBox CssClass="w3-input w3-margin" ID="txtAddEstado" Width="80%" runat="server"></asp:TextBox>
                            </div>
                            <div class="w3-col m6">
                                <b>
                                    <asp:Label ID="lbVerEstado" runat="server" Text="Estados registrados"></asp:Label>
                                </b>
                                <div class="w3-responsive">
                                    <asp:GridView ID="gvAddEstado" runat="server" AutoGenerateColumns="False" CellPadding="6" OnRowCancelingEdit="gvAddEstado_RowCancelingEdit"
                                        OnRowEditing="gvAddEstado_RowEditing" OnRowUpdating="gvAddEstado_RowUpdating" CssClass="w3-table w3-striped w3-border" Style="min-height: 212px" GridLines="None" ShowHeaderWhenEmpty="True" AllowPaging="true" PageSize="3" OnPageIndexChanging="gvAddEstado_PageIndexChanging" EnableViewState="false">
                                        <Columns>

                                            <asp:TemplateField HeaderText="ID">
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
                                                    <asp:LinkButton ID="btn_Edit" runat="server" CommandName="Edit" CausesValidation="false"> <i class="fa fa-pencil"></i></asp:LinkButton>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="btn_Update" runat="server" Text="Update" CommandName="Update" CausesValidation="false">  <i class="fa fa-check"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"> <i class="fa fa-times"></i></asp:LinkButton>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="w3-row">
                                <asp:Button ID="btnAddEstado" runat="server" Text="Agregar estado" CssClass="w3-padding w3-button w3-blue w3-hover-amber w3-display-bottommiddle" OnClick="btnAddEstado_Click" Style="width: 300px" />
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlPaisAddEstado" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
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
                <div class="w3-row w3-padding-16">
                    <asp:UpdatePanel ID="upAddMunicipio" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="w3-col m6">
                                <b>
                                    <asp:Label ID="lbAddMunicipio" runat="server" Text="Selecciona un país y escribe el nombre del estado"></asp:Label>
                                </b>
                                <asp:DropDownList CssClass="w3-dropdown-click w3-input w3-margin" ID="ddlPaisAddMunicipio" Style="width: 80%" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlPaisAddMunicipio_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                                <asp:DropDownList CssClass="w3-dropdown-click w3-input w3-margin" ID="ddlEstadoAddMunicipio" Style="width: 80%" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlEstadoAddMunicipio_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                <asp:Label ID="lbAdvMunicipio" runat="server" Text="lbAdvMunicipio" Visible="false" ForeColor="Red" Font-Size="Small" Height="10px"></asp:Label>
                                <asp:TextBox CssClass="w3-input w3-margin" ID="txtAddMunicipio" Width="80%" runat="server"></asp:TextBox>
                            </div>
                            <div class="w3-col m6">
                                <b>
                                    <asp:Label ID="Label3" runat="server" Text="Estados registrados"></asp:Label>
                                </b>
                                <div class="w3-responsive">
                                    <asp:GridView ID="gvAddMunicipio" runat="server" CssClass="w3-table w3-striped w3-border" Style="min-height: 212px" AutoGenerateColumns="False" GridLines="None" ShowHeaderWhenEmpty="True" AllowPaging="true" PageSize="3" OnPageIndexChanging="gvAddMunicipio_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="IDMunicipio" HeaderText="ID" HeaderStyle-Height="20px" ItemStyle-Height="10px" FooterStyle-Height="20px" />
                                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                        </Columns>
                                    </asp:GridView>
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
    </div>
    <%--MODAL PARA TOMAR FOTO DESDE CAMARA WEB--%>
    <div id="modalTomarFoto" class="w3-modal">
        <div class="w3-modal-content w3-animate-top w3-card-4 w3-round">
            <header class="w3-container w3-blue w3-round" style="height: 50px">
                <h3 class="w3-display-topleft w3-margin-left">Escuelas de procedencia</h3>
                <span onclick="document.getElementById('modalTomarFoto').style.display='none'"
                    class="w3-button w3-display-topright w3-hover-amber w3-round">&times;</span>
            </header>
            <div class="w3-container" style="min-height: 400px; max-height: 400px">
            </div>
        </div>
    </div>
    <%--MODAL PARA VER A LOS MAESTROS--%>
    <div id="modalAlumnos" class="w3-modal">
        <div class="w3-modal-content w3-animate-top w3-card-4 w3-round" style="width: 1000px; margin-top: -70px">
            <header class="w3-container w3-blue w3-round" style="height: 50px">
                <h3 class="w3-display-topleft w3-margin-left">Empleados</h3>
                <span onclick="document.getElementById('modalAlumnos').style.display='none'"
                    class="w3-button w3-display-topright w3-hover-amber w3-round">&times;</span>
            </header>
            <div class="w3-container" style="min-height: 480px; max-height: 480px">
                <asp:UpdatePanel ID="upAlumnos" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="w3-row w3-margin-top">
                            <div class="w3-col m12">
                                <asp:Label ID="lbMaestros" runat="server" Text="Seleccione de la lista que tipo de empleado que desea vizualizar y posteriormente presione en el icono de la derecha para ver su información" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:DropDownList CssClass="w3-dropdown-click w3-input w3-margin" ID="ddlMaestrosReg" Style="width: 20%" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlAlumnosReg_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Text="Activo" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Inactivo" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="w3-row ">
                            <div class="w3-col m12">
                                <b>
                                    <asp:Label ID="lbAlumnosReg" runat="server" Text="Alumnos registrados"></asp:Label>
                                </b>
                                <div class="w3-responsive">
                                    <asp:GridView ID="gvAlumnos" runat="server" AutoGenerateColumns="False" CellPadding="6"
                                        CssClass="w3-table w3-striped w3-border" Style="min-height: 288px" GridLines="None" ShowHeaderWhenEmpty="True" AllowPaging="true" PageSize="5" OnPageIndexChanging="gvAlumnos_PageIndexChanging" OnRowCommand="gvAlumnos_RowCommand" DataKeyNames="IDMaestro">
                                        <Columns>

                                            <asp:TemplateField HeaderText="ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("IDMaestro") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nombre">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("NomMaestro") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Primer apellido">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("ApePatMaestro") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Segundo apellido">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("ApeMatMaestro") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--  <asp:TemplateField HeaderText="Fecha de Nacimiento">
                                                      <ItemTemplate>
                                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("FechaNacAlumno") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                             <asp:TemplateField HeaderText="Usuario">
                                                       <ItemTemplate>
                                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Usuario") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Estatus">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("StatusMaestro") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-success btn-sm" Text="<i class='fa fa-eye w3-large'></i>" CausesValidation="False" CommandName="SelectAlum" Visible="true" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlMaestrosReg" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>


    <div class="w3-animate-right">
        <asp:UpdatePanel ID="upBotones" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <%--BOTON PARA REGISTRAR AL EMPLEADO--%>
                <div class="w3-row">
                    <asp:Button CssClass="w3-button w3-amber w3-hover-blue w3-round " ID="btnAgregarAlumno" runat="server" Text="Registrar" OnClick="btnAgregarEmp_Click" CausesValidation="true" Style="width: 100%" ValidationGroup="vlgrDatosEmp" />
                </div>
                <div class="w3-row">
                    <%--BOTON PARA MODIFICAR INFO DEL ALUMNO--%>
                    <asp:Button CssClass="w3-margin-left w3-third w3-button w3-amber w3-hover-blue w3-round" ID="btnModifAlumno" runat="server" Text="Modificar Información" OnClick="btnModifAlumno_Click" CausesValidation="true" Width="31%" Visible="false" ValidationGroup="vlgrDatosEmp" />
                </div>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>





    <%--SCRIPT PARA CAMBIAR AL MOMENTO LA IMAGEN DEL ALUMNO DESDE ARCHIVO--%>
    <script>
        var loadimage = function (event) {
            $("#<%=imgFotoEmp.ClientID%>").attr('src', URL.createObjectURL(event.target.files[0]));
            document.getElementById("<%=btnConfirmFoto.ClientID%>").style.display = "";
        };
    </script>
    <script>
        var loadimagecurri = function (event) {
            document.getElementById("<%=btnConfirmCurriculum.ClientID%>").style.display = "";
        };
    </script>
    <script>
        var guardarboton = function (event) {
            document.getElementById("<%=btnConfirmFoto.ClientID%>").style.display = "none";
        };
    </script>
    <script>
        var guardarbotoncurri = function (event) {
            document.getElementById("<%=btnConfirmCurriculum.ClientID%>").style.display = "none";
        };
    </script>

    <%--SCRIPT PARA ABRIR EL FILEUPLOAD CON EL ICONO--%>
    <script>
        function showBrowseDialog() {
            var fileuploadctrl = document.getElementById('<%=fotoEmp.ClientID%>');
            fileuploadctrl.click();

        }
    </script>

    <%--SCRIPTS DE ALERTAS--%>
    <script type="text/javascript">
        function successalert() {
            swal({
                title: 'Personal registrado!',
                text: 'El maestro ha sido registrado correctamente',
                type: 'success',
                showConfirmButton: false,
                timer: 1500
            });
        }

        function erroralert() {
            swal({
                title: 'Oh oh',
                text: 'Hubo un problema al guardar la información, verifica los datos',
                type: 'error'
            });
        }

        function fotosuccessalert() {
            swal({
                title: 'Foto guardada',
                text: 'Continua con el registro del maestro',
                type: 'success',
                showConfirmButton: false,
                timer: 1500

            });
        }

    </script>

</asp:Content>
