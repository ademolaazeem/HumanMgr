<%@ Control Language="C#" AutoEventWireup="true" CodeFile="reportSummary.ascx.cs" Inherits="Account_forms_reportSummary" %>
<style type="text/css">

    .style8
    {
    }
    .style9
    {
        height: 25px;
        width: 234px;
    }
    .style11
    {
        height: 25px;
        }
    </style>

<table id="Table2" border="0" cellpadding="1" cellspacing="1" class="dataTable" 
    width="100%">
    <tr>
        <td align="center" class="text18bb" colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="text18bb" colspan="2">
            <strong>Summary Reports</strong></td>
    </tr>
    <tr>
        <td class="style8">
            &nbsp;</td>
        <td class="text11b">
        </td>
    </tr>
    <tr>
        <td class="style9" align="right">
            Period
        </td>
        <td class="style11">
             <asp:DropDownList ID="ddMonthName" runat="server" class="dropMenu">
               
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddYearName" runat="server" class="dropMenu">
               
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style8">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnGenerate" runat="server" class="formbutton" 
                Text="Generate" />
        </td>
    </tr>
    <tr>
        <td class="style8" colspan="2">
            <asp:GridView ID="gvDetails" DataKeyNames="UserId" AutoGenerateColumns="false" CellPadding="5" runat="server">
<Columns>
<asp:TemplateField>
<ItemTemplate>
<asp:CheckBox ID="chkSelect" runat="server" />
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField HeaderText="UserId" DataField="UserId" />
<asp:BoundField HeaderText="UserName" DataField="UserName" />
<asp:BoundField HeaderText="Education" DataField="Education" />
<asp:BoundField HeaderText="Location" DataField="Location" />
</Columns>
<HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />
</asp:GridView>
<asp:Button ID="btnProcess" Text="Get Selected Records" runat="server"
Font-Bold="true" onclick="btnProcess_Click" /><br />
<asp:Label ID="lblmsg" runat="server" /></td>
    </tr>
    </table>




