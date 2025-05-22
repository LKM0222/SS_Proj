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
    [SerializeField] GameObject itemObj;
    [SerializeField] float waitTime = 2f;
    [SerializeField] List<GameObject> item_List; // 스택으로 동작해야함.

    [SerializeField] Transform group;



    void Start()
    {
        SpawnItem();
    }

    IEnumerator ItemSpawnCoroutine(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            AddObjectStack();
            Debug.Log("Spawn");
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
        Vector3 initPos = Vector3.zero;

        if (item_List.Count > 0)
        {
            float lastSize = item_List[item_List.Count - 1].GetComponent<Collider>().bounds.size.y;
            float lastPos = item_List[item_List.Count - 1].transform.localPosition.y;
            initPos = new Vector3(0f, lastSize + lastPos, 0f);
            Debug.Log($"SpawnPos : {initPos}, lastSize {lastSize}, lastPos {lastPos}");
        }

        var item = Instantiate(itemObj, initPos, Quaternion.identity, group);
        item_List.Add(item);
    }
}
