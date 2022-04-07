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
        public FormCalculadora()
        {
            InitializeComponent();
            this.Text = "Calculadora de Alejandro Heidenreich del curso 2°A";
            this.StartPosition = FormStartPosition.CenterScreen;
            string[] opArray = new string[] { "+", "-", "*", "/", "" };
            cmbOperador.Items.AddRange(opArray);
            lstOperaciones.TabStop = false;
            lblResultado.TabStop = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Limpiar();
            
        }

        private void cmbOperador_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmbOperador.Items.Add("");
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
           

            DialogResult rta = MessageBox.Show("¿Está seguro de querer salir?", "Salir",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
            cmbOperador.SelectedIndex = 4;
            lblResultado.Text = "0";
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
            lstOperaciones.Items.Add($"{txtNumero1.Text} {cmbOperador.Text} {txtNumero2.Text} = {lblResultado.Text}");
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

        private void lblResultado_Click(object sender, EventArgs e)
        {

        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
           
            lstOperaciones.Items.Add($"{txtNumero1.Text} = {Operando.DecimalBinario(txtNumero1.Text)}");
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lstOperaciones.Items.Add($"{txtNumero1.Text} = {Operando.BinarioDecimal(txtNumero1.Text)}");
        }
    }
}
