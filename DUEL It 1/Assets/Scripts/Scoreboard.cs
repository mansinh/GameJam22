using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] FloatVariable score;
    [SerializeField] TMP_Text text;
   
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
        score.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "SCORE: " + score.value;
    }
}
