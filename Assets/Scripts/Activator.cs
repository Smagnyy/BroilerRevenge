using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    bool canPress = false;
    GameObject note;
    SpriteRenderer sprRend;
    //public Color[] colors;
    public NoteType btnType;
    bool activated;
    
    // Start is called before the first frame update
    void Start()
    {
        btnType = NoteType.None;
        sprRend = GetComponent<SpriteRenderer>();
        note = null;
    }

    // Update is called once per frame
    void Update()
    {
        



        if (note!=null)
        {
            if (btnType == note.GetComponent<Note>().noteType && canPress)
            {
                Debug.Log("Игрок атакует");
                Destroy(note);
                EnemyManager.instance.newEnemy.GetDamage(Player.instance.myUnit.stats.damage);
                
                btnType = NoteType.None;
                activated = false;

            }
            else if (btnType != note.GetComponent<Note>().noteType && canPress && btnType!=NoteType.None)
            {
                Debug.Log("Противник атакует!");
                Player.instance.myUnit.GetDamage(EnemyManager.instance.newEnemy.stats.damage);
                Destroy(note);
                btnType = NoteType.None;
                activated = false;
            }
        }




    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Note"))
        {
            canPress = true;
            note = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            canPress = false;
            note = null;
        }
    }

    public void ClickOnRedPanel()
    {
        if (activated)
            return;
        StartCoroutine(ActivateRed());
    }

    public void ClickOnBluePanel()
    {
        if (activated)
            return;
        StartCoroutine(ActivateBlue());
    }
   
    public IEnumerator ActivateRed()
    {        
        activated = true;
        sprRend.color = Color.red;
        if (canPress)
            btnType = NoteType.Red;
        Debug.Log("Нажатие");
        yield return new WaitForSeconds(0.1f);
        sprRend.color = Color.white;
        btnType = NoteType.None;
        activated = false;
    }

    public IEnumerator ActivateBlue()
    {
        activated = true;
        sprRend.color = Color.blue;
        if (canPress)
            btnType = NoteType.Blue;
        
        Debug.Log("Нажатие");
        yield return new WaitForSeconds(0.1f);
        sprRend.color = Color.white;
        btnType = NoteType.None;
        activated = false;
    }

}
