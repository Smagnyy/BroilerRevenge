using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public static NoteSpawner instance;

    public Note[] prefabNotes;
    public Transform parent;
    public Transform spawnPoint;
    

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
    }

    
    public IEnumerator Spawn(int length)
    {
        for (int i = 0; i < length; i++)
        {
            yield return new WaitForSeconds(0.2f);
            int rand = Random.Range(0, 2);
            Note newNote = Instantiate(prefabNotes[rand], parent);
            
            newNote.transform.position = spawnPoint.position;

        }

    }

}

