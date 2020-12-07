using System;
using System.ComponentModel.DataAnnotations;

namespace Traductor.Models
{
    public class Frase
    {
        [Required]
        public String FraseEspañol { get; set; }

        [Required]
        public String Idioma { get; set; }

        public String Traduccion { get; set; }

        public Frase(String FraseEspañol, String Idioma)
        {
            this.FraseEspañol = FraseEspañol;
            this.Idioma = Idioma;
        }
    }
}