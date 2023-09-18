using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite : MonoBehaviour
{
    public float radius;
    public int damage;
    public float timer;
    public ParticleSystem explosionParticle;
    public GameObject fuse;
    

    // Start is called before the first frame update
    void Start()
    {
        fuse.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Explode();
          
        }
    }
    public void Explode()
    {
        Collider2D[] Explosion = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D collider in Explosion)
        {
            if (collider.gameObject.CompareTag("Enemy"))
            {
                collider.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
        StartCoroutine(ExplotionTimed());
      
    }
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
   
    IEnumerator ExplotionTimed()
    {
        fuse.SetActive(true);
        yield return new WaitForSeconds(timer);
        explosionParticle.Play();
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Explode();
        }
    }

}
