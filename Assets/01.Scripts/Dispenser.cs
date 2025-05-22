using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DispenserType
{
    NONE = 0,
    NOMAL = 1,
}

public class Dispenser : MonoBehaviour
{
    [SerializeField] DispenserType type;
    [SerializeField] float waitTime = 2f;
    [SerializeField] int maxCount = 4;

    [SerializeField] List<GameObject> item_List; // 스택으로 동작해야함.
    [SerializeField] Transform group;
    [SerializeField] GameObject itemObj;



    void Start()
    {
        SpawnItem();
    }

    IEnumerator ItemSpawnCoroutine(float time)
    {
        yield return new WaitForSeconds(time); //처음 생성됐을 때 기다리는 카운트
        while (true)
        {
            yield return new WaitUntil(() => item_List.Count < maxCount);
            AddObjectStack();
            Debug.Log("Spawn");
            yield return new WaitForSeconds(time);
        }
    }

    private void SpawnItem()
    {
        waitTime = itemObj.GetComponent<ItemObject>().itemInfo.spawnTime;
        StartCoroutine(ItemSpawnCoroutine(waitTime));
    }

    private void AddObjectStack()
    {
        // 마지막에 쌓여있는 오브젝트를 가져옴.
        var item = Instantiate(itemObj, group);
        float size = item.GetComponent<Collider>().bounds.size.y;
        float LastlocalPosY = item_List.Count > 0 ? item_List[item_List.Count - 1].transform.localPosition.y : 0f;
        item.transform.localPosition = item_List.Count > 0 ? new Vector3(0f, LastlocalPosY + size, 0f) : Vector3.zero;
        item_List.Add(item);
    }
}
