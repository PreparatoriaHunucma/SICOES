<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mstrpgAdmin.Master" AutoEventWireup="true" CodeBehind="GestionAlumnos.aspx.cs" Inherits="SICOES2018.GUI.RegistroAlumnos" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="w3-row">
        <div class="w3-col m8">
            <h2>Gestión de alumnos</h2>
        </div>
        <div class=" w3-col m4 w3-padding-16">
            <input class="w3-button w3-amber w3-hover-blue  w3-right" type="button" onclick="document.getElementById('modalAlumnos').style.display = 'block'" value="Ver registros de alumnos" />
        </div>
    </div>

    <%--DATOS GENERALES--%>
    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <asp:UpdatePanel ID="upDatosGen" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="w3-row">
                    <div class="w3-col m4">
                        <h4>DATOS GENERALES</h4>
                    </div>
                    <div class="w3-col m8 w3-right-align w3-margin-top">
                        <asp:CheckBox ID="chckNuevoIng" runat="server" Text=" Nuevo Ingreso" OnCheckedChanged="chckNuevoIng_CheckedChanged" Font-Bold="true" AutoPostBack="true" />&nbsp&nbsp;
                        <asp:CheckBox ID="chckRevalida" runat="server" Text=" Revalida" OnCheckedChanged="chckRevalida_CheckedChanged" Font-Bold="true" AutoPostBack="true" />
                    </div>
                </div>
                <hr style="margin: 5px" />
                <div class="w3-row">
                    <%--DATOS--%>
                    <div class="w3-padding w3-col m6">
                        <div class="w3-row" style="margin-bottom: -20px">
                            <asp:Label ID="lbNomAlumno" runat="server" Text="Nombre(s)" Font-Bold="true"></asp:Label>
                            <asp:RequiredFieldValidator ID="reqNomAlum" runat="server" ControlToValidate="txtNomAlumno" ErrorMessage="¡Ingrese el nombre del alumno!" ViewStateMode="Inherit" ForeColor="Red" Font-Size="Small" Height="10px" ValidationGroup="vlgrDatos"></asp:RequiredFieldValidator>
                            <br />
                            <asp:TextBox runat="server" CssClass="w3-input" ID="txtNomAlumno" type="text" />
                            <br />
                        </div>
                        <div class="w3-row" style="margin-bottom: -20px">
                            <asp:Label ID="lbApePatAlumno" runat="server" Text="Primer Apellido" Font-Bold="true"></asp:Label>
                            <br />
                            <asp:TextBox runat="server" CssClass="w3-input" ID="txtApePatAlumno" type="text" /><br />
                        </div>
                        <div class="w3-row" style="margin-bottom: -20px">
                            <asp:Label ID="lbApeMatAlumno" runat="server" Text="Segundo Apellido" Font-Bold="true"></asp:Label>
                            <br />
                            <asp:TextBox runat="server" CssClass="w3-input" ID="txtApeMatAlumno" type="text" /><br />
                        </div>
                        <div class="w3-row" style="margin-bottom: -20px">
                            <asp:Label ID="lbFechaNacAlum" runat="server" Text="Fecha de Nacimiento" Font-Bold="true"></asp:Label>
                            <asp:RequiredFieldValidator ID="reqFechaNacAlum" runat="server" ControlToValidate="txtFechaNacAlum" ErrorMessage="¡Ingrese la fecha!" ViewStateMode="Inherit" ForeColor="Red" Font-Size="Small" Height="10px" ValidationGroup="vlgrDatos"></asp:RequiredFieldValidator>
                            <asp:RangeValidator runat="server" ID="rngFechaNacAlum" ControlToValidate="txtFechaNacAlum" Type="Date" MinimumValue="01-01-1900" OnInit="rngFechaNacAlum_Init" ErrorMessage="¡Fecha invalida!" ViewStateMode="Inherit" ForeColor="Red" Font-Size="Small" Height="10px" ValidationGroup="vlgrDatos"></asp:RangeValidator>
                            <br />
                            <asp:TextBox runat="server" TextMode="Date" CssClass="w3-input" ID="txtFechaNacAlum" name="txtFechaNacAlum" />
                            <br />
                        </div>
                        <div class="w3-row" style="margin-bottom: -20px">
                            <asp:Label ID="lbCurpAlum" runat="server" Text="Clave Única de Registro de Población (CURP)" Font-Bold="true"></asp:Label>
                            <asp:RequiredFieldValidator ID="reqCurpAlum" runat="server" ControlToValidate="txtCurpAlum" ErrorMessage="¡Ingrese el CURP!" ViewStateMode="Inherit" ForeColor="Red" Font-Size="Small" Height="10px" ValidationGroup="vlgrDatos"></asp:RequiredFieldValidator>
                            <br />
                            <asp:TextBox runat="server" CssClass="w3-input" ID="txtCurpAlum" MaxLength="18" type="text" /><br />
                        </div>
                        <div class="w3-row" style="margin-bottom: -20px" runat="server" id="divmatricula" visible="false">
                            <asp:Label ID="lbMatriculaUADY" runat="server" Text="Matrícula de la UADY" Font-Bold="true"></asp:Label>
                            <br />
                            <asp:TextBox runat="server" CssClass="w3-input" ID="txtMatriculaUADY" MaxLength="18" type="text" /><br />
                        </div>
                    </div>
                    <%--FOTO--%>
                    <div class="w3-padding w3-col m6">
                        <div class="w3-row w3-center">
                            <div class="w3-row">
                                <asp:Image ID="imgFotoAlum" runat="server" ImageUrl="../Resources/images/imgPerfil.jpg" Style="width: 270px; height: 270px" CssClass="w3-image" ToolTip="Imágen de perfil del alumno" />
                            </div>
                            <div class="w3-row">
                                <div class="w3-col m5">
                                    <div class="image-upload w3-right">
                                        <label onclick="showBrowseDialog()" style="cursor: pointer" title="Subír una imágen">
                                            <i class="fa fa-folder-open w3-xxlarge" style="pointer-events: none; cursor: pointer"></i>
                                        </label>
                                        <asp:FileUpload runat="server" ID="fotoAlum" name="fotoAlum" type="file" accept="image/*" onchange="loadimage(event)" Style="display: none" />
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
                            <div class="w3-row w3-center">
                                <asp:Button ID="btnConfirmFoto" runat="server" Text="Confirmar foto" OnClick="btnConfirmFoto_Click" CssClass="w3-button w3-amber w3-hover-blue" Width="60%" Style="display: none" OnClientClick="guardarboton(event)" CausesValidation="false" />
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="chckNuevoIng" EventName="CheckedChanged" />
                <asp:AsyncPostBackTrigger ControlID="chckRevalida" EventName="CheckedChanged" />
                <asp:PostBackTrigger ControlID="btnConfirmFoto" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <%--DATOS DEL TUTOR--%>
    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <asp:UpdatePanel ID="upDatosTut" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="w3-row">
                    <h4>DATOS DEL TUTOR</h4>
                </div>
                <hr style="margin: 5px" />
                <div class="w3-row">
                    <div class="w3-padding w3-col m12">
                        <div class="w3-row">
                            <div class="w3-col m6">
                                <asp:Label ID="lbNomPadreAlum" runat="server" Text="Nombre del padre" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:TextBox runat="server" CssClass="w3-input" ID="txtNomPadreAlum" type="text" Style="width: 90%" /><br />
                            </div>
                            <div class="w3-col m5">
                                <asp:Label ID="lbTelPadreAlum" runat="server" Text="Teléfono del padre" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:TextBox runat="server" CssClass="w3-input" ID="txtTelPadreAlum" TextMode="Number" onkeypress="return this.value.length<=9" Style="width: 350px" />
                            </div>
                            <div class="w3-col m1 w3-center">
                                <asp:Label CssClass="w3-center" ID="lbTutorPadre" runat="server" Text="Tutor" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:CheckBox runat="server" CssClass="w3-check w3-center" ID="chckTutorPadre" type="checkbox" OnCheckedChanged="chckTutorPadre_CheckedChanged" AutoPostBack="true" /><br />
                            </div>
                        </div>
                        <div class="w3-row">
                            <div class="w3-col m6">
                                <asp:Label ID="lbNomMadreAlum" runat="server" Text="Nombre de la madre" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:TextBox runat="server" CssClass="w3-input" ID="txtNomMadreAlum" type="text" Style="width: 90%" /><br />
                            </div>
                            <div class="w3-col m5">
                                <asp:Label ID="lbTelMadreAlum" runat="server" Text="Teléfono de la madre" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:TextBox runat="server" CssClass="w3-input" ID="txtTelMadreAlum" TextMode="Number" onkeypress="return this.value.length<=9" Style="width: 350px" /><br />
                            </div>
                            <div class="w3-col m1 w3-center">
                                <asp:Label CssClass="w3-center" ID="lbTutorCheck" runat="server" Text="  " Font-Bold="true"></asp:Label>
                                <br />
                                <asp:CheckBox runat="server" CssClass="w3-check w3-center" ID="chckTutorMadre" type="checkbox" OnCheckedChanged="chckTutorMadre_CheckedChanged" AutoPostBack="true" /><br />
                            </div>
                        </div>
                        <div class="w3-row">
                            <div class="w3-col m6">
                                <asp:Label ID="lbNomTutorAlum" runat="server" Text="Nombre del tutor" Font-Bold="true"></asp:Label>
                                <asp:RequiredFieldValidator ID="reqNomTutorAlum" runat="server" ControlToValidate="txtNomTutorAlum" ErrorMessage="¡Ingrese el nombre o seleccione a un padre!" ViewStateMode="Inherit" ForeColor="Red" Font-Size="Small" Height="10px" ValidationGroup="vlgrDatos"></asp:RequiredFieldValidator>
                                <br />
                                <asp:TextBox runat="server" CssClass="w3-input" ID="txtNomTutorAlum" type="text" Style="width: 90%" /><br />
                            </div>
                            <div class="w3-col m6">
                                <asp:Label ID="lbTelTutorAlum" runat="server" Text="Teléfono del tutor" Font-Bold="true"></asp:Label>
                                <asp:RequiredFieldValidator ID="reqTelTutorAlum" runat="server" ControlToValidate="txtTelTutorAlum" ErrorMessage="¡Ingrese el teléfono o seleccione a un padre!" ViewStateMode="Inherit" ForeColor="Red" Font-Size="Small" Height="10px" ValidationGroup="vlgrDatos"></asp:RequiredFieldValidator>
                                <br />
                                <asp:TextBox runat="server" CssClass="w3-input" ID="txtTelTutorAlum" TextMode="Number" onkeypress="return this.value.length<=9" Style="width: 350px" /><br />
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="chckTutorPadre" EventName="CheckedChanged" />
                <asp:AsyncPostBackTrigger ControlID="chckTutorMadre" EventName="CheckedChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <%--DATOS DEL DOMICILIO--%>
    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <asp:UpdatePanel ID="upDatosDir" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="w3-row">
                    <h4>DATOS DEL DOMICILIO</h4>
                </div>
                <hr style="margin: 5px" />
                <div class="w3-row">
                    <div class="w3-padding w3-col m12">
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
                                <asp:Label ID="lbTelAlum" runat="server" Text="Teléfono del domicilio" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:TextBox runat="server" CssClass="w3-input" ID="txtTelAlum" TextMode="Number" onkeypress="return this.value.length<=9" Style="width: 200px" /><br />
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlPaisAlum" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddlEstadoAlum" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <%--DATOS DE LA ESCUELA DE PROCEDENCIA--%>
    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <asp:UpdatePanel ID="upDatosEscPro" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="w3-row">
                    <h4>DATOS DE LA ESCUELA DE PROCEDENCIA 
                    <asp:RequiredFieldValidator ID="rqNombreEscPro" runat="server" ControlToValidate="txtNomEscProAlum" ErrorMessage="¡Seleccione una escuela de procedencia!" ViewStateMode="Inherit" ForeColor="Red" Font-Size="Small" Height="10px" ValidationGroup="vlgrDatos"></asp:RequiredFieldValidator></h4>
                </div>
                <hr style="margin: 5px" />
                <div class="w3-row">
                    <div class="w3-padding w3-col m12">
                        <div class="w3-row">
                            <div class="w3-col m12">
                                <asp:Label ID="lbEscProAlum" runat="server" Text="Selecciona la escuela de procedencia" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:DropDownList CssClass="w3-dropdown-click w3-input" ID="ddlEscProAlum" Style="width: 96%" runat="server" OnTextChanged="ddlEscProAlum_TextChanged" AutoPostBack="true"></asp:DropDownList>
                                <a style="cursor: pointer" onclick="document.getElementById('modalAddEscPro').style.display='block'" title="Agregar una escuela de procedencia">&nbsp&nbsp<i class="fa fa-plus-circle w3-xlarge"></i></a>
                            </div>
                        </div>
                        <div class="w3-row">
                            <div class="w3-col m5 w3-margin-top">
                                <asp:Label ID="lbNomEscProAlum" runat="server" Text="Nombre de la escuela" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:TextBox runat="server" CssClass="w3-input" ID="txtNomEscProAlum" type="text" Style="width: 90%" disabled="disabled" /><br />
                            </div>
                            <div class="w3-col m4 w3-margin-top">
                                <asp:Label ID="lbClaveEscProAlum" runat="server" Text="Clave" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:TextBox runat="server" CssClass="w3-input" ID="txtClaveEscProAlum" type="text" Style="width: 90%" disabled="disabled" /><br />
                            </div>
                            <div class="w3-col m3 w3-margin-top">
                                <asp:Label ID="lbTurnoEscProAlum" runat="server" Text="Turno" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:DropDownList CssClass="w3-dropdown-click w3-input" ID="ddlTurnoEscPro" Style="width: 83%" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlEscProAlum" EventName="TextChanged" />
            </Triggers>
        </asp:UpdatePanel>

    </div>
    <%--DOCUMENTOS ENTREGADOS--%>
    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <asp:UpdatePanel ID="upDatosDocs" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="w3-row">
                    <h4>DOCUMENTOS ENTREGADOS</h4>
                </div>
                <hr style="margin: 5px" />
                <div class="w3-row">
                    <div class="w3-col m12">
                        <div class="w3-row">
                            <div class="w3-col m4 w3-margin-top">
                                <asp:CheckBox runat="server" CssClass="w3-check" ID="chckActaNacAlum" type="checkbox" Text=" Acta de nacimiento" Font-Bold="true" />
                                <br />
                                <asp:CheckBox runat="server" CssClass="w3-check" ID="chckFotosAlum" type="checkbox" Text=" Fotografías" Font-Bold="true" />
                                <br />
                                <asp:CheckBox runat="server" CssClass="w3-check" ID="chckCurpAlum" type="checkbox" Text=" CURP" Font-Bold="true" />
                                <br />
                                <asp:CheckBox runat="server" CssClass="w3-check" ID="chckConstanciaAlum" type="checkbox" Text=" Constancia" Font-Bold="true" />
                                <br />
                                <asp:CheckBox runat="server" CssClass="w3-check" ID="chckCompDomiAlum" type="checkbox" Text=" Comprobante de domicilio" Font-Bold="true" />
                                <br />
                            </div>
                            <div class="w3-col m4 w3-margin-top">
                                <asp:CheckBox runat="server" CssClass="w3-check" ID="chckBoleCalifAlum" type="checkbox" Text=" Boletas de calificaciones" Font-Bold="true" />
                                <br />
                                <asp:CheckBox runat="server" CssClass="w3-check" ID="chckCertifParcialAlum" type="checkbox" Text=" Certificado parcial" Font-Bold="true" />
                                <br />
                                <asp:CheckBox runat="server" CssClass="w3-check" ID="chckOfiRevalAlum" type="checkbox" Text=" Oficio de revalidación" Font-Bold="true" />
                                <br />
                                <asp:CheckBox runat="server" CssClass="w3-check" ID="chckConstanciaMediaAlum" type="checkbox" Text=" Constancia de comp. 1/2" Font-Bold="true" />
                                <br />
                                <asp:CheckBox runat="server" CssClass="w3-check bigcheck" ID="chckCertifSecunAlum" type="checkbox" Text="  Certificado de secundaria" Font-Bold="true" />
                            </div>
                            <div class="w3-col m4 w3-margin-top w3-margin-bottom">
                                <asp:Label ID="lbOtrosAlum" runat="server" Text="Otros documentos" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:TextBox runat="server" class="w3-input" ID="txtrOtrosAlum" cols="20" Rows="2" Style="min-width: 300px; max-width: 300px" TextMode="MultiLine" placeholder="Separa los documentos con comas, ejemplo: 'Acta, Comprobante'"></asp:TextBox>
                                <br />
                                <asp:Label ID="lbSemestre" runat="server" Text="Semestre de inscripción" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:DropDownList CssClass="w3-dropdown-click w3-input" ID="ddlSemestre" Style="width: 300px" runat="server" AppendDataBoundItems="true" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
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
    <%--MODAL PARA AGREGAR UNA ESCUELA DE PROCEDENCIA--%>
    <div id="modalAddEscPro" class="w3-modal">
        <div class="w3-modal-content w3-animate-top w3-card-4 w3-round">
            <header class="w3-container w3-blue w3-round" style="height: 50px">
                <h3 class="w3-display-topleft w3-margin-left">Escuelas de procedencia</h3>
                <span onclick="document.getElementById('modalAddEscPro').style.display='none'"
                    class="w3-button w3-display-topright w3-hover-amber w3-round">&times;</span>
            </header>
            <div class="w3-container" style="min-height: 400px; max-height: 400px">
                <asp:UpdatePanel ID="upModalEscPro" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="w3-row w3-margin-top">
                            <div class="w3-col m6">
                                <asp:Label ID="lbAddNomEscPro" runat="server" Text="Ingresa el nombre de la escuela" Font-Bold="true"></asp:Label>
                                <asp:RequiredFieldValidator ID="rqNomEscPro" runat="server" ControlToValidate="txtNomEscProAdd" ErrorMessage="¡Ingrese el nombre de la escuela!" ViewStateMode="Inherit" ForeColor="Red" Font-Size="Small" Height="10px" ValidationGroup="vlgrDatosAddEscPro"></asp:RequiredFieldValidator>
                                <asp:TextBox CssClass="w3-input w3-margin" ID="txtNomEscProAdd" Width="80%" runat="server"></asp:TextBox>
                            </div>
                            <div class="w3-col m6">
                                <asp:Label ID="lbAddClaveEscPro" runat="server" Text="Ingresa la clave de la escuela" Font-Bold="true"></asp:Label>
                                <asp:RequiredFieldValidator ID="rqClaveEscPro" runat="server" ControlToValidate="txtClaveEscProAdd" ErrorMessage="¡Ingrese la clave de la escuela!" ViewStateMode="Inherit" ForeColor="Red" Font-Size="Small" Height="10px" ValidationGroup="vlgrDatosAddEscPro"></asp:RequiredFieldValidator>
                                <asp:TextBox CssClass="w3-input w3-margin" ID="txtClaveEscProAdd" Width="80%" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="w3-row ">
                            <div class="w3-col m12">
                                <asp:Label ID="lbEscProReg" runat="server" Text="Escuelas registradas" Font-Bold="true"></asp:Label>
                                <div class="w3-responsive">
                                    <asp:GridView ID="gvEscProReg" runat="server" CssClass="w3-table w3-striped w3-border" Style="min-height: 212px" AutoGenerateColumns="False" GridLines="None" ShowHeaderWhenEmpty="True" AllowPaging="true" PageSize="3" OnPageIndexChanging="gvEscProReg_PageIndexChanging" OnRowEditing="gvEscProReg_RowEditing" OnRowUpdating="gvEscProReg_RowUpdating" OnRowCancelingEdit="gvEscProReg_RowCancelingEdit">
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_IDAddEscPro" runat="server" Text='<%#Eval("IDEscProAlumno") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nombre">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_NameAddEscPro" runat="server" Text='<%#Eval("NombreEscPro") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txt_NameAddEscPro" CssClass="w3-input" Style="min-height: 20px; max-height: 20px" runat="server" Text='<%#Eval("NombreEscPro") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Clave">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_ClaveAddEscPro" runat="server" Text='<%#Eval("ClaveEscPro") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txt_ClaveAddEscPro" CssClass="w3-input" Style="min-height: 20px; max-height: 20px" runat="server" Text='<%#Eval("ClaveEscPro") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btn_EditEscPro" runat="server" CommandName="Edit" CausesValidation="false"><i class="fa fa-pencil-alt"></i></asp:LinkButton>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="btn_UpdateEscPro" runat="server" Text="Update" CommandName="Update" CausesValidation="false">  <i class="fa fa-check"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="btn_CancelEscPro" runat="server" Text="Cancel" CommandName="Cancel"> <i class="fa fa-times"></i></asp:LinkButton>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <div class="w3-row">
                            <asp:Button ID="btnAddEscPro" runat="server" Text="Agregar escuela" CssClass="w3-padding w3-button w3-blue w3-hover-amber w3-display-bottommiddle" OnClick="btnAddEscPro_Click" Style="width: 300px" ValidationGroup="vlgrDatosAddEscPro" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
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
    <asp:UpdatePanel ID="upDivModalAlumnos" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="modalAlumnos" class="w3-modal">
                <div class="w3-modal-content w3-animate-top w3-card-4 w3-round" style="width: 1200px; margin-top: -70px">
                    <header class="w3-container w3-blue w3-round" style="height: 50px">
                        <h3 class="w3-display-topleft w3-margin-left">Alumnos</h3>
                        <span onclick="document.getElementById('modalAlumnos').style.display='none'"
                            class="w3-button w3-display-topright w3-hover-amber w3-round">&times;</span>
                    </header>
                    <div class="w3-container" style="min-height: 480px; max-height: 480px">
                        <asp:UpdatePanel ID="upModalAlumnos" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="w3-row w3-margin-top">
                                    <div class="w3-col m12">
                                        <asp:Label ID="lbAlumnos" runat="server" Text="Seleccione de la lista que tipo de alumno desea vizualizar y posteriormente presione en el icono del a derecha para ver su información" Font-Bold="true"></asp:Label>
                                        <br />
                                        <asp:DropDownList CssClass="w3-dropdown-click w3-input w3-margin" ID="ddlAlumnosReg" Style="width: 20%" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlAlumnosReg_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="w3-row ">
                                    <div class="w3-col m12">
                                        <asp:Label ID="lbAlumnosReg" runat="server" Text="Alumnos registrados" Font-Bold="true"></asp:Label>
                                        <div class="w3-responsive">
                                            <asp:GridView ID="gvAlumnos" runat="server" AutoGenerateColumns="False" CellPadding="6"
                                                CssClass="w3-table w3-striped w3-border" Style="min-height: 288px" GridLines="None" ShowHeaderWhenEmpty="True" AllowPaging="true" PageSize="5" OnPageIndexChanging="gvAlumnos_PageIndexChanging" OnRowCommand="gvAlumnos_RowCommand" DataKeyNames="IDAlumno">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("IDAlumno") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Nombre">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("NomAlumno") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Primer apellido">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("ApePatAlumno") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Segundo apellido">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("ApeMatAlumno") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fecha de Nacimiento">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("FechaNacAlumno") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Nombre del tutor">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("NomTutorAlumno") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Telefono del tutor">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("TelTutorAlumno") %>'></asp:Label>
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
                                <asp:AsyncPostBackTrigger ControlID="ddlAlumnosReg" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>

    <%--MODAL PARA INSCRIBIR A LOS ALUMNOS--%>
    <div id="modalInscripcion" class="w3-modal">
        <div class="w3-modal-content w3-animate-top w3-card-4 w3-round" style="width: 1200px; margin-top: -70px">
            <header class="w3-container w3-blue w3-round" style="height: 50px">
                <h3 class="w3-display-topleft w3-margin-left">Alumnos</h3>
                <span onclick="document.getElementById('modalInscripcion').style.display='none'"
                    class="w3-button w3-display-topright w3-hover-amber w3-round">&times;</span>
            </header>
            <div class="w3-container" style="min-height: 480px; max-height: 480px">
                <div class="w3-row w3-margin-top">
                    <div class="w3-col m12">
                        <asp:UpdatePanel ID="upModalInsc" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="w3-row">
                                    <asp:Label ID="lbinstruccion" runat="server" Text="Seleccione el grupo al que el alumno pertenecerá y presione el botón para asignarle ese grupo" Font-Bold="true" CssClass="w3-margin-bottom"></asp:Label><br />
                                    <asp:DropDownList CssClass="w3-dropdown-click w3-input w3-margin" ID="ddlGrupos" Style="width: 20%" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlGrupos_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div class="w3-row ">
                                    <div class="w3-col m12">
                                        <b>
                                            <asp:Label ID="lbAlumnosGrupos" runat="server" Text="Alumnos registrados al grupo seleccionado"></asp:Label>
                                        </b>
                                        <div class="w3-responsive">
                                            <asp:GridView ID="gvAlumnosGrupos" runat="server" AutoGenerateColumns="False" CellPadding="6"
                                                CssClass="w3-table w3-striped w3-border" Style="min-height: 288px" GridLines="None" ShowHeaderWhenEmpty="True" AllowPaging="true" PageSize="5" OnPageIndexChanging="gvAlumnos_PageIndexChanging" OnRowCommand="gvAlumnos_RowCommand" DataKeyNames="IDAlumno">
                                                <Columns>

                                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("IDAlumno") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Nombre">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("NomAlumno") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Primer apellido">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("ApePatAlumno") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Segundo apellido">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("ApeMatAlumno") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fecha de Nacimiento">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("FechaNacAlumno") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Nombre del tutor">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("NomTutorAlumno") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Telefono del tutor">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("TelTutorAlumno") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-success btn-sm" Text="<i class='fa fa-eye w3-large'></i>" CausesValidation="False" CommandName="SelectAlum" Visible="true" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                                <div class="w3-row">
                                    <asp:Button ID="btnInscribirAlum" runat="server" Text="Inscribir Alumno" CssClass="w3-padding w3-button w3-blue w3-hover-amber w3-display-bottommiddle" OnClick="btnInscribirAlumno_Click" Style="width: 300px" />
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlGrupos" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="btnInscribirAlum" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <%--BOTONES--%>
    <div class="w3-row w3-animate-right">
        <asp:UpdatePanel ID="upBotones" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <%--BOTON PARA REGISTRAR AL ALUMNO--%>
                <div class="w3-row">
                    <asp:Button CssClass="w3-button w3-amber w3-hover-blue w3-round" ID="btnAgregarAlumno" runat="server" Text="Pre-Inscribir al alumno" OnClick="btnAgregarAlumno_Click" ValidationGroup="vlgrDatos" Style="width: 100%" />
                </div>
                <div class="w3-row">
                    <%--BOTON PARA MODIFICAR INFO DEL ALUMNO--%>
                    <asp:Button CssClass="w3-margin-left w3-third w3-button w3-amber w3-hover-blue w3-round" ID="btnModifAlumno" runat="server" Text="Modificar Información" OnClick="btnModifAlumno_Click" CausesValidation="true" Width="31%" Visible="false" />
                    <%--BOTON PARA INSCRIBIR AL ALUMNO--%>
                    <asp:Button CssClass="w3-margin-left w3-margin-right w3-third w3-button w3-amber w3-hover-blue w3-round" ID="btnInscribirAlumno" runat="server" Text="Inscribir alumno" CausesValidation="true" Width="31%" Visible="false" OnClientClick="document.getElementById('modalInscripcion').style.display='block'; return false;" AutoPostBack="false" />
                    <%--BOTON PARA DAR DE BAJA AL ALUMNO--%>
                    <asp:Button CssClass="w3-margin-right w3-third w3-button w3-amber w3-hover-blue w3-round" ID="btnDarBajaAlumno" runat="server" Text="Dar de baja al alumno" OnClick="btnDarBajaAlumno_Click" CausesValidation="true" Width="31%" Visible="false" />
                    <%--BOTON PARA CREAR CARTA DE COMPROMISO--%>
                    <asp:Button CssClass="w3-margin-right w3-third w3-button w3-amber w3-hover-blue w3-round" ID="btnCartaCompromiso" runat="server" Text="Generar Carta Compromioso" OnClick="btnCartaCompromiso_Click" CausesValidation="true" Width="31%" Visible="false" />
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAgregarAlumno" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnModifAlumno" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnInscribirAlumno" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnDarBajaAlumno" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>

    <%--SCRIPT PARA CAMBIAR AL MOMENTO LA IMAGEN DEL ALUMNO DESDE ARCHIVO--%>
    <script>
        var loadimage = function (event) {
            $("#<%=imgFotoAlum.ClientID%>").attr('src', URL.createObjectURL(event.target.files[0]));
            document.getElementById("<%=btnConfirmFoto.ClientID%>").style.display = "";
        };
    </script>
    <script>
        var guardarboton = function (event) {
            document.getElementById("<%=btnConfirmFoto.ClientID%>").style.display = "none";
            swal({
                title: 'Foto guardada',
                text: 'Continua con el registro del alumno',
                type: 'success',
                showConfirmButton: false,
                timer: 1500
            });
        };
    </script>
    <%--SCRIPT PARA ABRIR EL FILEUPLOAD CON EL ICONO--%>
    <script>
        function showBrowseDialog() {
            var fileuploadctrl = document.getElementById('<%=fotoAlum.ClientID%>');
            fileuploadctrl.click();
        }
    </script>
    <%--SCRIPTS DE ALERTAS--%>
    <script type="text/javascript">
        function successalert() {
            swal({
                title: '¡Alumno registrado!',
                text: 'El alumno ha sido registrado correctamente',
                type: 'success',
                showConfirmButton: false,
                timer: 2000
            });
        }
        function modifsuccessalert() {
            swal({
                title: '¡Información modificada!',
                text: 'La información del alumno se modificó con éxito',
                type: 'success',
                showConfirmButton: false,
                timer: 2000
            });
        }
        function bajasuccessalert() {
            swal({
                title: '¡Alumno dado de baja!',
                text: 'El alumno ha sido dado de baja correctamente',
                type: 'success',
                showConfirmButton: false,
                timer: 2000
            });
        } function inscripcionsuccessalert() {
            swal({
                title: '¡Alumno inscrito!',
                text: 'El alumno ha sido inscrito correctamente',
                type: 'success',
                showConfirmButton: false,
                timer: 2000
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
        function erroralert() {
            swal({
                title: 'Oh oh',
                text: 'Hubo un problema al guardar la información, verifica los datos',
                type: 'error'
            });
        }
    </script>
</asp:Content>
