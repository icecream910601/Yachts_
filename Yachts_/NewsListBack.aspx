<%@ Page Title="" Language="C#" MasterPageFile="~/BackstageMaster.Master" AutoEventWireup="true" CodeBehind="NewsListBack.aspx.cs" Inherits="Yachts_.NewsListBack" %>

<%@ Register Src="~/UserControl/PageControl.ascx" TagPrefix="uc1" TagName="PageControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
   


        <div style="padding-left: 60px; margin-bottom: 20px">
            <asp:Button ID="AddNews" runat="server" Text="新增新聞" class="btn btn-info" OnClick="AddNews_Click" />
        </div>


        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>

                <div style="display: flex; justify-content: space-around; width: 90%; margin-bottom: 20px; border: 1px solid; align-items: center">

                    <div style="width: 20%">
                        <asp:Image ID="Image" runat="server" ImageUrl='<%# "Newsupload/"+Eval("newsImageCover") %>' Width="200px" Height="150px" />
                    </div>

                    <div style="display: flex; flex-direction: column; width: 50%">
                        <asp:Label ID="date" runat="server" Text='<%# Eval("date","{0:yyyy-MM-dd}") %>'></asp:Label>

                        <asp:Label ID="headline" runat="server" Text='<%# Eval("headline") %>'></asp:Label>
                        <asp:Label ID="summary" runat="server" Text='<%# Eval("summary") %>'></asp:Label>
                    </div>


                    <div style="width: 20%">



                        <asp:HyperLink ID="Edit" runat="server" NavigateUrl='<%# "NewsBack.aspx?id="+Eval("id") %>'>編輯</asp:HyperLink>


                        <asp:HyperLink ID="Delete" runat="server" NavigateUrl='<%# "NewsListBack.aspx?did="+Eval("id") %>'>刪除</asp:HyperLink>

                        <%--<asp:CheckBox ID="Istop" runat="server" Text="置頂" Checked='<%#Eval("isTop") %>' />--%>
                        <asp:Label ID="Istop" runat="server" Text='<%#Eval("status") %>' ForeColor="Red"></asp:Label>

                    </div>

                </div>


            </ItemTemplate>
        </asp:Repeater>

        <uc1:pagecontrol runat="server" id="PageControl" />




</asp:Content>
