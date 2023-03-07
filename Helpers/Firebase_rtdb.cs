using TOVA_APP_ASOCIADOS.Models.Firebase;
using Firebase.Database;
using Firebase.Database.Query;
using Org.Apache.Http.Authentication;

namespace TOVA_APP_ASOCIADOS.Helpers
{
    public class Firebase_rtdb
    {

        private static string auth = "hOvrSzPdSRQFJK2GuPUs0ifMSgRnNriZnUyf0dk6"; // your app secret
        FirebaseClient firebaseClient = new FirebaseClient(
            "https://tova-5daf5-default-rtdb.firebaseio.com/",
            new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(auth)
            }
        );

        public Firebase_rtdb() {

        }

        public async void NuevaPosicion(int UsuarioId, string CoordenadasGPS)
        {
            /*
            var rtdb = await firebaseClient.Child("LiveTracking").Child("pedro").PostAsync(
                new LiveTracking()
                {
                    CoordenadasGPS = "8.97560662823808, -79.50792073667883",
                    UltimaActualizacion = DateTime.Now,
                }
            );
            */
            /*
            var rtdb = await firebaseClient.Child("LiveTracking").PostAsync(
                new List<string[]>()
                {
                    "hola" = ""
                }
            ); ;
            */
        }
    }
}
