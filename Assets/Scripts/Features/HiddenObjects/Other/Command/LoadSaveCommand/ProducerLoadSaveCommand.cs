public class ProducerLoadSaveCommand : ILoadSaveCommand
{
    private IClickCommand _producerClickCommand;

    public ProducerLoadSaveCommand(IClickCommand producerClickCommand)
    {
        _producerClickCommand = producerClickCommand;
    }

    public void LoadSave(string key, SavingService savingService)
    {
        if (savingService.TryLoadSaveData(key, out string json))
        {
            _producerClickCommand.Execute();
        }
    }
}
