using Refuerzo2024.Model.DAO;
using Refuerzo2024.View.Docentes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Refuerzo2024.Controller.Docentes
{
    internal class ControllerDocentes
    {
        ViewDocentes obj;
        public ControllerDocentes(ViewDocentes vista)
        {
            this.obj = vista;
            vista.dgvDocentes.CellClick += new DataGridViewCellEventHandler(SeleccionarDatos);
            vista.Load += new EventHandler(CargaInicial);
            vista.btnAgregarDocente.Click += new EventHandler(AgregarDocente);
            vista.btnActualizar.Click += new EventHandler(ActualizarDocente);
            vista.btnEliminar.Click += new EventHandler(EliminarDocente);
            vista.btnBuscar.Click += new EventHandler(BuscarDocente);
        }

        public void CargaInicial(object sender, EventArgs e)
        {
            LlenarDataGridViewDocentes();
            obj.txtID.Enabled = false;
        }


        private void LlenarDataGridViewDocentes()
        {
            DAODocentes dao = new DAODocentes();
            DataSet ds = dao.ObtenerDocentes();
            obj.dgvDocentes.DataSource = ds.Tables["Docentes"];
        }

        private void SeleccionarDatos(object sender, EventArgs e)
        {
            int pos = obj.dgvDocentes.CurrentRow.Index;
            obj.txtID.Text = obj.dgvDocentes[0, pos].Value.ToString();
            obj.txtNombres.Text = obj.dgvDocentes[1, pos].Value.ToString();
            obj.txtApellidos.Text = obj.dgvDocentes[2, pos].Value.ToString();
            obj.mskNIT.Text = obj.dgvDocentes[3, pos].Value.ToString();

        }


        public void AgregarDocente(object sender, EventArgs e)
        {
            DAODocentes dao = new DAODocentes();
            dao.NombreDocente = obj.txtNombres.Text.Trim();
            dao.ApellidoDocente = obj.txtApellidos.Text.Trim();
            dao.DUI = obj.mskNIT.Text.Trim();
            if (dao.RegistrarDocente() == true)
            {
                MessageBox.Show("Datos registrados correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarDataGridViewDocentes();
            }
            else
            {
                MessageBox.Show("No se pudo guardar los datos", "Proceso incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void ActualizarDocente(object sender, EventArgs e)
        {
            DAODocentes dao = new DAODocentes();
            dao.IdDocente = int.Parse(obj.txtID.Text.Trim());
            dao.NombreDocente = obj.txtNombres.Text.Trim();
            dao.ApellidoDocente = obj.txtApellidos.Text.Trim();
            dao.DUI = obj.mskNIT.Text.Trim();
            if (dao.ActualizarDocente() == true)
            {
                MessageBox.Show("Datos Actualizados", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarDataGridViewDocentes();
            }
            else
            {
                MessageBox.Show("No se pudo Actualizar los datos", "Proceso incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void EliminarDocente(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(obj.txtID.Text.Trim()))
            {
                MessageBox.Show("Seleccione un registro", "Seleccione un valor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DAODocentes data = new DAODocentes();
                data.IdDocente = int.Parse(obj.txtID.Text);
                if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (data.EliminarDocente() == true)
                    {
                        MessageBox.Show("El dato fue eliminado correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LlenarDataGridViewDocentes();
                    }
                    else
                    {
                        MessageBox.Show("El registro no pudo ser eliminado", "Proceso interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        public void BuscarDocente(object sender, EventArgs e)
        {
            DAODocentes data = new DAODocentes();
            DataSet ds = data.BuscarDocente(obj.txtBuscar.Text.Trim());
            obj.dgvDocentes.DataSource = ds.Tables["Docentes"];
        }



    }
}
