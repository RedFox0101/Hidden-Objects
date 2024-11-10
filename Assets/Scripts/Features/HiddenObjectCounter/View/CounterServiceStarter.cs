using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class CounterServiceStarter : MonoBehaviour, IServiceStarter
{
    [SerializeField] private Transform _parent;

    private ObjectCounterService _counterService;

    [Inject]
    private void Constructor(ObjectCounterService counterService)
    {
        _counterService = counterService;
    }

    public async Task StartService()
    {
        await _counterService.SetupUIPanel(_parent);
    }

    public void StopService()
    {

    }
}
