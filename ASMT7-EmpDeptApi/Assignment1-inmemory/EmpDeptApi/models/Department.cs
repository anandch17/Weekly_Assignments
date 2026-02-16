namespace EmpDeptApi.models
{
    public class Department
    {
        public int Id { get; set; }
       public string Name { get; set; }

        public List<Employee>? Employee { get; set; }
}
}
