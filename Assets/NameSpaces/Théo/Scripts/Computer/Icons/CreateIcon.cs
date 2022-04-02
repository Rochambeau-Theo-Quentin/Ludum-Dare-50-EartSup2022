namespace Nazio_LT
{
    public class CreateIcon : ClickableIcon
    {
        public override void Click()
        {
            Window _win = computer.CreateWindow(type, path);
        }
    }
}