<%@ Page Title="" Language="C#" MasterPageFile="~/test.Master" AutoEventWireup="true" CodeBehind="testNews2.aspx.cs" Inherits="Yachts_.testNews2" %>



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
    <div id="crumb"><a href="#">Home</a> >> <a href="#">News </a>>> <a href="#"><span class="on1">News & Events</span></a></div>
    <div class="right">
        <div class="right1">
            <div class="title"><span>News & Events</span></div>

            <!--------------------------------內容開始---------------------------------------------------->
            <div class="box3">
                <h4>
                    <asp:Label ID="Label1" runat="server"></asp:Label></h4>


                <asp:Literal ID="Literal1" runat="server"></asp:Literal>


            </div>




            <!--------------------------------內容結束------------------------------------------------------>
        </div>


    </div>
</asp:Content>

