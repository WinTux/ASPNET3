using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ASPNET3.Herramientas
{
    public static class Conversor
    {
        public static void GuardarObjeto(
            this ISession sesion, string llave, object valor) {
            sesion.SetString(llave,JsonConvert.SerializeObject(valor));
        }
        public static T RecuperarObjeto<T>(
            this ISession sesion, string llave) {
            var valor = sesion.GetString(llave);
            return valor == null ? default(T)
                : JsonConvert.DeserializeObject<T>(valor);
        }
        // Persona pp = Conversor.RecuperarObjeto<Persona>("per");
    }
}
