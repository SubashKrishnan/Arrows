var app = angular.module("App", ['angularUtils.directives.dirPagination']);
app.directive('numbersOnly', NumbersOnly);
app.controller("Ctrl", function ($scope, $http, $timeout) {
    $scope.pagesize = 5;
    $scope.AddUpdate = function () {
        $('#divBtnGroup').hide();
        var validations = $scope.Validations();
        if (validations === false) {
            $('#divBtnGroup').show();
            return;
        }
        $('#Loader').show();
        $scope.c = {};
        $scope.c.IntClientID = document.getElementById("ID").value;
        $scope.c.StrClientCode = $scope.txtClientCode;
        $scope.c.IntCustomerID = $scope.ddlCustomers;
        $scope.c.FltInvestmentAmount = $scope.txtInvestmentAmount;
        $scope.c.IntClientPlanID = $scope.ddlPlans;
        $scope.c.IntReference_ClientID = $scope.ddlReferences;
        $scope.c.intMode = 1;
        if ($scope.chkIsActive === true ? $scope.c.IntClientIsActive = 1 : $scope.c.IntClientIsActive = 0);
        $http({
            method: "post",
            url: "/api/ClientApi/AddUpdate",
            datatype: "json",
            data: JSON.stringify($scope.c)
        }).then(function (response) {
            $scope.Msg = response.data;
            document.getElementById("btnSave").setAttribute("value", "Save");
            $scope.AutoHideMsgs();
            $scope.GetClients();
            $scope.ClearFields();
            $('#Loader').hide();
            $('#divBtnGroup').show();
        });
    };
    $scope.GetClients = function () {
        $('#Loader').show();
        $scope.GetCustomers();
        $scope.GetPlans();
        $scope.GetReferences();
        $http({
            method: "get",
            url: "/api/ClientApi/GetClients"
        }).then(function (response) {
            $scope.Clients = response.data;
        });
        $scope.sortKey = 'ID';
        $scope.sortReverse = true;
        $('#Loader').hide();
    };
    $scope.GetPlans = function () {
        $http({
            method: "get",
            url: "/api/ClientApi/GetPlans"
        }).then(function (response) {
            $scope.Plans = response.data;
        });
    };
    $scope.GetCustomers = function () {
        $http({
            method: "get",
            url: "/api/ClientApi/GetCustomers"
        }).then(function (response) {
            $scope.Customers = response.data;
        });
    };
    $scope.GetReferences = function () {
        $http({
            method: "get",
            url: "/api/ClientApi/GetReferences"
        }).then(function (response) {
            $scope.References = response.data;
        });
    };
    $scope.Delete = function (c) {
        var Delete = confirm('Are you sure you want to delete this ?');
        if (Delete) {
            $scope.c = {};
            $scope.c.IntClientID = c.ID;
            $scope.c.IntMode = 2;
            $http({
                method: "post",
                url: "/api/ClientApi/AddUpdate",
                datatype: "json",
                data: JSON.stringify($scope.c)
            }).then(function (response) {
                $scope.Msg = response.data;
                $scope.AutoHideMsgs();
                $scope.GetClients();
            });
        }
    };
    $scope.Edit = function (c) {
        document.getElementById("ID").value = c.ID;
        $scope.txtClientCode = c.CLIENT_CODE;
        $scope.ddlCustomers = c.CUSTOMER_ID;
        $scope.txtInvestmentAmount = c.INVESTMENT_AMOUNT;
        $scope.ddlPlans = c.PLAN_ID;
        $scope.ddlReferences = c.REFERENCE_CLIENT_ID;
        $scope.istxtClientCodeDisable = true;
        $scope.isddlReferencesDisable = true;
        $scope.isddlCustomersDisable = true;
        if (c.ISACTIVE === 1 ? $scope.chkIsActive = true : $scope.chkIsActive = false);
        document.getElementById("btnSave").setAttribute("value", "Update");
    };
    $scope.sort = function (key) {
        $scope.sortReverse = $scope.sortKey === key ? !$scope.sortReverse : $scope.sortReverse;
        $scope.sortKey = key;
    };
    $scope.ClearFields = function () {
        $scope.txtClientCode = "";
        $scope.ddlCustomers = "";
        $scope.txtInvestmentAmount = "";
        $scope.ddlPlans = "";
        $scope.ddlReferences = "";
        $scope.chkIsActive = false;
        $scope.istxtClientCodeDisable = false;
        $scope.isddlReferencesDisable = false;
        $scope.isddlCustomersDisable = false;
        document.getElementById("ID").value = 0;
        document.getElementById("btnSave").setAttribute("value", "Save");
    };
    $scope.Validations = function () {
        if ($scope.txtClientCode === "" || $scope.txtClientCode === undefined) {
            $("#divErrorClientCode").css("display", "block");
            $("#txtClientCode").focus();
            return false;
        }
        else {
            $("#divErrorClientCode").css("display", "none");
        }
        if ($scope.ddlCustomers === "" || $scope.ddlCustomers === undefined) {
            $("#divErrorCustomer").css("display", "block");
            $("#ddlCustomers").focus();
            return false;
        }
        else {
            $("#divErrorCustomer").css("display", "none");
        }
        if ($scope.txtInvestmentAmount === "" || $scope.txtInvestmentAmount === undefined) {
            $("#divErrorInvestmentAmount").css("display", "block");
            $("#txtInvestmentAmount").focus();
            return false;
        }
        else {
            $("#divErrorInvestmentAmount").css("display", "none");
        }
        if ($scope.ddlPlans === "" || $scope.ddlPlans === undefined) {
            $("#divErrorPlan").css("display", "block");
            $("#ddlPlans").focus();
            return false;
        }
        else {
            $("#divErrorPlan").css("display", "none");
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