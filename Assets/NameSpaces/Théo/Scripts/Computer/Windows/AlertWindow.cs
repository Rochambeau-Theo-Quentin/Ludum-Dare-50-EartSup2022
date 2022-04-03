using NazioToolKit;

namespace Nazio_LT
{
    public class AlertWindow : Window
    {
        private SoundController sound;

        public override void Init(int _id, OpenIcon _icon, string _path)
        {
            base.Init(_id, _icon, _path);

            sound = FindObjectOfType<SoundController>();

            sound.PlaySound("Alert");
        }
    }
}