using Main.Services;
using Main.Domain.Models;
var studentService = new StudentService();

while (true)
{
    char select;
    Console.WriteLine("Select Option");
    Console.WriteLine("l for list of students");
    Console.WriteLine("a for add");
    Console.WriteLine("u for update");
    Console.WriteLine("d for delete");
    Console.WriteLine("q for quit");
    select = Convert.ToChar(Console.ReadLine());

    if(select == 'q') break;

    _ = select switch
    {
        'l' => Show(),
        'a' => Add(),
        'u' => Update(),
        'd' => Delete(),
        _ => Invalid(),
    };
    Console.WriteLine(new string('-', 20));
}

bool Invalid()
{
    Console.WriteLine("invalid operation");
    return false;
}

bool Show()
{
    var students = studentService.GetStudents();

    Console.WriteLine("Id   Name          Surname");
    foreach (var student in students)
    {
        Console.WriteLine($"{student.Id}   {student.FirstName}          {student.LastName}");
    }
    return true;
}

bool Add()
{
    string name, surname;
    Console.Write("Name: ");
    name = Console.ReadLine();
    Console.Write("Surname: ");
    surname = Console.ReadLine();
    var student = new Student()
    {
        FirstName = name,
        LastName = surname
    };
    studentService.Add(student);
    return true;
}

bool Update()
{
    int id;
    string name, surname;
    System.Console.Write("Id: ");
    id = Convert.ToInt32(Console.ReadLine());
    System.Console.Write("Name: ");
    name = Console.ReadLine();
    System.Console.Write("Surname: ");
    surname = Console.ReadLine();
    var student = new Student()
    {
        Id = id,
        FirstName = name,
        LastName = surname
    };
    studentService.Update(student);
    return true;
}

bool Delete()
{
    int id;
    System.Console.Write("Id: ");
    id = Convert.ToInt32(Console.ReadLine());
    studentService.Delete(id);
    return true;
}

