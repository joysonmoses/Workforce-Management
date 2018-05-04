<%@ Page Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="Open.aspx.cs" Inherits="Open" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUserMaster" Runat="Server">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<BR />
            <TABLE class="clsTable" width="93%">
                <TBODY>
                    <TR>
                        <TH align="left" colspan="2" style="color: #009de4">Open In Time </TH>
                    </TR>
                    <TR>
                        <TD align=right style="color: #009de4">Select a Task:  </TD>
                        <TD align=left>
                            <asp:DropDownList id="ddlO_Task" runat="server" OnSelectedIndexChanged="ddlO_Task_SelectedIndexChanged" AutoPostBack="True" ForeColor="White" BackColor="#009de4" Width="170px">
                            </asp:DropDownList>
                            <%--<asp:TextBox id="tbT_Name" runat="server" Width="250px"></asp:TextBox>--%>
                        </TD>
                    </TR>
                    <TR>
                        <TD align=right valign="top" style="color: #009de4">Start Date:  </TD>
                        <TD align=left>
                            <asp:TextBox id="tbO_StartDate" runat="server" Width="250px" BorderColor="#009de4"></asp:TextBox>
                        </TD>
                    </TR>
                    <TR>
                        <TD align=right valign="top" style="color: #009de4">End Date:  </TD>
                        <TD align=left>
                            <asp:TextBox id="tbO_EndDate" runat="server" Width="250px" BorderColor="#009de4"></asp:TextBox>
                        </TD>
                    </TR>
                    <TR>
                        <TD align=right valign="top" style="color: #009de4">Estimated Hours:  </TD>
                        <TD align=left>
                            <asp:TextBox id="tbO_EstHrs" runat="server" Width="250px" BorderColor="#009de4"></asp:TextBox>
                        </TD>
                    </TR>
                    <TR>
                        <TD align=right valign="top" style="color: #009de4">Open Time:  </TD>
                        <TD align=left>
                            <asp:TextBox id="tbO_OpenTime" runat="server" Width="250px" BorderColor="#009de4"></asp:TextBox>
                        </TD>
                    </TR>
                    <TR>
                        <TD align=right style="color: #009de4">Active: </TD>
                        <TD align=left>
                            <asp:CheckBox id="cbO_Active" runat="server"></asp:CheckBox>
                        </TD>
                    </TR>
                    <TR>
                        <td></td>
                        <TD align="left" colSpan=2>
                            <asp:Label id="lblMsg" runat="server"></asp:Label>
                        </TD>
                    </TR>
                    <TR>
                        <TD>
                        </TD>
                        <TD align=left>
                            <asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Text="Save" BackColor="#009de4" Font-Bold="True" ForeColor="White" Height="29px" Width="68px" BorderStyle="None"></asp:Button>
                            <asp:Button id="btnReset" onclick="btnReset_Click" runat="server" Text="Reset" BackColor="#009de4" Font-Bold="True" ForeColor="White" Height="29px" Width="68px" BorderStyle="None"></asp:Button>
                            <%--<asp:Button id="Button1" onclick="btnSave_Click" runat="server" Text="Save"></asp:Button>
                            <asp:Button id="Button2" onclick="btnReset_Click" runat="server" Text="Reset"></asp:Button>--%>
                        </TD>
                    </TR>
                </TBODY>
            </TABLE>
</contenttemplate>
    </asp:UpdatePanel>
   </asp:Content>

