<%@ Control Language="C#" AutoEventWireup="true" CodeFile="loginCtrl.ascx.cs" Inherits="Account_forms_loginCtrl" %>
<style type="text/css">

    .style1
    {
        height: 20px;
        width: 153px;
    }
    .style2
    {
        width: 153px;
    }
    .style3
    {
        height: 47px;
    }
</style>

<table id="Table3" border="0" cellpadding="1" cellspacing="1" class="dataTable" 
    width="100%">
    <tr>
        <td align="center" class="text18bb" colspan="6">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center" class="text18bb" colspan="6">
            <strong>Login Panel</strong></td>
    </tr>
    <tr>
        <td align="center" colspan="6">
            <p>
                Please login to maintain all of your records and services.</p>
        </td>
    </tr>
    <tr>
        <td align="center" class="text18bb" colspan="6">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center" class="text18bb" colspan="6">
            <h1 class="text13b" style="MARGIN-TOP: 20px; TEXT-ALIGN: center">
                Login to your Account<img src="../images/images.jpg" 
                style="VERTICAL-ALIGN: bottom; height: 54px; width: 57px;" /></h1>
        </td>
    </tr>
    <tr>
        <td align="center" class="style3" colspan="6">
            <table id="Table1" border="0" cellpadding="0" cellspacing="0" width="30%">
                <tr>
                    <td class="text13b">
                        Username</td>
                    <td>
                        <asp:TextBox ID="txtuser" runat="server" cssclass="input_shadow"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="text13b">
                        Password</td>
                    <td>
                        <asp:TextBox ID="txtpass" runat="server" cssclass="input_shadow" 
                            TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="text11b" style="HEIGHT: 20px">
        </td>
        <td align="center" class="text11b" colspan="2" style="HEIGHT: 20px">
            &nbsp;</td>
        <td class="text11b" style="HEIGHT: 20px">
        </td>
        <td style="HEIGHT: 20px">
        </td>
        <td class="style1">
        </td>
    </tr>
    <tr>
        <td class="text11b" style="HEIGHT: 20px">
        </td>
        <td align="center" colspan="2" style="HEIGHT: 20px">
            <asp:Button ID="btnLogin" runat="server" 
                class="formbutton_shadow" Text="Login To My Account" />
        </td>
        <td class="text11b" style="HEIGHT: 20px">
        </td>
        <td style="HEIGHT: 20px">
        </td>
        <td class="style1">
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
        </td>
        <td style="WIDTH: 136px">
        </td>
        <td>
        </td>
        <td>
        </td>
        <td class="style2">
        </td>
    </tr>
    <tr>
        <td class="text11b">
            &nbsp;</td>
        <td class="text11b">
        </td>
        <td class="text11b" style="WIDTH: 148px">
        </td>
        <td class="text11b">
        </td>
        <td>
        </td>
        <td class="style2">
        </td>
    </tr>
</table>

