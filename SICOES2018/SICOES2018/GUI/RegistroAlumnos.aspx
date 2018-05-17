<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mstrpgAdmin.Master" AutoEventWireup="true" CodeBehind="RegistroAlumnos.aspx.cs" Inherits="SICOES2018.GUI.RegistroAlumnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Registro de alumnos</h2>

    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <h4>DATOS GENERALES</h4>
        <hr style="margin: 5px" />
        <div class="w3-padding w3-col m6">
            <div class="w3-row" style="margin-bottom: -20px">
                <b>
                    <asp:Label ID="lbNombreAlumno" runat="server" Text="Nombre(s)"></asp:Label>
                </b>
                <br />
                <input class="w3-input" id="txtNombreAlumno" type="text" style="width: 400px" /><br />
            </div>
            <div class="w3-row" style="margin-bottom: -20px">
                <b>
                    <asp:Label ID="lbApePatAlumno" runat="server" Text="Primer Apellido"></asp:Label>
                </b>
                <br />
                <input class="w3-input" id="txtApePatAlumno" type="text" style="width: 400px" /><br />
            </div>
            <div class="w3-row" style="margin-bottom: -20px">
                <b>
                    <asp:Label ID="lbApeMatAlumno" runat="server" Text="Segundo Apellido"></asp:Label>
                </b>
                <br />
                <input class="w3-input" id="txtApeMatAlumno" type="text" style="width: 400px" /><br />
            </div>
            <div class="w3-row" style="margin-bottom: -20px">
                <b>
                    <asp:Label ID="lbFechaNacAlum" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                </b>
                <br />
                <input class="w3-input" id="txtFechaNacAlum" type="date" style="width: 400px" /><br />
            </div>
            <div class="w3-row" style="margin-bottom: -20px">
                <b>
                    <asp:Label ID="lbCurpAlum" runat="server" Text="Código Unico de Registro Personal (CURP)"></asp:Label>
                </b>
                <br />
                <input class="w3-input" id="txtCurpAlum" type="text" style="width: 400px" /><br />
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
                            <label for="fotoAlum" style="cursor: pointer" title="Subír una imágen">
                                <i class="fa fa-folder-open-o w3-xxlarge" style="pointer-events: none; cursor: pointer"></i>
                            </label>
                            <input id="fotoAlum" type="file" accept="image/*" style="display: none" onchange="loadimage(event)" />
                        </div>
                    </div>
                    <div class="w3-col m2" style="margin-top: -10px">
                        <label class="w3-xxlarge">|</label>
                    </div>
                    <div class="w3-col m5">
                        <div class="image-upload w3-left">
                            <label for="fotoAlum2" style="cursor: pointer" title="Tomar una fotografía">
                                <i class="fa fa-camera-retro w3-xxlarge" style="pointer-events: none; cursor: pointer"></i>
                            </label>
                            <input id="fotoAlum2" type="file" style="display: none" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <h4>DATOS DEL TUTOR</h4>
        <hr style="margin: 5px" />
        <div class="w3-padding w3-col m12">
            <div class="w3-row" style="margin-bottom: -20px">
                <div class="w3-col m5">
                    <b>
                        <asp:Label ID="lbNomPadreAlum" runat="server" Text="Nombre del padre"></asp:Label>
                    </b>
                    <br />
                    <input class="w3-input" id="txtNomPadreAlum" type="text" style="width: 350px" /><br />
                </div>
                <div class="w3-col m5">
                    <b>
                        <asp:Label ID="lbTelPadreAlum" runat="server" Text="Teléfono del padre"></asp:Label>
                    </b>
                    <br />
                    <input class="w3-input" id="txtTelPadreAlum" type="text" style="width: 350px" /><br />
                </div>
                <div class="w3-col m2 w3-center">
                    <b>
                        <asp:Label CssClass="w3-center" ID="lbTutorPadre" runat="server" Text="Tutor"></asp:Label>
                    </b>
                    <br />
                    <input class="w3-check w3-center" id="chckTutorPadre" type="checkbox" /><br />
                </div>

            </div>
            <div class="w3-row" style="margin-bottom: -20px">
                <div class="w3-col m5">
                    <b>
                        <asp:Label ID="lbNomMadreAlum" runat="server" Text="Nombre de la madre"></asp:Label>
                    </b>
                    <br />
                    <input class="w3-input" id="txtNomMadreAlum" type="text" style="width: 350px" /><br />
                </div>
                <div class="w3-col m5">
                    <b>
                        <asp:Label ID="lbTelMadreAlum" runat="server" Text="Teléfono de la madre"></asp:Label>
                    </b>
                    <br />
                    <input class="w3-input" id="txtTelMadreAlum" type="text" style="width: 350px" /><br />
                </div>
                <div class="w3-col m2 w3-center">
                    <b>
                        <asp:Label CssClass="w3-center" ID="lbTutorCheck" runat="server" Text="Tutor"></asp:Label>
                    </b>
                    <br />
                    <input class="w3-check w3-center" id="chckTutorMadre" type="checkbox" /><br />
                </div>

            </div>
            <div class="w3-row" style="margin-bottom: -20px">
                <div class="w3-col m5">
                    <b>
                        <asp:Label ID="lbNomTutorAlum" runat="server" Text="Nombre del tutor"></asp:Label>
                    </b>
                    <br />
                    <input class="w3-input" id="txtNomTutorAlum" type="text" style="width: 350px" /><br />
                </div>
                <div class="w3-col m5">
                    <b>
                        <asp:Label ID="lbTelTutorAlum" runat="server" Text="Teléfono del tutor"></asp:Label>
                    </b>
                    <br />
                    <input class="w3-input" id="txtTelTutorAlum" type="tel" style="width: 350px" /><br />
                </div>
            </div>
        </div>
    </div>

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
                    <input class="w3-input" id="txtCallAlum" type="text" style="width: 200px" /><br />
                </div>
                <div class="w3-col m3">
                    <b>
                        <asp:Label ID="lbNumAlum" runat="server" Text="Número"></asp:Label>
                    </b>
                    <br />
                    <input class="w3-input" id="txtNumAlum" type="text" style="width: 200px" /><br />
                </div>
                <div class="w3-col m3">
                    <b>
                        <asp:Label ID="lbColAlum" runat="server" Text="Colonia"></asp:Label>
                    </b>
                    <br />
                    <input class="w3-input" id="txtColAlum" type="text" style="width: 200px" /><br />
                </div>
                <div class="w3-col m3">
                    <b>
                        <asp:Label ID="lbCPAlum" runat="server" Text="Código Postal"></asp:Label>
                    </b>
                    <br />
                    <input class="w3-input" id="txtCPAlum" type="text" style="width: 200px" /><br />
                </div>
            </div>
            <div class="w3-row" style="margin-bottom: -20px">
                <div class="w3-col m3">
                    <b>
                        <asp:Label ID="lbPaisAlum" runat="server" Text="País"></asp:Label>
                    </b>
                    <br />
                    <asp:DropDownList CssClass="w3-dropdown-click w3-input" ID="ddlPaisAlum" Style="width: 175px" runat="server"></asp:DropDownList><a style="cursor: pointer" title="Agregar un país">&nbsp&nbsp<i class="fa fa-plus-circle w3-xlarge"></i></a>
                </div>
                <div class="w3-col m3">
                    <b>
                        <asp:Label ID="lbEstadoAlum" runat="server" Text="Estado"></asp:Label>
                    </b>
                    <br />
                    <asp:DropDownList CssClass="w3-dropdown-click w3-input" ID="ddlEstadoAlum" Style="width: 175px" runat="server"></asp:DropDownList><a style="cursor: pointer" title="Agregar un estado">&nbsp&nbsp<i class="fa fa-plus-circle w3-xlarge"></i></a>
                </div>
                <div class="w3-col m3">
                    <b>
                        <asp:Label ID="lbMunicipioAlum" runat="server" Text="Municipio"></asp:Label>
                    </b>
                    <br />
                    <asp:DropDownList CssClass="w3-dropdown-click w3-input" ID="ddlMunicipioAlum" Style="width: 175px" runat="server"></asp:DropDownList><a style="cursor: pointer" title="Agregar un municipio">&nbsp&nbsp<i class="fa fa-plus-circle w3-xlarge"></i></a>
                </div>
                <div class="w3-col m3">
                    <b>
                        <asp:Label ID="lbTelAlum" runat="server" Text="Teléfono del domicilio"></asp:Label>
                    </b>
                    <br />
                    <input class="w3-input" id="txtTelAlum" type="text" style="width: 200px" /><br />
                </div>

            </div>
        </div>
    </div>

    <div class="w3-container w3-card w3-white w3-margin-bottom w3-animate-right">
        <h4>DATOS DE LA ESCUELA DE PROCEDENCIA</h4>
        <hr style="margin: 5px" />
        <div class="w3-padding w3-col m12">
            <div class="w3-row">
                <div class="w3-col m12">
                    <b>
                        <asp:Label ID="lbEscProAlum" runat="server" Text="Selecciona la escuela de procedencia"></asp:Label>
                    </b>
                    <br />
                    <asp:DropDownList CssClass="w3-dropdown-click w3-input" ID="ddlEscProAlum" Style="width: 96%" runat="server"></asp:DropDownList>
                    <a style="cursor: pointer" title="Agregar una escuela de procedencia">&nbsp&nbsp<i class="fa fa-plus-circle w3-xlarge"></i></a>
                </div>
            </div>
            <div class="w3-row">
                <div class="w3-col m5 w3-margin-top">
                    <b>
                        <asp:Label ID="lbNomEscProAlum" runat="server" Text="Nombre de la escuela"></asp:Label>
                    </b>
                    <br />
                    <input class="w3-input" id="txtNomEscProAlum" type="text" style="width: 90%" disabled="disabled" /><br />
                </div>
                <div class="w3-col m4 w3-margin-top">
                    <b>
                        <asp:Label ID="lbClaveEscProAlum" runat="server" Text="Clave"></asp:Label>
                    </b>
                    <br />
                    <input class="w3-input" id="txtClaveEscProAlum" type="text" style="width: 90%" disabled="disabled" /><br />
                </div>
                <div class="w3-col m3 w3-margin-top">
                    <b>
                        <asp:Label ID="lbTurnoEscProAlum" runat="server" Text="Turno"></asp:Label>
                    </b>
                    <br />
                    <asp:DropDownList CssClass="w3-dropdown-click w3-input" ID="ddlTurnoEscPro" Style="width: 90%" runat="server"></asp:DropDownList>
                </div>

            </div>

        </div>
    </div>


    <script>
        var loadimage = function (event) {
            var imgeditarlugar = document.getElementById('imgFotoAlum');
            imgFotoAlum.src = URL.createObjectURL(event.target.files[0]);
        };
    </script>
</asp:Content>
