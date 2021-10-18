using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace simpleCRUD
{
    public partial class frmCliente : Form
    {
        private string action = "";
        public frmCliente()
        {
            InitializeComponent();
        }
      

        private void Form1_Load(object sender, EventArgs e)
        {
            //deja un tab 
            tabs.TabPages.Remove(tabForm);

            //carga los datos en el datagridView
            //deshabilita controles
            fillDataGridView();
            controlsDisable();

        }

        //utilizado para mostrar los registros en el datagridview
        public void fillDataGridView()
        {
            //instancia de la clase libro| Book
            Cliente cliente = new Cliente();

            clearDataGridView();

            dtgCliente.Columns.Add("clienteId", "CLIENTE ID");
            dtgCliente.Columns.Add("names", "NOMBRES");
            dtgCliente.Columns.Add("address", "DIRECCION");
            dtgCliente.Columns.Add("telephon", "TELEFONO");
            dtgCliente.Columns.Add("mobile", "CELULAR");

            //llamado al medoto getCliente() de la clase Book
            MySqlDataReader dataReader = cliente.getAllCliente();

            //leer el resultado y mostrarlo en el datagridview
            while(dataReader.Read())
            {
                dtgCliente.Rows.Add(
                        dataReader.GetValue(0),
                        dataReader.GetValue(1),
                        dataReader.GetValue(2),
                        dataReader.GetValue(3),
                        dataReader.GetValue(4)
                       );
            }
        }

        public void clearDataGridView()
        {
            dtgCliente.Columns.Clear();
            dtgCliente.Rows.Clear();
        }
        //deshabilita los controles de formulario
        public void controlsDisable()
        {
            txtId.Enabled = false;
            txtNames.Enabled = false;
            txtAddress.Enabled = false;
            txtTelephon.Enabled = false;
            txtMobile.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }
        //habilitar los controles de formulario
        public void controlsEnable()
        {
            txtId.Enabled = false;
            txtNames.Enabled = true;
            txtAddress.Enabled = true;
            txtTelephon.Enabled = true;
            txtMobile.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }
        //limpiar el contenido de los controles
        public void clearControls()
        {
            txtId.Text = "";
            txtNames.Text = "";
            txtAddress.Text = "";
            txtTelephon.Text = "";
            txtMobile.Text = "";
        }

          
       
        private void dtgBooks_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            tabs.TabPages.Remove(tabData);//ocultar el tab de el datagridview
            tabs.TabPages.Add(tabForm); //mostrar el formulario para los datos
            tabs.TabPages[0].Text = "EDIT CLIENTE";

            action = "edit";
            controlsEnable();

            txtId.Visible = true;
            txtId.ReadOnly = true;
            lblId.Visible = true;

            //cargar datos en controles
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            //mediante este boton se programara para guardar y editar
        }

      

        private void btnExit_Click(object sender, EventArgs e)
        {
            //codigo del boton salir
            string mensaje = "¿Está seguró que desea salir?";
            if (MetroFramework.MetroMessageBox.Show(this, mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void lNew_Click(object sender, EventArgs e)
        {
            tabs.TabPages.Add(tabForm);//mostrar el formulario
            tabs.TabPages.Remove(tabData); //ocultar el  tab del dataagridview
            tabs.TabPages[0].Text = "NEW CLIENTE"; //agregar texto al tab

            txtId.Visible = false;
            lblId.Visible = false;
            txtNames.Focus(); //enviar enfoque al titulo
            action = "new";
            controlsEnable();
            clearControls();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            string mensaje = "¿Está seguró que desea cancelar?";
            if (MetroFramework.MetroMessageBox.Show(this, mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                clearControls();
                controlsDisable();


                tabs.TabPages.Remove(tabForm);
                tabs.TabPages.Add(tabData);
                tabs.TabPages[0].Text = "CLIENTE LIST";
            }
        }

        private void tabForm_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente(); //nueva instancia de la clase cliente 

            cliente._names = txtNames.Text;
            cliente._address = txtAddress.Text;
            cliente._telephon = txtTelephon.Text;
            cliente._mobile = txtMobile.Text;

            string mensaje = "¿Esta seguro que desea guardar el registro?";
            if(MetroFramework.MetroMessageBox.Show(this, mensaje, "CONFIRMACION", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //LLAMAR AL METODO PARA GUARDAR 
                if (cliente.newEditCliente(action))
                {
                    MetroFramework.MetroMessageBox.Show(this, "¡Los datos se han guardado exitosamente!",
                        "CONFIRMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

        }

        private void actions_Opening(object sender, CancelEventArgs e)
        {

        }
    }

}
