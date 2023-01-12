<%@ Page Title="" Language="C#" MasterPageFile="~/test.Master" AutoEventWireup="true" CodeBehind="testContact.aspx.cs" Inherits="Yachts_.testContact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <div class="bannermasks">
        <img src="/images/contact.jpg" alt="&quot;&quot;" width="967" height="371" />
    </div>--%>

    <div class="banner">
        <ul>
            <li>
                <img src="/images/contact.jpg" alt="Tayana Yachts" /></li>
        </ul>

    </div>


</asp:Content>





<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="left">

        <div class="left1">
            <p><span>CONTACT</span></p>
            <ul>
                <li>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="testContact.aspx">CONTACT</asp:HyperLink></li>

            </ul>
        </div>
    </div>
</asp:Content>





<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">


    <form id="form1" runat="server">


        <!--------------------------------右邊選單開始---------------------------------------------------->
        <div id="crumb"><a href="#">Home</a> >> <a href="#"><span class="on1">Contact</span></a></div>
        <div class="right">
            <div class="right1">
                <div class="title"><span>Contact</span></div>

                <!--------------------------------內容開始---------------------------------------------------->
                <!--表單-->
                <div class="from01">
                    <p>
                        Please Enter your contact information<span class="span01">*Required</span>
                    </p>
                    <br />
                    <table>
                        <tr>
                            <td class="from01td01">Name :</td>
                            <td><span>*</span><%--<input type="text" name="textfield" id="textfield" />--%>
                                <asp:TextBox runat="server" name="Name" type="text" ID="Name" class="{validate:{required:true, messages:{required:'Required'}}}" Style="width: 250px;" required="" aria-required="true" oninput="setCustomValidity('');" oninvalid="setCustomValidity('Required!')" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="from01td01">Email :</td>
                            <td><span>*</span><%--<input type="text" name="textfield" id="textfield" />--%>
                                <asp:TextBox runat="server" name="Email" type="text" ID="Email" class="{validate:{required:true, email:true, messages:{required:'Required', email:'Please check the E-mail format is correct'}}}" Style="width: 250px;" required="" aria-required="true" oninput="setCustomValidity('');" oninvalid="setCustomValidity('Required!')" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="from01td01">Phone :</td>
                            <td><span>*</span><%--<input type="text" name="textfield" id="textfield" />--%>
                                 <asp:TextBox runat="server" name="Phone" type="text" ID="Phone" class="{validate:{required:true, messages:{required:'Required'}}}" Style="width: 250px;" required="" aria-required="true" oninput="setCustomValidity('');" oninvalid="setCustomValidity('Required!')" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>


                        <tr>
                            <td class="from01td01">Country :</td>
                            <td><span>*</span>
                                <%--  <select name="select" id="select">
                                <option>Annapolis</option>--%>
                                <asp:DropDownList ID="Country" runat="server" DataSourceID="SqlDataSource1" DataTextField="Country" DataValueField="id"></asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:YachtsConnectionString %>" SelectCommand="SELECT * FROM [Country]"></asp:SqlDataSource>
                                <%--   </select>--%></td>
                        </tr>


                        <tr>
                            <td colspan="2"><span>*</span>Brochure of interest  *Which Brochure would you like to view?</td>
                        </tr>



                        <tr>
                            <td class="from01td01">&nbsp;</td>
                            <td>
                                <%--   <select name="select" id="select">
                                <option>Dynasty 72 </option>
                            </select>--%>
                                <asp:DropDownList ID="Type" runat="server" DataSourceID="SqlDataSource2" DataTextField="Type" DataValueField="id"></asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:YachtsConnectionString %>" SelectCommand="SELECT * FROM [Yachts]"></asp:SqlDataSource>
                            </td>
                        </tr>



                        <tr>
                            <td class="from01td01">Comments:</td>
                            <td>
                               <%-- <textarea name="textarea" id="textarea" cols="45" rows="5"></textarea>--%>
                                 <asp:TextBox runat="server" TextMode="MultiLine" name="Comments" Rows="2" cols="20" ID="Comments" Style="height: 150px; width: 330px;" MaxLength="500"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="from01td01">&nbsp;</td>
                            <td class="f_right"><a href="#">

                                <asp:ImageButton runat="server" type="image" name="ImageButton1" ID="ImageButton1" src="images/buttom03.gif" Style="border-width: 0px;" Height="25px" OnClick="ImageButton1_Click" />

                                <%--      <img src="images/buttom03.gif" alt="submit" width="59" height="25" /></a></td>--%>
                        </tr>
                    </table>
                </div>
                <!--表單-->


                <div class="box1">
                    <span class="span02">Contact with us</span><br />
                    Thanks for your enjoying our web site as an introduction to the Tayana world and our range of yachts.
As all the designs in our range are semi-custom built, we are glad to offer a personal service to all our potential customers. 
If you have any questions about our yachts or would like to take your interest a stage further, please feel free to contact us.
                </div>

                <div class="list03">
                    <p>
                        <span>TAYANA HEAD OFFICE</span><br />
                        NO.60 Haichien Rd. Chungmen Village Linyuan Kaohsiung Hsien 832 Taiwan R.O.C<br />
                        tel. +886(7)641 2422<br />
                        fax. +886(7)642 3193<br />
                        info@tayanaworld.com<br />
                    </p>
                </div>


                <div class="list03">
                    <p>
                        <span>SALES DEPT.</span><br />
                        +886(7)641 2422  ATTEN. Mr.Basil Lin<br />
                        <br />
                    </p>
                </div>

                <div class="box4">
                    <h4>Location</h4>
                    <p>
                        <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m12!1m3!1d35040.81553613824!2d120.30272134295289!3d22.6085564352614!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!5e0!3m2!1szh-TW!2stw!4v1666602110691!5m2!1szh-TW!2stw" width="600" height="450" style="border: 0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
                    </p>

                </div>






                <!--------------------------------內容結束------------------------------------------------------>
            </div>
        </div>

        <!--------------------------------右邊選單結束---------------------------------------------------->




    </form>




</asp:Content>
