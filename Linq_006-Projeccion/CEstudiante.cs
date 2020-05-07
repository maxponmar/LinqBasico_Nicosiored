using System;
using System.Collections.Generic;
using System.Text;

namespace Linq_006_Projeccion
{
    class CEstudiante
    {
        private string nombre;
        private string id;
        private string curso;
        private double promedio;

        public string Nombre { get => nombre; }
        public string Id { get => id; }
        public string Curso { get => curso; }
        public double Promedio { get => promedio; }

        public CEstudiante(string nombre, string id, string curso, double promedio)
        {
            this.nombre = nombre;
            this.id = id;
            this.curso = curso;
            this.promedio = promedio;
        }

        public override string ToString()
        {
            return string.Format("Nombre: {0}, {1}, curso: {2}, promedio: {3}", nombre, id, curso, promedio);
        }
    }
}
