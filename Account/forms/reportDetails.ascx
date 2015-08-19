<%@ Control Language="C#" AutoEventWireup="true" CodeFile="reportDetails.ascx.cs" Inherits="Account_forms_reportDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<style type="text/css">


    .style7
    {
        height: 25px;
    }
    .style8
    {
    }
    .style9
    {
        height: 25px;
        width: 234px;
    }
    .style10
    {
        height: 20px;
        width: 234px;
    }
    .style11
    {
        height: 25px;
        width: 160px;
    }
    .style12
    {
        height: 25px;
        width: 62px;
    }
    .style13
    {
        width: 234px;
        height: 22px;
    }
    .style14
    {
        height: 22px;
    }
    .Gridview
        {
        text-align: center;
    }

    </style>

<table id="Table2" border="0" cellpadding="1" cellspacing="1" class="dataTable" 
    width="100%">
    <tr>
        <td align="center" class="text18bb" colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style14" colspan="2">
            <strong>Customer Lists</strong></td>
    </tr>
    <tr>
        <td class="style10" align="right">
            Select to view</td>
        <td>
            <asp:DropDownList ID="ddInstitution" runat="server" class="dropMenu">
                <asp:ListItem Value="3">All</asp:ListItem>
                <asp:ListItem Value="1">Active</asp:ListItem>
                <asp:ListItem Value="0">Inactive</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style8">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnGenerate" runat="server" class="formbutton" 
                Text="Generate" onclick="btnGenerate_Click" />
        &nbsp;
            <asp:Button ID="btnDw" runat="server" Text="Download Report" />
        </td>
    </tr>
    <tr>
        <td class="style8" colspan="2">
            <asp:GridView ID="Gridview1" runat="server" AllowPaging="True" 
                                        AllowSorting="True" 
        AutoGenerateColumns="False" BackColor="#2b6ebb" 
                                        BorderColor="#CCCCFF" BorderStyle="None" 
        BorderWidth="1px" CellPadding="3" 
                                        CssClass="Gridview" DataKeyNames="USERID" 
                                        GridLines="Vertical" 
                                        Width="965px" 
        OnPageIndexChanging="Gridview1_PageIndexChanging" 
    OnSorting="Gridview1_Sorting" PageSize="20">
                                        <AlternatingRowStyle BackColor="#DCDCDC" />
                                        <Columns>
                                           
                                      <asp:TemplateField HeaderText="S/N">
                                        <ItemTemplate>
                              
                                                <%#Container.DataItemIndex+1 %>
                           
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                            
                                            <asp:BoundField DataField="NAME_ON_CARD" HeaderText="CUSTOMER NAME" 
                                                 />
                                            
                                            <asp:BoundField DataField="EMAIL" HeaderText="EMAIL" 
                                                 />
                                                  <asp:BoundField DataField="PHONE" HeaderText="PHONE" 
                                                />
                                            
                                            <asp:BoundField DataField="CONTRACT_NO" HeaderText="CONTRACT NO" 
                                                />
                                                  <asp:BoundField DataField="CATEGORY" HeaderText="CATEGORY" 
                                                 />
                                            
                                           <%-- <asp:BoundField DataField="STATUS" HeaderText="STATUS" 
                                                SortExpression="STATUS" />--%>
                                                <asp:BoundField DataField="CREATED_BY" HeaderText="CREATED BY" 
                                                />
                                                
                                                                                     
                                            
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



