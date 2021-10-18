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
        public string _names { get; set; }
        public string _address { get; set; }
        public string _telephon { get; set; }
        public string _mobile { get; set; }

        //instancias a la clase Crud
        private Crud crud = new Crud();

        //metodo para retornar los registros de la tabla Cliente
        public MySqlDataReader getAllCliente()
        {
            string query = "SELECT clienteId,names,address,telephon,mobile FROM cliente";

            //llamado al metodo select de la clase Crud
            return crud.select(query);
        }

        //metodo para insertar o editar un registro
        public Boolean newEditCliente(string action)
        {
            if (action == "new")
            {
                string query = "INSERT INTO cliente(names, address, telephon, mobile)" + 
                    "VALUES ('"+ _names +"', '"+ _address +"', '"+ _telephon +"', '"+ _mobile +"')";
                crud.executeQuery(query); //llamado al metodo executeQuery de la clase crud
                return true;
            }
            else if (action == "edit")
            {
                string query = "UPDATE cliente SET"
                    + "names = '" + _names + "',"
                    + "address = '" + _address + "',"
                    + "telephon = '" + _telephon + "',"
                    + "mobile = '" + _mobile + "',"
                    + "WHERE "
                    + "clienteId = '" + _clienteId + "'";
                crud.executeQuery(query);
                return true;
            }

            return false;

        }

        public Boolean deleteCliente()
        {
            string query = "DELETE FROM cliente WHRERE clienteId = '" + _clienteId + "'";
            crud.executeQuery(query);
            return true;
        }
    }
}
