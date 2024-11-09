using System.Linq;
using UnityEngine;

public class ObjectCounterService
{
    private LevelRepository _levelRepository;
    private HiddenObjectUIFactory _hiddenObjectUIFactory;

    public ObjectCounterService(LevelRepository levelRepository, HiddenObjectUIFactory hiddenObjectUIFactory)
    {
        _levelRepository = levelRepository;
        _hiddenObjectUIFactory = hiddenObjectUIFactory;

    }

    public async void SetupUIPanel(Transform parent)
    {

        var result = _levelRepository.LevelConfig[0].LevelData.Objects
            .GroupBy(x => x.Produces?.Id ?? x.Id)
            .Select(g => new { Id = g.Key, Count = g.Count() });


        foreach (var item in result)
        {
            Debug.Log($"{item.Id} - {item.Count}");
            var hiddenObjectUI = await _hiddenObjectUIFactory.Create(parent);
            hiddenObjectUI.Setup(item.Count.ToString(), item.Id);
        }
    }
}
