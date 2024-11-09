using Assets.Scripts.Features.AssetLoader;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HiddenObjectUI : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _label;

    private AssetsLoaderService _assetsLoaderService;

    [Inject]
    private void Constructor(AssetsLoaderService assetsLoaderService)
    {
        _assetsLoaderService=assetsLoaderService;
    }

    public  async void Setup(string maxHiddenObject, string id)
    {
        _label.text = $"{0}/{maxHiddenObject}";
        _icon.sprite =await _assetsLoaderService.LoadAsset<Sprite>(id);
    }
}
