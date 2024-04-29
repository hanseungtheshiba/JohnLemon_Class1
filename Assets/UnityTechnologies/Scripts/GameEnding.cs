using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    [Header("���̵� �ð�")]
    [SerializeField]
    private float fadeDuration = 1f;
    [Header("�̹��� ǥ�� �ð�")]
    [SerializeField]
    private float displayImageDuration = 1f;
    [Header("�÷��̾� ���ӿ�����Ʈ")]
    [SerializeField]
    private GameObject player;

    [Header("���� ĵ�����׷�")]
    [SerializeField]
    private CanvasGroup exitBackgroundImageCanvasGroup;
    [Header("���� ĵ�����׷�")]
    [SerializeField]
    private CanvasGroup caughtBackgroundImageCanvasGroup;

    private bool isPlayerExit = false;
    private bool isPlayerCaught = false;
    
    private float timer = 0f;

    private void OnTriggerEnter(Collider other)
    {
        // .Equals() : ==�� ����
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
        // timer = timer + Time.deltaTime�� ����
        timer += Time.deltaTime;

        imageGroup.alpha = timer / fadeDuration;

        if(timer > fadeDuration + displayImageDuration)
        {
            // ���� ����
            Application.Quit();
        }
    }
}
