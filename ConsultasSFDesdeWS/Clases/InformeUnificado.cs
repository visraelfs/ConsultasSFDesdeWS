using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultasSFDesdeWS.Clases
{
    class InformeUnificado
    {
        public string ExpedienteProyecto { get; set; }
        public DateTime? FechaDeCierre { get; set; }
        public string Producto { get; set; }
        public string Referencia { get; set; }
        public string EstatusCoS { get; set; }
        public DateTime? FechaActivo { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public DateTime? FechaPorInstalar { get; set; }
        public DateTime? FechaInstalado { get; set; }
        public DateTime? FechaDesinstalado { get; set; }
        public DateTime? FechaDesactivado { get; set; }
        public DateTime? FechaReemplazo { get; set; }
        public DateTime? FechaCancelado { get; set; }
        public DateTime? FechaEntregado { get; set; }
        public DateTime? FechaConluido { get; set; }
    }
}
