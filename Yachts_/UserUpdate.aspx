<%@ Page Title="" Language="C#" MasterPageFile="~/backstagemaster.Master" AutoEventWireup="true" CodeBehind="UserUpdate.aspx.cs" Inherits="Yachts_.UserUpdate" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div style="display: flex; flex-direction: column; line-height: 30px; margin-bottom: 20px; border: 1px solid black; width: 500px; padding: 10px;margin:auto " >


        <div >
            Username名稱:<asp:TextBox ID="Username" runat="server" placeholder="Username" class="form-control" Height="30px" Width="200px" Style="display: block; width: 100%"></asp:TextBox>
        </div>

        <%--  <div style="display:flex;margin:5px">
                信箱:<asp:TextBox ID="Email" runat="server"  placeholder="Email" class="form-control" Height="30px" Width="200px"></asp:TextBox>
            </div>--%>
        <div>
            Email信箱:<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        </div>

        <div >
            Password密碼:<asp:TextBox ID="Password" runat="server" placeholder="請輸入6-10碼Password" class="form-control" Height="30px" Width="200px" Style="display: block; width: 100%" MaxLength="10" TextMode="Password"></asp:TextBox>
        </div>

        <div >
            性別:
                <asp:DropDownList ID="Sex" runat="server">
                    <%--<asp:ListItem Value="0">請選擇</asp:ListItem>--%>
                    <asp:ListItem Selected="True">男</asp:ListItem>
                    <asp:ListItem>女</asp:ListItem>
                </asp:DropDownList>
        </div>

        <div >
            Birthdate生日:<asp:TextBox ID="Birthdate" runat="server" placeholder="yyyy-mm-dd" class="form-control" Height="30px" Width="200px" Style="display: block; width: 100%"></asp:TextBox>
        </div>

        <div >
            Phone電話:<asp:TextBox ID="Phone" runat="server" placeholder="Phone" class="form-control" Height="30px" Width="200px" Style="display: block; width: 100%"></asp:TextBox>
        </div>

        <div >
            Address地址:<asp:TextBox ID="Address" runat="server" placeholder="Address" class="form-control" Height="30px" Width="200px" Style="display: block; width: 100%"></asp:TextBox>
        </div>
        <asp:Label ID="Label1" runat="server" Text="" class="form-label" ForeColor="#ff0066"></asp:Label>

        <div>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal">
                <%--<asp:ListItem  >首頁</asp:ListItem>--%>
                <asp:ListItem>遊艇清單</asp:ListItem>
                <asp:ListItem>最新消息</asp:ListItem>
                <asp:ListItem>公司資料</asp:ListItem>
                <asp:ListItem>代理商資料</asp:ListItem>
                <asp:ListItem>帳號權限</asp:ListItem>
            </asp:CheckBoxList>
        </div>

        <div style="margin-top: 10px; display: flex; justify-content: center">
            <asp:Button ID="Button2" runat="server" Text="修改" class="btn btn-info" OnClick="Button1_Click" />
            <input id="Reset1" type="reset" value="重新填寫" class="btn btn-info" />
        </div>


    </div>



</asp:Content>
