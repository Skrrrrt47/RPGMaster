using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{

    public GameObject quest;
    public BoxCollider2D colliderpnj;
    public GameObject first_character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.gameObject.name == "quest_1")
        {
            Destroy(collision.gameObject.GetComponent<CircleCollider2D>());
            quest.SetActive(true);
            StartCoroutine("HideQuest");
        }
        if (collision.gameObject.name == "chest0")
        {
            Destroy(collision.gameObject);
            Destroy(colliderpnj);
            first_character.SetActive(false);
        }
    }
    IEnumerator HideQuest()
    {
        yield return new WaitForSeconds(3);
        quest.SetActive(false);
    }
}
