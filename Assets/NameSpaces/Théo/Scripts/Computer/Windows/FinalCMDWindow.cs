namespace Nazio_LT
{
    public class FinalCMDWindow : Window
    {
        public override void Close()
        {
            Window _target = computer.CreateWindow(WindowType.CloseCMD, "Alert");
            computer.SetFirstPlanWindow(_target);

        }
    }
}