using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class FishBook : MonoBehaviour
{
    public Image fishImage;
    public Image[] fishImagesInPage;
    public Sprite[] fishImages1; // 물고기 이미지1 배열
    public Sprite[] fishImages2; // 물고기 이미지2 배열

    //private List<int> acquiredFish; // 획득한 물고기 목록
    public List<int> acquiredFish; // 획득한 물고기 목록

    private void Start()
    {
        //fishImage = new Image();
        //fishImage.sprite = fishImages1[0]; // 초기 이미지1 설정

        acquiredFish = new List<int>();
        //acquiredFish.Add(4);
    }

    public void UpdateFishImage(int fishIndex, bool caught)
    {
        if (!caught)
        {            
            Debug.Log("우우우웅우우우우~~~ 놓쳤어 ㅜㅜ");
            // 필요한 코드 추가 (놓쳤다는 UI 이미지 처리등)
            return;
        }

        Debug.Log("111111111111111111111111");
        fishImage = fishImagesInPage[fishIndex];

        Debug.Log("2222222222222222222222");

        // 이미 획득한 물고기인지 확인
        if (!acquiredFish.Contains(fishIndex))
        {

            Debug.Log("333333333333333333333");
            fishImage.sprite = fishImages1[fishIndex]; // 이미지1 (잡은 색상 물고기)로 업데이트

            /*
            if (caught)
            {
                fishImage.sprite = fishImages1[fishIndex]; // 이미지1 (잡은 색상 물고기)로 업데이트
            }
            else
            {
                fishImage.sprite = fishImages2[fishIndex]; // 이미지2 (어두운 윤곽선 물고기, 사용안함)로 업데이트
            }
            */

            Debug.Log("4444444444444444444");
            acquiredFish.Add(fishIndex); // 획득한 물고기 목록에 추가

            Debug.Log("555555555555555555");
        }
        gameObject.SetActive(false);
    }
}