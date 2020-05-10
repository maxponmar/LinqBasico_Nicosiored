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

namespace Linq_019_Winforms
{
    public partial class Form1 : Form
    {
        // Nuestro documento XML
        XDocument documento = new XDocument();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            documento = XDocument.Load("Alumnos.xml");
            // Mostramos en el textbox
            txtXML.Text = documento.ToString();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            // Creamos un nuevo elemento
            XElement nuevoElemento = new XElement("Alumno", new XAttribute("Nombre", txtNombre.Text),
                new XElement("Curso", txtCurso.Text),
                new XElement("Calificacion", txtCalificacion.Text)
                );
            // Lo adicionamos al documento
            documento.Descendants("Alumnos").First().Add(nuevoElemento);
            // Actualizamos el textbox
            txtXML.Text = documento.ToString();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var resultados = from a in documento.Descendants("Alumno")
                             where (string)a.Element("Curso") == txtBusqueda.Text
                             select a.Element("Calificacion").Value + a.Element("Curso").Value;
            // Construimos una cadena con la informacion
            string datos = "";
            foreach (var dato in resultados.Distinct())
            {
                datos += string.Format(" Calificacion {0} \r\n", dato);               
            }
            MessageBox.Show(datos);
        }
    }
}
