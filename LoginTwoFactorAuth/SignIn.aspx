<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="LoginTwoFactorAuth.SignIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="page-wrapper bg-gra-01 p-t-100 p-b-10 font-poppins">
        <div class="wrapper wrapper--w780">

            <div class="card card-3">
                <div class="card-heading" runat="server" id="defaultBild">
                        <div class="p-t-10 text-center">
                       <a class="btn btn--pill btn--green" href="Default.aspx">Sign Up</a>  
                        </div>
                </div>
                <div class="card-body">
                    <h2 class="title">Sign in</h2>
                    <form method="POST">
                        <div class="input-group">
                            <input class="input--style-3" type="text" runat="server" id="TxtLogin" placeholder="Login" name="login">
                        </div>
                        <div class="input-group">
                            <input class="input--style-3" runat="server" id="TxtPwd" type="password" placeholder="password" name="password">
                        </div>
                         <div class="input-group">
                            <input class="input--style-3" type="text" runat="server" id="TxtToken" placeholder="token" name="login">
                        </div>
                        <div class="p-t-10">
                            <asp:Button ID="btnSubmit" runat="server" class="btn btn--pill btn--green" Text="Submit" type="submit" OnClick="btnSignIn_Click" />
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <!-- Jquery JS-->
    <script src="vendor/jquery/jquery.min.js"></script>
    <!-- Vendor JS-->
    <script src="vendor/select2/select2.min.js"></script>
    <!-- Main JS-->
    <script src="js/global.js"></script>

   
</asp:Content>
