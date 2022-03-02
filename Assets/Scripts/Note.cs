using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum NoteType
{
    None,
    Red,
    Blue
}
public class Note : MonoBehaviour
{
   

    public NoteType noteType;
    
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Vector2.left*7; 
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("NoteDestroyer"))
        {
            Debug.Log("Враг Атакует");
            
            Player.instance.myUnit.GetDamage(EnemyManager.instance.newEnemy.stats.damage);
            
            Destroy(gameObject);
            
        }
    }
}
