using Assets.Scripts.Config;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Repository", menuName = "Config/Level Repository", order = 0)]
public class LevelRepository : ScriptableObject
{
    [SerializeField] private LevelConfig[] _levelConfig;
    [SerializeField] private int _currentLevelIndex = 0;
    [field: SerializeField] public string LevelScene { get; private set; }

    public LevelConfig CurrentLevelConfig => _levelConfig[_currentLevelIndex];

    public int CurrentLevelIndex => _currentLevelIndex;

    public void NextLevel()
    {
        if (CurrentLevelIndex + 1 < _levelConfig.Length)
        {
            _currentLevelIndex++;
        }
        else
        {
            _currentLevelIndex = 0;
        }
        PlayerPrefs.SetInt(_levelConfig[0].name, _currentLevelIndex);
        PlayerPrefs.Save();
    }

    public string LoadCurrentLevel()
    {
        if (PlayerPrefs.HasKey(_levelConfig[0].name))
        {
            _currentLevelIndex = PlayerPrefs.GetInt(_levelConfig[0].name);
        }
        else
        {
            _currentLevelIndex = 0;
        }
        return CurrentLevelConfig.name;
    }
}
