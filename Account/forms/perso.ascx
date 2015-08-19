<%@ Control Language="C#" AutoEventWireup="true" CodeFile="perso.ascx.cs" Inherits="Account_forms_perso" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
 <link href="../Styles/jquery.ui.datepicker.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.ui.datepicker.js" type="text/javascript"></script>
<%--<script type="text/javascript">
        $(function () {
            $(".myClass").datepicker();
        });
	</script>--%>
<style type="text/css">
    .style3
    {
        height: 29px;
        width: 321px;
    }
    .style1
    {
        height: 29px;
        width: 870px;
    }
    .style4
    {
    }
    .style7
    {
        width: 870px;
    }
    .input_outl
    {}
    .style11
    {
        height: 22px;
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
            <strong>Credit Card Statement Customer</strong></td>
    </tr>
    <tr>
        <td class="style3">
            </td>
        <td class="style1">
            <asp:Label ID="lblstatus" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style4" align="right">
            Name on Card</td>
        <td class="style7">
            <asp:TextBox ID="txtname" runat="server" cssclass="input_outl" Width="234px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style4" align="right">
            Email Address</td>
        <td class="style7">
            <asp:TextBox ID="txtemail" runat="server" cssclass="input_outl" Width="234px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style4" align="right">
            Phone Number</td>
        <td class="style7">
            <asp:TextBox ID="txtPhone" runat="server" cssclass="input_outl" Width="234px"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td class="style4" align="right">
            Contract Number</td>
        <td class="style7">
            <asp:TextBox ID="txtContractNo" runat="server" cssclass="input_outl" 
                Width="234px"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td class="style4" align="right">
            Category</td>
        <td class="style7">
            <asp:DropDownList ID="ddCategory" runat="server">
                <asp:ListItem Value="STAFF">Staff</asp:ListItem>
                <asp:ListItem>Others</asp:ListItem>
            </asp:DropDownList>
            </td>
    </tr>
    <tr>
        <td class="style4" align="right">
            Status</td>
        <td class="style7">
            <asp:DropDownList ID="ddStatus" runat="server">
                <asp:ListItem Value="1">Active</asp:ListItem>
                <asp:ListItem Value="0">Inactive</asp:ListItem>
            </asp:DropDownList>
            </td>
    </tr>
    <tr>
        <td class="style4" align="right">
            &nbsp;</td>
        <td class="style7">
            <asp:Button ID="btnSave" runat="server" class="formbutton" 
                Text="Save" onclick="btnSave_Click" />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                SelectCommand="SELECT * FROM &quot;ACC_BILL_AUXEPORT&quot;">
            </asp:SqlDataSource>
        &nbsp;
            <asp:Button ID="btnUpdate" runat="server" class="formbutton" 
                Text="Update" onclick="btnUpdate_Click" />
        </td>
    </tr>
    <tr>
        <td class="style4" align="right">
            &nbsp;</td>
        <td class="style7">
            <asp:Label ID="lblUsrId" runat="server" Text="Label" ForeColor="White"></asp:Label>
            <asp:HiddenField ID="userID" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="style4" align="right">
            Contract No</td>
        <td class="style7">
            <asp:TextBox ID="txtsearch" runat="server" cssclass="input_outl" Width="234px"></asp:TextBox>
        &nbsp;<asp:Button ID="btnsearch" runat="server" Text="Search" 
                onclick="btnsearch_Click" />
        </td>
    </tr>
    <tr>
        <td class="style4" align="left" colspan="2">
            <asp:GridView ID="Gridview1" runat="server" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" BackColor="#2b6ebb" 
                BorderColor="#CCCCFF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                CssClass="Gridview" DataKeyNames="USERID" GridLines="Vertical" onselectedindexchanged="Gridview1_SelectedIndexChanged" onrowcommand="GridView2_RowCommand"
                OnPageIndexChanging="Gridview1_PageIndexChanging" OnSorting="Gridview1_Sorting" 
                PageSize="20" Width="965px" >
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                                
                                <div style="white-space:nowrap; clear:none; width:100%; display:inline;">
                                    
                                         <div style="white-space:nowrap; clear:none; width:100%; display:inline;">
                                        <asp:LinkButton ID="btnEdit"  runat="server" CommandName="Select" CommandArgument='<%#Eval("USERID")%>' 
                                        onclick="lnkPersoForm_Click">
                                        
                                        <asp:Image ID="Image1" ImageUrl="~/Account/images/edit.png" runat="server" /> 
                                        </asp:LinkButton>
                                         </div>
                           
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="S/N">
                        <ItemTemplate>
                              
                                <%#Container.DataItemIndex+1 %>
                           
                        </ItemTemplate>
                    </asp:TemplateField>
                     
                    <asp:BoundField DataField="NAME_ON_CARD" HeaderText="CUSTOMER NAME" 
                         />
                    <asp:BoundField DataField="EMAIL" HeaderText="EMAIL" />
                    <asp:BoundField DataField="PHONE" HeaderText="PHONE"  />
                    <asp:BoundField DataField="CONTRACT_NO" HeaderText="CONTRACT NO" 
                       />
                    <asp:BoundField DataField="CATEGORY" HeaderText="CATEGORY" 
                        />
                                            
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
    <tr>
        <td class="style4" align="right">
            <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Zip IT" />
        </td>
        <td class="style7">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style4" align="right">
            &nbsp;</td>
        <td class="style7">
            <br />
            &nbsp;</td>
    </tr>
    </table>
