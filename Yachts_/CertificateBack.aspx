<%@ Page Title="" Language="C#" MasterPageFile="~/BackstageMaster.Master" AutoEventWireup="true" CodeBehind="CertificateBack.aspx.cs" Inherits="Yachts_.Certificate" %>


<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="Scripts/ckeditor/ckeditor.js"></script>

    <%--<form runat="server">--%>

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


        <asp:Label ID="UploadCertificateTime" runat="server" Visible="False" ForeColor="#009933" class="d-flex justify-content-center"></asp:Label>
        <asp:Button ID="UploadCertificateBtn" runat="server" Text="更新" class="btn btn-info" OnClick="UploadCertificateBtn_Click" />

             <asp:Button ID="CertificateImage" runat="server" Text="新增證照" class="btn btn-info" OnClick="CertificateImage_Click"  />







 <%--   </form>--%>




</asp:Content>
