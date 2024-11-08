using Newtonsoft.Json;
using UnityEngine;

namespace Assets.Scripts.Config
{
    [CreateAssetMenu(menuName = "Config/Level Config", fileName = "Level1", order = 0)]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private TextAsset _levelJson;
        [SerializeField] private LevelData _levelData = new();

        private void OnValidate()
        {
            ParseJsonFile();
        }

       
        private void ParseJsonFile()
        {
            Debug.Log("ParseJsonFile");
            if (_levelJson != null)
                _levelData = JsonConvert.DeserializeObject<LevelData>(_levelJson.text);
        }
    }
}