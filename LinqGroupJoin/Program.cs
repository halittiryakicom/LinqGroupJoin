using LinqGroupJoin;

//Listeler ile nesne üretimi
List<Student> students = new List<Student>()
{
    new Student
    {
        StudentId = 1,
        StudentName ="Ali",
        ClassId = 1,
    },

    new Student
    {
        StudentId = 2,
        StudentName ="Ayşe",
        ClassId = 2,
    },

    new Student
    {
        StudentId = 3,
        StudentName ="Mehmet",
        ClassId = 1,
    },

    new Student
    {
        StudentId = 4,
        StudentName ="Fatma",
        ClassId = 3,
    },

    new Student
    {
        StudentId = 5,
        StudentName ="Ahmet",
        ClassId = 2,
    }
};

List<Class> classes = new List<Class>()
{
    new Class
    {
        ClassId = 1,
        ClassName = "Matematik"
    },

    new Class
    {
        ClassId = 2,
        ClassName = "Türkçe"
    },
    new Class
    {
        ClassId = 3,
        ClassName = "Kimya"
    }
};


var studentWithClasses = classes.GroupJoin(students, student => student.ClassId, lesson => lesson.ClassId
                                         , (lesson, studentGroup) => new
                                         {
                                             lesson = lesson.ClassName,
                                             student = studentGroup.ToList()
                                         });

foreach (var student in studentWithClasses)
{
    Console.WriteLine($"***** {student.lesson} *****");
    foreach (var item in student.student)
    {
        Console.WriteLine(item.StudentName);
    }
    Console.WriteLine("-----------------------------------------");
}