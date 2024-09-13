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
            EstudianteDAL estudianteDAL = new EstudianteDAL();
            List<Estudiante> estudiantes = estudianteDAL.ObtenerEstudiantes();
            dgvEstudiantes.Rows.Clear();
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

            btnNuevo.Enabled = !btnNuevo.Enabled;
            btnAgregar.Enabled = !btnAgregar.Enabled;
            btnEditar.Enabled = !btnEditar.Enabled;
            btnEliminar.Enabled = !btnEliminar.Enabled;
            btnCancelar.Enabled = !btnCancelar.Enabled;
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
            if (fila >= 0)
            {
                txtEstudianteID.Text = dgvEstudiantes.Rows[fila].Cells[0].Value.ToString();
                txtNombre.Text = dgvEstudiantes.Rows[fila].Cells[1].Value.ToString();
                txtApellido.Text = dgvEstudiantes.Rows[fila].Cells[2].Value.ToString();
                txtEmail.Text = dgvEstudiantes.Rows[fila].Cells[3].Value.ToString();
                dtpFechaNacimiento.Text = dgvEstudiantes.Rows[fila].Cells[4].Value.ToString();
            }
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            EstudianteDAL estudianteDAL = new EstudianteDAL();
            if (txtEstudianteID.Text == "")
            {
                Estudiante estudiante = new Estudiante
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Email = txtEmail.Text,
                    FechaNacimiento = dtpFechaNacimiento.Value
                };
                estudianteDAL.AgregarEstudiante(estudiante);
                LimpiarCampos();
                CambiarEstados();
                MessageBox.Show("Estudiante agregado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Estudiante estudiante = new Estudiante
                {
                    EstudianteID = int.Parse(txtEstudianteID.Text),
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Email = txtEmail.Text,
                    FechaNacimiento = dtpFechaNacimiento.Value
                };
                estudianteDAL.ActualizarEstudiante(estudiante);
                LimpiarCampos();
                CambiarEstados();
                MessageBox.Show("Estudiante modificado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ListarEstudiantes();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtEstudianteID.Text != "")
            {
                CambiarEstados();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro para poder editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EstudianteDAL estudianteDAL = new EstudianteDAL();
            if (txtEstudianteID.Text != "")
            {
                DialogResult opcion = MessageBox.Show("¿Desea eliminar este registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (opcion == DialogResult.Yes)
                {
                    estudianteDAL.EliminarEstudiante(int.Parse(txtEstudianteID.Text));
                    LimpiarCampos();
                    ListarEstudiantes();
                    MessageBox.Show("Estudiante eliminado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro para poder eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
