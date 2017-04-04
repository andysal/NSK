<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master"
    Inherits="System.Web.Mvc.ViewPage<Nsk.Web.OnlineStore.Models.Catalog.SearchViewModel>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceholder" runat="server">
    <div>
        <h2>
            Results for:
        </h2>
        <div style="float: left; width: 200px;">
            <h3>
                Categories:</h3>
            <ul>
                <% foreach (var cat in Model.Categories)
                   {%>
                <li><a href="/Catalog/Category/<% =cat.Name %>">
                    <% =cat.Name %></a></li>
                <% } %>
            </ul>
        </div>
        <div style="float: left;">
            <h3>
                Products:</h3>
            <table>
                <% foreach (var product in Model.Products)
                   {%>
                <tr>
                    <td><a href="/Catalog/Product/<% =product.Id %>"><% =product.Name %></a></td>
                    <td style="text-align: right"><% =product.UnitsInStock.ToString("##")%></td>
                    <td style="text-align: right">$<% =product.Price.ToString("##.00") %></td>
                </tr>
                <% } %>
            </table>
        </div>
    </div>
</asp:Content>
