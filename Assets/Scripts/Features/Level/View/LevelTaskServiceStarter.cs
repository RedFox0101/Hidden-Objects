using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class LevelTaskServiceStarter : MonoBehaviour, IServiceStarter
{
    private LevelTaskService _levelTaskService;

    [Inject]
    private void Constructor(LevelTaskService objectInitializer) => _levelTaskService = objectInitializer;


    public async Task StartService() => _levelTaskService.Initialize();

    public void StopService()
    {

    }
}
