using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{

    public Animator anim_L;
    public Animator anim_R;

    public void Clicked()
    {
        anim_L.SetBool("SceneChange", true);
        anim_R.SetBool("SceneChange", true);
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Home");
    }
}
