﻿using ApiDevsuCMunoz.Domain.Common;

namespace ApiDevsuCMunoz.Domain
{
    public class Persona : BaseDomainModel{
        public string? Nombre { get; set; }
        public string? Genero { get; set; }
        public int Edad { get; set; }
        public string? Identificacion { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }

    }
}
