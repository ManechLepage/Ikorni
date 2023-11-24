using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public float cooldown;
    public Sprite icon;
    public bool canUse = true;
    public int ID;
    public virtual void Use()
    {
        StartCoroutine(Cooldown());
    }

    public IEnumerator Cooldown()
    {
        canUse = false;
        yield return new WaitForSeconds(cooldown);
        canUse = true;
    }
}
