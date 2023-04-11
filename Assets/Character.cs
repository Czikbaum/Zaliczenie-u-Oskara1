
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SystemPostaci
{

    [System.Serializable]
    public class PotrzebyContainer
    {
        [Range(0f, 100f)]
        public float state;
        public float szybkoscPodnoszenia;
        public float szybkoscSpadania = 1f;
        public Potrzeby TypPotrzeby;
        public PotrzebyContainer(Potrzeby potrzeby)
        {
            TypPotrzeby = potrzeby;
        }


        public void Spadanie()
        {
            state -= szybkoscSpadania * Time.deltaTime;
            ClampState();
        }

        private void ClampState()
        {
            state = Mathf.Clamp(state, 0f, 100f);
        }

        public void Regenerowanie()
        {
            state += szybkoscPodnoszenia * Time.deltaTime;
        }
    }




    public enum Potrzeby
    {
        Glod,
        Pragnienie,
        Zabawa,
        Pecherz,
        Higiena,
        Energia,
    }
    public class Character : MonoBehaviour
    {

        public List<PotrzebyContainer> potrzeby;

        public const int PotrzebyIlosc = 6;


        [ContextMenu("Zacznij liste potrzeb")]


        public void InitPotrzeby()
        {
            potrzeby = new List<PotrzebyContainer>();
            for (int i = 0; i < PotrzebyIlosc; i++)
            {
                potrzeby.Add(new PotrzebyContainer((Potrzeby)i));
            }
        }


        private void Update()
        {
            PotrzebySpadanie();
            
        }

        private void PotrzebySpadanie()
        {
            for (int i = 0; i < PotrzebyIlosc; i++)
            {
                potrzeby[i].Spadanie();
                potrzeby[i].Regenerowanie();
            }
        }
    }
}