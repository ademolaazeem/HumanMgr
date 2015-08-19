<%@ Control Language="C#" AutoEventWireup="true" CodeFile="processOther.ascx.cs" Inherits="Account_forms_processOther" %>
<style type="text/css">
    .style1
    {
        height: 29px;
        width: 870px;
    }
    .style2
    {
        height: 22px;
        width: 870px;
    }
    .style3
    {
        height: 29px;
        width: 321px;
    }
    .style4
    {
        width: 321px;
    }
    .style5
    {
        height: 22px;
        width: 321px;
    }
    .style6
    {
        height: 20px;
        width: 321px;
    }
    .style7
    {
        width: 870px;
    }
    .style8
    {
        height: 20px;
        width: 870px;
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
            <strong>Process Account Billing</strong></td>
    </tr>
    <tr>
        <td class="style3">
            </td>
        <td class="style1">
            <asp:Button ID="btnProcess" runat="server" class="formbutton" 
                Text="Start Process" onclick="btnProcess_Click" />
        </td>
    </tr>
    <tr>
        <td class="style4" bgcolor="#CCCCFF">
            <strong>Process Name</strong></td>
        <td class="style7" bgcolor="#CCCCFF">
            <strong>Status</strong></td>
    </tr>
    <tr>
        <td class="style5">
            Processing
        </td>
        <td class="style2">
            <asp:Label ID="lblProcessing" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style6">
            Card Services
        </td>
        <td class="style8">
            <asp:Label ID="lblCardServices" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style4">
            Settlements
        </td>
        <td class="style7">
            <asp:Label ID="lblSettlements" runat="server"></asp:Label>
        </td>
    </tr>
    </table>