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
            char tipoTelegrama = 'o';  //Inicialmente tipoTelegrama es ordinario CM2223
            int numPalabras = 0;
            double costo =0;
           
            textoTelegrama = txtTelegrama.Text;      //Texto del telegrama
            
            if (cbUrgente.Checked)      // Si urgente cambia el tipo de telegrama
                tipoTelegrama = 'u';
           
            int calcularPalabras(string texto)    // Calculo del Nro.Palabras del telegrama
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


            if (tipoTelegrama == 'O' || tipoTelegrama == 'o')  // Caso Telegrama es ordinario
            {
                if (numPalabras <= 10)    // Si Nro.Palabras menor o igual a 10
                    costo = 2.5;         //Costo Telegrama es 2.5  (Error corregido antes era 25) 
                else
                    costo = 2.5 + 0.5 * (numPalabras - 10); // Si Nro.Palabras mayor a 10
                if (numPalabras == 0)
                    costo = 0;
            }
            else
            {
                if (tipoTelegrama == 'u')   // Caso Telegrama es Urgente
                    if (numPalabras <= 10)  // Si Nro.Palabras mayor que 10
                        costo = 5;              //Costo Telegrama es 5
                    else 
                        costo = 5 + 0.75 * (numPalabras - 10); 
                    if (numPalabras == 0)
                        costo = 0;
            }
            txtPrecio.Text = costo.ToString() + " euros";


        }

        private void cbUrgente_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
