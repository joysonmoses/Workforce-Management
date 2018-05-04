<%@ Page Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="UserLogin.aspx.cs" Inherits="Default2" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUserMaster" Runat="Server">
    <br />
    <br />
    <br />
    <br />
    <table align="center">
        <tr>
            <th colspan="2" style="font-weight: bold; text-align: center;">
                User Authentication
            </th>
        </tr>
        <tr>
            <td   style="color: #009de4">
                User Name</td>
            <td style="height: 26px">
                <asp:TextBox ID="tbUserName" runat="server" BorderColor="#009de4"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbUserName" ErrorMessage="Enter User Name"></asp:RequiredFieldValidator>
                </td>
        </tr>
        <tr>
            <td  style="color: #009de4">
                Password</td>
            <td>
                <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" Width="149px" BorderColor="#009de4"></asp:TextBox></td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbPassword" ErrorMessage="Enter Password"></asp:RequiredFieldValidator>
        </td>
       
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Label ID="lblMsg" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="btnSignIn" runat="server" OnClick="btnSignIn_Click" Text="Sign In" BackColor="#009de4" Font-Bold="True" ForeColor="White" Height="29px" Width="68px" BorderStyle="None"/></td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>

