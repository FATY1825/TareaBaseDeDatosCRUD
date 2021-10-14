using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace simpleCRUD
{
    class Cliente
    {
        //propiedades
        public int _clienteId { get; set; }
        public string _nombres { get; set; }
        public string _address { get; set; }
        public int _telephon { get; set; }
        public int _mobile { get; set; }

        //instancias a la clase Crud
        private Crud crud = new Crud();

        //metodo para retornar los registros de la tabla Book
        public MySqlDataReader getAllBooks()
        {
            string query = "SELECT clienteId,nombres,address,telephon,mobile FROM cliente";

            //llamado al metodo select de la clase Crud
            return crud.select(query);
        }
    }
}
