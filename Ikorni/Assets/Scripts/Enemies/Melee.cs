using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Enemy
{
    public int attackSpeed;
    public int attackRange;
    [HideInInspector]
    public float timeBetweenAttack;

    public CapsuleCollider2D attackRangeCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        float resizedRange = 0.1111111f * attackRange + 0.8888888f;
        Debug.Log(resizedRange);
        timeBetweenAttack = 10/attackSpeed;
        attackRangeCollider.size = new Vector2(resizedRange, resizedRange+1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
