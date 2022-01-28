using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform shootFrom;
    [SerializeField] GameObject upperBody;
    [SerializeField] float shootSpeed;
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] Controls controls;
    public IMoveState moveState;

    private void Start()
    {
        moveState = new Standing();
    }

    void Update()
    {
        if (Input.GetKeyDown(controls.up)) 
        {
            moveState = moveState.UpdateState(upperBody, gameObject, Vector3.up);
        }
        else if (Input.GetKeyDown(controls.down)) 
        {
            moveState = moveState.UpdateState(upperBody, gameObject, Vector3.down);
        }
        
        if (Input.GetKeyDown(controls.left))
        {
            Shoot(Vector3.left);
        }
        else if (Input.GetKeyDown(controls.right))
        {
            Shoot(Vector3.right);
        }
    }

    void Shoot(Vector3 direction) 
    {
        transform.right = direction;
        Projectile projectile = Instantiate(projectilePrefab, shootFrom.position, Quaternion.identity);
        projectile.direction = transform.right;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
