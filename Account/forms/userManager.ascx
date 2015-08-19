<%@ Control Language="C#" AutoEventWireup="true" CodeFile="userManager.ascx.cs" Inherits="Account_forms_userManager" %>

<style type="text/css">
        .Gridview
        {
        text-align: center;
    }
        .style558
        {
            width: 215px;
        }
        .style1
        {
            width: 650px;
            
        }
        .style559
        {
            width: 109px;
        }
    .input_outl
    {}
    </style>
<table class="style1">
            <tr>
                <td align="right" class="style559" bgcolor="Silver">
                    &nbsp;</td>
                <td bgcolor="Silver" class="style558" colspan="2">
                    <asp:Label ID="lblstatus" runat="server"></asp:Label>
                    <asp:Label ID="lblstatus0" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" class="style9" bgcolor="#CCCCFF" colspan="3">
                    <asp:Label ID="Label12" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Grant User Role and Permision"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style559">
                    <asp:Label ID="Label2" runat="server" Text="User Name"></asp:Label>
                </td>
                <td class="style558" colspan="2">
            <asp:TextBox ID="txtuser" runat="server" cssclass="input_outl" Width="164px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left" class="style10" bgcolor="#CCCCFF" colspan="3">
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Modules"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style559">
                    &nbsp;</td>
                <td class="style558" colspan="2">
                    <asp:Panel ID="Panel2" runat="server">
                     
                       
                     
                        <asp:CheckBox ID="chkAccess_user" runat="server" Text="User Management" />
                        <br />
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="left" class="style11" bgcolor="#CCCCFF" colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="style559">
                    &nbsp;</td>
                <td class="style558" colspan="2">
                    <asp:CheckBox ID="chkAccess_stf" runat="server" 
                        Text="Grant Access to Manage Staff Module" />
                   
                    
                &nbsp;<br />
                    <asp:Button ID="btnUpdateProfile0" runat="server" onclick="btnUpdateProfile0_Click" 
                        Text="Update Profile" />
                    
                </td>
            </tr>
            <tr>
                <td align="right" class="style559">
                    &nbsp;</td>
                <td class="style558" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="style559">
                    &nbsp;</td>
                <td class="style558">
                    &nbsp;</td>
                <td class="style558">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="style559">
                    &nbsp;</td>
                <td class="style558" colspan="2">
                    <asp:GridView ID="Gridview1" runat="server" AllowPaging="True" 
                                        AllowSorting="True" 
        AutoGenerateColumns="False" BackColor="White" 
                                        BorderColor="#CCCCFF" BorderStyle="None" 
        BorderWidth="1px" CellPadding="3" 
                                        CssClass="Gridview" DataKeyNames="user_id" 
                                        GridLines="Vertical" onselectedindexchanged="Gridview1_SelectedIndexChanged" 
                                        Width="399px" 
        OnPageIndexChanging="Gridview1_PageIndexChanging" 
    OnSorting="Gridview1_Sorting">
                                        <AlternatingRowStyle BackColor="#DCDCDC" />
                                        <Columns>
                                           <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                    <div style="white-space:nowrap; clear:none; width:100%; display:inline;">
                                     <asp:LinkButton ID="btnDelete"  runat="server" OnClientClick="return confirm('Are you sure you want to delete this record?');"
                                        CommandName="Delete">
                                        
                                        <asp:Image ID="imgDelete" ImageUrl="~/Account/images/imgdelete1.png" runat="server" /> 
                                        </asp:LinkButton>
                                         </div>
                                         <div style="white-space:nowrap; clear:none; width:100%; display:inline;">
                                        <asp:LinkButton ID="btnEdit"  runat="server" CommandName="Select" >
                                        
                                        <asp:Image ID="Image1" ImageUrl="~/Account/images/edit.png" runat="server" /> 
                                        </asp:LinkButton>
                                         </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                            
                                            <asp:BoundField DataField="username" HeaderText="USERNAME" 
                                                SortExpression="username" />
                                            
                                            <asp:BoundField DataField="last_login" HeaderText="LAST LOGIN" 
                                                SortExpression="last_login" />
                                            <asp:BoundField DataField="login_ip" HeaderText="IP ADDRESS" 
                                               />
                                            
                                        </Columns>
                                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#000065" />
                                    </asp:GridView>
&nbsp;  <asp:Label ID="lblShow" runat="server" ForeColor="DarkRed"></asp:Label></td>
            </tr>
        </table>

