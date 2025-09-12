using DemoWipro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoWipro.Pages
{
    public class EmployModel : PageModel
    {
        public List<Employ>? Employees { get; set; }

        public void OnGet()
        {
            Employees = new List<Employ>
     {
         new Employ{Empno=1,Name="Yamini",Basic=83234,Disigination="HR"},
         
         new Employ{Empno=2,Name="Uday",Basic=89923,Disigination = "HR"},
         new Employ{Empno=3,Name="Ganesh",Basic=92222,Disigination = "HR"},
         new Employ{Empno=4,Name="Datta",Basic=525458,Disigination="Developer"}
     };
        }
    }
}
