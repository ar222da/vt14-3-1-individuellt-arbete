<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Möbler.aspx.cs" Inherits="Laboration6.WebForm3" %>

    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Möbler</h1>
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="Fel inträffade. Korrigera det som är fel och försök igen."/>
        <asp:Label ID="Label1" runat="server" Text="Ny möbel har lagts till." Visible="false"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Möbeluppgifter har redigerats." Visible="false"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="Möbel har tagits bort" Visible="false"></asp:Label>
        <asp:ListView ID="ListView2" runat="server" ItemType="Laboration6.Model.PieceOfFurniture" 
            SelectMethod="FurnitureListView_GetData"
            InsertMethod="FurnitureListView_InsertItem"
            UpdateMethod="FurnitureListView_UpdateItem"
            DeleteMethod="FurnitureListView_DeleteItem"
            DataKeyNames="PieceOfFurnitureID"
            InsertItemPosition="FirstItem">

            <LayoutTemplate>
                    <table>
                        <tr>
                            <th>
                                Beskrivning
                            </th>
                            <th>
                                Pris
                            </th>
                            <th>
                                Inköpspris
                            </th>
                            <th>
                                Antal
                            </th>
                           
                        </tr>
     
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </table>
            </LayoutTemplate>
            
            <ItemTemplate>
                    <tr>
                        <td>
                            <%#: Item.Description %>
                        </td>
                        <td>
                            <%#: Item.Price %>
                        </td>
                        <td>
                            <%#: Item.BuyingPrice %>
                        </td>
                        <td>
                            <%#: Item.Quantity %>
                        </td>
                        <td class="r">
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" CausesValidation="false">Ta bort</asp:LinkButton> 
                            <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Edit" CausesValidation="true">Redigera</asp:LinkButton>   
                        </td>
                    </tr>
            </ItemTemplate>
            
            <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>
                                Möbler saknas.
                            </td>
                        </tr>
                    </table>
            </EmptyDataTemplate>
    
             <InsertItemTemplate>
                    <tr>
                        <td>
                            <asp:TextBox ID="Description" runat="server" Text='<%# BindItem.Description %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Price" runat="server" Text='<%# BindItem.Price %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="BuyingPrice" runat="server" Text='<%# BindItem.BuyingPrice %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Quantity" runat="server" Text='<%# BindItem.Quantity %>' />
                        </td>
                        <td class="r">
                            <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Insert" Text="Lägg till" />
                            <asp:LinkButton ID="LinkButton5" runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false" />
                        </td>
                    </tr>
                <asp:RequiredFieldValidator ValidationGroup="insert" ID="RequiredFieldValidator1" runat="server" ErrorMessage="En beskrivning måste anges." ControlToValidate="Description" Text="*" Display="Dynamic"></asp:RequiredFieldValidator> 
                <asp:RequiredFieldValidator ValidationGroup="insert" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ett pris måste anges." ControlToValidate="Price" Text="*" Display="Dynamic"></asp:RequiredFieldValidator> 
                <asp:RequiredFieldValidator ValidationGroup="insert" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ett inköpspris måste anges." ControlToValidate="BuyingPrice" Text="*" Display="Dynamic"></asp:RequiredFieldValidator> 
                <asp:RequiredFieldValidator ValidationGroup="insert" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Ett antal måste anges." ControlToValidate="Quantity" Text="*" Display="Dynamic"></asp:RequiredFieldValidator> 
                
                </InsertItemTemplate>
                <EditItemTemplate>
                    <tr>
                        <td>
                            <asp:TextBox ID="Description" runat="server" Text='<%# BindItem.Description %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Price" runat="server" Text='<%# BindItem.Price %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="BuyingPrice" runat="server" Text='<%# BindItem.BuyingPrice %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Quantity" runat="server" Text='<%# BindItem.Quantity %>' />
                        </td>
                        <td class="r">
                            <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Update" Text="Spara" />
                            <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                        </td>
                    </tr>
                <asp:RequiredFieldValidator ValidationGroup="edit" ID="RequiredFieldValidator1" runat="server" ErrorMessage="En beskrivning måste anges." ControlToValidate="Description" Text="*" Display="Dynamic"></asp:RequiredFieldValidator> 
                <asp:RequiredFieldValidator ValidationGroup="edit" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ett pris måste anges." ControlToValidate="Price" Text="*" Display="Dynamic"></asp:RequiredFieldValidator> 
                <asp:RequiredFieldValidator ValidationGroup="edit" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ett inköpspris måste anges." ControlToValidate="BuyingPrice" Text="*" Display="Dynamic"></asp:RequiredFieldValidator> 
                <asp:RequiredFieldValidator ValidationGroup="edit" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Ett antal måste anges." ControlToValidate="Quantity" Text="*" Display="Dynamic"></asp:RequiredFieldValidator> 
                

                </EditItemTemplate>
            </asp:ListView>
</asp:Content>
