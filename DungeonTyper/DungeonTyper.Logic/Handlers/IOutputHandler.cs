namespace DungeonTyper.Logic.Handlers
{
    public interface IOutputHandler
    {
        void HandleOutput(string outputToHandle);

        string GetOutput();
    }
}