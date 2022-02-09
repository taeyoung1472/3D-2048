using System.Collections.Generic;
using UnityEngine.UI;
[System.Serializable]
public class User
{
    public string name;
    public int money;
    public int bestScore;
    public List<int> gotCubeSkin = new List<int>();
    public List<int> gotStageSkin = new List<int>();

    public CubeSkinState skinState = CubeSkinState.NONE;
    public StageSkinState stageState = StageSkinState.NONE;
}