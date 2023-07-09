<%@ Page Language="C#" AutoEventWireup="true" CodeFile="signup.aspx.cs" Inherits="up" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cap" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>AdminLTE 2 | Registration Page</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <!-- Bootstrap 3.3.7 -->
    <link rel="stylesheet" href="bower_components/bootstrap/dist/css/bootstrap.min.css">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="bower_components/font-awesome/css/font-awesome.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="bower_components/Ionicons/css/ionicons.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css">
    <!-- iCheck -->
    <link rel="stylesheet" href="plugins/iCheck/square/blue.css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->

    <!-- Google Font -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic">
</head>
<body class="hold-transition register-page">
    <div class="register-box">
        <div class="register-logo">
            <a href="index2.html"><b>Admin</b>LTE</a>
        </div>

        <div class="register-box-body">
            <p class="login-box-msg">Register a new membership</p>
            <form id="form1" runat="server">
                <div class="form-group has-feedback">
                    <asp:TextBox ID="name" CssClass="form-control" placeholder="Username" runat="server"/>
                    <span class="glyphicon glyphicon-user form-control-feedback"><sup><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="name" ErrorMessage="*" ForeColor="Red"/></sup></span>
                </div>
                <div class="form-group has-feedback">
                    <asp:TextBox ID="email" CssClass="form-control" placeholder="Email ID" runat="server" reqiered ="" />
                    <span class="glyphicon glyphicon-envelope form-control-feedback"><sup><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="email" ErrorMessage="*" ForeColor="Red"/></sup></span>
                </div>
                <div class="form-group has-feedback">
                    <asp:TextBox ID="psw" CssClass="form-control" placeholder="Password" runat="server" TextMode="Password" reqiered ="" />
                    <span class="glyphicon glyphicon-lock form-control-feedback"><sup><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="psw" ErrorMessage="*" ForeColor="Red"/></sup></span>
                </div>
                <div class="form-group has-feedback">
                    <asp:TextBox ID="repsw" CssClass="form-control" placeholder="Confrim password" runat="server" TextMode="Password" reqiered ="" />
                    <span class="glyphicon glyphicon-log-in form-control-feedback"><sup><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="repsw" ErrorMessage="*" ForeColor="Red"/></sup></span>
                    <asp:Label ID="lpsw" runat="server"></asp:Label>
                </div>
                <div class="form-group has-feedback">
                    <asp:TextBox ID="num" CssClass="form-control" placeholder="Mobile No." runat="server" reqiered ="" />
                    <span class="glyphicon glyphicon-earphone form-control-feedback"><sup><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="num" ErrorMessage="*" ForeColor="Red"/></sup></span>
                </div>
                <div class="form-group has-feedback">
                    <asp:FileUpload ID="pic" CssClass="form-control" placeholder="Profile picture" runat="server" reqiered ="" />
                    <span class="	glyphicon glyphicon-camera form-control-feedback"><sup><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="pic" ErrorMessage="*" ForeColor="Red"/></sup></span>
                    <asp:Label ID="img_ckeck" runat="server"></asp:Label>
                </div>
                <div class="form-group has-feedback">
                    <cap:CaptchaControl ID="captcha1" runat="server" CaptchaLength="5" CaptchaHeight="50" CaptchaWidth="200" CaptchaLineNoise="None" CaptchaMinTimeout="3" CaptchaMaxTimeout="240" ForeColor="Blue" BackColor="White" CaptchaChars="ABCDEFGHIJKLMNOPQRSTUVWX123456789" Height="41px" Width="183px" />
                
                </div>
                <div class="form-group has-feedback">
                     <asp:TextBox ID="captcha" CssClass="form-control" placeholder="Enter Captcha" runat="server" reqiered ="" />
                     <asp:Label ID="lcap" runat="server"></asp:Label>
                </div>
                <div class="row">
                    <div class="col-xs-8">
                        <div class="checkbox icheck"> 
                            <label> 
                                <asp:CheckBox ID="chktrm" runat="server"/>
                                I agree to the <a href="#">terms<br/></a>
                                <asp:Label ID="Label3" runat="server"></asp:Label>
                            </label>
                        </div>
                    </div>
                    <!-- /.col -->
                    <div class="col-xs-4">
                        <asp:Button ID="Button1" CssClass ="btn btn-primary btn-block btn-flat" runat="server" OnClick="Button1_Click" Text="Sign Up" />
                    </div>
                    <!-- /.col -->
                </div>
            </form>

            

            <a href="login.aspx" class="text-center">I already have an account</a>
        </div>
        <!-- /.form-box -->
    </div>
    <!-- /.register-box -->

    <!-- jQuery 3 -->
    <script src="bower_components/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap 3.3.7 -->
    <script src="bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- iCheck -->
    <script src="plugins/iCheck/icheck.min.js"></script>
    <script>
        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' /* optional */
            });
        });
    </script>
</body>
</html>
