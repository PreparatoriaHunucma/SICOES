<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mstrpgAdmin.Master" AutoEventWireup="true" CodeBehind="RegistroAlumnos.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="SICOES2018.GUI.RegistroAlumnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="w3-row">
        <div class="w3-col m8">
            <h2>Registro de alumnos</h2>
        </div>
        <div class=" w3-col m4 w3-padding-16">
            <input class="w3-button w3-amber w3-hover-blue  w3-right" type="button" value="Ver registros de alumnos" />
        </div>
    </div>

    <%--DATOS GENERALES--%>
    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <h4>DATOS GENERALES</h4>
        <hr style="margin: 5px" />
        <div class="w3-padding w3-col m6">
            <div class="w3-row" style="margin-bottom: -20px">
                <b>
                    <asp:Label ID="lbNomAlumno" runat="server" Text="Nombre(s)"></asp:Label>
                </b>
                <asp:RequiredFieldValidator ID="reqNomAlum" runat="server" ControlToValidate="txtNomAlumno" ErrorMessage="¡Ingrese el nombre del alumno!" ViewStateMode="Inherit" ForeColor="Red" Font-Size="Small" Height="10px"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox runat="server" CssClass="w3-input" ID="txtNomAlumno" type="text" Style="width: 400px" />
                <br />
            </div>
            <div class="w3-row" style="margin-bottom: -20px">
                <b>
                    <asp:Label ID="lbApePatAlumno" runat="server" Text="Primer Apellido"></asp:Label>
                </b>
                <br />
                <asp:TextBox runat="server" CssClass="w3-input" ID="txtApePatAlumno" type="text" Style="width: 400px" /><br />
            </div>
            <div class="w3-row" style="margin-bottom: -20px">
                <b>
                    <asp:Label ID="lbApeMatAlumno" runat="server" Text="Segundo Apellido"></asp:Label>
                </b>
                <br />
                <asp:TextBox runat="server" CssClass="w3-input" ID="txtApeMatAlumno" type="text" Style="width: 400px" /><br />
            </div>
            <div class="w3-row" style="margin-bottom: -20px">
                <b>
                    <asp:Label ID="lbFechaNacAlum" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                </b>
                <asp:RequiredFieldValidator ID="reqFechaNacAlum" runat="server" ControlToValidate="txtFechaNacAlum" ErrorMessage="¡Ingrese la fecha!" ViewStateMode="Inherit" ForeColor="Red" Font-Size="Small" Height="10px"></asp:RequiredFieldValidator>
                <asp:RangeValidator runat="server" ID="rngFechaNacAlum" ControlToValidate="txtFechaNacAlum" Type="Date" MinimumValue="01-01-1900" OnInit="rngFechaNacAlum_Init" ErrorMessage="¡Fecha invalida!" ViewStateMode="Inherit" ForeColor="Red" Font-Size="Small" Height="10px"></asp:RangeValidator>
                <br />
                <asp:TextBox runat="server" CssClass="w3-input" ID="txtFechaNacAlum" TextMode="Date" Style="width: 400px" CausesValidation="true" /><br />
            </div>
            <div class="w3-row" style="margin-bottom: -20px">
                <b>
                    <asp:Label ID="lbCurpAlum" runat="server" Text="Clave Única de Registro de Población (CURP)"></asp:Label>
                </b>
                <asp:RequiredFieldValidator ID="reqCurpAlum" runat="server" ControlToValidate="txtCurpAlum" ErrorMessage="¡Ingrese el CURP!" ViewStateMode="Inherit" ForeColor="Red" Font-Size="Small" Height="10px"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox runat="server" CssClass="w3-input" ID="txtCurpAlum" type="text" Style="width: 400px" /><br />
            </div>
        </div>
        <div class="w3-padding w3-col m6">
            <div class="w3-row w3-center">
                <div class="w3-row">
                    <img class="w3-image" title="Imágen de perfil del alumno" style="width: 270px; height: 270px" src="../Resources/images/imgPerfil.jpg" id="imgFotoAlum" />
                </div>
                <div class="w3-row">
                    <div class="w3-col m5">
                        <div class="image-upload w3-right">
                            <label onclick="showBrowseDialog()" style="cursor: pointer" title="Subír una imágen">
                                <i class="fa fa-folder-open-o w3-xxlarge" style="pointer-events: none; cursor: pointer"></i>
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
            </div>
        </div>
    </div>

    <%--DATOS DEL TUTOR--%>
    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <h4>DATOS DEL TUTOR</h4>
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
                            <asp:TextBox runat="server" CssClass="w3-input" ID="txtTelPadreAlum" type="text" Style="width: 350px" /><br />
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
                            <asp:TextBox runat="server" CssClass="w3-input" ID="txtTelMadreAlum" type="text" Style="width: 350px" /><br />
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
                            <asp:TextBox runat="server" CssClass="w3-input" ID="txtTelTutorAlum" type="tel" Style="width: 350px" /><br />
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="chckTutorPadre" EventName="CheckedChanged" />
                    <asp:AsyncPostBackTrigger ControlID="chckTutorMadre" EventName="CheckedChanged" />
                </Triggers>
            </asp:UpdatePanel>

        </div>
    </div>

    <%--DATOS DEL DOMICILIO--%>
    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <h4>DATOS DEL DOMICILIO</h4>
        <hr style="margin: 5px" />
        <div class="w3-padding w3-col m12">
            <div class="w3-row" style="margin-bottom: -20px">
                <div class="w3-col m3">
                    <b>
                        <asp:Label ID="lbCalleAlum" runat="server" Text="Calle"></asp:Label>
                    </b>
                    <br />
                    <asp:TextBox runat="server" CssClass="w3-input" ID="txtCallAlum" type="text" Style="width: 200px" /><br />
                </div>
                <div class="w3-col m3">
                    <b>
                        <asp:Label ID="lbNumAlum" runat="server" Text="Número"></asp:Label>
                    </b>
                    <br />
                    <asp:TextBox runat="server" CssClass="w3-input" ID="txtNumAlum" type="text" Style="width: 200px" /><br />
                </div>
                <div class="w3-col m3">
                    <b>
                        <asp:Label ID="lbColAlum" runat="server" Text="Colonia"></asp:Label>
                    </b>
                    <br />
                    <asp:TextBox runat="server" CssClass="w3-input" ID="txtColAlum" type="text" Style="width: 200px" /><br />
                </div>
                <div class="w3-col m3">
                    <b>
                        <asp:Label ID="lbCPAlum" runat="server" Text="Código Postal"></asp:Label>
                    </b>
                    <br />
                    <asp:TextBox runat="server" CssClass="w3-input" ID="txtCPAlum" type="text" Style="width: 200px" /><br />
                </div>
            </div>
            <div class="w3-row" style="margin-bottom: -20px">
                <asp:UpdatePanel ID="upDireccion" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="w3-col m3">
                            <b>
                                <asp:Label ID="lbPaisAlum" runat="server" Text="País"></asp:Label>
                            </b>
                            <br />
                            <asp:DropDownList CssClass="w3-dropdown-click w3-input" ID="ddlPaisAlum" Style="width: 175px" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlPaisAlum_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <a style="cursor: pointer" title="Agregar un país" onclick="document.getElementById('modalAddPais').style.display = 'block'">&nbsp&nbsp<i class="fa fa-plus-circle w3-xlarge"></i></a>
                        </div>
                        <div class="w3-col m3">
                            <b>
                                <asp:Label ID="lbEstadoAlum" runat="server" Text="Estado"></asp:Label>
                            </b>
                            <br />
                            <asp:DropDownList CssClass="w3-dropdown-click w3-input" ID="ddlEstadoAlum" Style="width: 175px" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlEstadoAlum_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <a style="cursor: pointer" title="Agregar un estado" onclick="document.getElementById('modalAddEstado').style.display = 'block'">&nbsp&nbsp<i class="fa fa-plus-circle w3-xlarge"></i></a>
                        </div>
                        <div class="w3-col m3">
                            <b>
                                <asp:Label ID="lbMunicipioAlum" runat="server" Text="Municipio"></asp:Label>
                            </b>
                            <br />
                            <asp:DropDownList CssClass="w3-dropdown-click w3-input" ID="ddlMunicipioAlum" Style="width: 175px" runat="server" AppendDataBoundItems="true" AutoPostBack="true"></asp:DropDownList>
                            <a style="cursor: pointer" onclick="document.getElementById('modalAddMunicipio').style.display = 'block'" title="Agregar un municipio">&nbsp&nbsp<i class="fa fa-plus-circle w3-xlarge"></i></a>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlPaisAlum" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlEstadoAlum" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>

                <div class="w3-col m3">
                    <b>
                        <asp:Label ID="lbTelAlum" runat="server" Text="Teléfono del domicilio"></asp:Label>
                    </b>
                    <br />
                    <asp:TextBox runat="server" CssClass="w3-input" ID="txtTelAlum" type="text" Style="width: 200px" /><br />
                </div>
            </div>
        </div>
    </div>

    <%--DATOS DE LA ESCUELA DE PROCEDENCIA--%>
    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <h4>DATOS DE LA ESCUELA DE PROCEDENCIA</h4>
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
    </div>

    <%--DOCUMENTOS ENTREGADOS--%>
    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <h4>DOCUMENTOS ENTREGADOS</h4>
        <hr style="margin: 5px" />
        <div class="w3-col m12">
            <div class="w3-row">
                <div class="w3-col m4 w3-margin-top">
                    <b>
                        <asp:CheckBox runat="server" CssClass="w3-check" ID="chckActaNacAlum" type="checkbox" Text=" Acta de nacimiento" />
                    </b>
                    <br />
                    <b>
                        <asp:CheckBox runat="server" CssClass="w3-check" ID="chckFotosAlum" type="checkbox" Text=" Fotografías" />
                    </b>
                    <br />
                    <b>
                        <asp:CheckBox runat="server" CssClass="w3-check" ID="chckCurpAlum" type="checkbox" Text=" CURP" />
                    </b>
                    <br />
                    <b>
                        <asp:CheckBox runat="server" CssClass="w3-check" ID="chckConstanciaAlum" type="checkbox" Text=" Constancia" />
                    </b>
                    <br />
                    <b>
                        <asp:CheckBox runat="server" CssClass="w3-check" ID="chckCompDomiAlum" type="checkbox" Text=" Comprobante de domicilio" />
                    </b>
                    <br />
                </div>
                <div class="w3-col m4 w3-margin-top">
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
                </div>

                <div class="w3-col m4 w3-margin-top">
                    <b>
                        <asp:Label ID="lbOtrosAlum" runat="server" Text="Otros documentos"></asp:Label>
                    </b>
                    <br />
                    <asp:TextBox runat="server" class="w3-input" ID="txtrOtrosAlum" cols="20" Rows="2" Style="min-height: 100px; max-height: 100px; min-width: 300px; max-width: 300px" TextMode="MultiLine" placeholder="Separa los documentos con comas, ejemplo: 'Acta, Comprobante'"></asp:TextBox><br />
                </div>
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
                                    <asp:GridView ID="gvAddPais" runat="server" CssClass="w3-table w3-striped w3-border" Style="min-height: 212px" AutoGenerateColumns="False" GridLines="None" ShowHeaderWhenEmpty="True" AllowPaging="true" PageSize="3" OnPageIndexChanging="gvAddPais_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="IDPais" HeaderText="ID" HeaderStyle-Height="20px" ItemStyle-Height="10px" FooterStyle-Height="20px" />
                                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
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
                                    <asp:GridView ID="gvAddEstado" runat="server" CssClass="w3-table w3-striped w3-border" Style="min-height: 212px" AutoGenerateColumns="False" GridLines="None" ShowHeaderWhenEmpty="True" AllowPaging="true" PageSize="3" OnPageIndexChanging="gvAddEstado_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="IDEstado" HeaderText="ID" HeaderStyle-Height="20px" ItemStyle-Height="10px" FooterStyle-Height="20px" />
                                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
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
                                    <asp:GridView ID="gvEscProReg" runat="server" CssClass="w3-table w3-striped w3-border" Style="min-height: 212px" AutoGenerateColumns="False" GridLines="None" ShowHeaderWhenEmpty="True" AllowPaging="true" PageSize="3" OnPageIndexChanging="gvEscProReg_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="IDEscProAlumno" HeaderText="ID" HeaderStyle-Height="20px" ItemStyle-Height="10px" FooterStyle-Height="20px" />
                                            <asp:BoundField DataField="NombreEscPro" HeaderText="Nombre" />
                                            <asp:BoundField DataField="ClaveEscPro" HeaderText="Clave" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAddEscPro" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                <div class="w3-row">
                    <asp:Button ID="btnAddEscPro" runat="server" Text="Agregar escuela" CssClass="w3-padding w3-button w3-blue w3-hover-amber w3-display-bottommiddle" OnClick="btnAddEscPro_Click" Style="width: 300px" />
                </div>
            </div>
        </div>
    </div>

    <%--MODAL PARA AGREGAR UNA ESCUELA DE PROCEDENCIA--%>
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

    <%--BOTON PARA REGISTRAR AL ALUMNO--%>
    <asp:Button CssClass="w3-button w3-amber w3-hover-blue w3-round w3-animate-right" ID="btnAgregarAlumno" runat="server" Text="Pre-Inscribir al alumno" OnClick="btnAgregarAlumno_Click" CausesValidation="true" Style="width: 100%" />

    <%--SCRIPT PARA CAMBIAR AL MOMENTO LA IMAGEN DEL ALUMNO DESDE ARCHIVO--%>
    <script>
        var loadimage = function (event) {
            var imgeditarlugar = document.getElementById('imgFotoAlum');
            imgFotoAlum.src = URL.createObjectURL(event.target.files[0]);
        };
    </script>
    <%--SCRIPT PARA ABRIR EL FILEUPLOAD CON EL ICONO--%>
    <script>
        function showBrowseDialog() {
            var fileuploadctrl = document.getElementById('<%=fotoAlum.ClientID%>');
            fileuploadctrl.click();
        }
    </script>
</asp:Content>
