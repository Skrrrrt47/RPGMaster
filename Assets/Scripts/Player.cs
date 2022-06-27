using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : character
{
    

    Animator anim;

    [SerializeField]
    private Stats health;

    [SerializeField]
    private Stats mana;

    private float initMana = 50;

    private float initHealt = 100;

    protected Coroutine attackRoutine;


    [SerializeField]
    private Transform[] exitPoints;

    private int exitIndex;

    private SpellBook spellbook;

    [SerializeField]
    private Block[] blocks;
    private Transform target;

    public Transform MyTarget { get; set; }

    // Start is called before the first frame update
    protected override void Start()
    {
        spellbook = GetComponent<SpellBook>();
        health.Initialize(initHealt,initHealt);
        mana.Initialize(initMana,initMana);

        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        GetInput();
        //SetParam();
        base.Update();
        
    }


    private void GetInput() {
        direction = Vector2.zero;

        /// DEBUGGING
        ///
        if (Input.GetKeyDown(KeyCode.I))
        {
            health.MyCurrentValue -= 10;
            mana.MyCurrentValue -= 10;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            health.MyCurrentValue += 10;
            mana.MyCurrentValue += 10;
        }

        if (Input.GetKey(KeyCode.Z)) {
            exitIndex = 0;
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.D)) {
            exitIndex = 1;
            direction += Vector2.right;
        }
        if (Input.GetKey(KeyCode.S)) {
            exitIndex = 2;
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.Q)) {
            exitIndex = 3;
            direction += Vector2.left;
        }
    }

    private IEnumerator Attack(int spellIndex) {
        Spell newSpell = spellbook.CastSpell(spellIndex);
        yield return new  WaitForSeconds(newSpell.MyCastTime);
        SpellScript s = Instantiate(newSpell.MySpellPrefab, transform.position, Quaternion.identity).GetComponent<SpellScript>();
        s.MyTarget = MyTarget;
    }

    public void CastSpell(int spellIndex) {
        Block();
             if (MyTarget != null  && InLineofSight())
             {
                attackRoutine = StartCoroutine(Attack(spellIndex));
             }
    }

    private bool InLineofSight() {
        Vector3 taregtDir = (MyTarget.transform.position - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position,taregtDir,Vector2.Distance(transform.position,MyTarget.transform.position),512);
        if (hit.collider == null) {
            return true;
        }
        return false;
    }

    private void Block() {
        foreach (Block b in blocks) {
            b.Deactivate();
        }

        blocks[exitIndex].Activate();
    }
     private void SetParam()
    {
        if (direction == Vector2.zero) // sur place
        {
            anim.SetInteger("direction",0);
        }
        else if (direction == Vector2.down) // bas
        {
            anim.SetInteger("direction", 1);
        }
        else if (direction == Vector2.right) // droite
        {
            anim.SetInteger("direction", 2);
            anim.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (direction == Vector2.left) // gauche
        {
            anim.SetInteger("direction", 2);
            anim.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (direction == Vector2.up) // haut
        {
            anim.SetInteger("direction", 3);
        }
    }
}
