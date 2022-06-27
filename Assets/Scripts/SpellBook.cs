using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellBook : MonoBehaviour
{
    [SerializeField]
    private Image castingBar;

    [SerializeField]
    private Spell[] spells;

    private Coroutine spellRoutine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Spell CastSpell(int index) {
        castingBar.fillAmount = 0;

        castingBar.color = spells[index].MyBarColor;


       spellRoutine = StartCoroutine(Progress(index));

        return spells[index];
    }

    private IEnumerator Progress(int index) {
        float timeLeft = Time.deltaTime;

        float rate = 1.0f/spells[index].MyCastTime;

        float progress = 0.0f;

        while (progress <= 1.0)
        {
            castingBar.fillAmount = Mathf.Lerp(0,1,progress);
            progress += rate * Time.deltaTime;
            yield return null;
        }
    }

    void StopCasting()
    {
        if(spellRoutine != null)
        {
            StopCoroutine(spellRoutine);
            spellRoutine = null;
        }
    }
}
