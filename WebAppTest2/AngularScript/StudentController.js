app.controller("stuCntr", function ($scope, StudentService) {
    $scope.dvStudent = false;
    GetStudentList();
    $scope.students = [];
    $scope.salaries = [];
    //To Get All Records  
    function GetStudentList() {
     //   alert("ajmal service");
        StudentService.getAllStudents().success(function (stu) {
            $scope.students = stu;
        }).error(function () {
            alert('Error in getting records');
        });
    }
    // To display Add div  
    $scope.AddNewStudent = function () {
        $scope.Action = "Add";
        $scope.dvStudent = true;
    }
    // Adding New student record  
    $scope.AddStudnet = function (student) {
        StudentService.AddNewStudent(student).success(function (msg) {
            $scope.students.push(msg)
            $scope.dvAddStudnet = false;
        }, function () {
            alert('Error in adding record');
        });
    }
    // Deleting record.  
    $scope.deleteStudent = function (stu, index) {
        alert(stu.id);
       
        var retval = StudentService.deleteStudent(stu).success(function (msg) {
          //  $scope.students.splice(index, 1);
            // alert('Student has been deleted successfully.');  
            GetStudentList();
        }).error(function () {
            alert('Oops! something went wrong.');
        });
    }
    // Updateing Records  
    //$scope.UpdateStudent = function (tbl_Student) {
    //    alert("updatecheck");
    //    var RetValData = StudentService.UpdateStudent(tbl_Student);
    //    getData.then(function (tbl_Student) {
    //        alert($scope.studentName);
    //        Id: $scope.Id;
    //        StudentName: $scope.studentName;
    //        StudentAddress: $scope.StudentAddress;
    //        StudentEmail: $scope.StudentEmail;
    //    }, function () {
    //        alert('Error in getting records');
    //    });
    //}

     $scope.UpdateStudent = function (tbl_Student) {
      //  alert("updatecheck");
         var RetValData = StudentService.UpdateStudent(tbl_Student).success(function (msg, status) {
             alert("updatecheck1");
             alert(msg);
             alert(status);
             GetStudentList();
          
         }, function () {
             alert('Error in adding record');
         });
      
    }

    $scope.filterEvenStartFrom = function (index) {
       // alert("repete");
        return function (item) {
            return index++ % 2 == 1;
        };
    };


    $scope.sum = function () {
        var total = 0;
        angular.forEach($scope.salaries.lstEmpsal, function (value, key) { // this will get array of elements of parse the objects of it
            total += value.price;
        });
        return total
    }

    $scope.sum = function (data) {
        var total = 0;
        angular.forEach(data, function (value, key) {
            total += value.price;
        });
        return total
    }


    /////testcode
    $scope.detalles = [{
        name: 'Bush',
        price: 2,
        Total: 0
    }, {
        name: 'Obama',
        price: 5,
        Total: 0
    }, {
        name: 'Trump',
        price: 3,
        Total: 0
    }];

    $scope.sum1 = function () {
        var total = 0;
        angular.forEach($scope.detalles, function (key, value) {
            total += key.price;
        });
        return total;
    }

    var total = 0;


    $scope.sum3 = 100;
  

    $scope.sum2 = function (data) {
        alert("ajmal");
        alert(data.lstEmpsal.EmpSal);
       
        angular.forEach(data, function (value, key) {
            alert(value)
            total += value.EmpSal;

            $scope.sum3 = total;
          //  var total = 0;

            
        });
        return total


    }

    $scope.GetSalaryn = function (data) {
        alert("ajmal");
        alert(data);
          var total = 0;
        var i = 0;
        angular.forEach(data, function (key, value) {
            alert(key)
              alert(key.employeeName);
            alert(i);
            alert(key['lstEmpsal'][i].EmpSal);
            alert(data[i]['lstEmpsal'][0].EmpSal);
            total += data[i]['lstEmpsal'][0].EmpSal;;
             
          //  data[i]['lstEmpsal'][0].EmpSal;
          //  alert(key.EmpSal)
            $scope.sum4 = total;
           
            i++;

        });
        return total


    }
    //test code end

 

  

    //salary display
    $scope.GetSalary = function (tbl_Student) {
      //  var RetValData = StudentService.Displaysal(tbl_Student);
        $scope.sum = 0;
        $scope.EmpName = "";
        $scope.EmpCode = "";
        
        StudentService.Displaysal(tbl_Student).success(function (stu) {
        //    alert(stu)
            $scope.salaries = stu;
            sum(stu);
            console.log(stu);
        }).error(function () {
            alert('Error in getting records');
        });
    }

    ///newfunction
    function sum(data) {
      //  alert(data);
        var total = 0;
        var i = 0;
        angular.forEach(data, function (key, value) {
       //     alert(i);
         //  alert(key.id);
           // alert(key.employeeName);
            $scope.EmpName = key.employeeName;
            $scope.EmpCode = key.id;
            total += data[i]['lstEmpsal'][0].EmpSal;;
         //   alert(key['lstEmpsal'][i].EmpSal);
           // $scope.sum += key['lstEmpsal'][i].EmpSal;
         //   $scope.sum = total;
            $scope.sum = total;

            i++;
        });
    }
    //new func end
});