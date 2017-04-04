<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Nsk.Web.OnlineStore.Models.Home.ProductCategoriesViewModel>" %>
<%@ Import Namespace="Nsk.Web.OnlineStore.WorkerServices" %>
<div>
    <% foreach (var cat in Model.Categories)
       {%>
    <div style="float: left; padding: 5px; width: 260px;">
        <div style="float: left; margin-right:5px; width: 60px;" >
            <img src="/Home/CategoryThumbnail?categoryId=<% = cat.CategoryId %>" alt="<%: cat.CategoryName %>" />
        </div>
        <div style="margin-left: 10px;">
            <span style="font-weight: bold;"><a href="/Catalog/Category/<%: cat.CategoryName %>"><%: cat.CategoryName %></a></span><br />
            <a href="/Catalog/Category/<%: cat.CategoryName %>"><% = cat.ProductsCount %> products</a><br />
            <a href="/Catalog/Category/<%: cat.CategoryName %>?available=true"><% = cat.AvailableProductsCount %> products available</a>
        </div>
    </div>
    <%  } %>
</div>