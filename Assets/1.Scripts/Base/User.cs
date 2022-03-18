using System.Collections.Generic;
using UnityEngine.UI;
[System.Serializable]
public class User
{
    public string name;
    public bool isZingle;
    public int money;
    public int bestScore;
    public StageSkin stageSkin;
    //public List<int> gotCubeSkin = new List<int>();
    //public List<int> gotStageSkin = new List<int>();
}
public enum StageSkin
{
    Custom1,
    Custom2,
    Custom3,
    Custom4,
    Custom5,
    Custom6
}