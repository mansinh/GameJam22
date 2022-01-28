using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : IMoveState
{
    public IMoveState UpdateState(GameObject upperBody, GameObject body, Vector3 input)
    {   
        return this;
    }
}
