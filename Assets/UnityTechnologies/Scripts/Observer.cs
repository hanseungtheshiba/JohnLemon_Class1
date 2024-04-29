using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    [Header("�÷��̾� ���ӿ�����Ʈ")]
    [SerializeField]
    private GameObject player;
    [Header("���ӿ��� Ʈ���� ������Ʈ")]
    [SerializeField]
    private GameEnding gameEnding;

    private bool isPlayerInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(player))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.Equals(player))
        {
            isPlayerInRange = false;
        }
    }

    private void Update()
    {
        if(isPlayerInRange)
        {
            Vector3 direction = player.transform.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                if(raycastHit.collider.gameObject.Equals(player))
                {

                }
            }
        }
    }
}
