using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_GitHub_CML2223
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string textoTelegrama;
            char tipoTelegrama = 'o'; //se coloca como tipoTelegrama el ordinario CM2223
            int numPalabras = 0;
            double coste;
            //Leo el telegrama
            textoTelegrama = txtTelegrama.Text;
            // telegrama urgente?
            if (cbUrgente.Checked)
                tipoTelegrama = 'u';
            //Obtengo el número de palabras que forma el telegrama
            int calcularPalabras(string texto)
            {
                int i = 0, numPalabra = 1;
                while (i <= texto.Length - 1)
                {
                    if (texto[i] == ' ' || texto[i] == '\n' || texto[i] == '\t')
                    {
                        numPalabra++;
                    }
                    i++;
                }
                return numPalabra;
            }
            numPalabras = calcularPalabras(textoTelegrama);
            //Si el telegrama es ordinario
            if (tipoTelegrama == 'O' || tipoTelegrama == 'o')
                if (numPalabras <= 10)
                    coste = 2.5; //corregido costo de 25 se colocó 2.5 CM2223
                else
                    coste = 0.5 * numPalabras;
            else
            //Si el telegrama es urgente
            if (tipoTelegrama == 'u')
                if (numPalabras <= 10)
                    coste = 5;
                else
                    coste = 5 + 0.75 * (numPalabras - 10); //Punto Interrupcion Condicional CM2223
            else
                coste = 0;
            txtPrecio.Text = coste.ToString() + "euros";

        }

        private void cbUrgente_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
