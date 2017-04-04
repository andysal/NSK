<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Nsk.Web.OnlineStore.Models.Catalog.ProductViewModel>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceholder" runat="server">
<%: Model.Title %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderPlaceholder" runat="server">
    <meta name="keywords" content="<%: Model.KeyWords %>" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <article>
        <div id="ProductThumbnail" style="float:left; padding-left:20px; padding-right: 10px; padding-top: 20px">
            <img src="" alt="Product picture" style="width: 150px" />
        </div>
        <div id="ProductInfo" style="float:left; padding-left: 10px;">
            <h2 style="font-weight: bold"><%: Model.ProductDetail.Name %></h2><br />
            Price: $<% =Model.ProductDetail.UnitPrice.ToString("##.00")%><br />
            Quantity per unit: <% =Model.ProductDetail.QuantityPerUnit%><br />
            Units in stock: <% =Model.ProductDetail.UnitsInStock%><br />
        </div>
    </article>
    <div id="ShoppingCartBox" style="float:left; padding-left: 10px; text-align: center">
        <% Html.RenderAction("RenderAddToShoppingCartBox"); %>
    </div>
    <aside>
        <div id="SimilarProducts" style="float: none; clear:both; padding-top: 20px;">
            <h3>Related products</h3>
            <% foreach(var p in Model.RelatedProducts) {%>
            <div id="SimilarProduct" style="float:left; padding: 5px; text-align: center; width: 100px;">
                <a href="/Catalog/Product/<% =p.Id %>"><span><%: p.Name %></span></a><br />
                $<%: p.UnitPrice.ToString("##.00") %>
            </div>
            <% } %>
        </div>
    </aside>
</asp:Content>