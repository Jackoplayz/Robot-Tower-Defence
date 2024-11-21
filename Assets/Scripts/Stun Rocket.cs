using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunRocket : MonoBehaviour
{
    public float speed;
    public float stunDuration;
    public Transform target;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector2 direction = target.position - transform.position;
        float distance = speed * Time.deltaTime;

        if(direction.magnitude <= distance)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distance, Space.World);

    }
    public void HitTarget()
    {
        Turret hitTurret = target.GetComponent<Turret>();
        if(hitTurret != null)
        {
            hitTurret.Stun(stunDuration);

        }
        Destroy(gameObject);

    }
}
