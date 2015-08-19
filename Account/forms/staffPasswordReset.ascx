<%@ Control Language="C#" AutoEventWireup="true" CodeFile="staffPasswordReset.ascx.cs" Inherits="Account_forms_staffPasswordReset" %>

<%--<script type="text/javascript">

    this.txtsearch.Attributes.Add("onkeypress", "button_click(this,'" + this.txtsearch.ClientID + "')");
function button_click(objTextBox,objBtnID)
{
    if(window.event.keyCode==13)
    {
        document.getElementById(objBtnID).focus();
        document.getElementById(objBtnID).click();
    }
}
</script>  --%>      


<style type="text/css">



    .style11
    {
        height: 22px;
    }
    .style12
    {
        width: 236px;
    }
    .style7
    {
        width: 870px;
    }
    .style17
    {
        width: 236px;
        height: 70px;
    }
    .style18
    {
        width: 870px;
        height: 70px;
    }
    .style19
    {
        width: 236px;
        height: 35px;
    }
    .style20
    {
        width: 870px;
        height: 35px;
    }
    .style21
    {
        width: 236px;
        height: 24px;
    }
    .style22
    {
        width: 870px;
        height: 24px;
    }
    </style>

<table id="Table2" border="0" cellpadding="1" cellspacing="1" class="dataTable" 
    width="100%">
    <tr>
        <td align="center" class="style11" colspan="2">
        </td>
    </tr>
    <tr>
        <td class="text18bb" colspan="2">
            <strong>Human Manager Password Reset: Display Staff Information</strong></td>
    </tr>
    <tr>
        <td align="right" bgcolor="#CCCCFF" class="style19">
            Message:</td>
        <td bgcolor="#CCCCFF" class="style20">
            <asp:Label ID="lblstatus" runat="server"></asp:Label>
        </td>
    </tr>
    
    <tr bgcolor="#CCCCFF">
        <td align="right"  class="style12">
            User Id:</td>
        <td class="style7">
            <asp:Label ID="lbluserid" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right" class="style12">
            Username</td>
        <td class="style7">
            <asp:Label ID="lblusername" runat="server"></asp:Label>
        </td>
    </tr>
    <tr bgcolor="#CCCCFF">
        <td align="right" class="style12">
            Locked?</td>
        <td class="style7">
            <asp:DropDownList ID="ddlocked" runat="server">
                <asp:ListItem Selected="True" Value="">UnLocked</asp:ListItem>
                <asp:ListItem Value="L">Locked</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right" class="style21">
            New User?:</td>
        <td class="style22">
            <asp:DropDownList ID="ddnew_user" runat="server">
                <asp:ListItem Selected="True" Value="N">NO</asp:ListItem>
                <asp:ListItem Value="Y">YES</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right" class="style19">
            </td>
        <td class="style20">
            <asp:Button ID="btnUpdate" runat="server" class="formbutton" 
                onclick="btnUpdate_Click" Text="Update" />
        </td>
    </tr>
    <tr bgcolor="#CCCCFF">
        <td align="right" class="style17">
            </td>
        <td class="style18">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
            <asp:HiddenField ID="username" runat="server"/>
            <asp:HiddenField ID="userID" runat="server" />
        </td>
    </tr>
   <%-- <tr>
        <td align="right" class="style12">
            Staff Name:</td>
        <td class="style7">
           <asp:TextBox ID="txtsearch" runat="server" cssclass="input_outl" Width="234px"></asp:TextBox>
            &nbsp;<asp:Button ID="btnsearch" runat="server" onclick="btnsearch_Click" 
                Text="Search" />
        </td>
    </tr>--%>
    <tr>
        <td align="right" class="style12">
            &nbsp;</td>
        <td class="style7">
            <br />
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style4" colspan="2">
            <asp:GridView ID="Gridview1" runat="server" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" BackColor="#2b6ebb" 
                BorderColor="#CCCCFF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                CssClass="Gridview" DataKeyNames="USER_ID" GridLines="Vertical" 
                OnPageIndexChanging="Gridview1_PageIndexChanging" 
                onrowcommand="GridView1_RowCommand" 
                onselectedindexchanged="Gridview1_SelectedIndexChanged" 
                OnSorting="Gridview1_Sorting" PageSize="20" Width="965px">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <div style="white-space: nowrap; clear: none; width: 100%; display: inline;">
                                <div style="white-space: nowrap; clear: none; width: 100%; display: inline;">
                                    <asp:LinkButton ID="btnEdit" runat="server" 
                                        CommandArgument='<%#Eval("USER_ID")%>' CommandName="Select" 
                                        onclick="lnkPersoForm_Click" onrowcommand="GridView1_RowCommand">
                                        
                                        <asp:Image ID="Image1" ImageUrl="~/Account/images/edit.png" runat="server" /> 
                                        </asp:LinkButton>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="S/N">
                        <ItemTemplate>
                              
                                <%#Container.DataItemIndex+1 %>
                           
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="name" HeaderText="STAFF NAME" />
                    <asp:BoundField DataField="USER_ID" HeaderText="USER ID" />
                    <asp:BoundField DataField="USER_IN" HeaderText="LOCKED?" />
                    <asp:BoundField DataField="NEW_USER" HeaderText="USER_STATUS" />
                                            
                                           <%-- <asp:BoundField DataField="STATUS" HeaderText="STATUS" 
                                                SortExpression="STATUS" />--%>
                                               
                </Columns>
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="false" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="false" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>
        </td>
    </tr>
</table>

