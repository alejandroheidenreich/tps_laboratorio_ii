using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        string[] opArray = new string[] { "", "+", "-", "*", "/" };

        public FormCalculadora()
        {
            InitializeComponent();     
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            cmbOperador.Items.AddRange(opArray);
            Limpiar();
            
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Está seguro de querer salir?", "Salir",MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rta == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Limpiar()
        {
            lstOperaciones.Items.Clear();
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.SelectedIndex = -1;
            lblResultado.Text = "0";
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string op = cmbOperador.Text;

            lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
            if (op == "")
            {
                op = "+";
            }
            lstOperaciones.Items.Add($"{ValidarTxtBox(txtNumero1.Text)} {op} {ValidarTxtBox(txtNumero2.Text)} = {lblResultado.Text}");
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando num1 = new Operando(numero1);
            Operando num2 = new Operando(numero2);
            char[] caracterArray = operador.ToCharArray();
            if (caracterArray.Length == 0)
            {
                return Calculadora.Operar(num1, num2, '+');
            }
    
            return Calculadora.Operar(num1, num2, operador.ToCharArray()[0]);
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string resultado = Operando.DecimalBinario(lblResultado.Text);
            lstOperaciones.Items.Add($"{lblResultado.Text} = {resultado}");
            lblResultado.Text = resultado;
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string resultado = Operando.BinarioDecimal(lblResultado.Text);
            lstOperaciones.Items.Add($"{lblResultado.Text} = {resultado}");
            lblResultado.Text = resultado;
        }

        private double ValidarTxtBox(string strNumero)
        {
            if(!double.TryParse(strNumero, out double retorno))
            {
                retorno = 0;
            }

            return retorno;
        }
    }
}
