<%@ Control Language="C#" AutoEventWireup="true" CodeFile="InvoiceSum.ascx.cs" Inherits="Account_forms_InvoiceSum" %>
 <script type="text/javascript" language="javascript">
     function ConfirmOnDelete(item) {
         if (confirm("The following item(s) will be deleted: " + item + "Continue?") == true)
             return true;
         else
             return false;
     }
    </script>
<style type="text/css">
 .Gridview
        {
        text-align: center;
    }

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
    .style10
    {
        height: 20px;
        width: 234px;
    }
    .style12
    {
        width: 234px;
        height: 23px;
    }
    .style13
    {
        height: 23px;
    }
    .Gridview
    {}
    .style14
    {
        height: 22px;
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
            <strong>Detail Reports</strong></td>
    </tr>
    <tr>
        <td class="style14">
            </td>
        <td class="style14">
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
        <td class="style10" align="right">
           </td>
        <td>
            <asp:Button ID="btnGenerate" runat="server" class="formbutton" 
                Text="Generate" onclick="btnGenerate_Click" />
        </td>
    </tr>
    <tr>
        <td class="style12">
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        </td>
        <td class="style13">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="btnexport" runat="server" onclick="btnexport_Click" 
                Text="Export" class="formbutton"/>
        </td>
    </tr>
    <tr>
        <td class="style8" colspan="2">
            <asp:GridView ID="Gridview1" runat="server" AllowPaging="True" 
                                        AllowSorting="True" 
        AutoGenerateColumns="False" BackColor="#2b6ebb" 
                                        BorderColor="#CCCCFF" BorderStyle="None" 
        BorderWidth="1px" CellPadding="3" 
                                        CssClass="Gridview" DataKeyNames="SEQ_ID" 
                                        GridLines="Vertical" 
                                        Width="965px" 
        OnPageIndexChanging="Gridview1_PageIndexChanging" 
    OnSorting="Gridview1_Sorting" PageSize="20">
                                        <AlternatingRowStyle BackColor="#DCDCDC" />
                                                                                    <Columns>
                                                                                       <asp:TemplateField>
                                               <HeaderTemplate>
                                                  <asp:Button ID="ButtonDelete" runat="server" Text="Delete" />
                                               </HeaderTemplate>
                                               <ItemTemplate>
                                                  <asp:CheckBox ID="CheckBox1" runat="server" />
                                               </ItemTemplate>
                                               </asp:TemplateField>
                                            
                                            <asp:BoundField DataField="NAME_ON_CARD" HeaderText="NAME ON CARD" 
                                                SortExpression="NAME_ON_CARD" />
                                            
                                            <asp:BoundField DataField="EMAIL" HeaderText="EMAIL" 
                                                SortExpression="EMAIL" />
                                                  <asp:BoundField DataField="PHONE" HeaderText="PHONE" 
                                                SortExpression="PHONE" />
                                            
                                            <asp:BoundField DataField="CONTRACT_NO" HeaderText="CONTRACT NO" 
                                                SortExpression="CONTRACT_NO" />
                                                  <asp:BoundField DataField="MONTH" HeaderText="MONTH" 
                                                SortExpression="MONTH" />
                                            
                                            <asp:BoundField DataField="YEAR" HeaderText="YEAR" 
                                                SortExpression="YEAR" />
                                                <asp:BoundField DataField="SENT_TIME" HeaderText="SENT TIME" 
                                                SortExpression="SENT_TIME" />
                                                
                                                                                     
                                            
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
                                    </asp:GridView></td>
    </tr>
    </table>





