using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuisBot.Modelos
{
    [Serializable]
    public class Emocion
    {
        public string Nombre { get; set; }
        public float Score { get; set; }
    }
}