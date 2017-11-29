using Android.Content;
using Android.Net;
using Android.Telephony;
using System.Linq;
using Xamarin.Forms;
using XF.Recursos.API;
using XF.Recursos.Droid;

[assembly: Dependency(typeof(Ligar_Android))]
namespace XF.Recursos.Droid
{
    public class Ligar_Android : ILigar
    {
        public bool Discar(string telefone)
        {

            //context eh o forme corrente
            //so utilizo o as Activity quando preciso de uma resposta
            var context = Forms.Context;
            if (context == null) return false;

            //encapsula um comportamento desse objeto e dispara para o SO
            var intent = new Intent(Intent.ActionCall);
            intent.SetData(Uri.Parse("tel:" + telefone));

            //disponibilidade
            if (IsIntentAvailable(context, intent))
            {
                //garantiu a disponibilidade, dispara a intençao
                context.StartActivity(intent);
                return true;
            }

            return false;
        }

        public static bool IsIntentAvailable(Context context, Intent intent)
        {
            var packageManager = context.PackageManager;

            var list = packageManager.QueryIntentServices(intent, 0)
                .Union(packageManager.QueryIntentActivities(intent, 0));

            if (list.Any()) return true;

            var manager = TelephonyManager.FromContext(context);
            return manager.PhoneType != PhoneType.None;
        }
    }
}