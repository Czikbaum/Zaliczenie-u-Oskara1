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
        public List<PotrzebyContainer> potrzeby;
        public NavMeshAgent navMeshAgent;
        public float threshold = 30f;
        public Transform objectToMoveTowards;
        public float szybkoscPodnoszenia;
        public float szybkoscSpadania = 1f;
        public bool isSatisfied = false;
        public Potrzeby TypPotrzeby;

        public PotrzebyContainer(Potrzeby potrzeby)
        {
            TypPotrzeby = potrzeby;
        }

        public void Spadanie()
        {
            if (!isSatisfied) {
                state -= szybkoscSpadania * Time.deltaTime;
                ClampState();
            }
        }

        private void ClampState()
        {
            state = Mathf.Clamp(state, 0f, 100f);
        }

        public void Regenerowanie()
{
    if (!isSatisfied)
    {
        state += szybkoscPodnoszenia * Time.deltaTime;
        if (state >= 100f)
        {
            state = 100f;
            isSatisfied = true;
        }
    }
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
        public NavMeshAgent navMeshAgent;
        public Animator AIAnimator;
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
            CheckNeeds();

            if(navMeshAgent.velocity.sqrMagnitude > 0)
            {
                AIAnimator.SetBool("Ruszasie",true);
            } else if (navMeshAgent.velocity.sqrMagnitude == 0)
            {
                AIAnimator.SetBool("Ruszasie",false);
            }
        }

        private void PotrzebySpadanie()
        {
            for (int i = 0; i < PotrzebyIlosc; i++)
            {
                potrzeby[i].Spadanie();
                potrzeby[i].Regenerowanie();
            }
        }

       private IEnumerator ResetIsSatisfied(PotrzebyContainer need)
{
    yield return new WaitForSeconds(2f);
    need.isSatisfied = false;
}

private void CheckNeeds()
{
    foreach (PotrzebyContainer need in potrzeby)
    {
        if (!need.isSatisfied && need.state < need.threshold)
        {
            need.navMeshAgent.SetDestination(need.objectToMoveTowards.position);
            if (Vector3.Distance(transform.position, need.objectToMoveTowards.position) < 1f)
            {
                need.isSatisfied = true;
                need.szybkoscSpadania = 0f;
                need.szybkoscPodnoszenia = 0f;
            }
            break;
        }
        else if (need.isSatisfied)
        {
            need.szybkoscPodnoszenia = 0f;
            StartCoroutine(ResetIsSatisfied(need));
        }
    }
}
    }
}
