<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="WcfService2.account.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:LinkButton ID="lnkbtnLogout" runat="server" OnClick="lnkbtnLogout_Click">Logout</asp:LinkButton>
    <br/>
    Hello <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
    <br />
        <p>
            <a href="WebForm2.aspx">Look through the gift registry list</a>
            <br />
            <br />
            <hr />
            <a href="newProducts.aspx">Add new products to gift registry</a>
        </p>

    </div>
    </form>
</body>
</html>
