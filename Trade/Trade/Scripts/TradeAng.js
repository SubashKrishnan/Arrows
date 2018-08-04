var app = angular.module("App", ['angularUtils.directives.dirPagination']);
app.directive("dateTimePicker", DatetimePicker)
app.directive('numbersOnly', NumbersOnly);
app.directive('decimalOnly', DecimalOnly);
app.controller("Ctrl", function ($scope, $http, $timeout) {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1;
    var yyyy = today.getFullYear();
    if (dd < 10) {
        dd = '0' + dd;
    }
    if (mm < 10) {
        mm = '0' + mm;
    }
    today = dd + '/' + mm + '/' + yyyy;
    $scope.txtDate = today;
    $scope.pagesize = 5;
    $scope.AddUpdate = function (index) {
        $('#btnUpdate').hide()
        var validations = $scope.Validations();
        if (validations === false) {
            $('#btnUpdate').show()
            $scope.Msg = "Date Should not be empty";
            $scope.AutoHideMsgs();
            return;
        }
        $('#Loader').show();
        var Trade = $scope.Trades[index];
        $scope.t = {};
        $scope.t.IntClientID = Trade.ID
        $scope.t.StrDate = $scope.txtDate;
        $scope.t.FltCRDR = Trade.CRDR;
        $scope.t.intMode = 1;
        $http({
            method: "post",
            url: "/api/TradeApi/AddUpdate",
            datatype: "json",
            data: JSON.stringify($scope.t)
        }).then(function (response) {
            $scope.Msg = response.data;
            $scope.AutoHideMsgs();
            $scope.GetTrades();
            //$scope.ClearFields();
            $('#Loader').hide();
            $('#btnUpdate').show();
        });
    };
    $scope.GetTrades = function () {
        var validations = $scope.Validations();
        if (validations === false) {
            return;
        }
        $('#Loader').show();
        $scope.t = {};
        $scope.t.StrDate = $scope.txtDate;
        $http({
            method: "Post",
            url: "/api/TradeApi/GetTrades",
            datatype: "json",
            data: JSON.stringify($scope.t)
        }).then(function (response) {
            $scope.Trades = response.data;
        });
        $scope.sortKey = 'ID';
        //$scope.sortReverse = true;
        $('#Loader').hide();
    };
    //$scope.Delete = function (c) {
    //    var Delete = confirm('Are you sure you want to delete this ?');
    //    if (Delete) {
    //        $scope.c = {};
    //        $scope.c.IntClientID = c.ID;
    //        $scope.c.IntMode = 2;
    //        $http({
    //            method: "post",
    //            url: "/api/ClientApi/AddUpdate",
    //            datatype: "json",
    //            data: JSON.stringify($scope.c)
    //        }).then(function (response) {
    //            $scope.Msg = response.data;
    //            $scope.AutoHideMsgs();
    //            $scope.GetTradeUpdtes();
    //        });
    //    }
    //};
    //$scope.Edit = function (c) {
    //    document.getElementById("ID").value = c.ID;
    //    $scope.txtClientCode = c.CLIENT_CODE;
    //    $scope.ddlCustomers = c.CUSTOMER_ID;
    //    $scope.txtInvestmentAmount = c.INVESTMENT_AMOUNT;
    //    $scope.ddlPlans = c.PLAN_ID;
    //    $scope.ddlReferences = c.REFERENCE_CLIENT_ID;
    //    $scope.istxtClientCodeDisable = true;
    //    $scope.isddlReferencesDisable = true;
    //    $scope.isddlCustomersDisable = true;
    //    if (c.ISACTIVE === 1 ? $scope.chkIsActive = true : $scope.chkIsActive = false);
    //    document.getElementById("btnSave").setAttribute("value", "Update");
    //};
    $scope.sort = function (key) {
        $scope.sortReverse = $scope.sortKey === key ? !$scope.sortReverse : $scope.sortReverse;
        $scope.sortKey = key;
    };
    //$scope.ClearFields = function () {
    //    $scope.txtClientCode = "";
    //    $scope.ddlCustomers = "";
    //    $scope.txtInvestmentAmount = "";
    //    $scope.ddlPlans = "";
    //    $scope.ddlReferences = "";
    //    $scope.chkIsActive = false;
    //    $scope.istxtClientCodeDisable = false;
    //    $scope.isddlReferencesDisable = false;
    //    $scope.isddlCustomersDisable = false;
    //    document.getElementById("ID").value = 0;
    //    document.getElementById("btnSave").setAttribute("value", "Save");
    //};
    $scope.Validations = function () {
        if ($scope.txtDate === "" || $scope.txtDate === undefined) {
            $("#divErrorDate").css("display", "block");
            $("#txtDate").focus();
            return false;
        }
        else {
            $("#divErrorDate").css("display", "none");
        }
        
        return true;
    };
    $scope.AutoHideMsgs = function () {
        $scope.divMsgs = true;
        $timeout(function () {
            $scope.divMsgs = false;
        }, 3000);
    };
});