<%@ Page Title="" Language="C#" MasterPageFile="~/BackstageMaster.Master" AutoEventWireup="true" CodeBehind="DealersDetailBack.aspx.cs" Inherits="Yachts_.DealersDetailBack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <%--<form id="form1" runat="server">--%>



        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id"  OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting" >
            <Columns>
                <asp:BoundField DataField="Area" HeaderText="地區" SortExpression="Area" />
                <asp:TemplateField HeaderText="照片" SortExpression="Dealerphoto">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/Dealersphoto/"+Eval("Dealerphoto") %>' Width="100px"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Name" HeaderText="公司名稱" SortExpression="Name" />
                <asp:BoundField DataField="Contact" HeaderText="聯絡人" SortExpression="Contact" />
                <asp:BoundField DataField="Address" HeaderText="地址" SortExpression="Address" />
                <asp:BoundField DataField="Tel" HeaderText="電話" SortExpression="Tel" />
                <asp:BoundField DataField="Fax" HeaderText="傳真" SortExpression="Fax" />
                <asp:BoundField DataField="Email" HeaderText="信箱" SortExpression="Email" />
                <asp:BoundField DataField="Link" HeaderText="官網" SortExpression="Link" />
                <asp:BoundField DataField="initDate" HeaderText="建立日期" SortExpression="initDate" />
                 
                    <asp:TemplateField HeaderText="編輯" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Edit" Text="編輯"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="刪除" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <div style="border: 1px solid black; width: 500px/*max-content*/;margin-left:auto;margin-right:auto;margin-top:20px;padding:10px">

            <div>Area地區:<asp:TextBox ID="Area" runat="server" Style="display: block; width: 100%" class="form-control" placeholder="Area"></asp:TextBox></div>
            <br />
            <div>Name公司名稱:<asp:TextBox ID="Name" runat="server" Style="display: block; width: 100%" class="form-control" placeholder="Name"></asp:TextBox></div>
            <br />
            <div>Contact聯絡人:<asp:TextBox ID="Contact" runat="server" Style="display: block; width: 100%" class="form-control" placeholder="Contact"></asp:TextBox></div>
            <br />
            <div>Address地址:<asp:TextBox ID="Address" runat="server" Style="display: block; width: 100%" class="form-control" placeholder="Address"></asp:TextBox></div>
            <br />
            <div>Tel電話:<asp:TextBox ID="Tel" runat="server" Style="display: block; width: 100%" class="form-control" placeholder="Tel"></asp:TextBox></div>
            <br />
            <div>Fax傳真:<asp:TextBox ID="Fax" runat="server" Style="display: block; width: 100%" class="form-control" placeholder="Fax"></asp:TextBox></div>
            <br />
            <div>Email信箱:<asp:TextBox ID="Email" runat="server" Style="display: block; width: 100%" class="form-control" placeholder="Email"></asp:TextBox></div>
            <br />
            <div>Link官網:<asp:TextBox ID="Link" runat="server" Style="display: block; width: 100%" class="form-control" placeholder="Link"></asp:TextBox></div>
            <br />
            <div>Photo相片:<asp:FileUpload ID="FileUpload1" runat="server" Style="display: block; width: 100%"/></div>
            <br />


            <div>
                <asp:Label ID="Label1" runat="server" Text="" class="form-label" ForeColor="#ff0066"></asp:Label>
            </div>
            <br />

            <div style="display:flex;justify-content:center">
                <asp:Button ID="Button1" runat="server" Text="新增" class="btn btn-info" OnClick="Button1_Click" /><input id="Reset1" type="reset" value="重新填寫" class="btn btn-info" />
            </div>
        </div>





<%--    </form>--%>





</asp:Content>
