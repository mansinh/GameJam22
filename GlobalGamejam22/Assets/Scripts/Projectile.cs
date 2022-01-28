using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IDamaging
{
    public Vector3 direction;
    [SerializeField] FloatVariable speed;
    [SerializeField] FloatVariable damage;
    [SerializeField] FloatVariable score;

    void Update()
    {
        transform.Translate(direction*speed.value*Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        if (collision.CompareTag(this.tag))
        {
            score.value++;
        }

        Destroy(gameObject);
    }

    public float GetDamage()
    {
        return damage.value;
    }
}
