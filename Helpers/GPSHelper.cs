namespace TOVA_APP_ASOCIADOS.Helpers
{
    public static class GPSHelper
    {
        private const double EarthRadius = 6378137; // Earth's radius in meters

        public static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            double dLat = ToRadians(lat2 - lat1);
            double dLon = ToRadians(lon2 - lon1);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = EarthRadius * c;

            return distance;
        }

        private static double ToRadians(double angle)
        {
            return Math.PI * angle / 180;
        }
    }
}
