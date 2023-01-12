<%@ Page Title="" Language="C#" MasterPageFile="~/FrontdeskMaster.Master" AutoEventWireup="true" CodeBehind="Dealers1stversion.aspx.cs" Inherits="Yachts_.Dealers" %>


<%--圖片--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div style="padding-left: 20px">
        <asp:Image ID="Image1" runat="server" src="/images/DEALERS.jpg" alt="&quot;&quot;" Width="967" Height="371" />
    </div>
</asp:Content>



<%--左選單--%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server"></asp:Label>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:YachtsConnectionString %>" SelectCommand="SELECT * FROM [Country]"></asp:SqlDataSource>
</asp:Content>



<%--右邊內容--%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <%-- HyperLink--%>
    <div id="crumb">
        <a href="#">Home</a> >> <a href="#">Dealers </a>>> <a href="#"><span class="on1">
            <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink></span></a>
    </div>

    <%-- Label--%>
    <div class="right">
        <div class="right1">
            <div class="title">
                <span>
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </span>
            </div>


            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>

                    <div class="box2_list">
                        <ul>
                            <div style="display: flex; margin: 10PX">
                                <asp:Image ID="Dealerphoto" runat="server" ImageUrl='<%# "Dealersphoto/"+Eval("Dealerphoto") %>' Width="209px" />

                                <div style="display: flex; flex-direction: column; margin: 10PX">
                                    <asp:Label ID="Area" runat="server" Text='<%# Eval("Area") %>'></asp:Label>
                                    <asp:Label ID="Contact" runat="server" Text='<%# Eval("Contact") %>'></asp:Label>
                                    <asp:Label ID="Address" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                                    <asp:Label ID="Tel" runat="server" Text='<%# Eval("Tel") %>'></asp:Label>
                                    <asp:Label ID="Fax" runat="server" Text='<%# Eval("Fax") %>'></asp:Label>
                                    <asp:Label ID="Email" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                    <asp:Label ID="Link" runat="server" Text='<%# Eval("Link") %>'></asp:Label>
                                </div>
                            </div>
                        </ul>
                </ItemTemplate>
            </asp:Repeater>

        </div>
    </div>
</asp:Content>









