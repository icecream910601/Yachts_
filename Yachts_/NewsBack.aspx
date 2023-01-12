<%@ Page Title="" Language="C#" MasterPageFile="~/BackstageMaster.Master" AutoEventWireup="true" CodeBehind="NewsBack.aspx.cs" Inherits="Yachts_.News" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<%--    <form runat="server">--%>

        <%--   新增Headline
   是否置頂
   舊新聞可以刪除--%>

   

        <h6>Date :</h6>

        <%--  <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" OnDayRender="Calendar1_DayRender"></asp:Calendar>--%>

        <asp:TextBox ID="Calendar" runat="server" type="date"></asp:TextBox>

        <h6>Add Headline 新增標題 :</h6>
        <asp:CheckBox ID="CBoxIsTop" runat="server" Text="Top Tag" Width="100%" />
        <asp:TextBox ID="headlineTbox" runat="server" type="text" class="form-control" placeholder="Enter headline text"></asp:TextBox>

        <h6>Add Summary 新增簡介 :</h6>
        <asp:TextBox ID="summary" runat="server" type="text" class="form-control" placeholder="Enter summary" TextMode="MultiLine"></asp:TextBox>

        <h6>Add Content 新增內文 :</h6>
        <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" BasePath="/Scripts/ckeditor/"
            Toolbar="Bold|Italic|Underline|Strike|Subscript|Superscript|-|RemoveFormat
        NumberedList|BulletedList|-|Outdent|Indent|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|-|BidiLtr|BidiRtl
        /
        Styles|Format|Font|FontSize
        TextColor|BGColor
        Link|Image"
            Height="400px">
        </CKEditor:CKEditorControl>


        <h6>Add Cover 新增封面 :</h6>
        <asp:FileUpload ID="imageUpload" runat="server" />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

        </br>
        <asp:Button ID="AddHeadlineBtn" runat="server" Text="送出" class="btn btn-info" OnClick="AddHeadlineBtn_Click" />








   <%-- </form>--%>
</asp:Content>
