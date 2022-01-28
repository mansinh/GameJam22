using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveState 
{
    IMoveState UpdateState(GameObject upperBody, GameObject body, Vector3 input);
}
