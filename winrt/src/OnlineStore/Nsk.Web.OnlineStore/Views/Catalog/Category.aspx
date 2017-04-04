<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Nsk.Web.OnlineStore.Models.Catalog.ProductCategoryViewModel>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceholder" runat="server">
    <h2>
        Category</h2>
    <div id="Suppliers" style="float: left; padding: 10px">
    </div>
    <div id="Products" style="float: left; padding: 10px; width: 90%">
        <table style="width: 100%">
            <tr>
                <td colspan="2" style="text-align: right">
                    <form action="/Catalog/Category/<%: Model.CategoryName %>" method="get">
                    <label for="sort" class="sortByLabel">
                        Sort by&nbsp;</label><select name="sort" id="sort" onchange="this.form.submit();">
                            <% foreach (var c in Model.SortingCriteria) { %>
                            <option value="<%: c.CriterionName %>" <% if (Model.SelectedSortingCriterionName==c.CriterionName) { %>
                                selected="selected" <% } %>>
                                <%: c.Text %></option>
                            <% } %>
                        </select>
                    </form>
                </td>
            </tr>
            <% foreach (var p in Model.Products)
               {%>
            <tr>
                <td style="width: 100px;">
                    <a href="/Catalog/Product/<% =p.Id %>">
                        <img style="border: 0px" src="" alt="<%: p.Name %>" />
                    </a>
                </td>
                <td style="padding-left: 10px">
                    <a href="/Catalog/Product/<% =p.Id %>"><span style="font-weight: bold">
                        <%: p.Name %></span></a><br />
                    Brand:
                    <%: p.SupplierName %><br />
                    Price: $<% =p.Price.ToString("##.00") %><br />
                    Units in stock:
                    <% =p.UnitsInStock %>
                </td>
            </tr>
            <% } %>
        </table>
    </div>
</asp:Content>
