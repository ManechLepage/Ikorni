using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [Header("Ability")]
    public float cooldown;
    public Sprite icon;
    public bool canUse = true;
    public int ID;
    private AbilityManager abilityUI;

    public virtual void Start()
    {
        abilityUI = gameObject.GetComponent<AbilityManager>();
        abilityUI.iconImage.sprite = icon;
        canUse = true;
    }
    public virtual void Use()
    {
        abilityUI.StartAnimation(cooldown / 32);
        StartCoroutine(Cooldown());
    }

    public IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown); canUse = true;
    }
}
