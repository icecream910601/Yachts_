<%@ Page Title="" Language="C#" MasterPageFile="~/test.Master" AutoEventWireup="true" CodeBehind="testYachts.aspx.cs" Inherits="Yachts_.testYachts" %>





<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--遮罩-->

    <div class="bannermasks">
        <img src="/images/banner01_masks.png" alt="&quot;&quot;" />
    </div>
    <!--遮罩結束-->

    <div class="banner">
        <div id="gallery" class="ad-gallery">
            <div class="ad-image-wrapper">
            </div>
            <div class="ad-controls" style="display: none">
            </div>
            <div class="ad-nav">
                <div class="ad-back" style="opacity: 0.6;"></div>
                <div class="ad-thumbs">
                    <ul class="ad-thumb-list" >
                        
                        <asp:Literal ID="Banner" runat="server"></asp:Literal>
                        <%--<li>
                            <a href="/images/test1.jpg">
                                <img src="/images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="/images/test002.jpg">
                                <img src="/images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="/images/test002.jpg">
                                <img src="/images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="/images/test002.jpg">
                                <img src="/images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="/images/test002.jpg">
                                <img src="/images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="/images/test002.jpg">
                                <img src="/images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="/images/test002.jpg">
                                <img src="/images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="/images/test002.jpg">
                                <img src="/images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="/images/test002.jpg">
                                <img src="/images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="/images/test002.jpg">
                                <img src="/images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="/images/test002.jpg">
                                <img src="/images/pit003.jpg">
                            </a>
                        </li>--%>
                    </ul>
                </div>
                <div class="ad-forward" style="opacity: 0.6;"></div>
            </div>
        </div>
    </div>
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="left">

        <div class="left1">
            <p><span>Yachts</span></p>
            <ul>

                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%#Eval("Type") %>' NavigateUrl='<%#Eval("id","testYachts.aspx?yachtsid={0}") %>'>HyperLink</asp:HyperLink>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>

            </ul>
        </div>
    </div>
</asp:Content>








<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <form runat="server">

        <!--------------------------------右邊選單開始---------------------------------------------------->
        <div id="crumb"><a href="#">Home</a> >> <a href="#">Yachts</a> >>
            <asp:HyperLink ID="HyperLink2" runat="server"></asp:HyperLink></div>
        <div class="right">
            <div class="right1">
                <div class="title">
                    <asp:Label ID="Label2" runat="server"></asp:Label></div>




                <!--------------------------------內容開始---------------------------------------------------->

                <%--      <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" TEXT-DECORATION="none" CssClass="menu_yli01">  Overview   |</asp:LinkButton>
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" TEXT-DECORATION="none"CssClass="menu_yli02">  Layout & deck plan   |</asp:LinkButton>
            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" TEXT-DECORATION="none"CssClass="menu_yli03">  Specification  </asp:LinkButton>--%>

                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" TEXT-DECORATION="none" >  Overview   |</asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" TEXT-DECORATION="none" >  Layout & deck plan   |</asp:LinkButton>
                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" TEXT-DECORATION="none" >  Specification  </asp:LinkButton>




                <!--次選單-->
                <%--     <div class="menu_y">
                <ul>
                    <li class="menu_y00">YACHTS</li>
                    <li><a class="menu_yli01" href="#">Interior</a></li>
                    <li><a class="menu_yli02" href="#">Layout & deck plan</a></li>
                    <li><a class="menu_yli03" href="#">Specification</a></li>
                </ul>
            </div>--%>
                <!--次選單-->

                <div class="box1">
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

                </div>
              <%--  <asp:Label ID="Label1" runat="server" Text="Overview" Visible="false"></asp:Label>--%>


            </div>
            <%--<p class="topbuttom"><img src="images/top.gif" alt="top" /></p>--%>


            <asp:Panel ID="Panel1" runat="server">
                <!--下載開始-->
<div class="downloads">
<p><img src="images/downloads.gif" alt="&quot;&quot;" /></p>
<ul>
<li> <asp:HyperLink ID="HyperLink1" runat="server"  target="_blank"></asp:HyperLink></li>
    <%--不是girdview所以不要繫結跟Eval--%>
                    


    
<%--    
    Text='<%# Eval("OverviewDownload") %>' NavigateUrl='<%# "~/Yachtsupload/"+Eval("OverviewDownload") %>'--%>
<%--    href="Yachtsupload/ch2.pdf"--%>


</ul> 
 </div>
<!--下載結束-->
 </asp:Panel>

            <!--------------------------------內容結束------------------------------------------------------>
        </div>


        <!--------------------------------右邊選單結束---------------------------------------------------->

    </form>
</asp:Content>
