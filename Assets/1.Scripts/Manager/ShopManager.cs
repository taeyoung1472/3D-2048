using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CubeSkinState
{
    NONE = 0,
    TAEYOUNG = 1,
    LENGTH,
}
public enum StageSkinState
{
    NONE = 0,
    TAEYOUNG = 1,
    LENGTH,
}
public class ShopManager : MonoSingleton<ShopManager>
{
    public CubeSkinState CubeSkin
    {
        get
        {
            return playerCubeSkin;
        }
    }
    public StageSkinState StageSkin
    {
        get
        {
            return playerStageSkin;
        }
    }
    private CubeSkinState playerCubeSkin = CubeSkinState.NONE;
    private StageSkinState playerStageSkin = StageSkinState.NONE;

    #region 이벤트
    private void Start() {
        //TODO : 시작할때 for문으로 LIST와 맞는 숫자를 가진애들의 ispurchase를 켜준다.
        //TODO : isPurchase를 켜줬으니 Refresh해준다
    }
    #endregion
}
