using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using static System.Data.CommandType;
using System.Data;

namespace WebAPI_Dapper
{
    internal class EmployeeRepository : BaseRepository, IRepository<Employee>
    {
        public bool Add(Employee entity)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@FirstName", entity.FirstName);
                parameters.Add("@LastName", entity.LastName);
                parameters.Add("@EmpCode", entity.EmpCode);
                parameters.Add("@Position", entity.Position);
                parameters.Add("@Office", entity.Office);
                SqlMapper.Execute(con, "insert into Employee ([FirstName],[LastName],[EmpCode],[Position],[Office])" +
                    " Values(@FirstName,@LastName,@EmpCode,@Position,@Office)", parameters, commandType: Text);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            SqlMapper.Execute(con, "Delete From Employee where EmployeeId=@Id", parameters, commandType: Text);
            return true;
        }

        public IEnumerable<Employee> Get()
        {
            List<Employee> Employees = SqlMapper.Query<Employee>(
                (SqlConnection)con, "select * from Employee", commandType: Text).ToList();

            return Employees;
        }

        public Employee Get(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@id", id);
                return SqlMapper.Query<Employee>((SqlConnection)con, "select * from Employee where EmployeeID = @id", parameters, commandType: Text).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Employee entity)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmployeeID", entity.EmployeeID);
                parameters.Add("@FirstName", entity.FirstName);
                parameters.Add("@LastName", entity.LastName);
                parameters.Add("@EmpCode", entity.EmpCode);
                parameters.Add("@Position", entity.Position);
                parameters.Add("@Office", entity.Office);
                SqlMapper.Execute(con, "update Employee set FirstName=@FirstName, LastName=@LastName, EmpCode=@EmpCode," +
                    "Position=@Position, Office=@Office Where EmployeeID=@EmployeeID", parameters, commandType: Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}