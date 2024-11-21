using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigNPCManager : MonoBehaviour
{
    [SerializeField] private GameObject pigNPC;
    [SerializeField] private int health = 0;
    [SerializeField] private GameObject ghostFox;
    [SerializeField] private int damageDoneByGhost = 0;
    [SerializeField] private int damageDelay = 0;

    private bool canDamage;

    // Start is called before the first frame update
    void Start () {
        if (health == 0)
            health = 100;
        if (damageDoneByGhost == 0)
            damageDoneByGhost = 5;
        if (damageDelay == 0)
            damageDelay = 1;

        canDamage = true;
    }

    // Update is called once per frame
    void Update () {
        if (IsTouchingPig () && canDamage) {
            health -= damageDoneByGhost;
            canDamage = false;
        }
        if (health <= 0) {
            Destroy (pigNPC, 3);
        }

        if (!canDamage) {
            StartCoroutine (DamageDelay ());
        }
    }

    private bool IsTouchingPig () {
        return Mathf.Sqrt (Mathf.Pow (ghostFox.transform.position.x - pigNPC.transform.position.x, 2) +
                            Mathf.Pow (ghostFox.transform.position.y - pigNPC.transform.position.y, 2)) > 1;
    }
    private IEnumerator DamageDelay () {
        yield return new WaitForSeconds (damageDelay);
        canDamage = true;
    }
}
