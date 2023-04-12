using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SystemPostaci;

public class IncreaseNeedOnCollision : MonoBehaviour
{
   public Potrzeby potrzebaToIncrease;
    public float increaseAmount;

    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if (character != null)
        {
            PotrzebyContainer potrzebyContainer = character.potrzeby.Find(p => p.TypPotrzeby == potrzebaToIncrease);
            if (potrzebyContainer != null)
            {
                potrzebyContainer.szybkoscPodnoszenia += increaseAmount;
            }
        }
    }
}
