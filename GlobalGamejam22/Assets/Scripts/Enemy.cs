using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform shootFrom;
    [SerializeField] GameObject upperBody;
    [SerializeField] float shootSpeed;
    [SerializeField] Projectile projectilePrefab;

    private PlayerController player;

    const int NONE = 0, ATTACK = 1, DOWN = 2, UP = 3;

    public IMoveState moveState;
  

    private void Start()
    {
        moveState = new Standing();
        player = FindObjectOfType<PlayerController>();
    }




    public void RandomAction() 
    {
        int random = (int)(Random.value*4);
        switch (random)
        {
            case NONE:             
                break;
            case ATTACK: 
                Shoot(player.transform.position-transform.position);             
                break;
            case DOWN:
                moveState = moveState.UpdateState(upperBody, gameObject, Vector3.down);         
                break;
            case UP:
                moveState = moveState.UpdateState(upperBody, gameObject, Vector3.up);
                break;
        }
    }

    void Shoot(Vector3 direction)
    {
        transform.right = direction;
        Projectile projectile = Instantiate(projectilePrefab, shootFrom.position, Quaternion.identity);
        projectile.direction = transform.right;
    }
}
