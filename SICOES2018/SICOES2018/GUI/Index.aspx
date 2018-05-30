<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SICOES2018.GUI.LoginGUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inicio de sesión | SICOES</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="Velvety Sign In Form Responsive Widget,Login form widgets, Sign up Web forms , Login signup Responsive web form,Flat Pricing table,Flat Drop downs,Registration Forms,News letter Forms,Elements" />
    <link href="../Resources/CSS/flexslider.css" rel="stylesheet" />
    <link href="../Resources/CSS/font-awesome.css" rel="stylesheet" />
    <link href="../Resources/CSS/style.css" rel="stylesheet" />
    <link href="//fonts.googleapis.com/css?family=Righteous" rel="stylesheet">
    <link href="//fonts.googleapis.com/css?family=Josefin+Sans:100,300,400,600,700" rel="stylesheet">
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
</head>
<body>
    <center>
    <h1>Bienvenido a SICOES</h1></center>
    <div class="main-agile">
        <div class="content-wthree">
            <div class="about-middle">
                <section class="slider">
                    <div class="flexslider">
                        <ul class="slides">
                            <li>
                                <div class="banner-bottom-2">
                                    <div class="about-midd-main">
                                        <img class="agile-img" src="../Resources/images/logoprepahunucma.jpeg" alt=" " style="width: 150px" class="img-responsive">
                                        <h4>Escuela Preparatoria Hunucmá</h4>
                                        <p style="font-style: italic">"Somos una institución dedicada a la educación y formación integral de los jóvenes estudiantes"</p>
                                    </div>
                                </div>
                            </li>
                            <li>
                                <div class="banner-bottom-2">
                                    <div class="about-midd-main">
                                        <img class="agile-img" src="../Resources/images/logouady.jpg" alt=" " style="width: 150px" class="img-responsive">
                                        <h4>Universidad Autónoma de Yucatán</h4>
                                        <p style="font-style: italic">"Luz, Ciencia y Verdad"</p>
                                    </div>
                                </div>
                            </li>
                            <li>
                                <div class="banner-bottom-2">
                                    <div class="about-midd-main">
                                        <img class="agile-img" src="../Resources/images/logosicoes.png" alt=" " style="width: 150px" class="img-responsive">
                                        <h4>Sistema de control escolar</h4>
                                        <p style="font-style: italic">Portal de herramientas académicas para el docente y alumno.</p>
                                    </div>
                                </div>
                            </li>
                        </ul>
                    </div>
                    <div class="clear"></div>
                </section>
            </div>
            <div class="new-account-form">
                <form action="#" method="post" runat="server">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <h2 class="heading-w3-agile">Inicio de sesión</h2>
                            <div class="inputs-w3ls">
                                <p>Usuario</p>
                                <i class="fa fa-user" aria-hidden="true"></i>
                                <asp:TextBox ID="txtuser" CssClass="email" runat="server" required=""></asp:TextBox>
                            </div>
                            <div class="inputs-w3ls">
                                <p>Contraseña</p>
                                <i class="fa fa-unlock-alt" aria-hidden="true"></i>
                                <asp:TextBox ID="txtpass" runat="server" CssClass="password" required="" TextMode="Password"></asp:TextBox>
                            </div>
                            <label class="anim">
                                <%--                        <input type="checkbox" class="checkbox">
                        <span>Remember Me</span>--%>
                                <a href="#">¿Olvidaste tu contraseña?</a>
                            </label>
                            <br />
                            <asp:Button ID="btnLogin" runat="server" Text="Iniciar sesión" OnClick="btnLogin_Click"/>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </form>
            </div>
            <div class="clear"></div>

        </div>
    </div>
    <script src="../Scripts/sweetalert2.all.js"></script>
    <script src="../Resources/js/jquery.min.js"></script>
    <script>
        $(document).ready(function (c) {
            $('.alert-close').on('click', function (c) {
                $('.main-agile').fadeOut('slow', function (c) {
                    $('.main-agile').remove();
                });
            });
        });
    </script>
    <!-- FlexSlider -->
    <script src="../Resources/js/jquery.flexslider.js"></script>
    <script type="text/javascript">
        $(function () {

        });
        $(window).load(function () {
            $('.flexslider').flexslider({
                animation: "slide",
                start: function (slider) {
                    $('body').removeClass('loading');
                }
            });
        });
    </script>
    <script type="text/javascript">
        function erroralert() {
            swal({
                title: 'Oh oh',
                text: 'Nombre de usuario o contraseña erroneas, intenta de nuevo',
                type: 'error'
            });
        }
    </script>
    <!-- FlexSlider -->
</body>
</html>
