using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class FishBook : MonoBehaviour
{
    public Image fishImage;
    public Image[] fishImagesInPage;
    public Sprite[] fishImages1; // ����� �̹���1 �迭
    public Sprite[] fishImages2; // ����� �̹���2 �迭

    //private List<int> acquiredFish; // ȹ���� ����� ���
    public List<int> acquiredFish; // ȹ���� ����� ���

    private void Start()
    {
        //fishImage = new Image();
        //fishImage.sprite = fishImages1[0]; // �ʱ� �̹���1 ����

        acquiredFish = new List<int>();
        //acquiredFish.Add(4);
    }

    public void UpdateFishImage(int fishIndex, bool caught)
    {
        if (!caught)
        {            
            Debug.Log("����������~~~ ���ƾ� �̤�");
            // �ʿ��� �ڵ� �߰� (���ƴٴ� UI �̹��� ó����)
            return;
        }

        Debug.Log("111111111111111111111111");
        fishImage = fishImagesInPage[fishIndex];

        Debug.Log("2222222222222222222222");

        // �̹� ȹ���� ��������� Ȯ��
        if (!acquiredFish.Contains(fishIndex))
        {

            Debug.Log("333333333333333333333");
            fishImage.sprite = fishImages1[fishIndex]; // �̹���1 (���� ���� �����)�� ������Ʈ

            /*
            if (caught)
            {
                fishImage.sprite = fishImages1[fishIndex]; // �̹���1 (���� ���� �����)�� ������Ʈ
            }
            else
            {
                fishImage.sprite = fishImages2[fishIndex]; // �̹���2 (��ο� ������ �����, ������)�� ������Ʈ
            }
            */

            Debug.Log("4444444444444444444");
            acquiredFish.Add(fishIndex); // ȹ���� ����� ��Ͽ� �߰�

            Debug.Log("555555555555555555");
        }
        gameObject.SetActive(false);
    }
}