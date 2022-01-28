using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouching : IMoveState
{

    public IMoveState UpdateState(GameObject upperBody, GameObject body, Vector3 input )
    {
        if (input.Equals(Vector3.up))
        {
            upperBody.transform.Translate(Vector3.up);
            return new Standing();
        }
        return this;
    }
}
