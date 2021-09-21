using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBird : Bird
{
    public float explodeRadius = 1.38f;
    public float force = 350f;

    public LayerMask LayerToHit;

    public GameObject efekLedakan;

    public override void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
        Explode();
    }

    void Explode(){
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, explodeRadius, LayerToHit);

        foreach(Collider2D obj in objects){
            Vector2 arah = obj.transform.position - transform.position;

            obj.GetComponent<Rigidbody2D>().AddForce(arah * force);
            if(obj.tag == "Enemy"){
                Enemy musuh = obj.GetComponent<Enemy>();
                musuh.Mati();
            }
        }
        GameObject ledak = Instantiate(efekLedakan, transform.position, Quaternion.identity);
        Destroy(ledak, 5);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explodeRadius);
    }
}
