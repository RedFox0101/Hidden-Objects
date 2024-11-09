using UnityEngine;
using Zenject;

public class LevelInitializer : MonoBehaviour
{
    [SerializeField] private BaseObjectView hiddenObjectViewPrefab;
    [SerializeField] private BaseObjectView _producerViewPrefab;
    [SerializeField] private Transform _parent;

    private HiddenObjectFactory _hiddenObjectFactoryService;
    private LevelRepository _levelRepository;

    
    [Inject]
    public void Constructor(HiddenObjectFactory hiddenObjectFactoryService, LevelRepository levelRepository)
    {
        _hiddenObjectFactoryService = hiddenObjectFactoryService;
        _levelRepository = levelRepository;
    }

    public void Start()
    {
        InitLevel();
    }

    private void InitLevel()
    {
        foreach (var hiddenObject in _levelRepository.LevelConfig[0].LevelData.Objects)
        {
            var prefab = hiddenObject.Produces != null ? _producerViewPrefab : hiddenObjectViewPrefab;

            var newObjects = _hiddenObjectFactoryService.Create((prefab, _parent));
            newObjects.Setup(hiddenObject);
        }
    }
}
