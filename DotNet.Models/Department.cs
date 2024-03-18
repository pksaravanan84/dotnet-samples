using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.Models;


[Table("Department", Schema = "dbo")]
public class Department
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
}