using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace RegistroPersonasT.MODELS
{
    public class PersonasModels
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }

        [MaxLength(50)]
        public string nombres { get; set; }

        [MaxLength(50)]
        public string apellidos { get; set; }
        public double edad { get; set; }

        [MaxLength(150)]
        public string correo { get; set; }

        [MaxLength(150)]
        public string direccion { get; set; }
    }
}
