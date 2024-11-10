using System.Collections.Generic;

[System.Serializable]
public class HiddenObjectProgressRepository
{
    public int Level;
    public List<HiddenObjectProgress> HiddenObjectProgresses;


    public HiddenObjectProgressRepository(List<HiddenObjectProgress> hiddenObjectTasks, int level)
    {
        HiddenObjectProgresses = hiddenObjectTasks;
        Level = level;
    }
}
