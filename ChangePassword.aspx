<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="_Default" %>

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
    <p class="login-box-msg">Change Password</p>
    <form id="form2" runat="server">
      <div class="form-group has-feedback">
                    <asp:TextBox ID="txtNewPassword" CssClass="form-control" placeholder="New Password" runat="server" TextMode="Password" />
                    <span class="glyphicon glyphicon-lock form-control-feedback"><sup><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNewPassword" ErrorMessage="*" ForeColor="Red"/></sup></span>
       </div>
        <div class="form-group has-feedback">

            <asp:TextBox ID="txtConfirmNewPassword" CssClass="form-control" TextMode="Password" placeholder="Confirm Password" runat="server" />
          <span class="glyphicon glyphicon-log-in form-control-feedback"><sup><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNewPassword" ErrorMessage="*" ForeColor="Red"/></sup></span>
          <asp:Label ID="lpsw" runat="server"></asp:Label>
          <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
        
        <div class="row">
          
          <!-- /.col -->
          <div class="col-xs-8">
            <asp:Button CssClass="btn btn-primary btn-block btn-flat" ID="btnSave" Text=" Reset Password" runat="server" OnClick="btnSave_Click" />
          </div>
        <!-- /.col -->
      </div>
      </form>

    

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
