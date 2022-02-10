using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJumpable
{
    void Jump(JumpZone jumpZone, float force, Vector3 direction);
}
