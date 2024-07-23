<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pending.aspx.cs" Inherits="Project.Pending" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <%--SOURCE http://startbootstrap.com/template-overviews/simple-sidebar/--%>
    <%--GITHUB URL https://github.com/IronSummitMedia/startbootstrap-simple-sidebar--%>
    <!-- Bootstrap Core CSS -->
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>

    <!-- Custom CSS -->
    <link href="css/simple-sidebar.css" rel="stylesheet" />
    <title>AYAYA</title>

    <style>
                body {
    font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
    font-size: 20px;
    line-height: 1.42857143;
    color: #1c1c1c;
    background-color: #e2e1e0;
}
        h1{
            font-size:50px;
            font-weight:800;
            padding-left: 350px
        }

        .container {
            padding: 50px 50px 50px 50px;
            background-color: black;
            border-radius: 20px;
            color: #e2e1e0;
            width: 750px;
            margin-left: 350px;
            margin-right: 0;
        }

        th {
            text-align: center;
        }

        #sidebar-wrapper {
            z-index: 1000;
            position: fixed;
            left: 250px;
            height: 100%;
            margin-left: -250px;
            overflow-y: auto;
            background: #1a1a1a;
        }

        .sidebar-nav {
            top: 0;
            width: 250px;
            margin: 0;
            padding: 0;
                        font-weight:700;
            font-family: Verdana,sans-serif;
        }

            .sidebar-nav li {
                text-indent: 20px;
                line-height: 40px;
            }

                .sidebar-nav li a {
                    display: block;
                    font-size: 20px;
                    text-decoration: none;
                    color: #fff;
                    padding-top: 25px;
                    padding-bottom: 25px;
                }

                    .sidebar-nav li a:hover {
                        text-decoration: none;
                        color: #e2e1e0;
                        font-weight: bold;
                        background: rgba(255,255,255,0.2);
                    }

                    .sidebar-nav li a:active, .sidebar-nav li a:focus {
                        text-decoration: none;
                    }

            .sidebar-nav > .sidebar-brand {
                text-align: center;
                padding: 25px 0 25px 0;
            }

                .sidebar-nav > .sidebar-brand a {
                    font-size: 30px;
                }



        #sidebar-wrapper {
            width: 250px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
            <!-- Sidebar -->
            <div id="sidebar-wrapper">
                <br />
                <ul class="sidebar-nav">

                    <li class="sidebar-brand"><a href="Dashboard.aspx">Admin </a></li>
                    <li><a href="Dashboard.aspx"><span class="glyphicon glyphicon-dashboard"></span>&nbsp;&nbsp;Dashboard</a></li>
                    <li><a href="Approved.aspx"><span class="glyphicon glyphicon-ok"></span>&nbsp;&nbsp;Approved</a></li>
                    <li><a href="Pending.aspx"><span class="glyphicon glyphicon-pencil"></span>&nbsp;&nbsp;Pending</a></li>
                    <li><a href="History.aspx"><span class="glyphicon glyphicon-trash"></span>&nbsp;&nbsp;History</a></li>
                    <li><a href="Coffee.aspx"><span class="glyphicon glyphicon-off"></span>&nbsp;&nbsp;Coffee Shop</a></li>

                </ul>
            </div>
                <div class="w3-container">
        <br />
        <br />
        <br />

        <h1>Pending</h1>
        <br />
        <br />
        <br />

    </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div id="dvGrid" style="padding: 0 0 0 290px; width: 700px; text-align: center; font-size: 15px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1"
                            runat="server"
                            AutoGenerateColumns="false"
                            OnRowDataBound="OnRowDataBound"
                            AOnRowDataBound="AOnRowDataBound"
                            DataKeyNames="Order_id"
                            OnRowEditing="OnRowEditing"
                            PageSize="10"
                            AllowPaging="true"
                            OnPageIndexChanging="OnPaging"
                            OnRowDeleting="OnRowDeleting"
                            EmptyDataText="No records has been added."
                            Width="1570"
                            Height="500">
                            <Columns>
                                <asp:TemplateField HeaderText="First name" ItemStyle-Width="150">
                                    <ItemTemplate>
                                        <asp:Label ID="Fname" runat="server" Text='<%# Eval("Fname") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Last name" ItemStyle-Width="150">
                                    <ItemTemplate>
                                        <asp:Label ID="Lname" runat="server" Text='<%# Eval("Lname") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mobile" ItemStyle-Width="150">
                                    <ItemTemplate>
                                        <asp:Label ID="Mobile" runat="server" Text='<%# Eval("Mobile") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email" ItemStyle-Width="150">
                                    <ItemTemplate>
                                        <asp:Label ID="Email" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Booking" ItemStyle-Width="150">
                                    <ItemTemplate>
                                        <asp:Label ID="Booking" runat="server" Text='<%# Eval("Booking") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date & Time" ItemStyle-Width="150">
                                    <ItemTemplate>
                                        <asp:Label ID="Date_time" runat="server" Text='<%# Eval("Date_time") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ButtonType="Link"
                                    ShowEditButton="true"
                                    ShowDeleteButton="true"
                                    EditText="<i aria-hidden='true' > Approve</i>"
                                    DeleteText="<i aria-hidden='true' > Decline</i>"
                                    ItemStyle-Width="150" />                                
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>
