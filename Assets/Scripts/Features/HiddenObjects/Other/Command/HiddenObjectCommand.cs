using UniRx;
public class HiddenObjectCommand : ICommand
{
    private BaseObjectView _baseObjectView;

    public ReactiveCommand<BaseObjectView> ObjectClickCommand;

    public void Execute()
    {
        ObjectClickCommand.Execute(_baseObjectView);
        _baseObjectView.gameObject.SetActive(false);
    }
}
