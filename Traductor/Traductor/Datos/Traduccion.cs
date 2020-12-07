using System;
using System.IO;
using System.Web;
using System.Xml;
using Traductor.Models;

namespace Traductor.Datos
{
    public class Traduccion
    {

        public static String Traducir(Frase f)
        {
            String TextoTraducido = "";

            //Obtener la ruta del archivo XML
            String archivoDatos = HttpContext.Current.Server.MapPath("~/Datos/FrasesTraducidas.xml");

            //Abrir el archivo XML
            XmlDocument xmlD = new XmlDocument();
            xmlD.Load(archivoDatos);

            //Realizar busqueda de nodos
            XmlNodeList nl = xmlD.SelectNodes("//Frase/Traduccion[../Texto='" + f.FraseEspañol
                + "' and Idioma='" + f.Idioma + "']/TextoTraducido");

            //Verificar que se hayan obtenido nodos de respuesta
            if (nl != null && nl.Count > 0)
            {
                //Leer contenido del nodo
                TextoTraducido = nl.Item(0).FirstChild.Value;
            }

            return TextoTraducido;
        }


        public static byte[] ObtenerAudio(Frase f)
        {
            byte[] bAudio = null;

            if (f.FraseEspañol != null && !f.FraseEspañol.Equals(""))
            {
                //Construir el nombre del archivo de audio con base en la frase
                String archivoAudio = "~/Datos/Audios/" +
                                    f.FraseEspañol.Replace(" ", "")
                                    .Replace("á", "a")
                                    .Replace("é", "e")
                                    .Replace("í", "i")
                                    .Replace("ó", "o")
                                    .Replace("ú", "u")
                                    .Replace("?", "")
                                    .Replace("¿", "") +
                                    "-" + f.Idioma + ".mp3";
                //Obtener el nombre fisico del archivo
                archivoAudio = HttpContext.Current.Server.MapPath(archivoAudio);
                if (File.Exists(archivoAudio))
                {
                    bAudio = File.ReadAllBytes(archivoAudio);
                }
            }
            return bAudio;
        }
    }

}