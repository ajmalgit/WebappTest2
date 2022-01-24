var app = angular.module('MyApp', [])
app.controller('MyController', function ($scope, $http, $window) {

    alert("load");
    //Getting records from database.
    //  $.getJSON('/Handler1.ashx?customerId=' + customerId + '&callback=?', function (result) {
    $scope.Id = 2;
    $scope.Name = "ajaml1";
    $scope.Type = "list";
    var post = $http({
        method: "POST",
        // url: "/Handler2.ashx",
        //  url: '/Handler2.ashx?Id=' + $scope.Id + '&Name=' + $scope.Name,
        url: '/Handler2.ashx?Id=' + $scope.Id + '&Name=' + $scope.Name + '&type=' + $scope.Type,
        dataType: 'json',
        headers: { "Content-Type": "application/json" }
    });
    post.success(function (data, status) {
        alert("sucess1");
        //  alert(data);
        alert(data[0].employeeName);
        //The received response is saved in Customers array.
        $scope.Employees = data;
    });

    //Adding new record to database.
    $scope.Add = function () {

        $scope.Type = "add";
        if (typeof ($scope.EmployeeName) == "undefined" || typeof ($scope.phone) == "undefined") {
            //    return;
        }
        //  alert("ajmal");
        alert($scope.EmployeeName);
        alert($scope.mobile);
        alert($scope.Address);

        var obj = {};
        obj.EmployeeName = $scope.EmployeeName;
        obj.mobile = $scope.mobile;
        obj.address = $scope.address;


        //In order to proper pass a json string, you have to use function JSON.stringfy
        var jsonData = JSON.stringify(obj);



        var post = $http({
            method: "POST",
            url: '/Handler2.ashx?type=' + $scope.Type,
            data: jsonData,
            //  url: '/Handler2.ashx?Id=' + $scope.Id + '&Name=' + $scope.EmployeeName+'&type='+$scope.Type,
            //  data: "{EmployeeName: '" + $scope.EmployeeName + "', phone: '" + $scope.phone + "'}",
            dataType: 'json',
            headers: { "Content-Type": "application/json" }
        });
        post.success(function (data, status) {
            //The newly inserted record is inserted into the Customers array.
            $scope.Employees.push(data)
            $scope.Load();
            // $scope.$apply();
        });

        $scope.EmployeeName = "";
        $scope.mobile = "";
        $scope.address = "";
    };

    //This variable is used to store the original values.
    $scope.EditItem = {};

    //Editing an existing record.
    $scope.Edit = function (index) {

        //Setting EditMode to TRUE makes the TextBoxes visible for the row.
        $scope.Employees[index].EditMode = true;

        //The original values are saved in the variable to handle Cancel case.
        $scope.EditItem.employeeName = $scope.Employees[index].employeeName;
        $scope.EditItem.mobile = $scope.Employees[index].mobile;
        $scope.EditItem.address = $scope.Employees[index].address;
    };

    //Cancelling an Edit.
    $scope.Cancel = function (index) {
        // The original values are restored back into the Customers Array.
        $scope.Employees[index].employeeName = $scope.EditItem.employeeName;
        $scope.Employees[index].mobile = $scope.EditItem.mobile;
        $scope.Employees[index].address = $scope.EditItem.address;

        //Setting EditMode to FALSE hides the TextBoxes for the row.
        $scope.Employees[index].EditMode = false;
        $scope.EditItem = {};
    };

    //load function again
    $scope.Load = function () {
        alert("loadagain");
        //Getting records from database.
        //  $.getJSON('/Handler1.ashx?customerId=' + customerId + '&callback=?', function (result) {
        $scope.Id = 2;
        $scope.Name = "ajaml1";
        $scope.Type = "list";
        var post = $http({
            method: "POST",
            // url: "/Handler2.ashx",
            //  url: '/Handler2.ashx?Id=' + $scope.Id + '&Name=' + $scope.Name,
            url: '/Handler2.ashx?Id=' + $scope.Id + '&Name=' + $scope.Name + '&type=' + $scope.Type,
            dataType: 'json',
            headers: { "Content-Type": "application/json" }
        });
        post.success(function (data, status) {
            alert("sucess1");
            alert(data);
            alert(data[0].employeeName);
            //The received response is saved in Customers array.
            $scope.Employees = data;
        });


    };

    //load function again

    //Updating an existing record to database.
    $scope.Update = function (index) {
        $scope.Type = "update";
        var employee = $scope.Employees[index];
        var obj = {};
        alert(employee.employeeName)
        alert(employee.employeeId);
        alert(employee.id);
        obj.EmployeeName = employee.employeeName;
        obj.mobile = employee.mobile;
        obj.address = employee.address;

        obj.id = employee.id;



        //In order to proper pass a json string, you have to use function JSON.stringfy
        var jsonData = JSON.stringify(obj);
        var post = $http({
            method: "POST",
            url: '/Handler2.ashx?type=' + $scope.Type,
            data: jsonData,
            // data: '{employee:' + JSON.stringify(employee) + '}',
            dataType: 'json',
            headers: { "Content-Type": "application/json" }
        });
        post.success(function (data, status) {
            //Setting EditMode to FALSE hides the TextBoxes for the row.
            employee.EditMode = false;
        });
    };

    //Deleting an existing record from database.
    $scope.Delete = function (employeeId) {
        alert(employeeId);
        var obj = {};
        obj.id = employeeId;
        //In order to proper pass a json string, you have to use function JSON.stringfy
        var jsonData = JSON.stringify(obj);
        $scope.Type = "delete";
        if ($window.confirm("Do you want to delete this row?")) {
            var post = $http({
                method: "POST",
                url: '/Handler2.ashx?type=' + $scope.Type,
                data: "{id: " + employeeId + "}",
                dataType: 'json',
                headers: { "Content-Type": "application/json" }
            });
            post.success(function (data, status) {
                $scope.Load();

                ////Remove the Deleted record from the Customers Array.
                //$scope.Employees = $scope.Employees.filter(function (employee) {
                //    return employee.employeeId !== employeeId;
                //});
            });
        }
    };
});