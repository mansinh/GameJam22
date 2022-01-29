using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DifficultyCurve", menuName = "ScriptableObjects/DifficultyCurve", order = 1)]
public class DifficultyCurve : ScriptableObject
{
    [SerializeField] AnimationCurve dissapationTime;

    public float GetDissapationTime(float round) {
        return dissapationTime.Evaluate(round)/10;
    }
}
