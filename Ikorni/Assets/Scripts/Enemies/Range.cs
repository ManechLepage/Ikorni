using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : Enemy
{
    public int r = 100;
    private Vector2 destination = new Vector2();
    private float angle_of_dir;
    private IEnumerator directionChange;
    private void Start(){
        directionChange = DirectionChange();
        StartCoroutine(directionChange);
    }
    override protected void Update()
    {
        base.Update(); 
        calculateTarget(destination);
    }
    public IEnumerator DirectionChange(){
        while(true){
            angle_of_dir = Random.Range(0f, 360f);
            destination.x = r*Mathf.Cos(angle_of_dir);
            destination.y = r*Mathf.Sin(angle_of_dir);
            Debug.Log(destination);
            yield return new WaitForSeconds(1.5f);
        }
    }
    public void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            Debug.Log("TOUCHE");
            hp -= 1;
        }
    }
}
