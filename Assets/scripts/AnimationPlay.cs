using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlay : MonoBehaviour {


 
    IEnumerator Start()
    {
        GetComponent<Animator>().Play("cannon", -1, 0.0f);

        yield return new WaitForSeconds(4);
        print("4");

    }
}
