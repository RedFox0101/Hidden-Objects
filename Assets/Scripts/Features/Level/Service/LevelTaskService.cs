using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

public class LevelTaskService
{
    private CompositeDisposable _disposable = new CompositeDisposable();
    private LevelRepository _levelRepository;
    private SavingService _savingService;
    private MessageBroker _messageBroker;


    private List<HiddenObjectProgress> _hiddenObjectTasks = new List<HiddenObjectProgress>();

    public List<HiddenObjectProgress> HiddenObjectTasks => _hiddenObjectTasks;

    public LevelTaskService(LevelRepository levelRepository, SavingService savingService, MessageBroker messageBroker)
    {
        _levelRepository = levelRepository;
        _savingService = savingService;
        _messageBroker = messageBroker;
        SubscribeToHiddenObjectMessages();
    }

    public void Initialize()
    {
        _hiddenObjectTasks = new();
        if (_savingService.TryLoadSaveData(_levelRepository.LoadCurrentLevel(), out string json))
        {
            LoadHiddenObjectProgress(json);
        }
        else
        {
            InitializeHiddenObjectProgress();
        }
    }

    private void LoadHiddenObjectProgress(string json)
    {

        var repository = JsonUtility.FromJson<HiddenObjectProgressRepository>(json);
        _hiddenObjectTasks = repository.HiddenObjectProgresses;
    }

    private void InitializeHiddenObjectProgress()
    {
        _hiddenObjectTasks.Clear();
        var result = _levelRepository.CurrentLevelConfig.LevelData.Objects
            .GroupBy(x => x.Produces?.Id ?? x.Id)
            .Select(g => new { Id = g.Key, Count = g.Count() });

        foreach (var obj in result)
        {
            _hiddenObjectTasks.Add(new HiddenObjectProgress
            {
                Id = obj.Id,
                FoundObjectCount = 0,
                MaxFoundObjectCount = obj.Count,
            });
        }
    }


    private void SubscribeToHiddenObjectMessages()
    {
        _messageBroker.Receive<HiddenObjectMessage>()
           .Subscribe(msg =>
           {
               UpdateTaskProgress(msg.MessageContainer);
               SaveProgress();
           }).AddTo(_disposable);
    }

    private void UpdateTaskProgress(HiddenObjectMessageContainer hiddenObjectMessageContainer)
    {
        var task = _hiddenObjectTasks.FirstOrDefault(task => task.Id == hiddenObjectMessageContainer.HiddenObjectData.Id);
        if (task != null)
        {
            task.FoundObjectCount++;
        }

        var allTasksComplete = AreAllTasksComplete();

        if (allTasksComplete)
        {
            _levelRepository.NextLevel();
            InitializeHiddenObjectProgress();
            SaveProgress();
            _messageBroker.Publish(new SceneMessage(null, _levelRepository.LevelScene));
        }
    }

    private void SaveProgress()
    {
        Debug.Log("SaveProgress " + _levelRepository.CurrentLevelConfig.name);
        var json = JsonUtility.ToJson(new HiddenObjectProgressRepository(_hiddenObjectTasks, _levelRepository.CurrentLevelIndex));
        _messageBroker.Publish(new SavingMessage(null, json, _levelRepository.CurrentLevelConfig.name));
    }

    private bool AreAllTasksComplete()
    {
        return _hiddenObjectTasks.All(task => task.FoundObjectCount == task.MaxFoundObjectCount);
    }
}
