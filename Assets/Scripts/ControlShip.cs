using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlShip : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MakeShipSurface());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MakeShipSurface()
    {
        yield return new WaitForSeconds(1.0f);
        anim.SetTrigger("surface");
    }
}
