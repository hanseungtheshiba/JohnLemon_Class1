using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    [Header("페이드 시간")]
    [SerializeField]
    private float fadeDuration = 1f;
    [Header("이미지 표시 시간")]
    [SerializeField]
    private float displayImageDuration = 1f;
    [Header("플레이어 게임오브젝트")]
    [SerializeField]
    private GameObject player;

    [Header("성공 캔버스그룹")]
    [SerializeField]
    private CanvasGroup exitBackgroundImageCanvasGroup;
    [Header("실패 캔버스그룹")]
    [SerializeField]
    private CanvasGroup caughtBackgroundImageCanvasGroup;

    private bool isPlayerExit = false;
    private bool isPlayerCaught = false;
    
    private float timer = 0f;

    private void OnTriggerEnter(Collider other)
    {
        // .Equals() : ==과 같음
        if(other.gameObject.Equals(player))
        {
            isPlayerExit = true;
        }
    }

    private void Update()
    {
        if(isPlayerExit == true)
        {
            EndLevel(exitBackgroundImageCanvasGroup);
        }
        else if(isPlayerCaught == true)
        {
            EndLevel(caughtBackgroundImageCanvasGroup);
        }
    }

    private void EndLevel(CanvasGroup imageGroup)
    {
        // timer = timer + Time.deltaTime과 같음
        timer += Time.deltaTime;

        imageGroup.alpha = timer / fadeDuration;

        if(timer > fadeDuration + displayImageDuration)
        {
            // 게임 종료
            Application.Quit();
        }
    }
}
