using TOVA_APP_ASOCIADOS.Models.Firebase;
using Firebase.Database;
using Firebase.Database.Query;

namespace TOVA_APP_ASOCIADOS.Helpers
{
    public class Firebase_rtdb
    {

        FirebaseClient firebaseClient = new FirebaseClient("https://tova-5daf5-default-rtdb.firebaseio.com/");

        public Firebase_rtdb() {

        }

        public async void NuevaPosicion()
        {
            var fif = await firebaseClient.Child("GPS").PostAsync(new LiveTracking()
            {
                Usuario = "rgonzalez",
                CoordenadasGPS = "8.97560662823808, -79.50792073667883"
            });
        }
    }
}
