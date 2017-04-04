<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Nsk.Web.OnlineStore.Models.Catalog.AddToShoppingCartViewModel>" %>
<form method="post">
    <span>Quantity</span><br />
    <% =Html.DropDownListFor(m => m.Quantity, Model.SelectableQuantities)%><br />
    <input type="image" alt="Add to cart" src="" />
</form>