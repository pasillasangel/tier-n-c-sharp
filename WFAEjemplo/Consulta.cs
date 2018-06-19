using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EN;
using PL;

namespace WFAEjemplo
{
    public partial class Consulta : Form
    {
        Ventas _en = new Ventas();
        VentasPL _pl = new VentasPL();

        public Consulta()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                MessageBox.Show("Falta llenar el cambo de busqueda", "Falta Campo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                _en.Nombre = txtBuscar.Text;
                
                dgdatos.DataSource = _pl.MostrarVentasPorNombre(_en);

                //BindingSource bindingSource1 = new BindingSource();

                //// Automatically generate the DataGridView columns.
                //dgdatos.AutoGenerateColumns = true;

                //// Set up the data source.
                //bindingSource1.DataSource = _pl.MostrarVentasPorNombre(_en);
                //dgdatos.DataSource = bindingSource1;

                //// Automatically resize the visible rows.
                //dgdatos.AutoSizeRowsMode =
                //    DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;

                //// Set the DataGridView control's border.
                //dgdatos.BorderStyle = BorderStyle.Fixed3D;

                //// Put the cells in edit mode when user enters them.
                //dgdatos.EditMode = DataGridViewEditMode.EditOnEnter;

                //dgdatos.ItemSource = _pl.MostrarVentasPorNombre(_en);

                //dgdatos.Rows.Add(_pl.MostrarVentasPorNombre(_en));

                //dgdatos.Rows.Add(new object[] { _pl.MostrarVentasPorNombre(_en) });

                //var list = new BindingList<Ventas>(_pl.MostrarVentasPorNombre(_en));
                //dgdatos.DataSource = list;

                //dgdatos.DataSource = _pl.MostrarVentasPorNombre(_en);

            }


        }

        private void dgdatos_SelectionChanged(object sender, EventArgs e)
        {
            //_en.Id = dgdatos.SelectedRows[0].Index;
            //_en = dgdatos.Rows[0] as Ventas;
            //_en = dgdatos.SelectedCells[0].Value as Ventas;
            //_en = dgdatos.CurrentCell.Value as Ventas;
            //_en = dgdatos.SelectedIndex as Ventas;


            //if (_en != null)
            //{
            //    txtN.Text = _en.Nombre;
            //    txtV.Text = Convert.ToString(_en.Total_Ventas);
            //    txtE.Text = _en.Estado;
            //}
        }

        private void dgdatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _en.Id = Convert.ToInt32(dgdatos.Rows[e.RowIndex].Cells["Id"].Value);
            
            if (_en.Id != 0)
            {
                _en.Nombre = Convert.ToString(dgdatos.Rows[e.RowIndex].Cells["Nombre"].Value);
                _en.Total_Ventas = Convert.ToInt32(dgdatos.Rows[e.RowIndex].Cells["Total_ventas"].Value);
                _en.Estado = Convert.ToString(dgdatos.Rows[e.RowIndex].Cells["Estado"].Value);
                txtN.Text = _en.Nombre;
                txtV.Text = Convert.ToString(_en.Total_Ventas);
                txtE.Text = _en.Estado;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //IF textBox vacios
            _en.Nombre = txtN.Text;
            _en.Total_Ventas = Convert.ToInt32(txtV.Text);
            _en.Estado = txtE.Text;

            if (_pl.ModificarVentas(_en) > 0)
            {
                MessageBox.Show("SE MODIFICO CORRECTAMENTE", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("No se pudo modificar..", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //IF textBox vacios
            //MessageBoxResult
            _pl.Eliminar(_en);
            //Refres.Items.Refres();

            //dgdatos.ItemSource = _pl.MostrarVentas();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Form1 _ver = new Form1();
            this.Close();
            _ver.ShowDialog();
        }
    }
}
