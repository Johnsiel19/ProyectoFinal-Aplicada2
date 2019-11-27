<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="ProyectoFinal_Aplicada2.LogIn" %>





<html>
<head runat="server">

 <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%:Page.Title%>Registro de Evaluacion Estudiantil</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <%--Librerias para el toast--%>
    <link href="./Media/css/Grey/ListBox.Grey.css" rel="stylesheet" type="text/css" />
    <link href="./Media/css/WebTrack.css" rel="stylesheet" type="text/css" />
    <script src="http://code.jquery.com/jquery-3.4.1.min.js" type="text/javascript"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.css"
        rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.min.js"
        type="text/javascript"></script>


    <%--Programacion en Javascript para que funcione el toast--%>
    <script type="text/javascript">
        function Notify(msg, title, type, clear, pos, sticky) {
            if (clear == true) {
                toastr.clear();
            }
            if (sticky == true) {
                toastr.tapToDismiss = true;
                toastr.timeOut = 10000;
            }
            //"toast-top-left"; 
            toastr.options.positionClass = pos;
            if (type.toLowerCase() == 'info') {
                toastr.options.timeOut = 1000;
                toastr.tapToDismiss = true;
                toastr.info(msg, title);
            }
            if (type.toLowerCase() == 'success') {
                toastr.options.timeOut = 1500;
                toastr.success(msg, title);
            }
            if (type.toLowerCase() == 'warning') {
                toastr.options.timeOut = 3000;
                toastr.warning(msg, title);
            }
            if (type.toLowerCase() == 'error') {
                toastr.options.timeOut = 10000;
                toastr.error(msg, title);
            }
        }

        function isLetterKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return true;

            return false;
        }
    </script>

    <script type="text/javascript">
        function openModal() {
            $('#ModalEliminar').modal('show');
        }
     </script>

    <style>
        .navbar-inverse { background-color: #198ebc}
        .navbar-inverse .navbar-nav>.active>a:hover,.navbar-inverse .navbar-nav>li>a:hover, .navbar-inverse .navbar-nav>li>a:focus { background-color: #000000}
        .dropdown-menu { background-color: #198ebc}
        .dropdown-menu>li>a:hover, .dropdown-menu>li>a:focus { background-color: #19ea3f}
        .navbar-inverse { border-color: #FFFFFF}
        .navbar-inverse .navbar-brand { color: #000000}
        .navbar-inverse .navbar-brand:hover { color: #000000}
        .navbar-inverse .navbar-nav>li>a { color: #000000}

    </style>
 

    
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />

        <%--Menu Principal--%>
              <div class="container" style="
    width: 450px;
">
        <div class="panel panel-primary">
            <div class="panel-heading">Registro de Clientes</div>

    <div class="panel-body">
        <div class="form-horizontal col-md-7" role="form">

            </div></div></div></div>
        <%--contenedor y pie de pagina--%>
      
    </form>
</body>
</html>

