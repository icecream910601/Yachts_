<%@ Page Title="" Language="C#" MasterPageFile="~/test.Master" AutoEventWireup="true" CodeBehind="testCompany.aspx.cs" Inherits="Yachts_.testCompany" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <%--   <div class="bannermasks">
        <img src="/images/company.jpg" alt="&quot;&quot;" width="967" height="371" />
    </div>--%>

       <div class="banner">
            <ul>
                <li>
                    <img src="/images/company.jpg" alt="Tayana Yachts" /></li>
            </ul>

        </div>



</asp:Content>





<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="left">

        <div class="left1">
            <p><span>COMPANY</span></p>
            <ul>
                <li> <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="testCompany.aspx">About Us</asp:HyperLink></li>
              
                <li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="testCompany2.aspx">Certificate</asp:HyperLink></li>
            </ul>
        </div>
    </div>
</asp:Content>





<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div id="crumb"><a href="#">Home</a> >> <a href="#">Company </a>>> <a href="#"><span class="on1">About Us</span></a></div>
    <div class="right">
        <div class="right1">
            <div class="title"><span>About Us</span></div>

  
<!--------------------------------內容開始----------------------------------------------------> 
<div class="box3">
<h4>The Luxury Tayana 48 Pilothouse Lavish Woodwork Is Among</h4>

  
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    

</div>




<!--------------------------------內容結束------------------------------------------------------> 
</div>


    </div>
</asp:Content>
