<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Bookings.aspx.cs" Inherits="Laboration6.Pages.Bookings" %>

    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Möbelbokningar</h1>
    <asp:ValidationSummary ID="ValidationSummary3" runat="server" HeaderText="Fel inträffade."/>
    <asp:Label ID="Label1" runat="server" Text="Ny bokning har lagts till." Visible="false"></asp:Label>
    <asp:Label ID="Label2" runat="server" Text="Bokning har tagits bort" Visible="false"></asp:Label>
    
        <asp:ListView ID="ListView2" runat="server" ItemType="Laboration6.Model.Booking" 
            SelectMethod="BookingListView_GetData"
            InsertMethod="BookingListView_InsertItem"
            DeleteMethod="BookingListView_DeleteItem"
            DataKeyNames="BookingID"
            OnItemInserting="ListView2_ItemInserting"
            InsertItemPosition="FirstItem">

            <LayoutTemplate>
                    <table>
                        <tr>
                            <th>
                                Student
                            </th>
                            <th>
                                Möbel
                            </th>
                            <th>
                                Antal
                            </th>
                            <th>
                                Pris
                            </th>
                           
                        </tr>
     
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </table>
            </LayoutTemplate>
            
            <ItemTemplate>
                    <tr>
                        <td>
                            <%#: Item.Name %>
                        </td>
                        <td>
                            <%#: Item.Description %>
                        </td>
                        <td>
                            <%#: Item.Quantity %>
                        </td>
                        <td>
                            <%#: Item.Price %>
                        </td>
                        <td class="r">
                            <asp:LinkButton ID="LinkButton5" runat="server" CommandName="Delete" CausesValidation="false">Ta bort</asp:LinkButton> 
                        </td>
                    </tr>
            </ItemTemplate>
            
            <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>
                                Bokningar saknas.
                            </td>
                        </tr>
                    </table>
            </EmptyDataTemplate>
            
            <InsertItemTemplate>
                    <tr>
                        <td>
                            <asp:DropDownList ID="DropDownList1" SelectMethod="BookingListView_GetStudents" DataTextField="Name" DataValueField="StudentID" runat="server"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList2" SelectMethod="BookingListView_GetFurniture" DataTextField="Description" DataValueField="PieceOfFurnitureID" runat="server"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="Quantity" runat="server" Text='<%# BindItem.Quantity %>' />
                        </td>
                        <td class="r">
                        </td>
                        <td class="r">    
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Insert" Text="Lägg till" />
                        </td>
                        <td class="r">    
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false" />
                        </td>
                    </tr>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ett antal måste anges." ControlToValidate="Quantity" Text="*" Display="Dynamic"></asp:RequiredFieldValidator> 
                
                </InsertItemTemplate>
             
            </asp:ListView>
</asp:Content>


