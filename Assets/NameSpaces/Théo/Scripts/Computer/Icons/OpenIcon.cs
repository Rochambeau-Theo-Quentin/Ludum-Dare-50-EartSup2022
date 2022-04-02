namespace Nazio_LT
{
    public class OpenIcon : ClickableIcon
    {
        public override void Click()
        {
            if (linkedWindow == null) linkedWindow = computer.CreateWindow(type);

            linkedWindow.ChangeState();
        }
    }
}