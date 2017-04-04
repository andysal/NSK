<%@ Page Title="Northwind online store" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Nsk.Web.OnlineStore.Models.Home.IndexViewModel>" %>

<asp:Content runat="server" ContentPlaceHolderID="TitlePlaceholder">
    Northwind Online Store
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderPlaceholder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#tabs").tabs();
        });    
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceholder" runat="server">
    <div>
        <% foreach (var p in Model.RecommendedProducts) { %>
        <div id="Product1" style="float: left; padding-top: 10px; padding-bottom: 10px; text-align: center; width: 33%">
            <img src="" alt="<%: p.Name %> image" /><br />
            <a href="/Catalog/Product/<% =p.Id %>"><span style="font-weight: bold"><%: p.Name %></span></a><br />
            $<%: p.UnitPrice.ToString("##.00") %>
        </div>
        <% } %>
        <div id="tabs" style="border: 0px; float:none; clear:both">
            <ul>
                <li><a href="#tabs-1">Product categories</a></li>
                <li><a href="#tabs-2">Best selling categories</a></li>
            </ul>
            <div id="tabs-1">
                <div>
                    <% Html.RenderAction("RenderProductCategories"); %>
                </div>
            </div>
            <div id="tabs-2">
                <div>
                    <% Html.RenderAction("RenderBestSellingProductCategories"); %>
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
