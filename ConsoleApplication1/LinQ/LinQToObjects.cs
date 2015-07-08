using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1.LinQ
{
    public class DataToTest
    {
        public List<Orgnization> PrepareData()
        {
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee() { EmpId = 1, Address = "Rajaveer1", Name = "Vishal1", DptIDRef =6 });
            empList.Add(new Employee() { EmpId = 2, Address = "Rajaveer2", Name = "Vishal2", DptIDRef = 2 });
            empList.Add(new Employee() { EmpId = 3, Address = "Rajaveer3", Name = "Vishal3", DptIDRef = 1 });
            empList.Add(new Employee() { EmpId = 4, Address = "Rajaveer2", Name = "Vishal4", DptIDRef = 4 });
            empList.Add(new Employee() { EmpId = 5, Address = "Rajaveer3", Name = "Vishal5", DptIDRef = 2 });
            empList.Add(new Employee() { EmpId = 6, Address = "Rajaveer2", Name = "Vishal6", DptIDRef = 1 });
            empList.Add(new Employee() { EmpId = 7, Address = "Rajaveer1", Name = "Vishal7", DptIDRef = 5 });
            empList.Add(new Employee() { EmpId = 8, Address = "Rajaveer3", Name = "Vishal8", DptIDRef = 2 });
            empList.Add(new Employee() { EmpId = 9, Address = "Rajaveer2", Name = "Vishal9", DptIDRef = 1 });
            empList.Add(new Employee() { EmpId = 10, Address = "Rajaveer3", Name = "Vishal10", DptIDRef = 2 });
            empList.Add(new Employee() { EmpId = 11, Address = "Rajaveer2", Name = "Vishal11", DptIDRef = 3 });
            empList.Add(new Employee() { EmpId = 12, Address = "Rajaveer1", Name = "Vishal12", DptIDRef = 2 });

            List<Department> deptList = new List<Department>();
            deptList.Add(new Department() { DptId = 1, Name = "Finance", EmployeeCount=14, Employees=empList, OrgIDRef =1 });
            deptList.Add(new Department() { DptId = 2, Name = "Education", EmployeeCount = 51, Employees = empList, OrgIDRef = 1 });
            deptList.Add(new Department() { DptId = 3, Name = "Chemical", EmployeeCount = 11, Employees = empList, OrgIDRef = 2 });
            deptList.Add(new Department() { DptId = 4, Name = "Biology", EmployeeCount = 12, Employees = empList, OrgIDRef = 2 });
            deptList.Add(new Department() { DptId = 5, Name = "Accounts", EmployeeCount = 31, Employees = empList, OrgIDRef = 3 });
            deptList.Add(new Department() { DptId = 6, Name = "HR", EmployeeCount = 14, Employees = empList, OrgIDRef = 2 });
            deptList.Add(new Department() { DptId = 7, Name = "Banking", EmployeeCount = 51, Employees = empList, OrgIDRef = 4 });
            deptList.Add(new Department() { DptId = 8, Name = "Security", EmployeeCount = 31, Employees = empList, OrgIDRef = 3 });
            deptList.Add(new Department() { DptId = 9, Name = "Insurance", EmployeeCount = 21, Employees = empList, OrgIDRef = 1 });
            deptList.Add(new Department() { DptId = 10, Name = "Mining", EmployeeCount = 11, Employees = empList, OrgIDRef = 3 });





            List<Orgnization> orgList = new List<Orgnization>();
            orgList.Add(new Orgnization { OrgId = 1, Address = "MIDC", DepartmentCount = 1, Departments = deptList, Name = "TataChemical" });
            orgList.Add(new Orgnization { OrgId = 2, Address = "GIDC", DepartmentCount = 2, Departments = deptList, Name = "TataMotors" });
            orgList.Add(new Orgnization { OrgId = 3, Address = "GIDC", DepartmentCount = 3, Departments = deptList, Name = "TataSteel" });



            return AllocateData(orgList);
        }

        private List<Orgnization> AllocateData(List<Orgnization> orgList)
        {

            foreach (Orgnization org in orgList)
            {
                org.Departments = org.Departments.Where(r => r.OrgIDRef == org.OrgId).ToList();
                foreach (Department dpt in org.Departments)
                {
                    dpt.Employees = dpt.Employees.Where(e => e.DptIDRef == dpt.DptId).ToList();
                }
            }
            return orgList;
        }
    }
    public class LinQToObjects
    {
        StringBuilder bldr = new StringBuilder();

        List<Orgnization> lstdata;
       public LinQToObjects()
        {
            DataToTest tst = new DataToTest();
            lstdata = tst.PrepareData();
        }
       public List<Orgnization> ShowDataSet()
       {
           return lstdata;
       }
        public void display<T>(IEnumerable<T> lst)
        {

            foreach (var o in lst)
            {
                foreach (var p in o.GetType().GetProperties())
                {
                    
                    if (p.PropertyType == Type.GetType("System.Collections.Generic.List`1[ConsoleApplication1.LinQ.Department]"))
                    {

                        Console.WriteLine();
                        foreach (var pt in ((Orgnization)(object)o).Departments)
                        {
                            foreach (var pDept in pt.GetType().GetProperties())
                            {
                                if (pDept.PropertyType == Type.GetType("System.Collections.Generic.List`1[ConsoleApplication1.LinQ.Employee]"))
                                {
                                    Console.WriteLine();
                                    foreach (var ptEmp in ((Department)(object)pt).Employees)
                                    {
                                        foreach (var pEmpProp in ptEmp.GetType().GetProperties())
                                        {
                                            bldr.Append(Environment.NewLine + "```````````````````````````````````" + pEmpProp.Name + ":" + pEmpProp.GetValue(ptEmp, null));
                                            
                                        }

                                    }
                                    
                                }
                                else
                                {
                                    bldr.Append(Environment.NewLine + "````````````````" + pDept.Name + ":" + pDept.GetValue(pt, null));
                                }
                                
                            }
                            
                        }

                    }
                    
                    else
                    {

                        bldr.Append(Environment.NewLine + p.Name + ":" + p.GetValue(o, null));
                    }

                }
            }
            System.IO.File.WriteAllText(@"D:\20150516Projects\DesignPatterm\DesignPattern\ConsoleApplication1\LinQ\Output\LinqOutput.txt", bldr.ToString());

        }


        public void GetOrgById(int id)
        {
            List<Orgnization> p = lstdata.Where(r => r.OrgId == id).ToList();
            display(p);
            
        }
        public List<Orgnization> GetOrgByName(string address)
        {
            List<Orgnization> p = lstdata.Where(r => r.Address == address).ToList();
            return p;
        }
        public void GetDeptEmployeeByAddress(int orgid, int deptId, string address)
        {
            //var mf = lstdata.Where(oo => oo.OrgId == orgid).Select(kk => kk.Departments.Select(dptd => dptd.DptId == deptId));
            //var ppp = lstdata.Where(org => org.OrgId == orgid).Select(ll => ll.Departments.Select(dept => dept.DptId == deptId));
            //var ppp = lstdata.Where(org=> org.OrgId == orgid && org.Departments.Any((dept => dept.DptId == deptId && 
            //    dept.OrgIDRef == orgid && dept.Employees.Any(emp=>emp.Address==address))));
            //var ppp = lstdata.Where(org => org.OrgId == orgid && org.Departments.Any((dept => dept.DptId == deptId  
            //    && dept.Employees.Any(emp => emp.Address == address))));
            //var ppp = lstdata.Where(org => org.OrgId == orgid).Select(kk => kk.Departments.Select(tk => tk.DptId == 5 ));
                //.Select(pp=> pp.Departments.Where((dept => dept.DptId == deptId)));

            var testdat = from ll in lstdata 
                         
                         where ll.OrgId == orgid && ll.Departments.Any(pp=>pp.DptId==deptId && pp.Employees.Any(emp=>emp.Address == address))
                         select ll;
            display(testdat);

    //        var diff = lstdata.Where(large =>
    //!entitiesSmallerSet.Any(small =>
    //    small.Key.Equals(large.Key)
    //    && small.StringResourceValues.Any(x =>
    //        x.Culture.Equals(defaultCulture) && x.Value.Length > 0))).ToList();

            //var ttt = lstdata.Select(r => r.Departments.Any(dpt => dpt.DptId == deptId));
        }

        
        
    }

    public class LinqClient
    {
        public void Process()
        {
            Console.WriteLine("Writing File..........");
            LinQToObjects ob = new LinQToObjects();
            //ob.GetOrgById(3);
            //ob.GetOrgByName("GIDC");
            //ob.display(ob.ShowDataSet());
            ob.GetDeptEmployeeByAddress(3, 5, "Rajaveer1");
            Console.WriteLine("File write complete..........");
            
        
        }
    }

    public class Orgnization
    {
        public int OrgId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int DepartmentCount { get; set; }
        public List<Department> Departments { get; set; } 
        
        
    }
    public class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int DptIDRef{ get; set; }
        
    }
    public class Department
    {
        public int DptId { get; set; }
        public string Name { get; set; }
        public int EmployeeCount { get; set; }
        public List<Employee> Employees { get; set; } 
        public int OrgIDRef{ get; set; }
    }

}
