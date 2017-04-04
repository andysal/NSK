<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<DateTime>" %>
<% =Html.TextBox(string.Empty, Model.ToString("dd/MM/yyyy"), new { @class = "date" })%>
<script type="text/javascript">
    $(function () {
        $("#<% =ViewData.TemplateInfo.GetFullHtmlFieldId(string.Empty) %>").datepicker();
    });
</script>
