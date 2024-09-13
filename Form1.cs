using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnIdad2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            string nombre, caEmpleado;
            int categoria;
            double salario, salarioTotal, añosTrabajados, incrementoCa = 0, incrementoAño, incremento;

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("El campo nombre no está llenado");
                return;
            }

            if (string.IsNullOrEmpty(txtAños.Text))
            {
                MessageBox.Show("El campo años trabajados no está llenado");
                return;
            }

            if (string.IsNullOrEmpty(txtSalario.Text))
            {
                MessageBox.Show("El campo salario no está llenado");
                return;
            }

            if (cbxCategoría.SelectedIndex == -1)
            {
                MessageBox.Show("No eligio su categoría");
                return;
            }

            if (double.TryParse(txtSalario.Text, out salario ) == false || double.Parse(txtSalario.Text) == 0)
            {
                MessageBox.Show("Por favor ingrese un valor de salario válido.");
                txtSalario.Text = "";
                txtSalario.Focus();
                return;
            }

            if (double.TryParse(txtAños.Text, out añosTrabajados) == false || double.Parse(txtSalario.Text) == 0)
            {
                MessageBox.Show("Por favor ingrese un valor de año válido.");
                txtAños.Text = "";
                txtAños.Focus();
                return;
            }

            nombre = txtNombre.Text;
            caEmpleado = Convert.ToString(cbxCategoría.SelectedItem);
            salario = Convert.ToDouble(txtSalario.Text);
            añosTrabajados = Convert.ToDouble(txtAños.Text);

            categoria = cbxCategoría.SelectedIndex;

            switch (categoria)
            {
                case 0: 
                    incrementoCa = 0.15;
                    break;
                case 1:
                    incrementoCa = 0.10;

                    break;
                case 2:
                    incrementoCa = 0.05;
                    break;
                deafault: break;
            }
         

            incrementoAño = 0.05 * añosTrabajados;
            incremento = incrementoCa + incrementoAño;

            salarioTotal = salario + (salario * incremento);

            MessageBox.Show("El empleado: " + nombre  + "\nObtendra este salario el próximo año: $" + salarioTotal);

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtAños.Text = "varios años moises";
            txtNombre.Text = "";
            txtSalario.Text = "";
            cbxCategoría.SelectedIndex = -1;
            txtNombre.Focus();
        }

       
    }
}
