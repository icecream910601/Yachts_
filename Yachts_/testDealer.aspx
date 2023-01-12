<%@ Page Title="" Language="C#" MasterPageFile="~/test.Master" AutoEventWireup="true" CodeBehind="testDealer.aspx.cs" Inherits="Yachts_.test2" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <%--   <div class="bannermasks">
        <img src="/images/DEALERS.jpg" alt="&quot;&quot;" width="967" height="371" />
    </div>--%>

         <div class="banner">
            <ul>
                <li>
                    <img src="/images/DEALERS.jpg" alt="Tayana Yachts" /></li>
            </ul>

        </div>



</asp:Content>





<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="left">

        <div class="left1">
            <p><span>DEALERS</span></p>
            <ul>

                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <li>
                        <asp:HyperLink ID="HyperLink1" runat="server" Text='<%#Eval("Country") %>' NavigateUrl='<%#Eval("id","testDealer.aspx?countryid={0}") %>'>HyperLink</asp:HyperLink> <%--文字是綁死的--%>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>

            </ul>
        </div>
    </div>
</asp:Content>





<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div id="crumb"><a href="#">Home</a> >> <a href="#">Dealers </a>>> <asp:HyperLink ID="HyperLink5" runat="server" > </asp:HyperLink></div>  <%--這邊不能綁死 要根據事件去跑--%>
    <div class="right">
        <div class="right1">
            <div class="title">
                <asp:Label ID="Label1" runat="server" style="height:20px"></asp:Label></div>

            <!--------------------------------內容開始---------------------------------------------------->
            <div class="box2_list">
                <ul>

                    <li>
                        <div class="list02">
                            <ul>

                                <asp:Repeater ID="Repeater2" runat="server">
                                    <ItemTemplate>


                                        <div style="display: flex">
                                            <li class="list02li">
                                                <div>
                                                    <p>
                                                        <asp:Image ID="Dealerphoto" runat="server" ImageUrl='<%# "Dealersphoto/"+Eval("Dealerphoto") %>' Width="209px" Height="148px" />
                                                    </p>
                                                </div>
                                            </li>

                                            <div style="display: flex;flex-direction:column">
                                                <div>
                                                    <li><span>
                                                        <asp:Label ID="Area" runat="server" Text='<%# Eval("Area") %>'></asp:Label></span></li>
                                                </div>

                                                <div>
                                                    <asp:Label ID="Contact" runat="server" Text='<%# Eval("Contact") %>'></asp:Label>
                                                </div>

                                                <div>
                                                    <asp:Label ID="Address" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                                                </div>

                                                <div>
                                                    <asp:Label ID="Tel" runat="server" Text='<%# Eval("Tel") %>'></asp:Label>
                                                </div>

                                                <div>
                                                    <asp:Label ID="Fax" runat="server" Text='<%# Eval("Fax") %>'></asp:Label>
                                                </div>

                                                <div>
                                                    <asp:Label ID="Email" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                                </div>

                                                <div>
                                                    <asp:Label ID="Link" runat="server" Text='<%# Eval("Link") %>'></asp:Label>
                                                </div>

                                                <div>
                                                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#Eval("Link") %>' Target="_blank"></asp:HyperLink>
                                                </div>

                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </ul>
                        </div>
                    </li>


                </ul>

             <%--   <div class="pagenumber">| <span>1</span> | <a href="#">2</a> | <a href="#">3</a> | <a href="#">4</a> | <a href="#">5</a> |  <a href="#">Next</a>  <a href="#">LastPage</a></div>
                <div class="pagenumber1">Items：<span>89</span>  |  Pages：<span>1/9</span></div>--%>


            </div>

            <!--------------------------------內容結束------------------------------------------------------>
        </div>
    </div>
</asp:Content>


