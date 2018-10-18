using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using LuisBot.Helpers;
using LuisBot.Modelos;
using System.IO;

namespace LuisBot.Servicios
{
    public static class ServicioFace
    {
        public static async Task<Emocion> ObtenerEmocion(Stream foto)
        {
            Emocion emocion = null;

            try
            {
                if (foto != null)
                {
                    var clienteFace = new FaceServiceClient(Constantes.FaceApiKey, Constantes.FaceApiURL);
                    var atributosFace = new FaceAttributeType[] { FaceAttributeType.Emotion, FaceAttributeType.Age };

                    using (var stream = foto)
                    {
                        Face[] rostros = await clienteFace.DetectAsync(stream, false, false, atributosFace);

                        if (rostros.Any())
                        {
                            var analisisEmocion = rostros.FirstOrDefault().FaceAttributes.Emotion.ToRankedList().FirstOrDefault();
                            emocion = new Emocion()
                            {
                                Nombre = analisisEmocion.Key,
                                Score = analisisEmocion.Value
                            };
                        }

                        foto.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return emocion;
        }
    }
}