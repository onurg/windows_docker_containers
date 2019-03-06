<%@ Page Language="C#" Inherits="HelloWorldASP.Default" %>
<%
    HelloWorldLabel.Text = "Hello, world!";
%>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Default</title>
</head>
<body>
	<form id="form1" runat="server">
		<asp:Label runat="server" id="HelloWorldLabel"></asp:Label>
	</form>
</body>
</html>
