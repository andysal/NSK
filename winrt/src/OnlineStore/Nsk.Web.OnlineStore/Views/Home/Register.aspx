<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Nsk.Web.OnlineStore.Models.Home.RegisterViewModel>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content4" runat="server" ContentPlaceHolderID="HeaderPlaceholder">

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceholder" runat="server">
    <% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Please let us know who you are</legend>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.FirstName) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.FirstName) %>
            <%: Html.ValidationMessageFor(model => model.FirstName) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.LastName) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.LastName)%>
            <%: Html.ValidationMessageFor(model => model.LastName) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.EmailAddress) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.EmailAddress) %>
            <%: Html.ValidationMessageFor(model => model.EmailAddress) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.UserName) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.UserName)%>
            <%: Html.ValidationMessageFor(model => model.UserName) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Password) %>
        </div>
        <div class="editor-field">
            <%: Html.PasswordFor(model => model.Password)%>
            <%: Html.ValidationMessageFor(model => model.Password) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.ConfirmPassword) %>
        </div>
        <div class="editor-field">
            <%: Html.PasswordFor(model => model.ConfirmPassword)%>
            <%: Html.ValidationMessageFor(model => model.ConfirmPassword) %>
        </div>
        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
    <% } %>
    <p>
    Note: are you registering a company? You will be able to specify accounting informations in your profile page.
    </p>
</asp:Content>


