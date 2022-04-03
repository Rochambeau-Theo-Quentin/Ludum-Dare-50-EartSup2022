namespace Nazio_LT
{
    public class CMDWindow : Window
    {
        private CMDController cmd;

        public override void Init(int _id, OpenIcon _icon, string _path)
        {
            cmd = GetComponentInChildren<CMDController>();

            base.Init(_id, _icon, _path);
        }

        public override void ChangeState()
        {
            base.ChangeState();

            cmd.enabled = state;
        }

        private void Update()
        {
            cmd.enabled = canvas.sortingOrder == 10 ? false : true;
        }

        public override void Close()
        {
            Window _target = computer.CreateWindow(WindowType.CloseCMD, "Alert");
            computer.SetFirstPlanWindow(_target);

        }
    }
}