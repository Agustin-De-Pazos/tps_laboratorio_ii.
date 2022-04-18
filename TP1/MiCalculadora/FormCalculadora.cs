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
        }

        /// <summary>
        /// Realiza la operacion de 2 numeros pasados por parametro y su operador
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns> Retorna el resultado del calculo, 0 si no es posible</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            return Calculadora.Operar(new Operando(numero1), new Operando(numero2), operador[0]);
        }

        /// <summary>
        /// Recibe los datos de los 2 textbox y combox, realiza el calculo y lo muestra en el labelbox y listbox
        /// si el combox esta vacio realiza una suma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string calculo;
            string operador;
            operador = (string)this.cmbOperador.SelectedItem;

            if (double.TryParse(this.txtNumero1.Text, out double num1) && double.TryParse(this.txtNumero2.Text, out double num2))
            {
                if (operador == " ")
                {
                    operador = "+";
                }
                double resultado = Operar(this.txtNumero1.Text, this.txtNumero2.Text, operador);
                lblResultado.Text = resultado.ToString();
                calculo = num1.ToString() + " " + operador + " " + num2.ToString() + " = " + resultado + "\n";
                lstOperaciones.Items.Add(calculo);
            }
        }
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        /// <summary>
        /// Limpia el txt1,2 el combox indice 0 y el label en 0
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperador.SelectedIndex = 0;
            this.lblResultado.Text = "0";
        }

        /// <summary>
        /// Cierra el formulario al clickear el boton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Antes de cerrar el formulario pregunta al usuario si quiere salir 
        /// mediante un messageBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Al pulsar el boton convierte en binario el resultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string resultado;
            Operando operando = new Operando();
            double.TryParse(lblResultado.Text, out double valor);

            resultado = operando.DecimalBinario(valor);
            lblResultado.Text = resultado.ToString();
        }

        /// <summary>
        /// Al pulsar el boton convierte en decimal el resultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando operando = new Operando();
            lblResultado.Text = operando.BinarioDecimal(lblResultado.Text);
        }

    }
}
