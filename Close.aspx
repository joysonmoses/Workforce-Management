<%@ Page Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="Close.aspx.cs" Inherits="Close" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUserMaster" Runat="Server">
   <asp:ScriptManager id="ScriptManager1" runat="server">
</asp:ScriptManager>
    <br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE class="clsTable" width="93%"><TBODY><TR><TH style="COLOR: #009de4" align=left colSpan=2>Close out Time </TH></TR><TR><TD style="COLOR: #009de4" align=right>Select a Task: </TD><TD align=left><asp:DropDownList id="ddlC_Task" runat="server" Width="170px" BackColor="#009de4" ForeColor="White" AutoPostBack="True" OnSelectedIndexChanged="ddlC_Task_SelectedIndexChanged">
                            </asp:DropDownList> </TD></TR><TR><TD style="COLOR: #009de4" vAlign=top align=right>Start Time: </TD><TD align=left><asp:TextBox id="tbC_StartTime" runat="server" Width="250px"></asp:TextBox> </TD></TR><TR><TD style="COLOR: #009de4" vAlign=top align=right>End Time: </TD><TD align=left><asp:TextBox id="tbC_EndTime" runat="server" Width="250px"></asp:TextBox> </TD></TR><TR><TD style="COLOR: #009de4" vAlign=top align=right>Estimated Hours: </TD><TD align=left><asp:TextBox id="tbC_EstHrs" runat="server" Width="250px"></asp:TextBox> </TD></TR><TR><TD style="COLOR: #009de4" vAlign=top align=right>Actual Time Spent: </TD><TD align=left><asp:TextBox id="tbC_SpentTime" runat="server" Width="250px"></asp:TextBox> </TD></TR><TR><TD style="COLOR: #009de4" align=right>Active: </TD><TD align=left><asp:CheckBox id="cbC_Active" runat="server"></asp:CheckBox> </TD></TR><TR><TD></TD><TD align=left colSpan=2><asp:Label id="lblMsg" runat="server"></asp:Label> </TD></TR><TR><TD></TD><TD align=left><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="68px" BackColor="#009de4" ForeColor="White" BorderStyle="None" Height="29px" Font-Bold="True" Text="Save"></asp:Button> <asp:Button id="btnReset" onclick="btnReset_Click" runat="server" Width="68px" BackColor="#009de4" ForeColor="White" BorderStyle="None" Height="29px" Font-Bold="True" Text="Reset"></asp:Button> </TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>

