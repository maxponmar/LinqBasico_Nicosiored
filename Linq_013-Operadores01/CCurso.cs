using System;
using System.Collections.Generic;
using System.Text;

namespace Linq_013_Operadores01
{
    class CCurso
    {
        private string curso;
        private int id;

        public CCurso(string curso, int id)
        {
            this.curso = curso;
            this.id = id;
        }
        public string Curso { get => curso; set => curso = value; }
        public int Id { get => id; set => id = value; }

        public override string ToString()
        {
            return string.Format("Curso => {0}", curso);
        }
    }
}
