using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{

    public GameObject Hitfield;
    public GameObject QuicktimeEvent;

    public GameObject QTEvent;

    public float width;
    public float height;

    public int Score;

    bool alive = true;

    public float DisipationTime = 2f;

    // Start is called before the first frame update
    void Start(){

        width = Hitfield.GetComponent<BoxCollider2D>().bounds.size.x;
        height = Hitfield.GetComponent<BoxCollider2D>().bounds.size.y;

       Round();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Round() {
        Debug.Log("Round");
        StartCoroutine(BetweenTimer());
    }

    public void Spawn() {
        
        float x = Random.RandomRange(-(width/2), (width/2));
        float y = Random.RandomRange(-(height/2), (height/2));


        float radius = 2;

        Vector2 position = new Vector2(x,y);

        QTEvent = Instantiate(QuicktimeEvent, new Vector3(x,y,0),QuicktimeEvent.transform.rotation);

        QTEvent.transform.localScale = new Vector3(radius, radius, radius);

        Debug.Log(QTEvent);
        Debug.Log("Spawned");
    }

    public IEnumerator Shot() {
        Debug.Log("Shot");
        yield return new WaitForSeconds(0.2f);

        Spawn();

        yield return new WaitForSeconds(DisipationTime);

        if (QTEvent) {
            Destroy(QTEvent);
            Debug.Log("Destroyed by Timeout");
            alive = false;
        } else Debug.Log("There was no Circle");
    }


    public void D() {
        Destroy(QTEvent);
        Score++;
        Debug.Log("Destroyed by click");
        StopAllCoroutines();
        Round();
    }

    public IEnumerator BetweenTimer() {
        Debug.Log("Aim");

        if(((Score%6)==0) && DisipationTime > 0.3f) {
            Debug.Log("Enemy Reloading");
            yield return new WaitForSeconds(4);
            Debug.Log("End of Reloading");
            DisipationTime = DisipationTime -0.1f;}

        float T = Random.RandomRange(0.3f,1.5f);
        Debug.Log(T);
        yield return new WaitForSeconds(T);
        Debug.Log(" end of Aiming");

        StartCoroutine(Shot());
    }
}
