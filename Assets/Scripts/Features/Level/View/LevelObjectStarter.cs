using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class LevelObjectStarter : MonoBehaviour,IServiceStarter
{
    [SerializeField] private Transform _parent;

    private ObjectInitializeService _objectInitializer;

    [Inject]
    private void Constructor(ObjectInitializeService objectInitializer) => _objectInitializer = objectInitializer;


    public async Task StartService() => await _objectInitializer.InitializeObjects(_parent);

    public void StopService()
    {
        
    }
}
