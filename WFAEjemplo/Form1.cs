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

    public partial class Form1 : Form
    {

        Ventas _en = new Ventas();
        VentasPL _pl = new VentasPL();

        private void LimpiarTxt()
        {
            txtN.Text = string.Empty;
            txtE.Text = string.Empty;
            txtV.Text = string.Empty;
            txtN.Focus();
        }
        public Form1()
        {
            InitializeComponent();
        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtN.Text == "" || txtV.Text == "" || txtE.Text == "")
                {
                    MessageBox.Show("Hay espacios en blanco.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    _en.Nombre = txtN.Text;
                    _en.Total_Ventas = Convert.ToInt32(txtV.Text);
                    _en.Estado = txtE.Text;
                    int resultado = _pl.AgregarVentas(_en);

                    if (resultado == 1)
                    {
                        MessageBox.Show("Los datos se guardaron correctamente", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        LimpiarTxt();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarTxt();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Consulta _ver = new Consulta();
            this.Hide();
            _ver.ShowDialog();
        }
    }
}
