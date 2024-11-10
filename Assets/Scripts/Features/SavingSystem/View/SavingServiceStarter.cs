using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class SavingServiceStarter : MonoBehaviour, IServiceStarter
{
    private ProducerSaveDataAdapter _producerSavingAdapter;
    private HiddenObjectSaveDataAdapter _hiddenObjectSaveDataAdapter;

    [Inject]
    private void Constructor(ProducerSaveDataAdapter dataAdapter, HiddenObjectSaveDataAdapter hiddenObjectSaveDataAdapter)
    {
        _producerSavingAdapter = dataAdapter;
        _hiddenObjectSaveDataAdapter = hiddenObjectSaveDataAdapter;
    }

    public async Task StartService()
    {
        _producerSavingAdapter.Setup();
        _hiddenObjectSaveDataAdapter.Setup();
    }

    public void StopService()
    {
        
    }
}
