using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject[] fishPrefabs; // ����� ������ �迭
    public GameObject[] fishPrefabs0; // ����� ������ �迭
    public GameObject[] fishPrefabs1; // ����� ������ �迭
    public GameObject[] fishPrefabs2; // ����� ������ �迭
    public GameObject[] fishPrefabs3; // ����� ������ �迭
    public List<GameObject[]> fishPrefabsList;

    public Transform fishingRodHook;

    public int fishIndex; // ����� �ε���

    public float minInterval = 1f; // �ּ� �ð� ����
    public float maxInterval = 3f; // �ִ� �ð� ����

    private float nextSpawnTime; // ���� ���� �ð�
    private bool isFishCaught; // ����Ⱑ �������� ����

    // ����� ������ �ε��� ���
    private const int TunaIndex = 0;
    private const int BlobfishIndex = 1;
    private const int FlatfishIndex = 2;
    private const int ShrimpIndex = 3;
    // �߰����� ����� �ε��� ��� ����

    //public Sprite[] fishImages1; // ����� �̹���1 �迭
    //public Sprite[] fishImages2; // ����� �̹���2 �迭

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
        int fishGrade = ChanceMaker();  // 0~3 �ϱ�~�ֻ��, 4 ����� ��ħ

        Debug.Log("���� ����� : " + ChanceMaker());

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

        //// fishPrefabs �迭���� �������� ����� �������� ����
        //GameObject fishPrefab = fishPrefabs[Random.Range(0, fishPrefabs.Length)];
        // fishPrefabs �迭���� �������� ����� �������� ����
        GameObject fishPrefab = fishPrefabsList[fishGrade][fishIndex];

        // ����� �������� �ν��Ͻ� ����
        GameObject fishObject = Instantiate(fishPrefab, fishingRodHook.position, Quaternion.identity);

        // ���ô� �� ��ġ�� ������� ��ġ�� �̵�
        fishObject.transform.parent = fishingRodHook;

        // ������� ���� ��ȯ ���� �缳��
        fishObject.transform.localPosition = Vector3.zero;
        fishObject.transform.localRotation = Quaternion.identity;

        Debug.Log("����Ⱑ �������ϴ�!");

        // ���ϴ� ������ �����ϰų� ���� ������ �߰��ϼ���
        // ��: ���� ����, ����� ���� ��
    }

    /* ���� �ڵ�
        public void UpdateFishCaught()
    {
        int fishGrade = ChanceMaker();  // 0~3 �ϱ�~�ֻ��, 4 ����� ��ħ

        Debug.Log("���� ����� : " + ChanceMaker());
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

        // fishPrefabs �迭���� �������� ����� �������� ����
        GameObject fishPrefab = fishPrefabs[Random.Range(0, fishPrefabs.Length)];

        // ����� �������� �ν��Ͻ� ����
        GameObject fishObject = Instantiate(fishPrefab, fishingRodHook.position, Quaternion.identity);

        // ���ô� �� ��ġ�� ������� ��ġ�� �̵�
        fishObject.transform.parent = fishingRodHook;

        // ������� ���� ��ȯ ���� �缳��
        fishObject.transform.localPosition = Vector3.zero;
        fishObject.transform.localRotation = Quaternion.identity;

        Debug.Log("����Ⱑ �������ϴ�!");

        // ���ϴ� ������ �����ϰų� ���� ������ �߰��ϼ���
        // ��: ���� ����, ����� ���� ��
    }
    */

    public int ChanceMaker()
    {
        int twoDiceSum = Random.Range(1, 5) + Random.Range(1, 5);

        //�ӽ� �׽�Ʈ �ڵ� ������ �۾� (�ν����Ϳ��� FishSpawner ������Ʈ�� FishSpawner.cs , Canvas�� �ִ� Panel0~4�� FishBook.cs ������Ʈ ��� ���� ���� �Ҵ� �Ϸ��� �Ʒ� �� ����
        return 0;

        switch (twoDiceSum)
        {
            case 2:
                return 3;   // �ֻ��
                //break;
            case 3:
                return 2;   // ���
                //break;
            case 4:
                return 1;   // �߱�
                //break;
            case 5: 
                return 0;   // �ϱ�
                //break;
            default :
                return 4;   // ����⸦ ������ ��� �ڵ� 4
                //break;      
        }
    }
}



/*
 * ��� ��� ����
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
------------------- (����� ������ Ȯ�� ���� 37.5%)
6 : 2,4 4,2 3,3 (3)     3/16 (18.75%)       
7 : 3,4 4,3 (2)         2/16 (12.5%)
8 : 4,4  (1)            1/16 (6.25%)


16


��� ����
 -> �ǽ� �� ����
 -> ���� �� �ǽ� �Ͽ��� ����� ����
 -> ���� ����� ������ �ֱ� (UI ĵ���� ������ == ���)
*/

/*
 * ������ ���� ���� �۾� (�ν����Ϳ���)
 1) FishSpawner ������Ʈ FishSpawner.cs �� ��޺� prefab �迭 ���� ����
 2) Canvas�� �ִ� Panel0~4�� FishBook.cs ������Ʈ��
   ��) FishImagesInPage �̹����� -> ���� �ǳڿ� �ִ� Image ��ü ����
   ��) Image�� ������(���������) �̹��� ���� �� �̸� ���� (��� ������� FishSpawner ����Ʈ�� ��ġ���Ѿ���)
 3) ��� ���� ����
   : FishSpawner.cs ��  �Ʒ� ���ּ��� return 0; �κ� ���� ��� �۾� �Ϸ� ��)
    public int ChanceMaker()
    {
        int twoDiceSum = Random.Range(1, 5) + Random.Range(1, 5);

        //�ӽ� �׽�Ʈ �ڵ� ������ �۾� (�ν����Ϳ��� FishSpawner ������Ʈ�� FishSpawner.cs , Canvas�� �ִ� Panel0~4�� FishBook.cs ������Ʈ ��� ���� ���� �Ҵ� �Ϸ��� �Ʒ� �� ����
        return 0;

        switch (twoDiceSum)
        {
            case 2:
*/