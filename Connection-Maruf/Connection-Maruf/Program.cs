using System.Data.SqlClient;

namespace CSharp_Conn;

class Program
{
    private static SqlConnection connection;
    private static string connectionString = "Data Source=USR01;Initial Catalog=db_hr_sibkm;Integrated Security=True;Connect Timeout=30;Encrypt=False";
    static void Main(string[] args)
    {
        //connection = new SqlConnection(connectionString);
        //try
        //{
        //    connection.Open();
        //    Console.WriteLine("Connection Open!");
        //    connection.Close();
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine("Can not open connection ! " + ex);
        //}

        //== Region ==//
        //GetAllRegion();
        //GetRegionById(3);
        //InsertRegion("New Region");
        //UpdateRegion(5, "Update New Region");
        //DeleteRegion(5);

        //== Country ==//
        //GetAllCountry();
        //GetCountryById("ID");
        //InsertCountry("NC", "New Country", 1);
        //UpdateCountry("NC", "Update New Country", 2);
        //DeleteCountry("NC");

    }

    //GET ALL : Region
    public static void GetAllRegion()
    {
        //membuat instance sql sever connection 
        connection = new SqlConnection(connectionString);


        //membuat instance sql command
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM region";

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Console.WriteLine("ID : " + reader[0]);
                Console.WriteLine("Name : " + reader[1]);
                Console.WriteLine("");
            }
        }
        else
        {
            Console.WriteLine("Region is Empty");
        }
        reader.Close();
        connection.Close();
    }

    //GET BY ID : Region
    public static void GetRegionById(int id)
    {
        //membuat instance sql sever connection
        connection = new SqlConnection(connectionString);

        //membuat instance sql command
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM region WHERE id = @id";

        //membuat instance sql parameter
        SqlParameter pId = new SqlParameter();
        pId.ParameterName = "@id";
        pId.SqlDbType = System.Data.SqlDbType.Int;
        pId.Value = id;
        command.Parameters.Add(pId);

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            reader.Read();

            Console.WriteLine("ID : " + reader[0]);
            Console.WriteLine("Name : " + reader[1]);
            Console.WriteLine("");
        }
        else
        {
            Console.WriteLine($"id : {id} is Not Found!");
        }
        reader.Close();
        connection.Close();
    }

    //INSERT : Region
    public static void InsertRegion(string name)
    {
        connection = new SqlConnection(connectionString);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Insert Into region (name) Values (@name);";
            command.Transaction = transaction;

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = System.Data.SqlDbType.VarChar;
            pName.Value = name;
            command.Parameters.Add(pName);

            command.ExecuteNonQuery();

            transaction.Commit();
            Console.WriteLine("Insert Success!");
            connection.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine("Something Wrong! : " + e.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }

    //UPDATE : Region
    public static void UpdateRegion(int id, string name)
    {
        connection = new SqlConnection(connectionString);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Update region Set name = @name Where id = @id;";
            command.Transaction = transaction;

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = System.Data.SqlDbType.VarChar;
            pName.Value = name;
            command.Parameters.Add(pName);

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.Int;
            pId.Value = id;
            command.Parameters.Add(pId);

            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Update Success!");
            }
            else
            {
                Console.WriteLine($"id = {id} is not found!");
            }

            transaction.Commit();
            connection.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine("Something Wrong! : " + e.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }

    // DELETE : Region
    public static void DeleteRegion(int id)
    {
        connection = new SqlConnection(connectionString);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Delete From region Where id = @id;";
            command.Transaction = transaction;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.Int;
            pId.Value = id;
            command.Parameters.Add(pId);

            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Delete Success!");
            }
            else
            {
                Console.WriteLine($"id = {id} is not found!");
            }

            transaction.Commit();
            connection.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine("Something Wrong! : " + e.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }

    //===========================================================

    // GET ALL : Country
    public static void GetAllCountry()
    {
        connection = new SqlConnection(connectionString);// instance sql server connection

        SqlCommand command = new SqlCommand(); // instance sql command
        command.Connection = connection; // set connection ke command
        command.CommandText = "SELECT * FROM country"; // set query ke command

        connection.Open(); // membuka koneksi
        using SqlDataReader reader = command.ExecuteReader(); // mengeksekusi query
        if (reader.HasRows) // mengecek apakah ada data
        {
            while (reader.Read()) // membaca data
            {
                Console.WriteLine($"ID : {reader[0]}"); // membaca data dari kolom 0
                Console.WriteLine("Name : " + reader[1]); // membaca data dari kolom 1
                Console.WriteLine("Region : " + reader[2]); // membaca data dari kolom 2
            }
        }
        else
        {
            Console.WriteLine("Country is Empty"); // jika tidak ada data akan menampilkan " Country is Empty "
        }
        reader.Close(); // menutup reader
        connection.Close(); // menutup koneksi
    }

    // GET BY ID : Country
    public static void GetCountryById(string id)
    {
        connection = new SqlConnection(connectionString); // instance sql server connection

        SqlCommand command = new SqlCommand(); // instance sql command
        command.Connection = connection; // set connection ke command
        command.CommandText = "SELECT * FROM country WHERE id = @id"; // set query ke command
        SqlParameter pId = new SqlParameter(); // instance sql parameter
        pId.ParameterName = "@id"; // set nama parameter
        pId.SqlDbType = System.Data.SqlDbType.VarChar; // set tipe data parameter
        pId.Value = id; // set value parameter
        command.Parameters.Add(pId); // menambahkan parameter ke command

        connection.Open(); // membuka koneksi
        using SqlDataReader reader = command.ExecuteReader(); // mengeksekusi query
        if (reader.HasRows) // mengecek apakah ada data
        {
            reader.Read(); // membaca data
            Console.WriteLine("ID : " + reader[0]); // membaca data dari kolom 0
            Console.WriteLine("Name : " + reader[1]); // membaca data dari kolom 1
            Console.WriteLine("Region : " + reader[2]); // membaca data dari kolom 2
        }
        else
        {
            Console.WriteLine($"id : {id} is Not Found!"); // jika tidak ada data akan menampilkan " id : {id} is Not Found! "
        }
        reader.Close(); // menutup reader
        connection.Close(); // menutup koneksi
    }

    // INSERT : Country
    public static void InsertCountry(string id, string name, int region)
    {
        connection = new SqlConnection(connectionString); // instance sql server connection

        connection.Open(); // membuka koneksi
        SqlTransaction transaction = connection.BeginTransaction(); // instance sql transaction
        try // try catch untuk menangani error
        {
            SqlCommand command = new SqlCommand(); // instance sql command
            command.Connection = connection; // set connection ke command
            command.CommandText = "Insert Into country (id, name, region) Values (@id, @name, @region);"; // set query ke command
            command.Transaction = transaction; // set transaction ke command

            SqlParameter pId = new SqlParameter(); // instance sql parameter
            pId.ParameterName = "@id"; // set nama parameter
            pId.SqlDbType = System.Data.SqlDbType.VarChar; // set tipe data parameter
            pId.Value = id; // set value parameter
            command.Parameters.Add(pId); // menambahkan parameter ke command

            SqlParameter pName = new SqlParameter(); // instance sql parameter
            pName.ParameterName = "@name"; // set nama parameter
            pName.SqlDbType = System.Data.SqlDbType.VarChar; // set tipe data parameter
            pName.Value = name; // set value parameter
            command.Parameters.Add(pName); // menambahkan parameter ke command

            SqlParameter pRegion = new SqlParameter(); // instance sql parameter
            pRegion.ParameterName = "@region"; // set nama parameter
            pRegion.SqlDbType = System.Data.SqlDbType.Int; // set tipe data parameter
            pRegion.Value = region; // set value parameter
            command.Parameters.Add(pRegion); // menambahkan parameter ke command

            command.ExecuteNonQuery(); // mengeksekusi query
            transaction.Commit(); // commit transaction
            Console.WriteLine("Insert Success!"); // menampilkan pesan
            connection.Close(); // menutup koneksi
        }
        catch (Exception e) // menangani error
        {
            Console.WriteLine("Something Wrong! : " + e.Message); // menampilkan pesan error
            try // try catch untuk menangani error
            {
                transaction.Rollback(); // rollback transaction
            }
            catch (Exception exception) // menangani error
            {
                Console.WriteLine(exception.Message); // menampilkan pesan error
            }
        }
    }

    // UPDATE : Country
    public static void UpdateCountry(string id, string name, int region)
    {
        connection = new SqlConnection(connectionString); // instance sql server connection

        connection.Open(); // membuka koneksi
        SqlTransaction transaction = connection.BeginTransaction(); // instance sql transaction
        try // try catch untuk menangani error
        {
            SqlCommand command = new SqlCommand(); // instance sql command
            command.Connection = connection; // set connection ke command
            command.CommandText = "Update country Set name = @name, region = @region Where id = @id;"; // set query ke command
            command.Transaction = transaction; // set transaction ke command

            SqlParameter pName = new SqlParameter(); // instance sql parameter
            pName.ParameterName = "@name"; // set nama parameter
            pName.SqlDbType = System.Data.SqlDbType.VarChar; // set tipe data parameter
            pName.Value = name; // set value parameter
            command.Parameters.Add(pName); // menambahkan parameter ke command

            SqlParameter pRegion = new SqlParameter(); // instance sql parameter
            pRegion.ParameterName = "@region"; // set nama parameter
            pRegion.SqlDbType = System.Data.SqlDbType.Int; // set tipe data parameter
            pRegion.Value = region; // set value parameter
            command.Parameters.Add(pRegion); // menambahkan parameter ke command

            SqlParameter pId = new SqlParameter(); // instance sql parameter
            pId.ParameterName = "@id"; // set nama parameter
            pId.SqlDbType = System.Data.SqlDbType.VarChar; // set tipe data parameter
            pId.Value = id; // set value parameter
            command.Parameters.Add(pId); // menambahkan parameter ke command

            int result = command.ExecuteNonQuery(); // mengeksekusi query
            if (result > 0) // mengecek apakah ada data yang terupdate
            {
                Console.WriteLine("Update Success!"); // menampilkan pesan
            }
            else
            {
                Console.WriteLine($"id = {id} is not found!"); // jika tidak ada data yang terupdate akan menampilkan " id = {id} is not found! "
            }
            transaction.Commit(); // commit transaction
            connection.Close(); // menutup koneksi
        }
        catch (Exception e) // menangani error
        {
            Console.WriteLine("Something Wrong! : " + e.Message); // menampilkan pesan error
            try // try catch untuk menangani error
            {
                transaction.Rollback(); // rollback transaction
            }
            catch (Exception exception) // menangani error
            {
                Console.WriteLine(exception.Message); // menampilkan pesan error
            }
        }
    }

    // DELETE : Country
    public static void DeleteCountry(string id)
    {
        connection = new SqlConnection(connectionString); // instance sql server connection

        connection.Open(); // membuka koneksi
        SqlTransaction transaction = connection.BeginTransaction(); // instance sql transaction
        try // try catch untuk menangani error
        {
            SqlCommand command = new SqlCommand(); // instance sql command
            command.Connection = connection; // set connection ke command
            command.CommandText = "Delete From country Where id = @id;"; // set query ke command
            command.Transaction = transaction; // set transaction ke command

            SqlParameter pId = new SqlParameter(); // instance sql parameter
            pId.ParameterName = "@id"; // set nama parameter
            pId.SqlDbType = System.Data.SqlDbType.VarChar; // set tipe data parameter
            pId.Value = id; // set value parameter
            command.Parameters.Add(pId); // menambahkan parameter ke command

            int result = command.ExecuteNonQuery(); // mengeksekusi query
            if (result > 0) // mengecek apakah ada data yang terhapus
            {
                Console.WriteLine("Delete Success!"); // menampilkan pesan
            }
            else
            {
                Console.WriteLine($"id = {id} is not found!"); // jika tidak ada data yang terhapus akan menampilkan " id = {id} is not found! "
            }
            transaction.Commit(); // commit transaction
            connection.Close(); // menutup koneksi
        }
        catch (Exception e) // 
        {
            Console.WriteLine("Something Wrong! : " + e.Message); // menampilkan pesan error
            try // try catch untuk menangani error
            {
                transaction.Rollback(); // rollback transaction
            }
            catch (Exception exception) // menangani error
            {
                Console.WriteLine(exception.Message); // menampilkan pesan error
            }
        }
    }

    //===========================================================
}