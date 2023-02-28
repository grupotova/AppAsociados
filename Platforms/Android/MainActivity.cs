using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;

namespace TOVA_APP_ASOCIADOS;

[Activity(Theme = "@style/Maui.SplashTheme", LaunchMode = LaunchMode.SingleTop,  MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    public MainActivity()
    {
        Plugin.Maui.AppInstallHelper.InstallationHelper.Init("com.grupotova.tova_app_asociados.fileprovider");
    }

    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
    {
        Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        base.OnRequestPermissionsResult(
            requestCode,
            permissions,
            grantResults
        );
    }

    protected override void OnNewIntent(Intent intent)
    {
        Plugin.Maui.AppInstallHelper.InstallationHelper.OnNewIntent(intent);
        base.OnNewIntent(intent);
    }

}
