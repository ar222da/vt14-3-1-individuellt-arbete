<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Studenter.aspx.cs" Inherits="Laboration6.WebForm2" %>
    
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Studenter</h1>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Fel inträffade. Korrigera det som är fel och försök igen."/>
        <asp:Label ID="Label1" runat="server" Text="Ny student har lagts till." Visible="false"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Studentuppgifter har redigerats." Visible="false"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="Student har tagits bort" Visible="false"></asp:Label>

        <asp:ListView ID="ListView1" runat="server" ItemType="Laboration6.Model.Student" 
            SelectMethod="StudentListView_GetData"
            InsertMethod="StudentListView_InsertItem"
            UpdateMethod="StudentListView_UpdateItem"
            DeleteMethod="StudentListView_DeleteItem"
            DataKeyNames="StudentID"
            InsertItemPosition="FirstItem">

            <LayoutTemplate>
                    <table>
                        <tr>
                            <th>
                                Namn
                            </th>
                            <th>
                                Adress
                            </th>
                            <th>
                                Postnummer
                            </th>
                            <th>
                                Ort
                            </th>
                            <th>
                                Telefon
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
                            <%#: Item.Address %>
                        </td>
                        <td>
                            <%#: Item.PostalCode %>
                        </td>
                        <td>
                            <%#: Item.PostalAddress %>
                        </td>
                        <td>
                            <%#: Item.Telephone %>
                        </td>
                        <td class="r">
                            <asp:LinkButton runat="server" Text="Bokningar" PostBackUrl ='<%# "~/Pages/Bookings.aspx?FileName=" + Item.StudentID %>'></asp:LinkButton>
                            <asp:LinkButton runat="server" CommandName="Delete" CausesValidation="false">Ta bort</asp:LinkButton> 
                            <asp:LinkButton runat="server" CommandName="Edit" CausesValidation="true">Redigera</asp:LinkButton>   
                        </td>
                    </tr>
            </ItemTemplate>
            
            <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>
                                Studenter saknas.
                            </td>
                        </tr>
                    </table>
            </EmptyDataTemplate>
    
             <InsertItemTemplate>
                    <tr>
                        <td>
                            <asp:TextBox ID="Name" runat="server" Text='<%# BindItem.Name %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Address" runat="server" Text='<%# BindItem.Address %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="PostalCode" runat="server" Text='<%# BindItem.PostalCode %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="PostalAddress" runat="server" Text='<%# BindItem.PostalAddress %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Telephone" runat="server" Text='<%# BindItem.Telephone %>' />
                        </td>

                        <td class="r">
                            <asp:LinkButton runat="server" CommandName="Insert" Text="Lägg till" />
                            <asp:LinkButton runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false" />
                        </td>
                    </tr>
                <asp:RequiredFieldValidator ValidationGroup="insert" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ett namn måste anges." ControlToValidate="Name" Text="*" Display="Dynamic"></asp:RequiredFieldValidator> 
                <asp:RequiredFieldValidator ValidationGroup="insert" ID="RequiredFieldValidator2" runat="server" ErrorMessage="En adress måste anges." ControlToValidate="Address" Text="*" Display="Dynamic"></asp:RequiredFieldValidator> 
                <asp:RequiredFieldValidator ValidationGroup="insert" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ett postnummer måste anges." ControlToValidate="PostalCode" Text="*" Display="Dynamic"></asp:RequiredFieldValidator> 
                <asp:RequiredFieldValidator ValidationGroup="insert" ID="RequiredFieldValidator4" runat="server" ErrorMessage="En ort måste anges." ControlToValidate="PostalAddress" Text="*" Display="Dynamic"></asp:RequiredFieldValidator> 
                <asp:RequiredFieldValidator ValidationGroup="insert" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Ett telefonnummer måste anges." ControlToValidate="Telephone" Text="*" Display="Dynamic"></asp:RequiredFieldValidator> 
                
                </InsertItemTemplate>
                <EditItemTemplate>
                    <tr>
                        <td>
                            <asp:TextBox ID="Name" runat="server" Text='<%# BindItem.Name %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Address" runat="server" Text='<%# BindItem.Address %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="PostalCode" runat="server" Text='<%# BindItem.PostalCode %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="PostalAddress" runat="server" Text='<%# BindItem.PostalAddress %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Telephone" runat="server" Text='<%# BindItem.Telephone %>' />
                        </td>
                        <td class="r">
                            <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Update" Text="Spara" />
                            <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                        </td>
                    </tr>
                <asp:RequiredFieldValidator ValidationGroup="edit" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ett namn måste anges." ControlToValidate="Name" Text="*" Display="Dynamic"></asp:RequiredFieldValidator> 
                <asp:RequiredFieldValidator ValidationGroup="edit" ID="RequiredFieldValidator2" runat="server" ErrorMessage="En adress måste anges." ControlToValidate="Address" Text="*" Display="Dynamic"></asp:RequiredFieldValidator> 
                <asp:RequiredFieldValidator ValidationGroup="edit" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ett postnummer måste anges." ControlToValidate="PostalCode" Text="*" Display="Dynamic"></asp:RequiredFieldValidator> 
                <asp:RequiredFieldValidator ValidationGroup="edit" ID="RequiredFieldValidator4" runat="server" ErrorMessage="En ort måste anges." ControlToValidate="PostalAddress" Text="*" Display="Dynamic"></asp:RequiredFieldValidator> 
                <asp:RequiredFieldValidator ValidationGroup="edit" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Ett telefonnummer måste anges." ControlToValidate="Telephone" Text="*" Display="Dynamic"></asp:RequiredFieldValidator> 
                
                </EditItemTemplate>
            </asp:ListView>
</asp:Content>
