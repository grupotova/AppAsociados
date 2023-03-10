using TOVA_APP_ASOCIADOS.Models.Firebase;
using Firebase.Database;
using Firebase.Database.Query;
using Org.Apache.Http.Authentication;

namespace TOVA_APP_ASOCIADOS.Helpers
{
    public class FirebaseRTDB
    {

        // Autentificacion
        private static string authKey = Constants.FirebaseAuthKey; // Key

        // Firebase Cliente
        FirebaseClient firebaseClient = new FirebaseClient(
            Constants.FirebaseUrl,
            new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(authKey)
            }
        );

        public FirebaseRTDB() {

        }

        public async void NuevaPosicion(int UsuarioId, string CoordenadasGPS)
        {
            // var CheckItem = await firebaseClient.Child("LiveTracking").Child(UsuarioId.ToString()).OnceAsync<>;
            //if (CheckItem) { }
            /*
            var NewItem = await firebaseClient.Child("LiveTracking").Child(UsuarioId.ToString()).PostAsync(
                new LiveTracking()
                {
                    CoordenadasGPS = CoordenadasGPS,
                    UltimaActualizacion = DateTime.Now,
                }
            );
            */
        }
    }
}
