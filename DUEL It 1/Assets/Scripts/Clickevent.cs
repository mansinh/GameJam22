using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickevent : MonoBehaviour
{
    public GameObject Circle;
    Interactables INC;

    // Start is called before the first frame update
    private void Start() {
        INC = FindObjectOfType<Interactables>();
    }

    private void OnMouseDown() {
        INC.D();
    }
}
