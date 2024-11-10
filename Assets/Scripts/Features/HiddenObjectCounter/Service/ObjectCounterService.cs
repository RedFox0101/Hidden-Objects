using System.Threading.Tasks;
using UnityEngine;

public class ObjectCounterService
{
    private LevelTaskService _levelTaskService;
    private HiddenObjectUIFactory _hiddenObjectUIFactory;

    public ObjectCounterService(LevelTaskService levelTaskService, HiddenObjectUIFactory hiddenObjectUIFactory)
    {
        _levelTaskService = levelTaskService;
        _hiddenObjectUIFactory = hiddenObjectUIFactory;

    }

    public async Task SetupUIPanel(Transform parent)
    {
        foreach (var task in _levelTaskService.HiddenObjectTasks)
        {
            var hiddenObjectUI = await _hiddenObjectUIFactory.Create(parent);
            hiddenObjectUI.Setup(task.MaxFoundObjectCount,task.FoundObjectCount ,task.Id);
        }
    }
}
