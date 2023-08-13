using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_BooKCrud.Models
{
    public class BookCurd
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public BookCurd() {
            string conststr = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            con = new SqlConnection(conststr);
        }



        public int AddBook(Book prod)
        {
            string quey = "insert into Book values(@name,@author,@price)";

            cmd=new SqlCommand(quey, con);
            cmd.Parameters.AddWithValue("@name", prod.Name);
            cmd.Parameters.AddWithValue("@author", prod.Author);
            cmd.Parameters.AddWithValue("@price", prod.Price);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int UpdateBook(Book prod)
        {
            string qury = "update book set @name=name,@author=author, @price=price where id=@id";

            cmd = new SqlCommand(qury, con);
            cmd.Parameters.AddWithValue("@name", prod.Name);
            cmd.Parameters.AddWithValue("@author",prod.Author);
            cmd.Parameters.AddWithValue("@price", prod.Price);
            cmd.Parameters.AddWithValue("@id", prod.Id);

            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }

        public int DeleteBook(int id)
        {
            string qury = "delete from Book where @id=id";

            cmd = new SqlCommand(qury, con);

            cmd.Parameters.AddWithValue("@id",id);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public Book GetBookById(int id)
        {
            Book b = new Book();
            string qery = "select * from Book where @id=id";

            cmd=new SqlCommand(qery, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr= cmd.ExecuteReader();
            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    b.Id = Convert.ToInt32(dr["id"]);
                    b.Name = dr["name"].ToString();
                    b.Author = dr["author"].ToString();
                    b.Price = Convert.ToInt32(dr["author"]);

                }
            }
            con.Close();
            return b;

        }
        public DataTable GetAllBooks()
        {
            DataTable dt = new DataTable();
            string qry = "select * from Book";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dt.Load(dr);
            }
            con.Close();
            return dt;
        }
    }
}
