using ProjWebAPI16042023.Models;
using System.Data.SqlClient;
using System.Text;

namespace ProjWebAPI16042023.Services
{
    public class CarService
    {
        readonly string strCon = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=D:\bancoAula\dbcars.mdf;";
        readonly SqlConnection conn;

        public CarService()
        {
            conn = new SqlConnection(strCon);
            conn.Open();
        }

        public bool insert(Car carro)
        {
            bool status = false;
            try
            {
                string strInsert = "insert into Car (Name, Year, Model, Color) values ( @Name, @Year, @Model, @Color)";
                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Name", carro.Name));
                commandInsert.Parameters.Add(new SqlParameter("@Year", carro.Year));
                commandInsert.Parameters.Add(new SqlParameter("@Model", carro.Model));
                commandInsert.Parameters.Add(new SqlParameter("@Color", carro.Color));

                commandInsert.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            finally
            {
                conn.Close();
            }
            return status;
        }

        public List<Car> FindAll()
        {
            List<Car> cars = new();

            StringBuilder sb = new StringBuilder();
            sb.Append("select Id, Name, Year, Model, Color from Car");

            SqlCommand commandSelect = new(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Car car = new();

                car.Id = Convert.ToInt32(dr["Id"]);
                car.Name = (string) dr["Name"];
                car.Year = (string) dr["Year"];
                car.Model = (string) dr["Model"];
                car.Color = (string) dr["Color"];

                cars.Add(car);
            }
            return cars;
        }
    }
}
