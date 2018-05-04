<%@ Page Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="UserHome.aspx.cs" Inherits="UserHome" Title="Work Force Management System - User Home" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUserMaster" Runat="Server">

   <%-- <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <%--<asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>--%>
        
<asp:Label id="lbl_username" runat="server" Text="lbl_username"></asp:Label>
<BR />
<TABLE class="clsTable" width="93%">
<TBODY>
<TR>
<TH align=left colSpan=2>&nbsp;
<asp:Label id="lblReportTitle" runat="server"></asp:Label> </TH></TR>
<TR><TD align=center colSpan=2>
<asp:GridView id="gvUserHome" class="clsGrid" runat="server" HeaderStyle-BackColor="#009de4" HeaderStyle-ForeColor="white" Width="252px">
    <HeaderStyle BackColor="#009DE4" ForeColor="White" />
</asp:GridView>
 </TD></TR>
 </TBODY>
 </TABLE>
<%--</contenttemplate>

 </asp:UpdatePanel>--%>
</asp:Content>