using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using System.IO;

namespace Pagina web
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Resize += new System.EventHandler(this.Form_Resize);
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            webView21.Size = this.ClientSize - new System.Drawing.Size(webView21.Location);
            botonlr.Left = this.ClientSize.Width - botonlr.Width;
            comboBox1.Width = botonlr.Left - comboBox1.Left;
        }
        private void Guardar(string fileName, string texto)
        {
            FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(texto);
            writer.Close();
        }
        private void botonlr_Click(object sender, EventArgs e)
        {
            string link = comboBox1.Text;
            if(!(comboBox1.Text.Contains(".")))
            {
                link = "https://www.google.com/search?q=" + comboBox1.Text;
            }

            if (webView21 != null && webView21.CoreWebView2 != null)
            {
                webView21.CoreWebView2.Navigate(link);
            }
            Guardar(@"C:\Users\MarcoBolanos\source\repos\Pagina web\bin\Debug\historial.txt", comboBox1.Text);
            
        }

    private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void haciaAtrásToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void haciaDelanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string line;
            int counter = 0 ;

            StreamReader lector = new StreamReader(@"C:\Users\MarcoBolanos\source\repos\Pagina web\bin\Debug\historial.txt");

            while ((line = lector.ReadLine()) != null)

            {
                comboBox1.Items.Add(lector.ReadLine());
                counter++;
            }
            lector.Close();

        }
    }
}


