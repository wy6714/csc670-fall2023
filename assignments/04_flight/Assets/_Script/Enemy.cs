using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float speed = 1f;

    private void Start()
    {
       
    }

    private void Update()
    {
        
        float fromplayer = Vector3.Distance(transform.position, player.position);
        //Debug.Log(fromplayer);

        if (fromplayer < 3f)
        {
            Vector3 direction = (transform.position-player.position).normalized;
            direction.y = 0f;
            transform.position = Vector3.Lerp(transform.position, player.position, speed * Time.deltaTime);
            Vector3 WonderPosition = transform.position;

        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("playerAttack"))
        {
            Destroy(gameObject);
            
        }
    }


}
