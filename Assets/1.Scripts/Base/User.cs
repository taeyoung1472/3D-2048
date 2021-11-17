using System.Collections.Generic;

[System.Serializable]
public class User
{
    public string nameTemp;
    public string name;
    public int money;
    public int bestScore;
    public int score;
    public List<int> gotCubeSkin = new List<int>();
    public List<int> gotStageSkin = new List<int>();

    public CubeSkinState skinState = CubeSkinState.NONE;
    public StageSkinState stageState = StageSkinState.NONE;
    public void ChangeName(string temp)
    {
        nameTemp = temp;
        GameManager.Instance.googleSheetManager.Call("Change", 0);
    }
    public void RealChangeName()
    {
        name = nameTemp;
    }
}