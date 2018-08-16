using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;

namespace Projekt
{
    public partial class ListaIgraca : Form
    {
        public ListaIgraca()
        {
            InitializeComponent();
        }



        private void ListaIgraca_Load(object sender, EventArgs e)
        {
            XElement element = XElement.Load("Vjezba.xml");
            IEnumerable<XElement> vjezba = element.Elements();
            richTextBox1.Text = "Popis igrača i njihovih rezulutata\n\n";
            richTextBox1.Enabled = false;
            foreach (var ele in vjezba)
            {
                String Ime = ele.Element("Ime").Value;
                String Rezultat = ele.Element("Rezultat").Value;

                richTextBox1.Text += Ime + " ima rezultat:" + Rezultat+"\n\n";
            }

         }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
