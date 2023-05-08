<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="JSON_MADELEN.WebForm2"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    
        Temperaturen nå i Fredrikstad er: <asp:Label ID="LabelTempNow" runat="server" Text="TempNowValue"></asp:Label> celsius
            <br />
         <br />

         Vind farten i Fredrikstad er: <asp:Label ID="LabelWindsNow" runat="server" Text="WindsNowValue"></asp:Label>
            <br />
         <br />

         Vindretningen i Fredrikstad er: <asp:Label ID="LabelWindsogNow" runat="server" Text="WindsogNowValue"></asp:Label>
            <br />
         <br />

        Vind kvalitet i Fredrikstad er: <asp:Label ID="LabelLuftkNow" runat="server" Text="LuftkNowValue"></asp:Label>
            <br />
         <br />


    </form>
</body>
</html>
