<%@ Page Title="" Language="C#" MasterPageFile="~/BackstageMaster.Master" AutoEventWireup="true" CodeBehind="AboutUsBack.aspx.cs" Inherits="Yachts_.test" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<%--    <form runat="server">--%>

        <h6>Content :</h6>
        <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" BasePath="/Scripts/ckeditor/"
            Toolbar="Bold|Italic|Underline|Strike|Subscript|Superscript|-|RemoveFormat
        NumberedList|BulletedList|-|Outdent|Indent|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|-|BidiLtr|BidiRtl
        /
        Styles|Format|Font|FontSize
        TextColor|BGColor
        Link|Image"
            Height="400px">
        </CKEditor:CKEditorControl>



        <%--        <asp:Literal ID="Literal1" runat="server"></asp:Literal>--%>


        <asp:Label ID="UploadAboutUsTime" runat="server" Visible="False" ForeColor="#009933" class="d-flex justify-content-center"></asp:Label>
        <asp:Button ID="UploadAboutUsBtn" runat="server" Text="更新" class="btn btn-info" OnClick="UploadAboutUsBtn_Click" />



<%--    </form>--%>
</asp:Content>

