using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SystemPostaci;


public class PanelPotrzeb : MonoBehaviour
{
  [SerializeField]  List<PotrzebyUI> children;
    [SerializeField] Character testCharacter;


    void Update()
    {
        UpadtePanel(testCharacter);
    }

    public void UpadtePanel(Character testCharacter)
    {
        for(int i = 0; i < children.Count; i++)
        {
            children[i].SetStatus(testCharacter.potrzeby[i].state);
        }
    }
}
