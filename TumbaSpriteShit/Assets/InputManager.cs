using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    enum state
    {
        sprites
    }
    [SerializeField] GameObject[] sprites;
    int num = 0;
    Animator anim;
    AnimationClip[] anims;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            Next();
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            Prev();
        else if (Input.GetKeyDown(KeyCode.Space))
            Action();
        else if (Input.GetKeyDown(KeyCode.LeftControl))
            Action2();
    }
    void Next()
    {
        num++;
        if (num > sprites.Length - 1) num = 0;
        SetActive();
    }
    void Prev()
    {
        num--;
        if (num < 0) num = sprites.Length - 1;
        SetActive();
    }
    void SetActive()
    {
        foreach (GameObject go in sprites)
            go.SetActive(false);

        GameObject active = sprites[num];
        active.SetActive(true);
        anims = null;
        anim = active.GetComponentInChildren<Animator>();
        if(anim != null)
            anims = anim.runtimeAnimatorController.animationClips;
    }
    void Action()
    {
        StartAction();
    }
    void Action2()
    {
        StartAction();
    }
    int lastAnim = -1;
    void StartAction()
    {
        if (anims == null) return;
        if (anims.Length < 2) return;
        int rand = Random.Range(0, anims.Length);
        if (lastAnim == rand)
            StartAction();
        else
        {
            lastAnim = rand;
            anim.Play(anims[rand].name);
        }
        //foreach (AnimationClip ac in anim.runtimeAnimatorController.animationClips)
        //{
        //    // look at all the animation clips here!
        //}
    }
}
