using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static Door instance;
    public bool close,open;
    public GameObject[] doors;
    public List<GameObject> enemies = new List<GameObject>();
    private bool roomActive;
    public GameObject box;
    public float timeToClose;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Count>0&&roomActive&&open)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i]==null)
                {
                    enemies.RemoveAt(i);
                    i--;
                }
            }
            if (enemies.Count == 0)
            {
                foreach (GameObject door in doors)
                {
                    door.SetActive(false);
                    close = false;
                }
                box.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="player")
        {
            if (close)
            {
                foreach (GameObject door in doors)
                {
                    StartCoroutine(TimeClose());
                    //door.SetActive(true);
                }
            }
            roomActive = true;
        }
    }
    /*private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag=="player")
        {
            StartCoroutine(TimeClose());
            roomActive = false;
        }
    }*/
    IEnumerator TimeClose()
    {
        yield return new WaitForSeconds(1f);
        foreach (GameObject door in doors)
        {
            door.SetActive(true);
        }
    }    
}
