<%@ Page Title="" Language="C#" MasterPageFile="~/test.Master" AutoEventWireup="true" CodeBehind="testNews.aspx.cs" Inherits="Yachts_.testNews" %>

<%@ Register Src="~/UserControl/PageControl.ascx" TagPrefix="uc1" TagName="PageControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- <div class="bannermasks">
        <img src="/images/banner02_masks.png" alt="&quot;&quot;" width="967" height="371" />
    </div>--%>


    <div class="banner">
        <ul>
            <li>
                <img src="/images/newbanner.jpg" alt="Tayana Yachts" /></li>
        </ul>

    </div>


</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="left">
        <div class="left1">
            <p><span>News & Events</span></p>
            <ul>
                <li>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="testNews.aspx">News & Events</asp:HyperLink>
                </li>
            </ul>
        </div>
    </div>
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

    <form id="form1" runat="server">

    <!--------------------------------右邊選單開始---------------------------------------------------->
    <div id="crumb"><a href="#">Home</a> >> <a href="#">News </a>>> <a href="#"><span class="on1">News & Events</span></a></div>
    <div class="right">
        <div class="right1">
            <div class="title"><span>News & Events</span></div>

            <!--------------------------------內容開始---------------------------------------------------->

            <div class="box2_list">
                <ul>

                    <li>
                        <div class="list01">
                            <ul>

                                <li>
 
                                </li>

                                <asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>

                                        <div style="display: flex">

                                            <li>
                                                <div>
                                                    <p>
                                                        <asp:Image ID="Image" runat="server" ImageUrl='<%# "Newsupload/"+Eval("newsImageCover") %>' Width="187px" Height="121px" />
                                                    </p>
                                                </div>
                                            </li>

                                            <div style="display: flex; flex-direction: column">
                                                <div>
                                                    <li><span>
                                                        <asp:Label ID="date" runat="server" Text='<%# Eval("date","{0:yyyy-MM-dd}") %>'></asp:Label></span>
                                                </div>

                                                <div>
                                                    <asp:HyperLink ID="headline" runat="server" Text='<%# Eval("headline") %>' NavigateUrl='<%#Eval("id","testNews2.aspx?id={0}") %>'></asp:HyperLink>
                                                </div>

                                                <div>
                                                    <asp:Label ID="summary" runat="server" Text='<%# Eval("summary") %>'></asp:Label>
                                                </div>

                                            </div>

                                        </div>
                                       
                                    </ItemTemplate>
                                </asp:Repeater>
                         


                            </ul>
                           
                        </div>
                    </li>

                </ul>

                <uc1:PageControl runat="server" ID="PageControl" />

               <%-- <div class="pagination">共<span style="color:red">11</span>筆資料<span class="disabled">上一頁</span><span class="current">1</span><a href="testNews.aspx?page=2">2</a><a href="testNews.aspx?page=3">3</a><a href="testNews.aspx?page=2">下一頁</a></div>--%>
                   

                  <%-- <div class="pagenumber">| <span>1</span> | <a href="#">2</a> | <a href="#">3</a> | <a href="#">4</a> | <a href="#">5</a> |  <a href="#">Next</a>  <a href="#">LastPage</a></div>
                <div class="pagenumber1">Items：<span>89</span>  |  Pages：<span>1/9</span></div>--%>
            </div>

 
            <!--------------------------------內容結束------------------------------------------------------>
        </div>
        
    </div>

    <!--------------------------------右邊選單結束---------------------------------------------------->
    

 

    </form>
    

 

</asp:Content>
