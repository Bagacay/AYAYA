<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Project.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style>
        body {
            background-color: #e2e1e0;
                        font-weight:700;
            font-family: Verdana,sans-serif;
        }

        .head1 {
            color: #e2e1e0;
        }

        .table1 {
            padding-left: 385px;
            padding-right: 85px;
            font-size: 20px;
        }

        .table2 {
            padding-left: 389px;
            padding-right: 85px;
            font-size: 20px;
        }

        .table3 {
            padding-left: 630px;
            padding-bottom: 150px;
            font-size: 20px;
        }

        .table4 {
            padding-top: 150px;
            font-size: 20px;
        }

        .section4 {
            margin-top: 150px;
            margin-left: 350px;
            margin-right: 450px;
            padding-top:150px;
            padding-left:450px;
            font-size: 50px;
            background-color:  #1a1a1a;
            color: #e2e1e0;
            border-top-left-radius: 5px;
            border-top-right-radius: 5px;
        }

        .section1 {
            margin-left: 350px;
            margin-right: 450px; 
            color: #e2e1e0;
            background-color: #1a1a1a;

            font-size: 20px;
        }

        .section2 {
            margin-left: 350px;
            margin-right: 450px;
            color: #e2e1e0;
            background-color:  #1a1a1a;
            font-size: 20px;
        }

        .section3 {
            margin-left: 350px;
            margin-right: 450px;
            margin-bottom: 150px;
            color: #e2e1e0;
            background-color:  #1a1a1a;
            border-bottom-left-radius: 5px;
            border-bottom-right-radius: 5px;
            font-size: 20px;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="section4" id="section4">
            <table class="table4">
                <asp:Label runat="server" Text="Login" Width="473px"></asp:Label>
            </table>
        </div>

        <div class="section1" id="section1">
            <table class="table1">
                <tr>
                    <td class="style1">Username:</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator2"
                            runat="server"
                            ControlToValidate="TextBox1">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
        </div>
        <div class="section2" id="section2">
            <table class="table2">
                <tr>
                    <td class="style2">Password:</td>
                    <td>
                        <asp:TextBox ID="TextBox2" TextMode="password" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="TextBox2">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
        </div>
        <div class="section3" id="section3">
            <table class="table3">
                <tr>
                    <td class="style3"></td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Log In" OnClick="Button1_Click" />
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
