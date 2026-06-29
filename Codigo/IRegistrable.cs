using MySql.Data.MySqlClient;

namespace ClubDeportivo
{
    public interface IRegistrable
    {
        void Registrar(MySqlConnection con);
    }
}
