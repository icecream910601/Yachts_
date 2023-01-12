<%@ Page Title="" Language="C#" MasterPageFile="~/BackstageMaster.Master" AutoEventWireup="true" CodeBehind="CertificateImageBack.aspx.cs" Inherits="Yachts_.CertificateImage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<%--    
    <form id="form1" runat="server">--%>

        <h6>Upload Image :</h6>
        <div class="input-group my-3">
            <asp:FileUpload ID="imageUpload" runat="server" class="btn btn-outline-primary btn-block" AllowMultiple="True" />

            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </br>
            <asp:Button ID="UploadHBtn" runat="server" Text="上傳證照" class="btn btn-info" OnClick="UploadHBtn_Click" />
        </div>

        <h6>Image List :</h6>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="證照" SortExpression="CertificateImage">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/Companyupload/"+Eval("CertificateImage") %>' Width="400px"/>                     
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="initDate" HeaderText="建立日期" SortExpression="initDate" />
                <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="刪除" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>



<%--    </form>--%>



</asp:Content>
