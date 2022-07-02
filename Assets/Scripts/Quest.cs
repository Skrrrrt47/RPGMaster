using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;

public class Quest : MonoBehaviour
{

    public GameObject quest;
    public BoxCollider2D colliderpnj;
    public GameObject first_character;
    // Start is called before the first frame update


    public Text text;

    public Button btn;

    void Start()
    {
        Button but = btn.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
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
    public void TaskOnClick() {
        var client = new SecretClient(vaultUri: new Uri("https://keyvaultalgebra2021.vault.azure.net/"),
        credential: new VisualStudioCodeCredential());

        var secret = client.GetSecret("TestAlgebraDevOps2022");
        if (secret != null)
        {
            Debug.Log(secret.Value.Value);
            StartCoroutine(ShowNotification(secret.Value.Value,10));
        }
    }

    IEnumerator ShowNotification(string txt,int time) {

            text.text = txt;
            yield return new WaitForSeconds(time);
            text.text = "";
    }
}
