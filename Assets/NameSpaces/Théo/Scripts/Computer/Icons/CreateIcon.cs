namespace Nazio_LT
{
    public class CreateIcon : ClickableIcon
    {
        public override void Click()
        {
            //Instantie lui meme
            //Reset l'objet
            Window _win = computer.CreateWindow(type);
            //link l'ojet a un nouveau bouton
        }
    }
}