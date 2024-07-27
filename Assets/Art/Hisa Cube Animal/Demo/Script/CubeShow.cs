using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeShow : MonoBehaviour
{
    [SerializeField] float timeTransition;
    float currentTime;

    [SerializeField] SpriteRenderer cubeSpriteObj;
    [SerializeField] Sprite[] cubeSprites;

    int currentIndex;

    void Start()
    {
        currentIndex = 0;
        cubeSpriteObj.sprite = cubeSprites[currentIndex];
        currentTime = timeTransition;
    }

    void Update()
    {
        if(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            currentTime = timeTransition;
            currentIndex = (currentIndex + 1) % cubeSprites.Length;
            cubeSpriteObj.sprite = cubeSprites[currentIndex];
        }
    }
}
