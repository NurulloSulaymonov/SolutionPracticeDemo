namespace Main.Services;
using Main.Domain.Models;
public class StudentService
{
    private List<Student> students;
    private int lastId;
    public StudentService()
    {
       students = new List<Student>();  
    }

    public void Add(Student student)
    {
       
        if(student.FirstName == null || student.LastName == null) 
        throw new ArgumentNullException("properties shuld not be null"); // error
        student.Id = ++lastId;
        students.Add(student);

    }

    public void Update(Student student)
    {
         var st = students.FirstOrDefault(x => x.Id == student.Id);
         if (st != null)
         {
             st.FirstName = student.FirstName;
             st.LastName = student.LastName;
         }

        // foreach (var st in students)
        // {
        //     if(st.Id == student.Id)
        //     {
        //       st.FirstName = student.FirstName;
        //       st.LastName = student.LastName;
        //     }
        // }
    }

    public List<Student> GetStudents()
    {
        return students;
    }

    public void Delete(int id)
    {
      var st = students.SingleOrDefault(x=>x.Id == id);
      students.Remove(st);
    }
}