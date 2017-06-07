function ShoppingCartController($scope, $http) {
    function GetTotalPrice() {
        var totalPrice = 0.0;
        $scope.ShoppingCart.Items.forEach(function (item) {
            //alert(item.Quantity + ' ' + item.UnitPrice);
            totalPrice += (item.Quantity * item.UnitPrice);
        });
        return totalPrice;
    }

    $scope.checkout = function () {
        //alert('Prepare to pay!');
        window.location = '/Cart/Checkout';
    }

    $scope.refreshItems = function () {
        $http.get('/Cart/InspectBackendService').success(function (data) {
            $scope.ShoppingCart = data;
            $scope.TotalPrice = GetTotalPrice();
        });
    }

    var updateComponent = function () {
        $http.get('ReloadViewComponent').then(
            function (response) {
                $('.counterIcon').html(response.data);
            });
    }

    $scope.removeFromCart = function (item) {
        if (window.confirm('Are you sure you want to remove this product from your cart?')) {
            //alert(item.Quantity);
            var url = '/Cart/RemoveProduct/?productId=' + item.ProductId;
            //alert(url);
            $http.get(url).then(function () {
                updateComponent();
            }, function (data, status, headers, config) {
                alert('Unable to remove the product from cart.');
            });
            $scope.refreshItems();
            //location.reload();
        }

    }

    $scope.updateCart = function (item) {
        //alert(item.Quantity + ' ' + item.ProductId);
        var url = '/Cart/UpdateProduct/?productId=' + item.ProductId + '&quantity=' + item.Quantity;
        //alert(url);
        $http.get(url).then(function () {
            updateComponent();
        },
            function (data, status, headers, config) {
                alert('Unable to update cart.')
            });
        $scope.TotalPrice = GetTotalPrice();
    }

    $scope.refreshItems();

    $scope.preventCheckout = function () {
        return $scope.TotalPrice <= 0;
    }
}

var nskApp = angular.module('nskShoppingCart', []);
nskApp.controller('ShoppingCartController', ['$scope', '$http', ShoppingCartController]);
nskApp.$inject = ['$scope', '$http'];
nskApp.filter('beautify', function () {
    return function (input) {
        //alert(input);
        var beautifiedUrl = input.replace(/ /g, '-')
            .replace(/'/g, "-")
            .replace("/", "-")
            //.replace(/./g, "-");
            .replace(/,/g, "-")
            .replace(/--/g, "-")
            .replace(/@/g, "-at-")
            .replace(/:/g, "")
            .replace(/\?/g, "")
            .replace(/%/g, "")
            .replace(/&/g, "-and-")
            .replace(/&amp;/g, "-and-")
            .replace(/"/g, "")
            .replace(/\\/g, "");

        //alert(beautifiedUrl);
        return beautifiedUrl;
    };
});
nskApp.filter('encodeURI', function () {
    return window.encodeURI;
});
nskApp.filter('unescape', function () {
    return function (input) {
        return $('<div/>').html(input).text();
    }
});