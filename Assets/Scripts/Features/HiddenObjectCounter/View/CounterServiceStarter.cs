using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class CounterServiceStarter : MonoBehaviour, IServiceStarter
{
    [SerializeField] private Transform _parent;

    private ObjectCounterService _counterService;
    private HiddenObjectUIFactory _hiddenObjectUIFactory;
    [Inject]
    private void Constructor(ObjectCounterService counterService, HiddenObjectUIFactory hiddenObjectUIFactory)
    {
        _counterService = counterService;
        _hiddenObjectUIFactory = hiddenObjectUIFactory;
    }

    public async Task StartService()
    {
        await _hiddenObjectUIFactory.LoadPrefab();
        await _counterService.SetupUIPanel(_parent);
    }

    public void StopService()
    {

    }
}
