<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="utf-8" />
  <meta http-equiv="X-UA-Compatible" content="IE=edge" />
  <title>AdminLTE 2 | Log in</title>
  <!-- Tell the browser to be responsive to screen width -->
  <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
  <!-- Bootstrap 3.3.7 -->
  <link rel="stylesheet" href="bower_components/bootstrap/dist/css/bootstrap.min.css" />
  <!-- Font Awesome -->
  <link rel="stylesheet" href="bower_components/font-awesome/css/font-awesome.min.css" />
  <!-- Ionicons -->
  <link rel="stylesheet" href="bower_components/Ionicons/css/ionicons.min.css" />
  <!-- Theme style -->
  <link rel="stylesheet" href="dist/css/AdminLTE.min.css" />
  <!-- iCheck -->
  <link rel="stylesheet" href="plugins/iCheck/square/blue.css" />

  <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
  <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
  <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->

  <!-- Google Font -->
  <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic" />
    <style type="text/css">
        .auto-style1 {
            margin-left: 0px;
        }
    </style>    
</head>
<body class="hold-transition login-page">
<div class="login-box">
  <div class="login-logo">
    <a href="index2.html"><b>Admin</b>LTE</a>
  </div>
  <!-- /.login-logo -->
  <div class="login-box-body">
    <p class="login-box-msg">Sign in to start your session</p>

    <form id="form1" runat="server">
      <div class="form-group has-feedback">
        <asp:TextBox ID="txtemail" CssClass="form-control" placeholder="Email" runat="server" />
        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback">
          <asp:TextBox ID="txtpass" type="password" CssClass="form-control" placeholder="Password" runat="server" />
        <span class="glyphicon glyphicon-lock form-control-feedback"></span>
      </div>
      <div class="row">
        <div class="col-xs-8">
          <div class="checkbox icheck">
              <asp:CheckBox ID="chkRememberMe" runat="server" Text ="Remember me"/> 
          </div>
        </div>
        <!-- /.col -->
        <div class="col-xs-4">
            <asp:Button CssClass="btn btn-primary btn-block btn-flat" ID="Button1" Text="Sign In" runat="server" OnClick="Button1_Click" />
        </div>
        <!-- /.col -->
      </div>

    <div class="social-auth-links text-center">
      <p>- OR -
        </p>
        <asp:LinkButton runat="server" ID="ImageButton1" ValidationGroup="edt" OnClick="ImageButton1_Click" CssClass="btn btn-block btn-social btn-google btn-flat" ><i class="fa fa-google-plus"></i>Sign in using
        Google+</asp:LinkButton>
        
    </div>
    </form>

    <!-- /.social-auth-links -->

    <a href="ResetPassword.aspx">I forgot my password</a><br />
    <a href="signup.aspx" class="text-center">Register a new membership</a>

  <!-- /.login-box-body -->
</div>
<!-- /.login-box -->
</div>

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
