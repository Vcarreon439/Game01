using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator sharedGenerator;
    public List<LevelBlock> prefabs = new List<LevelBlock>();
    public List<LevelBlock> current = new List<LevelBlock>();
    public Transform levelInitialPoint;

    void Awake() 
    {
        sharedGenerator = this;
    }

    public void AddNewBlock() 
    {
        int randomIndex = Random.Range(0, prefabs.Count);
        LevelBlock block = (LevelBlock)Instantiate(prefabs[randomIndex]);
        block.transform.SetParent(this.transform, false);
        Vector3 blockposition = Vector3.zero;


        if (current.Count == 0) 
            blockposition = levelInitialPoint.position;
        else
            blockposition = current[current.Count - 1].exitpoint.position;

        block.transform.position = blockposition;
        current.Add(block);
    }

    public void RemoveBlock() 
    {
        LevelBlock block = current[0];
        current.Remove(block);
        Destroy(block.gameObject);
    }

    public void GenerateIntialBlocks() 
    {
        for (int i = 0; i < 3; i++)
            AddNewBlock();
    }


    // Start is called before the first frame update
    void Start()
    {
        GenerateIntialBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
