<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LoginTwoFactorAuth._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="page-wrapper bg-gra-01 p-t-20 p-b-10 font-poppins">
        <div class="wrapper wrapper--w780">
            <div class="card card-3">
                <div class="card-heading" runat="server" id="defaultBild">
                      <div class="p-t-10 text-center">
                       <a class="btn btn--pill btn--green" href="SignIn.aspx">Sign in</a>  
                        </div>
                </div>
                <div class="card-body text-center" runat="server" id="QRBild">
                    <h2 class="title">Your QR Code</h2>
                    <asp:Image  class="QRCode title"  id="iimg" runat="server" />
                    <h5 class="title">
                        <asp:Label runat="server" ID="lblPsk"> please scan your QRCode </asp:Label>
                    </h5>

                </div>
                <div class="card-body">
                    <h2 class="title">Registration Info</h2>
                    <form method="POST">
                        <div class="input-group">
                            <input class="input--style-3" type="text" runat="server" id="TxtFirstName" placeholder="First Name" name="name">
                        </div>
                        <div class="input-group">
                            <input class="input--style-3" runat="server" id="TxtSurName" type="text" placeholder="Surname" name="Surname">
                        </div>
                         <div class="input-group">
                            <input class="input--style-3" type="email" runat="server" id="TxtEmail" placeholder="Email" name="email">
                        </div>
                         <div class="input-group">
                            <input class="input--style-3" type="text" runat="server" id="TxtAdress" placeholder="Adress" name="adress">
                        </div>

                         <div class="input-group">
                            <input class="input--style-3" type="text" runat="server" id="TxtLogin" placeholder="Login" name="login">
                        </div>
                        <div class="input-group">
                            <input class="input--style-3" type="password" runat="server" id="TxtPwd" placeholder="password" name="password">
                        </div>

                        <div class="p-t-10">
                            <asp:Button ID="btnSubmit" runat="server" class="btn btn--pill btn--green" Text="Submit" type="submit" OnClick="btnSubmit_Click" />
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
