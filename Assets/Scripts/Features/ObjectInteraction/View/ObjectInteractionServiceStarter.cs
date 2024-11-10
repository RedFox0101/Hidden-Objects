using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class ObjectInteractionServiceStarter : MonoBehaviour, IServiceStarter
{
    private ObjectInteractionService _interactionService;

    [Inject]
    private void Constructor(ObjectInteractionService interactionService)
    {
        _interactionService = interactionService;
    }
    public async Task StartService()
    {
        _interactionService.Start();
    }

    public void StopService()
    {
       
    }
}
