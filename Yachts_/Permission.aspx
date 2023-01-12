<%@ Page Title="" Language="C#" MasterPageFile="~/backstagemaster.Master" AutoEventWireup="true" CodeBehind="Permission.aspx.cs" Inherits="Yachts_.Permission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <%--  <form class="form" runat="server">--%>




        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" DataKeyNames="id" OnDataBound="GridView1_DataBound" align="center" >
            <Columns>
                <%--<asp:TemplateField HeaderText="編號">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1%>
                    </ItemTemplate>
                </asp:TemplateField>--%>

                <asp:BoundField DataField="Username" HeaderText="使用者名稱" SortExpression="Username" />
                <asp:BoundField DataField="Email" HeaderText="信箱" SortExpression="Email" />

                <%--<asp:TemplateField HeaderText="首頁管理" ShowHeader="False">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>



                <asp:TemplateField HeaderText="遊艇表單管理" ShowHeader="False">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                        <input type="checkbox" id="scales" name="scales" checked="checked">
                        
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="最新消息管理" ShowHeader="False">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="公司資料管理" SortExpression="Rank">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="代理商資料管理" ShowHeader="False">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="帳號權限管理" ShowHeader="False">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>--%>

                <asp:BoundField DataField="initDate" HeaderText="建立日期" SortExpression="initDate" />
                <asp:TemplateField HeaderText="編輯">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "UserUpdate.aspx?id="+Eval("id") %>'>修改</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="刪除" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>



    <%--</form>--%>





</asp:Content>
