app.service("StudentService", function ($http) {
    //get All Eployee  
    this.getAllStudents = function () {
        alert("ajmal");
       // $scope.Type = 'list';
      //  url: '/Handler3.ashx?type=' + 'list'
      //  url: '/Handler2.ashx?Id=' + $scope.Id + '&Name=' + $scope.Name + '&type=' + $scope.Type,
        return $http.get('/Handler3.ashx?type=' + 'list');
    };
    // Adding Record  
    this.AddNewStudent = function (tbl_Student) {
        alert(tbl_Student.employeeName);
        return $http({
            method: "post",
            url:'/Handler3.ashx?type=' + 'add',
            data: JSON.stringify(tbl_Student),
            dataType: "json"
        });
    }
    // Updating record  
    this.UpdateStudent = function (tbl_Student) {
        return $http({
            method: "post",
            url: '/Handler3.ashx?type=' + 'update',
            data: JSON.stringify(tbl_Student),
            dataType: "json"
        });
    }
    //salary operation
    this.Displaysal = function (tbl_Student) {
        return $http({
            method: "post",
            url: '/Handler3.ashx?type=' + 'salary',
            data: JSON.stringify(tbl_Student),
            dataType: "json"
        });
    }
    // Deleting records  
    //this.deleteStudent = function (Id) {
    //    return $http.post('/Handler3.ashx?type='+'delete&Id=' + Id)
    //}

    this.deleteStudent = function (tbl_Student) {
        return $http({
            method: "post",
            url: '/Handler3.ashx?type=' + 'delete',
            data: JSON.stringify(tbl_Student),
            dataType: "json"
        });
    }
});