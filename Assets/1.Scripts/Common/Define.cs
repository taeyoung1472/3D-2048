using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Define
{
    private static Camera maincam;

    public static Camera MainCam{
        get{
            if(maincam == null){
                maincam = Camera.main;
            }
            return maincam;
        }
    }
}
