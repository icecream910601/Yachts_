<%@ Page Title="" Language="C#" MasterPageFile="~/BackstageMaster.Master" AutoEventWireup="true" CodeBehind="YachtsPhotoBack.aspx.cs" Inherits="Yachts_.YachtsPhotoBack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h6>Upload Photo :</h6>
    <div class="input-group my-3">
        <asp:FileUpload ID="imageUpload" runat="server" class="btn btn-outline-primary btn-block" AllowMultiple="True" />

        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </br>
        <asp:Button ID="UploadHBtn" runat="server" Text="上傳照片" class="btn btn-info" OnClick="UploadHBtn_Click" />
    </div>

    <h6>Photo List :</h6>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound1"  >

        <Columns>

            <asp:TemplateField HeaderText="封面">
                <ItemTemplate>
                    <asp:RadioButton ID="RadioButton1" OnCheckedChanged="rbSelector_CheckedChanged" AutoPostBack="true" GroupName="Apply" runat="server"  SelectedValue='<%# Eval("isCover") %>' ></asp:RadioButton>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText=" 相片" SortExpression="CertificateImage">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/Yachtsupload/"+Eval("yachts_photo") %>' Width="400px" />
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


    <asp:Button ID="Button1" runat="server" Text="確認封面照面" OnClick="Button1_Click" />


</asp:Content>
