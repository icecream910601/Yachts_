<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contactstore.aspx.cs" Inherits="Yachts_.contactstore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>




 <!--表單-->
            <div class="from01">
                <p>
                    Please Enter your contact information<span class="span01">*Required</span>
                </p>
                <br />
                <table>
                    <tr>
                        <td class="from01td01">Name :</td>
                        <td><span>*</span><input type="text" name="textfield" id="textfield" />
                        </td>
                    </tr>
                    <tr>
                        <td class="from01td01">Email :</td>
                        <td><span>*</span><input type="text" name="textfield" id="textfield" /></td>
                    </tr>
                    <tr>
                        <td class="from01td01">Phone :</td>
                        <td><span>*</span><input type="text" name="textfield" id="textfield" /></td>
                    </tr>


                    <tr>
                        <td class="from01td01">Country :</td>
                        <td><span>*</span>
                          <%--  <select name="select" id="select">
                                <option>Annapolis</option>--%>
                               <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Country" DataValueField="id"></asp:DropDownList>
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
                            <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="Type" DataValueField="id"></asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:YachtsConnectionString %>" SelectCommand="SELECT * FROM [Yachts]"></asp:SqlDataSource>
                        </td>
                    </tr>



                    <tr>
                        <td class="from01td01">Comments:</td>
                        <td>
                            <textarea name="textarea" id="textarea" cols="45" rows="5"></textarea></td>
                    </tr>
                    <tr>
                        <td class="from01td01">&nbsp;</td>
                        <td class="f_right"><a href="#">

                            <asp:ImageButton runat="server" type="image" name="ImageButton1" id="ImageButton1" src="images/buttom03.gif" style="border-width: 0px;" Height="25px" OnClick="ImageButton1_Click" />

                      <%--      <img src="images/buttom03.gif" alt="submit" width="59" height="25" /></a></td>--%>
                    </tr>
                </table>
            </div>
            <!--表單-->