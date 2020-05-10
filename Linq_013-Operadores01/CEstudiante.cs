using System;
using System.Collections.Generic;
using System.Text;

namespace Linq_013_Operadores01
{
    class CEstudiante
    {
        private string nombre;
        private int id;

        public string Nombre { get => nombre; }
        public int Id { get => id; }

        public CEstudiante(string nombre, int id)
        {
            this.nombre = nombre;
            this.id = id;
        }

        public override string ToString()
        {
            return string.Format("Estudiante: {0}, {1}", nombre, id);
        }
    }
}
