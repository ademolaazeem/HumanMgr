<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 366px;
        }
        .style6
        {
            FONT: bold 13px tahoma,arial,helvetica;
            COLOR: #000000;
            height: 41px;
        }
        .style7
        {
            height: 41px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    
    <table id="Table3" border="0" cellpadding="1" cellspacing="1" class="dataTable" 
    width="100%">
        <tr>
            <td align="center" class="text18bb" colspan="6">
            &nbsp;</td>
        </tr>
        <tr>
            <td align="center"  colspan="6">
                <strong><asp:Label ID="lblstatus" runat="server"></asp:Label></strong>
            </td>
        </tr>
        
        
        <tr>
            <td align="center" class="text18bb" colspan="6">
                <h1 class="text13b" style="MARGIN-TOP: 20px; TEXT-ALIGN: center">
                Login using your Windows Account<img src="images/images.jpg" 
                style="VERTICAL-ALIGN: bottom; height: 54px; width: 57px;" /></h1>
            </td>
        </tr>
        <tr>
            <td align="center"  colspan="6">
                <table id="Table1" border="0" cellpadding="0" cellspacing="0" width="30%">
                    <tr>
                        <td class="text13b">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style6">
                        Username</td>
                        <td align="left" class="style7">
                            <asp:TextBox ID="txtuser" runat="server" cssclass="input_shadow" Height="16px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtuser" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text13b">
                        Password</td>
                        <td align="left">
                            <asp:TextBox ID="txtpass" runat="server" cssclass="input_shadow" 
                                TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtpass" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text13b">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="text13b">
                            &nbsp;</td>
                        <td align="left"><img src="images/button_left.jpg" style="VERTICAL-ALIGN: bottom" alt="CCDS">
                            
                <asp:Button ID="btnLogin" runat="server" 
               Text="Login "  class="formbutton_shadow" onclick="btnLogin_Click"/>
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
                &nbsp;</td>
            <td class="text11b" style="HEIGHT: 20px">
            </td>
            <td style="HEIGHT: 20px">
            </td>
            <td >
                &nbsp;</td>
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
    
    
</asp:Content>

