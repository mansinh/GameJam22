using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Standing : IMoveState
{
    public IMoveState UpdateState(GameObject upperBody, GameObject body, Vector3 input)
    {
        if (input.Equals(Vector3.down))
        {
            upperBody.transform.Translate(Vector3.down);
            return new Crouching();
        }
        return this;
    }
}
