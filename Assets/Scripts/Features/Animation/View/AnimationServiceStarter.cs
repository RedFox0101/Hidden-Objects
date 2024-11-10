using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class AnimationServiceStarter : MonoBehaviour, IServiceStarter
{
    [SerializeField] private Transform _parent;
    private AnimationViewFactory _animationViewFactory;

    [Inject]
    private void Constructor(AnimationViewFactory animationViewFactory)
    {
        _animationViewFactory = animationViewFactory;
    }

    public async Task StartService()
    {
       await _animationViewFactory.LoadPrefab(_parent);
    }

    public void StopService()
    {
        
    }
}
