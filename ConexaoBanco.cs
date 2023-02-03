using System.Data;
using MySql.Data.MySqlClient;

namespace GeradorSenha
{
    internal class ConexaoBanco
    {
        MySqlConnection con;
        public void ConectarBD()
        {
            try
            {
                con = new MySqlConnection("Persist Security info= false; server = localhost;" + "database=senhas;user=root;pwd=jpedro05;");
                con.Open();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public void executarComandos(String sql)
        {
            try
            {
                ConectarBD();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        public DataTable executarConsulta(String sql)
        {
            try
            {
                ConectarBD();

                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
