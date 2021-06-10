<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecondPage.aspx.cs" Inherits="SessionManagement.SecondPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Second Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblUser" runat="server" Font-Size="Large" />
            <asp:Button ID="btnLogIn" runat="server" Font-Size="Large" Text="Continue to Main Page" OnClick="btnLogIn_Clicked" />
    </form>
</body>
</html>
