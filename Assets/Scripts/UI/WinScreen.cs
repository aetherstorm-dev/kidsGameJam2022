using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public VariableStore store;
    public PlayerState playerState;

    private bool won = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!won)
        {
            if (store.GetInt("alex_done") > 0 && store.GetInt("kid1_done") > 0 && store.GetInt("kid2_done") > 0)
            {
                won = true;
                GetComponent<Animator>().SetTrigger("win");
            }
        }
    }
}
