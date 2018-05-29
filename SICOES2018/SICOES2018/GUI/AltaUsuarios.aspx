<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mstrpgAdmin.Master" AutoEventWireup="true" CodeBehind="AltaUsuarios.aspx.cs" Inherits="SICOES2018.GUI.AltaUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <div class="w3-row">
                <div class="w3-col m8">
                    <h2>Alta de Usuarios</h2>
                </div>
                <div class=" w3-col m4 w3-padding-16">
                    <input class="w3-button w3-amber w3-hover-blue  w3-right" type="button" onclick="document.getElementById('modalAlumnos').style.display = 'block'" value="Ver registros de empleados" />
                </div>
            </div>

            <%--DATOS GENERALES--%>
            <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
                <div class="w3-row">
                    <div class="w3-col m4">
                        <h4>DATOS DEL EMPLEADO</h4>
                    </div>
                    <div class="w3-col m8 w3-right-align w3-margin-top">
                        <b>
                           <%-- <asp:CheckBox ID="chckNuevoIng" runat="server" Text=" Nuevo Ingreso" OnCheckedChanged="chckNuevoIng_CheckedChanged"/>
                            &nbsp&nbsp
                        <asp:CheckBox ID="chckRevalida" runat="server" Text=" Revalida" OnCheckedChanged="chckRevalida_CheckedChanged"/>--%>

                        </b>
                    </div>

                </div>
                <hr style="margin: 5px" />
                <div class="w3-padding w3-col m6">
                    <div class="w3-row" style="margin-bottom: -20px">
                        <b>
                            <asp:Label ID="lbNomEmp" runat="server" Text="Nombre(s)"></asp:Label>
                        </b>
                        <asp:RequiredFieldValidator ID="reqNomEmp" runat="server" ControlToValidate="txtNomEmp" ErrorMessage="¡Ingrese el nombre del alumno!" ViewStateMode="Inherit" ForeColor="Red" Font-Size="Small" Height="10px"></asp:RequiredFieldValidator>
                        <br />
                        <asp:TextBox runat="server" CssClass="w3-input" ID="txtNomEmp" type="text" Style="width: 400px" />
                        <br />
                    </div>
                    <div class="w3-row" style="margin-bottom: -20px">
                        <b>
                            <asp:Label ID="lbApePatEmp" runat="server" Text="Primer Apellido"></asp:Label>
                        </b>
                        <br />
                        <asp:TextBox runat="server" CssClass="w3-input" ID="txtApePatEmp" type="text" Style="width: 400px" /><br />
                    </div>
                    <div class="w3-row" style="margin-bottom: -20px">
                        <b>
                            <asp:Label ID="lbApeMatEmp" runat="server" Text="Segundo Apellido"></asp:Label>
                        </b>
                        <br />
                        <asp:TextBox runat="server" CssClass="w3-input" ID="txtApeMatEmp" type="text" Style="width: 400px" /><br />
                    </div>
                    <div class="w3-row" style="margin-bottom: -20px">
                        <b>
                            <asp:Label ID="lbCedula" runat="server" Text="Cédula Profesional"></asp:Label>
                        </b>
                        <asp:RequiredFieldValidator ID="reqCedula" runat="server" ControlToValidate="txtCedula" ErrorMessage="¡Ingrese la Cédula profesional!" ViewStateMode="Inherit" ForeColor="Red" Font-Size="Small" Height="10px"></asp:RequiredFieldValidator>
                        <br />
                        <asp:TextBox runat="server" CssClass="w3-input" ID="txtCedula" MaxLength="18" type="text" Style="width: 400px" /><br />
                    </div>
                    <div class="w3-row" style="margin-bottom: -20px">
                        <b>
                            <asp:Label ID="lbGradoEmp" runat="server" Text="Último Grado Académico"></asp:Label>
                        </b>
                        <br />
                        <asp:TextBox runat="server" CssClass="w3-input" ID="txtGradoEmp" MaxLength="18" type="text" Style="width: 400px" /><br />
                    </div>
                    <div class="w3-row" style="margin-bottom: -20px">
                        <b>
                            <asp:Label ID="lbCurriculum" runat="server" Text="Curriculum"></asp:Label>
                        </b>
                        <br />
                        <asp:FileUpload runat="server" CssClass="w3-input " ID="filecurriculum" MaxLength="18" type="file" Style="width: 400px" />
                        <asp:Label runat="server" Visible="false" id="curriculumok"></asp:Label>
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
                            <asp:Button ID="btnConfirmFoto" runat="server" Text="Confirmar Foto" OnClick="btnConfirmFoto_Click" CssClass="w3-button w3-amber w3-hover-blue" Width="100%" CausesValidation="false" />
                        </div>
                        <div class="w3-row">
                            <asp:Button ID="btnConfirmCurriculum" runat="server" Text="Confirmar Curriculum" OnClick="btnConfirmCurriculum_Click" CssClass="w3-button w3-amber w3-hover-blue" Width="100%" CausesValidation="false" />
                        </div>
                    </div>
                </div>
            </div>

            <%--Información de Contacto y Dirección--%>
            <%--<div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
                <h4>INFORMACIÓN DE CONTACTO Y DIRECCIÓN</h4>
                <hr style="margin: 5px" />
                <div class="w3-padding w3-col m12">
                    <asp:UpdatePanel ID="upTutor" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="w3-row" style="margin-bottom: -20px">
                                <div class="w3-col m6">
                                    <b>
                                        <asp:Label ID="lbNomPadreAlum" runat="server" Text="Nombre del padre"></asp:Label>
                                    </b>
                                    <br />
                                    <asp:TextBox runat="server" CssClass="w3-input" ID="txtNomPadreAlum" type="text" Style="width: 90%" /><br />
                                </div>
                                <div class="w3-col m5">
                                    <b>
                                        <asp:Label ID="lbTelPadreAlum" runat="server" Text="Teléfono del padre"></asp:Label>
                                    </b>
                                    <br />
                                    <asp:TextBox runat="server" CssClass="w3-input" ID="txtTelPadreAlum" TextMode="Number" onkeypress="return this.value.length<=9" Style="width: 350px" />
                                </div>
                                <div class="w3-col m1 w3-center">
                                    <b>
                                        <asp:Label CssClass="w3-center" ID="lbTutorPadre" runat="server" Text="Tutor"></asp:Label>
                                    </b>
                                    <br />
                                    <asp:CheckBox runat="server" CssClass="w3-check w3-center" ID="chckTutorPadre" type="checkbox" OnCheckedChanged="chckTutorPadre_CheckedChanged" AutoPostBack="true" /><br />
                                </div>

                            </div>
                            <div class="w3-row" style="margin-bottom: -20px">
                                <div class="w3-col m6">
                                    <b>
                                        <asp:Label ID="lbNomMadreAlum" runat="server" Text="Nombre de la madre"></asp:Label>
                                    </b>
                                    <br />
                                    <asp:TextBox runat="server" CssClass="w3-input" ID="txtNomMadreAlum" type="text" Style="width: 90%" /><br />
                                </div>
                                <div class="w3-col m5">
                                    <b>
                                        <asp:Label ID="lbTelMadreAlum" runat="server" Text="Teléfono de la madre"></asp:Label>
                                    </b>
                                    <br />
                                    <asp:TextBox runat="server" CssClass="w3-input" ID="txtTelMadreAlum" TextMode="Number" onkeypress="return this.value.length<=9" Style="width: 350px" /><br />
                                </div>
                                <div class="w3-col m1 w3-center">
                                    <b>
                                        <asp:Label CssClass="w3-center" ID="lbTutorCheck" runat="server" Text="  "></asp:Label>
                                    </b>
                                    <br />
                                    <asp:CheckBox runat="server" CssClass="w3-check w3-center" ID="chckTutorMadre" type="checkbox" OnCheckedChanged="chckTutorMadre_CheckedChanged" AutoPostBack="true" /><br />
                                </div>
                            </div>
                            <div class="w3-row" style="margin-bottom: -20px">
                                <div class="w3-col m6">
                                    <b>
                                        <asp:Label ID="lbNomTutorAlum" runat="server" Text="Nombre del tutor"></asp:Label>
                                    </b>
                                    <asp:RequiredFieldValidator ID="reqNomTutorAlum" runat="server" ControlToValidate="txtNomTutorAlum" ErrorMessage="¡Ingrese el nombre o seleccione a un padre!" ViewStateMode="Inherit" ForeColor="Red" Font-Size="Small" Height="10px"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:TextBox runat="server" CssClass="w3-input" ID="txtNomTutorAlum" type="text" Style="width: 90%" /><br />
                                </div>
                                <div class="w3-col m6">
                                    <b>
                                        <asp:Label ID="lbTelTutorAlum" runat="server" Text="Teléfono del tutor"></asp:Label>
                                    </b>
                                    <asp:RequiredFieldValidator ID="reqTelTutorAlum" runat="server" ControlToValidate="txtTelTutorAlum" ErrorMessage="¡Ingrese el teléfono o seleccione a un padre!" ViewStateMode="Inherit" ForeColor="Red" Font-Size="Small" Height="10px"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:TextBox runat="server" CssClass="w3-input" ID="txtTelTutorAlum" TextMode="Number" onkeypress="return this.value.length<=9" Style="width: 350px" /><br />
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="chckTutorPadre" EventName="CheckedChanged" />
                            <asp:AsyncPostBackTrigger ControlID="chckTutorMadre" EventName="CheckedChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>--%>

            <%--DATOS DEL DOMICILIO--%>
            <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
                <h4>DIRECCIÓN E INFORMACIÓN DE CONTACTO</h4>
                <hr style="margin: 5px" />
                <div class="w3-padding w3-col m12">
                    <div class="w3-row" style="margin-bottom: -20px">
                            <b>
                                <asp:Label ID="lbDireccEmp" runat="server" Text="Dirección" ></asp:Label>
                            </b>
                            <br />
                            <asp:TextBox runat="server" CssClass="w3-input" ID="txtDireccEmp" type="text" placeholder="Calle, cruzamientos, Número, Colonia y Código Postal" /><br />
                        <%--<div class="w3-col m3">
                            <b>
                                <asp:Label ID="lbNumEmp" runat="server" Text="Número"></asp:Label>
                            </b>
                            <br />
                            <asp:TextBox runat="server" CssClass="w3-input" ID="txtNumEmp" type="text" Style="width: 200px" /><br />
                        </div>
                        <div class="w3-col m3">
                            <b>
                                <asp:Label ID="lbColEmp" runat="server" Text="Colonia"></asp:Label>
                            </b>
                            <br />
                            <asp:TextBox runat="server" CssClass="w3-input" ID="txtColEmp" type="text" Style="width: 200px" /><br />
                        </div>
                        <div class="w3-col m3">
                            <b>
                                <asp:Label ID="lbCPEmp" runat="server" Text="Código Postal"></asp:Label>
                            </b>
                            <br />
                            <asp:TextBox runat="server" CssClass="w3-input" ID="txtCPEmp" type="text" Style="width: 200px" /><br />
                        </div>--%>
                    </div>
                    <div class="w3-row" style="margin-bottom: -20px">
                        <asp:UpdatePanel ID="upDireccion" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="w3-col m3">
                                    <b>
                                        <asp:Label ID="lbPaisEmp" runat="server" Text="País"></asp:Label>
                                    </b>
                                    <br />
                                    <asp:DropDownList CssClass="w3-dropdown-click w3-input" ID="ddlPaisEmp" Style="width: 175px" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlPaisEmp_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    <a style="cursor: pointer" title="Agregar un país" onclick="document.getElementById('modalAddPais').style.display = 'block'">&nbsp&nbsp<i class="fa fa-plus-circle w3-xlarge"></i></a>
                                </div>
                                <div class="w3-col m3">
                                    <b>
                                        <asp:Label ID="lbEstadoEmp" runat="server" Text="Estado"></asp:Label>
                                    </b>
                                    <br />
                                    <asp:DropDownList CssClass="w3-dropdown-click w3-input" ID="ddlEstadoEmp" Style="width: 175px" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlEstadoEmp_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    <a style="cursor: pointer" title="Agregar un estado" onclick="document.getElementById('modalAddEstado').style.display = 'block'">&nbsp&nbsp<i class="fa fa-plus-circle w3-xlarge"></i></a>
                                </div>
                                <div class="w3-col m3">
                                    <b>
                                        <asp:Label ID="lbMunicipioEmp" runat="server" Text="Municipio"></asp:Label>
                                    </b>
                                    <br />
                                    <asp:DropDownList CssClass="w3-dropdown-click w3-input" ID="ddlMunicipioEmp" Style="width: 175px" runat="server" AppendDataBoundItems="true" AutoPostBack="true"></asp:DropDownList>
                                    <a style="cursor: pointer" onclick="document.getElementById('modalAddMunicipio').style.display = 'block'" title="Agregar un municipio">&nbsp&nbsp<i class="fa fa-plus-circle w3-xlarge"></i></a>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlPaisEmp" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ddlEstadoEmp" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>

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
                            <asp:TextBox runat="server" CssClass="w3-input" ID="TxtCorreoEmp" type="email"  /><br />
                        </div>
                </div>
            </div>

            <%--DATOS DE LA ESCUELA DE PROCEDENCIA--%>
            <%--<div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
                <h4>DATOS DE LA ESCUELA DE PROCEDENCIA 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNomEscProAlum" ErrorMessage="¡Seleccione una escuela de procedencia!" ViewStateMode="Inherit" ForeColor="Red" Font-Size="Small" Height="10px"></asp:RequiredFieldValidator></h4>
                <hr style="margin: 5px" />
                <div class="w3-padding w3-col m12">
                    <asp:UpdatePanel ID="upEscProAlum" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="w3-row">
                                <div class="w3-col m12">
                                    <b>
                                        <asp:Label ID="lbEscProAlum" runat="server" Text="Selecciona la escuela de procedencia"></asp:Label>
                                    </b>
                                    <br />
                                    <asp:DropDownList CssClass="w3-dropdown-click w3-input" ID="ddlEscProAlum" Style="width: 96%" runat="server" OnTextChanged="ddlEscProAlum_TextChanged" AutoPostBack="true"></asp:DropDownList>
                                    <a style="cursor: pointer" onclick="document.getElementById('modalAddEscPro').style.display='block'" title="Agregar una escuela de procedencia">&nbsp&nbsp<i class="fa fa-plus-circle w3-xlarge"></i></a>
                                </div>
                            </div>
                            <div class="w3-row">
                                <div class="w3-col m5 w3-margin-top">
                                    <b>
                                        <asp:Label ID="lbNomEscProAlum" runat="server" Text="Nombre de la escuela"></asp:Label>
                                    </b>
                                    <br />
                                    <asp:TextBox runat="server" CssClass="w3-input" ID="txtNomEscProAlum" type="text" Style="width: 90%" disabled="disabled" /><br />
                                </div>
                                <div class="w3-col m4 w3-margin-top">
                                    <b>
                                        <asp:Label ID="lbClaveEscProAlum" runat="server" Text="Clave"></asp:Label>
                                    </b>
                                    <br />
                                    <asp:TextBox runat="server" CssClass="w3-input" ID="txtClaveEscProAlum" type="text" Style="width: 90%" disabled="disabled" /><br />
                                </div>
                                <div class="w3-col m3 w3-margin-top">
                                    <b>
                                        <asp:Label ID="lbTurnoEscProAlum" runat="server" Text="Turno"></asp:Label>
                                    </b>
                                    <br />
                                    <asp:DropDownList CssClass="w3-dropdown-click w3-input" ID="ddlTurnoEscPro" Style="width: 90%" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlEscProAlum" EventName="TextChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>--%>

            <%--Permisos de Empleado--%>
            <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
                <h4>Permisos Administrativos</h4>
                <hr style="margin: 5px" />
                <div class="w3-col m12">
                    <div class="w3-row">
                        <div class="w3-col m4 w3-margin-top">
                            <b>
                                <asp:CheckBox runat="server" CssClass="w3-check" ID="chckDirectivo" type="checkbox" Text=" Directivo" />
                            </b>
                            <br />
                            <b>
                                <asp:CheckBox runat="server" CssClass="w3-check" ID="chckSecretariaAdm" type="checkbox" Text=" Secretaría Académica" />
                            </b>
                            <br />
                            <b>
                                <asp:CheckBox runat="server" CssClass="w3-check" ID="chckSecretariaAca" type="checkbox" Text=" Secretaría Administrativa" />
                            </b>
                            <br />
                            <b>
                                <asp:CheckBox runat="server" CssClass="w3-check" ID="chckControl" type="checkbox" Text=" Control Escolar" />
                            </b>
                            <br />
                            <b>
                                <asp:CheckBox runat="server" CssClass="w3-check" ID="chckDocente" type="checkbox" Text=" Docente" />
                            </b>
                            <br />
                        </div>
                        <%--<div class="w3-col m4 w3-margin-top">
                            <b>
                                <asp:CheckBox runat="server" CssClass="w3-check" ID="chckBoleCalifAlum" type="checkbox" Text=" Boletas de calificaciones" />
                            </b>
                            <br />
                            <b>
                                <asp:CheckBox runat="server" CssClass="w3-check" ID="chckCertifParcialAlum" type="checkbox" Text=" Certificado parcial" />
                            </b>
                            <br />
                            <b>
                                <asp:CheckBox runat="server" CssClass="w3-check" ID="chckOfiRevalAlum" type="checkbox" Text=" Oficio de revalidación" />
                            </b>
                            <br />
                            <b>
                                <asp:CheckBox runat="server" CssClass="w3-check" ID="chckConstanciaMediaAlum" type="checkbox" Text=" Constancia de comp. 1/2" />
                            </b>
                            <br />
                            <b>
                                <asp:CheckBox runat="server" CssClass="w3-check bigcheck" ID="chckCertifSecunAlum" type="checkbox" Text="  Certificado de secundaria" />
                            </b>
                        </div>--%>

                       <%-- <div class="w3-col m4 w3-margin-top">
                            <b>
                                <asp:Label ID="lbOtrosAlum" runat="server" Text="Otros documentos"></asp:Label>
                            </b>
                            <br />
                            <asp:TextBox runat="server" class="w3-input" ID="txtrOtrosAlum" cols="20" Rows="2" Style="min-height: 100px; max-height: 100px; min-width: 300px; max-width: 300px" TextMode="MultiLine" placeholder="Separa los documentos con comas, ejemplo: 'Acta, Comprobante'"></asp:TextBox><br />
                        </div>--%>
                    </div>
                    <br />
                </div>
            </div>
           <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
               <h4>Estatus del Maestro</h4>
                <hr style="margin: 5px" />
                <div class="w3-col m12">
                    <div class="w3-row">
                <div class="w3-col m4 w3-margin-top">
                    <b>
                                <asp:CheckBox runat="server" CssClass="w3-check" ID="ChckActivo" type="checkbox" Text=" Activo" />
                            </b>
                            <br />
                    <b>
                                <asp:CheckBox runat="server" CssClass="w3-check" ID="ChckInactivo" type="checkbox" Text=" Inactivo" />
                            </b>
                            
                </div>
                        </div>
                    <br />
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
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnAddNewPais" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <div class="w3-row">
                                <asp:Button ID="btnAddNewPais" runat="server" Text="Agregar país" CssClass="w3-padding w3-button w3-blue w3-hover-amber w3-display-bottommiddle" OnClick="btnAddNewPais_Click" Style="width: 300px" />
                            </div>
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
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnAddEstado" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlPaisAddEstado" EventName="SelectedIndexChanged" />

                                </Triggers>
                            </asp:UpdatePanel>
                            <div class="w3-row">
                                <asp:Button ID="btnAddEstado" runat="server" Text="Agregar estado" CssClass="w3-padding w3-button w3-blue w3-hover-amber w3-display-bottommiddle" OnClick="btnAddEstado_Click" Style="width: 300px" />
                            </div>
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
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnAddMunicipio" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlPaisAddMunicipio" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlEstadoAddMunicipio" EventName="SelectedIndexChanged" />

                                </Triggers>
                            </asp:UpdatePanel>
                            <div class="w3-row">
                                <asp:Button ID="btnAddMunicipio" runat="server" Text="Agregar municipio" CssClass="w3-padding w3-button w3-blue w3-hover-amber w3-display-bottommiddle" OnClick="btnAddMunicipio_Click" Style="width: 300px" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <%--MODAL PARA AGREGAR UNA ESCUELA DE PROCEDENCIA--%>
            <div id="modalAddEscPro" class="w3-modal">
                <div class="w3-modal-content w3-animate-top w3-card-4 w3-round">
                    <header class="w3-container w3-blue w3-round" style="height: 50px">
                        <h3 class="w3-display-topleft w3-margin-left">Escuelas de procedencia</h3>
                        <span onclick="document.getElementById('modalAddEscPro').style.display='none'"
                            class="w3-button w3-display-topright w3-hover-amber w3-round">&times;</span>
                    </header>
                    <div class="w3-container" style="min-height: 400px; max-height: 400px">
                        <asp:UpdatePanel ID="upAddEscPro" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="w3-row w3-margin-top">
                                    <div class="w3-col m6">
                                        <b>
                                            <asp:Label ID="lbAddNomEscPro" runat="server" Text="Ingresa el nombre de la escuela"></asp:Label>
                                        </b>
                                        <asp:Label ID="lbAdvNomEscPro" runat="server" Text="Label" Visible="false" ForeColor="Red" Font-Size="Small" Height="10px"></asp:Label>
                                        <asp:TextBox CssClass="w3-input w3-margin" ID="txtNomEscProAdd" Width="80%" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="w3-col m6">
                                        <b>
                                            <asp:Label ID="lbAddClaveEscPro" runat="server" Text="Ingresa la clave de la escuela"></asp:Label>
                                        </b>
                                        <asp:Label ID="lbAdvClaveEscPro" runat="server" Text="Label" Visible="false" ForeColor="Red" Font-Size="Small" Height="10px"></asp:Label>
                                        <asp:TextBox CssClass="w3-input w3-margin" ID="txtClaveEscProAdd" Width="80%" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="w3-row ">
                                    <div class="w3-col m12">
                                        <b>
                                            <asp:Label ID="lbEscProReg" runat="server" Text="Escuelas registradas"></asp:Label>
                                        </b>
                                        <div class="w3-responsive">
                                            <%--<asp:GridView ID="gvEscProReg" runat="server" CssClass="w3-table w3-striped w3-border" Style="min-height: 212px" AutoGenerateColumns="False" GridLines="None" ShowHeaderWhenEmpty="True" AllowPaging="true" PageSize="3" OnPageIndexChanging="gvEscProReg_PageIndexChanging">
                                                <Columns>
                                                    <asp:BoundField DataField="IDEscProAlumno" HeaderText="ID" HeaderStyle-Height="20px" ItemStyle-Height="10px" FooterStyle-Height="20px" />
                                                    <asp:BoundField DataField="NombreEscPro" HeaderText="Nombre" />
                                                    <asp:BoundField DataField="ClaveEscPro" HeaderText="Clave" />
                                                </Columns>
                                            </asp:GridView>--%>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                            <%--<Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnAddEscPro" EventName="Click" />
                            </Triggers>--%>
                        </asp:UpdatePanel>
                        <%--<div class="w3-row">
                            <asp:Button ID="btnAddEscPro" runat="server" Text="Agregar escuela" CssClass="w3-padding w3-button w3-blue w3-hover-amber w3-display-bottommiddle" OnClick="btnAddEscPro_Click" Style="width: 300px" />
                        </div>--%>
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

            <%--MODAL PARA VER A LOS ALUMNOS--%>
            <div id="modalAlumnos" class="w3-modal">
                <div class="w3-modal-content w3-animate-top w3-card-4 w3-round" style="width: 1000px; margin-top: -70px">
                    <header class="w3-container w3-blue w3-round" style="height: 50px">
                        <h3 class="w3-display-topleft w3-margin-left">Alumnos</h3>
                        <span onclick="document.getElementById('modalAlumnos').style.display='none'"
                            class="w3-button w3-display-topright w3-hover-amber w3-round">&times;</span>
                    </header>
                    <div class="w3-container" style="min-height: 480px; max-height: 480px">
                        <asp:UpdatePanel ID="upAlumnos" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="w3-row w3-margin-top">
                                    <div class="w3-col m12">
                                        <b>
                                            <asp:Label ID="lbAlumnos" runat="server" Text="Seleccione de la lista que tipo de alumno desea vizualizar y posteriormente presione en el icono del a derecha para ver su información"></asp:Label>
                                        </b>
                                        <br />
                                        <asp:DropDownList CssClass="w3-dropdown-click w3-input w3-margin" ID="ddlAlumnosReg" Style="width: 20%" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlAlumnosReg_SelectedIndexChanged" AutoPostBack="true"><asp:ListItem Text="Inactivo" Value="0"></asp:ListItem><asp:ListItem Text="Activo" Value="1" Selected="True"></asp:ListItem></asp:DropDownList>
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

                                                    <asp:TemplateField HeaderText="ID">
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
                                                   <%-- <asp:TemplateField HeaderText="Nombre del tutor">
                                                       <ItemTemplate>
                                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("NomTutorAlumno") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
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
                                <asp:PostBackTrigger ControlID="btnConfirmFoto" />
                                <asp:PostBackTrigger ControlID="btnConfirmCurriculum" />
                                <asp:AsyncPostBackTrigger ControlID="ddlAlumnosReg" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>


            <%--BOTON PARA REGISTRAR AL EMPLEADO--%>
            <div class="w3-row">
            <asp:Button CssClass="w3-button w3-amber w3-hover-blue w3-round w3-animate-right" ID="btnAgregarAlumno" runat="server" Text="Registrar" OnClick="btnAgregarEmp_Click" CausesValidation="true" Style="width: 100%" />
                </div>
              <div class="w3-row">
                <%--BOTON PARA MODIFICAR INFO DEL ALUMNO--%>
                <asp:Button CssClass="w3-margin-left w3-third w3-button w3-amber w3-hover-blue w3-round w3-animate-right" ID="btnModifAlumno" runat="server" Text="Modificar Información" OnClick="btnModifAlumno_Click" CausesValidation="true" Width="31%" Visible="false" />
            </div>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAgregarAlumno" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnModifAlumno" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>






    <%--SCRIPT PARA CAMBIAR AL MOMENTO LA IMAGEN DEL ALUMNO DESDE ARCHIVO--%>
    <script>
        var loadimage = function (event) {
            $("#<%=imgFotoEmp.ClientID%>").attr('src', URL.createObjectURL(event.target.files[0]));
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
                title: 'Alumno registrado!',
                text: 'El alumno ha sido registrado correctamente',
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
                text: 'Continua con el registro del alumno',
                type: 'success',
                showConfirmButton: false,
                timer: 1500

            });
        }

    </script>

</asp:Content>