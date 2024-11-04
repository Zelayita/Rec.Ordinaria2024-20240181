using Refuerzo2024.Model.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refuerzo2024.Model.DTO
{
    internal class DToDocentes : dbContext
    {
        private int idDocente;
        private string nombreDocente;
        private string apellidoDocente;
        private string dUI;

        public int IdDocente { get => idDocente; set => idDocente = value; }
        public string NombreDocente { get => nombreDocente; set => nombreDocente = value; }
        public string ApellidoDocente { get => apellidoDocente; set => apellidoDocente = value; }
        public string DUI { get => dUI; set => dUI = value; }
    }
}
