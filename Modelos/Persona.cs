using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuisBot.Modelos
{
    [Serializable]
    public class Persona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string FotoURL { get; set; }
    }
}