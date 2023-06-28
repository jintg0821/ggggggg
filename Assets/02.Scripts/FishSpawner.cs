using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject[] fishPrefabs; // 물고기 프리팹 배열
    public GameObject[] fishPrefabs0; // 물고기 프리팹 배열
    public GameObject[] fishPrefabs1; // 물고기 프리팹 배열
    public GameObject[] fishPrefabs2; // 물고기 프리팹 배열
    public GameObject[] fishPrefabs3; // 물고기 프리팹 배열
    public List<GameObject[]> fishPrefabsList;

    public Transform fishingRodHook;

    public int fishIndex; // 물고기 인덱스

    public float minInterval = 1f; // 최소 시간 간격
    public float maxInterval = 3f; // 최대 시간 간격

    private float nextSpawnTime; // 다음 생성 시간
    private bool isFishCaught; // 물고기가 잡혔는지 여부

    // 물고기 프리팹 인덱스 상수
    private const int TunaIndex = 0;
    private const int BlobfishIndex = 1;
    private const int FlatfishIndex = 2;
    private const int ShrimpIndex = 3;
    // 추가적인 물고기 인덱스 상수 정의

    //public Sprite[] fishImages1; // 물고기 이미지1 배열
    //public Sprite[] fishImages2; // 물고기 이미지2 배열

    public FishBook[] fishBooks;
    public FishBook fishBook;       // Selected Fish Book by FishGrade


    void Start()
    {
        fishPrefabsList = new List<GameObject[]> { fishPrefabs0, fishPrefabs1, fishPrefabs2, fishPrefabs3 };
        SetNextSpawnTime();
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime && !isFishCaught)
        {
            UpdateFishCaught();
        }
    }

    void SetNextSpawnTime()
    {
        nextSpawnTime = Time.time + Random.Range(minInterval, maxInterval);
    }

    public void UpdateFishCaught()
    {
        int fishGrade = ChanceMaker();  // 0~3 하급~최상급, 4 물고기 놓침

        Debug.Log("나온 등급은 : " + ChanceMaker());

        if (fishGrade == 4)
        {
            isFishCaught = false;
        }   
        else
        {
            isFishCaught = true;
            fishBook = fishBooks[fishGrade];
        }


        //FishBook fishBook = FindObjectOfType<FishBook>();
        //fishBook = FindObjectOfType<FishBook>();

        fishIndex = Random.Range(0, fishPrefabsList[fishGrade].Length);
        Debug.Log("FishIndex : " + fishIndex);

        if (fishBook != null)
        {
            fishBook.gameObject.SetActive(true);
            fishBook.UpdateFishImage(fishIndex, isFishCaught);
        }

        //// fishPrefabs 배열에서 무작위로 물고기 프리팹을 선택
        //GameObject fishPrefab = fishPrefabs[Random.Range(0, fishPrefabs.Length)];
        // fishPrefabs 배열에서 무작위로 물고기 프리팹을 선택
        GameObject fishPrefab = fishPrefabsList[fishGrade][fishIndex];

        // 물고기 프리팹의 인스턴스 생성
        GameObject fishObject = Instantiate(fishPrefab, fishingRodHook.position, Quaternion.identity);

        // 낚시대 끝 위치로 물고기의 위치를 이동
        fishObject.transform.parent = fishingRodHook;

        // 물고기의 로컬 변환 값을 재설정
        fishObject.transform.localPosition = Vector3.zero;
        fishObject.transform.localRotation = Quaternion.identity;

        Debug.Log("물고기가 잡혔습니다!");

        // 원하는 동작을 수행하거나 게임 로직을 추가하세요
        // 예: 점수 증가, 물고기 제거 등
    }

    /* 원본 코드
        public void UpdateFishCaught()
    {
        int fishGrade = ChanceMaker();  // 0~3 하급~최상급, 4 물고기 놓침

        Debug.Log("나온 등급은 : " + ChanceMaker());
        if (fishGrade == 4)
            isFishCaught = false;
        else
            isFishCaught = true;

        //FishBook fishBook = FindObjectOfType<FishBook>();
        fishBook = FindObjectOfType<FishBook>();

        if (fishBook != null)
        {
            fishBook.UpdateFishImage(fishIndex, isFishCaught);
        }

        // fishPrefabs 배열에서 무작위로 물고기 프리팹을 선택
        GameObject fishPrefab = fishPrefabs[Random.Range(0, fishPrefabs.Length)];

        // 물고기 프리팹의 인스턴스 생성
        GameObject fishObject = Instantiate(fishPrefab, fishingRodHook.position, Quaternion.identity);

        // 낚시대 끝 위치로 물고기의 위치를 이동
        fishObject.transform.parent = fishingRodHook;

        // 물고기의 로컬 변환 값을 재설정
        fishObject.transform.localPosition = Vector3.zero;
        fishObject.transform.localRotation = Quaternion.identity;

        Debug.Log("물고기가 잡혔습니다!");

        // 원하는 동작을 수행하거나 게임 로직을 추가하세요
        // 예: 점수 증가, 물고기 제거 등
    }
    */

    public int ChanceMaker()
    {
        int twoDiceSum = Random.Range(1, 5) + Random.Range(1, 5);

        //임시 테스트 코드 프리팹 작업 (인스펙터에서 FishSpawner 오브젝트와 FishSpawner.cs , Canvas에 있는 Panel0~4의 FishBook.cs 컴포넌트 목록 연결 참조 할당 완료후 아래 줄 삭제
        return 0;

        switch (twoDiceSum)
        {
            case 2:
                return 3;   // 최상급
                //break;
            case 3:
                return 2;   // 상급
                //break;
            case 4:
                return 1;   // 중급
                //break;
            case 5: 
                return 0;   // 하급
                //break;
            default :
                return 4;   // 물고기를 못잡을 경우 코드 4
                //break;      
        }
    }
}



/*
 * 희귀 등급 결정
A  B  C  D
0  0  0  0
1  1  1
2  2  2
3  3 
4  4
5  5
6

2 : 1,1  (1)            1/16 (6.25%)
3 : 1,2 2,1 (2)         2/16 (12.5%)
4 : 1,3 3,1 2,2 (3)     3/16 (18.75%)
5 : 1,4 4,1 2,3 3,2 (4) 4/16 (25%)
------------------- (물고기 못잡을 확률 총합 37.5%)
6 : 2,4 4,2 3,3 (3)     3/16 (18.75%)       
7 : 3,4 4,3 (2)         2/16 (12.5%)
8 : 4,4  (1)            1/16 (6.25%)


16


등급 결정
 -> 피쉬 북 선정
 -> 선정 된 피쉬 북에서 물고기 생성
 -> 잡힌 물고기 도감에 넣기 (UI 캔버스 페이지 == 등급)
*/

/*
 * 프리팹 참조 연결 작업 (인스펙터에서)
 1) FishSpawner 오브젝트 FishSpawner.cs 의 등급별 prefab 배열 참조 연결
 2) Canvas에 있는 Panel0~4의 FishBook.cs 컴포넌트의
   가) FishImagesInPage 이미지들 -> 도감 판넬에 있는 Image 객체 연결
   나) Image의 윤곽선(검정물고기) 이미지 변경 및 이름 변경 (등급 순서대로 FishSpawner 리스트와 일치시켜야함)
 3) 등급 고정 수정
   : FishSpawner.cs 의  아래 긴주석과 return 0; 부분 삭제 상기 작업 완료 후)
    public int ChanceMaker()
    {
        int twoDiceSum = Random.Range(1, 5) + Random.Range(1, 5);

        //임시 테스트 코드 프리팹 작업 (인스펙터에서 FishSpawner 오브젝트와 FishSpawner.cs , Canvas에 있는 Panel0~4의 FishBook.cs 컴포넌트 목록 연결 참조 할당 완료후 아래 줄 삭제
        return 0;

        switch (twoDiceSum)
        {
            case 2:
*/