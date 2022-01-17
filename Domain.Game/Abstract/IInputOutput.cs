namespace Domain.Game.Abstract
{
    public interface IInputOutput
    {
        string Input();
        void Output(string text = "");
    }
}
