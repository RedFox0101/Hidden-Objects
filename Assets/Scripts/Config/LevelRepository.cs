using Assets.Scripts.Config;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Repository", menuName = "Config/Level Repository", order =0)]
public class LevelRepository : ScriptableObject
{
    [field:SerializeField] public LevelConfig[] LevelConfig {  get;private set; }
}
