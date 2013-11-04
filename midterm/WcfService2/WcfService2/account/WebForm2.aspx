<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WcfService2.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        //alert("hi");

    </script>
</head>
<body>        
    <br />
    <a href="main.aspx">Back to home page</a>
    <form id="form1" runat="server">
        <p>

        Registry creator (make sure this is the correct username):
        <asp:TextBox ID="TextBox4" runat="server" OnTextChanged="TextBox4_TextChanged"></asp:TextBox>
        </p>
        <p>
            &nbsp;</p>
        <p>
            Product Name:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
    
        If it says false, it means nobody has bought this item. type in true to claim it!
    
            <asp:TextBox ID="TextBox3" runat="server" ></asp:TextBox>
        </p>
    <div>
    
        &nbsp;Price:
    
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    
        <br />
        <br />
        Registry Type:&nbsp; <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
    
    </div>
        <p>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Update" />
        </p>
        <p>

    <asp:Button ID="Button1" runat="server" Text="First/Previous" OnClick="Button1_Click" />

    <asp:Button ID="Button2" runat="server" Text="Next" OnClick="Button2_Click" />

        </p>
    </form>
</body>
</html>
