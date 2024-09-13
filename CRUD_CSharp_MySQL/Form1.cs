using CRUD_CSharp_MySQL.DAL;
using CRUD_CSharp_MySQL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_CSharp_MySQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ListarEstudiantes()
        {
            EstudianteDAL estudianteBLL = new EstudianteDAL();
            List<Estudiante> estudiantes = estudianteBLL.ObtenerEstudiantes();

            foreach (Estudiante estudiante in estudiantes)
            {
                dgvEstudiantes.Rows.Add(estudiante.EstudianteID.ToString(), estudiante.Nombre, estudiante.Apellido, estudiante.Email, estudiante.FechaNacimiento.ToString("yyyy-MM-dd"));
            }
        }

        private void CambiarEstados()
        {
            txtNombre.ReadOnly = !txtNombre.ReadOnly;
            txtApellido.ReadOnly = !txtApellido.ReadOnly;
            txtEmail.ReadOnly = !txtEmail.ReadOnly;
            dtpFechaNacimiento.Enabled = !dtpFechaNacimiento.Enabled;
            dgvEstudiantes.Enabled = !dgvEstudiantes.Enabled;
        }

        private void LimpiarCampos()
        {
            txtEstudianteID.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            dtpFechaNacimiento.Value.ToLocalTime();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListarEstudiantes();
            CambiarEstados();
        }

        private void dgvEstudiantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = e.RowIndex;
            txtEstudianteID.Text = dgvEstudiantes.Rows[fila].Cells[0].Value.ToString();
            txtNombre.Text = dgvEstudiantes.Rows[fila].Cells[1].Value.ToString();
            txtApellido.Text = dgvEstudiantes.Rows[fila].Cells[2].Value.ToString();
            txtEmail.Text = dgvEstudiantes.Rows[fila].Cells[3].Value.ToString();
            dtpFechaNacimiento.Text = dgvEstudiantes.Rows[fila].Cells[4].Value.ToString();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            CambiarEstados();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            CambiarEstados();
        }
    }
}
