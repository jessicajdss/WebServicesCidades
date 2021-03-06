
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WebServicesCidades.Models
{
    public class DAOCidades
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader rd = null;

        string conexao = @"Data Source = .\SqlExpress;Initial Catalog = ProjetoCidades;user id=sa;password=senai@123";
        public List<Cidades> Listar()
        {

            List<Cidades> cidades = new List<Cidades>();
            try
            {
                con = new SqlConnection(conexao);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Cidades";
                rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    cidades.Add(new Cidades()
                    {
                        Id = rd.GetInt32(0),
                        Nome = rd.GetString(1),
                        Estado = rd.GetString(2),
                        Habitantes = rd.GetInt32(3)
                    });
                }

            }
            catch (SqlException se)
            {
                throw new ConstraintException(se.Message);
            }
            catch (ConstraintException ex)
            {
                throw new ConstraintException(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return cidades;
        }

        public bool Cadastro(Cidades cidades)
        {
            bool resultado = false;
            try
            {
                con = new SqlConnection(conexao);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Cidades(Nome,Estado,Habitantes) values (@n,@e,@h)";
                cmd.Parameters.AddWithValue("@n", cidades.Nome);
                cmd.Parameters.AddWithValue("@e", cidades.Estado);
                cmd.Parameters.AddWithValue("@h", cidades.Habitantes);

                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                    resultado = true;

                cmd.Parameters.Clear();
            }
            catch (SqlException se)
            {
                throw new ConstraintException(se.Message);
            }
            catch (ConstraintException ex)
            {
                throw new ConstraintException(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return resultado;
        }

        public bool Editar(Cidades cidades)
        {
            bool resultado = false;
            try
            {
                con = new SqlConnection(conexao);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Cidades set Nome =@n, Estado = @e, Habitantes = @h where Id = @id";
                cmd.Parameters.AddWithValue("@id", cidades.Id);
                cmd.Parameters.AddWithValue("@n", cidades.Nome);
                cmd.Parameters.AddWithValue("@e", cidades.Estado);
                cmd.Parameters.AddWithValue("@h", cidades.Habitantes);

                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                    resultado = true;

                cmd.Parameters.Clear();
            }
            catch (SqlException se)
            {
                throw new ConstraintException(se.Message);
            }
            catch (ConstraintException ex)
            {
                throw new ConstraintException(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return resultado;
        }

        public bool Apagar(int id)
        {
            bool resultado = false;
            try
            {
                con = new SqlConnection(conexao);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Cidades where Id = @id";   
                cmd.Parameters.AddWithValue("@id", id);  

                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                    resultado = true;

                cmd.Parameters.Clear();
            }
            catch (SqlException se)
            {
                throw new ConstraintException(se.Message);
            }
            catch (ConstraintException ex)
            {
                throw new ConstraintException(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return resultado;
        }


    }
}