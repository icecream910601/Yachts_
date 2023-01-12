<%@ Page Title="" Language="C#" MasterPageFile="~/BackstageMaster.Master" AutoEventWireup="true" CodeBehind="YachtsOverview.aspx.cs" Inherits="Yachts_.YatchsDetailBack" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <%--<form id="form1" runat="server">--%>



        <%--    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "YachtsOverview.aspx?yatchid="+Eval("id") %>'>Overview</asp:HyperLink>    
        |
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "YachtsLayout.aspx?yatchid="+Eval("id")%>'>Layout & deck plan</asp:HyperLink>
        |
         <asp:HyperLink ID="HyperLink3" runat="server">Specification</asp:HyperLink>

        <a href="YachtsOverview.aspx?yachtid=1">37</a> |
            <a href="YachtsOverview.aspx?yachtid=2">42</a>--%>





        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" TEXT-DECORATION="none">  Overview   |</asp:LinkButton>
        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" TEXT-DECORATION="none">  Layout & deck plan   |</asp:LinkButton>
        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" TEXT-DECORATION="none">  Specification  </asp:LinkButton>


        <h6>Content :</h6>
        <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" BasePath="/Scripts/ckeditor/"
            Toolbar="Bold|Italic|Underline|Strike|Subscript|Superscript|-|RemoveFormat
        NumberedList|BulletedList|-|Outdent|Indent|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|-|BidiLtr|BidiRtl
        /
        Styles|Format|Font|FontSize
        TextColor|BGColor
        Link|Image|Table"
            Height="400px">
        </CKEditor:CKEditorControl>

        <%-- <asp:Label ID="UploadOverviewTime" runat="server" Visible="False" ForeColor="#009933" class="d-flex justify-content-center"></asp:Label>--%>
        <asp:Button ID="UploadOverviewBtn" runat="server" Text="更新" class="btn btn-info" OnClick="UploadOverviewBtn_Click" />



        <asp:Label ID="Label1" runat="server" Text="Overview" Visible="false"></asp:Label>


  

        <asp:Panel ID="Panel1" runat="server" >
      <div class="dlpart" style="display: flex">
            <div>
                <asp:FileUpload ID="FileUpload1" runat="server" /></div>
            <div>
                <asp:Button ID="UploadHBtn" runat="server" Text="上傳檔案" class="btn btn-info" OnClick="UploadHBtn_Click" /></div>
        </div>

            
        檔案:
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="檔案" SortExpression="OverviewDownload">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Eval("OverviewDownload") %>' NavigateUrl='<%# "~/Yachtsupload/"+Eval("OverviewDownload") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        </asp:Panel>




     

   <%-- </form>--%>

</asp:Content>
