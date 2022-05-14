using CrossJoinLinq;

//Example1: Cross Join Using Query Syntax
var CrossJoinResult = from employee in Student.GetAllStudnets()
                      from subject in Subject.GetAllSubjects()
                      select new
                      {
                          Name = employee.Name,
                          SubjectName = subject.SubjectName
                      };
foreach (var item in CrossJoinResult)
{
    Console.WriteLine($"Name : {item.Name}, Subject: {item.SubjectName}");
}

Console.WriteLine(string.Empty);

//Example2: Cross Join using Method Syntax

//Cross Join using SelectMany Method
var CrossJoinResult2 = Student.GetAllStudnets()
            .SelectMany(sub => Subject.GetAllSubjects(),
             (std, sub) => new
             {
                 Name = std.Name,
                 SubjectName = sub.SubjectName
             });
foreach (var item in CrossJoinResult2)
{
    Console.WriteLine($"Name : {item.Name}, Subject: {item.SubjectName}");
}

Console.WriteLine(string.Empty);

//Cross Join using Join Method
var CrossJoinResult3 = Student.GetAllStudnets()
            .Join(Subject.GetAllSubjects(),
                std => true,
                sub => true,
                (std, sub) => new
                {
                    std.Name,
                    sub.SubjectName
                }
             );
foreach (var item in CrossJoinResult3)
{
    Console.WriteLine($"Name : {item.Name}, Subject: {item.SubjectName}");
}

Console.ReadLine();