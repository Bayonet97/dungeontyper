namespace DungeonTyper.Logic
{
    public interface IOutputHandler
    {
        void HandleOutput(string outputToHandle);

        string GetOutput();
    }
}