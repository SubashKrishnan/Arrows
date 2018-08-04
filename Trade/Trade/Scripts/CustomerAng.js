var app = angular.module("App", ['angularUtils.directives.dirPagination']);
app.directive('numbersOnly', NumbersOnly);
app.controller("Ctrl", function ($scope, $http, $timeout) {
    $scope.pagesize = 5;
    $scope.AddUpdateCustomer = function () {
        $('#divBtnGroup').hide();
        var validations = $scope.Validations();
        if (validations === false) {
            $('#divBtnGroup').show();
            return;
        }
        $('#Loader').show();
        $scope.c = {};
        $scope.c.IntCustomerID = document.getElementById("ID").value;
        $scope.c.StrCustomerName = $scope.txtName;
        $scope.c.StrCustomerPancard = $scope.txtPancard;
        $scope.c.StrCustomerAadhar = $scope.txtAadhar;
        $scope.c.StrCustomerMobile = $scope.txtMobile;
        $scope.c.StrCustomerEmail = $scope.txtEmail;
        $scope.c.StrCustomerAddress = $scope.txtAddress;
        $scope.c.intMode = 1;
        if ($scope.chkIsActive === true ? $scope.c.IntCustomerIsActive = 1 : $scope.c.IntCustomerIsActive = 0);
        $http({
            method: "post",
            url: "/api/CustomerAPI/AddUpdateCustomer",
            datatype: "json",
            data: JSON.stringify($scope.c)
        }).then(function (response) {
            $scope.Msg = response.data;
            document.getElementById("btnSave").setAttribute("value", "Save");
            $scope.AutoHideMsgs();
            $scope.GetCustomers();
            $scope.ClearFields();
            $('#Loader').hide();
            $('#divBtnGroup').show();
        });
    };
    $scope.GetCustomers = function () {
        $('#Loader').show();
        $http({
            method: "get",
            url: "/api/CustomerAPI/GetCustomers"
        }).then(function (response) {
            $scope.Customers = response.data;
        });
        $scope.sortKey = 'ID';
        $scope.sortReverse = true;
        $('#Loader').hide();
    };
    $scope.Delete = function (c) {
        var Delete = confirm('Are you sure you want to delete this ?');
        if (Delete) {
            $scope.c = {};
            $scope.c.IntCustomerID = c.ID;
            $scope.c.IntMode = 2;
            $http({
                method: "post",
                url: "/api/CustomerAPI/AddUpdateCustomer",
                datatype: "json",
                data: JSON.stringify($scope.c)
            }).then(function (response) {
                $scope.Msg = response.data;
                $scope.AutoHideMsgs();
                $scope.GetCustomers();
            });
        }
    };
    $scope.Edit = function (c) {
        document.getElementById("ID").value = c.ID;
        $scope.txtName = c.NAME;
        $scope.txtPancard = c.PANCARD;
        $scope.txtAadhar = c.AADHAR;
        $scope.txtMobile = c.MOBILE;
        $scope.txtEmail = c.EMAIL;
        $scope.txtAddress = c.ADDRESS;
        if (c.ISACTIVE === 1 ? $scope.chkIsActive = true : $scope.chkIsActive = false);
        document.getElementById("btnSave").setAttribute("value", "Update");
    };
    $scope.sort = function (key) {
        $scope.sortReverse = $scope.sortKey === key ? !$scope.sortReverse : $scope.sortReverse;
        $scope.sortKey = key;
    };
    $scope.ClearFields = function () {
        $scope.txtName = "";
        $scope.txtPancard = "";
        $scope.txtAadhar = "";
        $scope.txtMobile = "";
        $scope.txtEmail = "";
        $scope.txtAddress = "";
        $scope.chkIsActive = false;
        document.getElementById("ID").value = 0;
        document.getElementById("btnSave").setAttribute("value", "Save");
    };
    $scope.Validations = function () {
        if ($scope.txtName === "" || $scope.txtName === undefined) {
            $("#divErrorName").css("display", "block");
            $("#txtName").focus();
            return false;
        }
        else {
            $("#divErrorName").css("display", "none");
        }
        if ($scope.txtPancard === "" || $scope.txtPancard === undefined) {
            $("#divErrorPancard").css("display", "block");
            $("#txtPancard").focus();
            return false;
        }
        else {
            $("#divErrorPancard").css("display", "none");
        }
        if ($scope.txtAadhar === "" || $scope.txtAadhar === undefined) {
            $("#divErrorAadhar").css("display", "block");
            $("#txtAadhar").focus();
            return false;
        }
        else {
            $("#divErrorAadhar").css("display", "none");
        }
        if ($scope.txtMobile.length === 0) {
            $("#divErrorMobileLength").css("display", "none");
            $("#divErrorMobile").css("display", "block");
            $("#txtMobile").focus();
            return false;
        }
        else {
            if ($scope.txtMobile.length < 10) {
                $("#divErrorMobile").css("display", "none");
                $("#divErrorMobileLength").css("display", "block");
                $("#txtMobile").focus();
                return false;
            }
            else {
                $("#divErrorMobileLength").css("display", "none");
                $("#divErrorMobile").css("display", "none");
            }
        }
        if ($scope.txtEmail === "") {
            $("#divErrorEmailVal").css("display", "none");
            $("#divErrorEmail").css("display", "block");
            $("#txtEmail").focus();
            return false;
        }
        else {
            $("#divErrorEmail").css("display", "none");
        }
        if (/^\w+[\+\.\w-]*@([\w-]+\.)*\w+[\w-]*\.([a-z]{2,4}||\d+)$/i.test($scope.txtEmail)) {
            $("#divErrorEmailVal").css("display", "none");
        }
        else {
            $("#divErrorEmail").css("display", "none");
            $("#divErrorEmailVal").css("display", "block");
            $("#txtEmail").focus();
            return false;
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