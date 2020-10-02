using System.Collections.Generic;
using UnityEngine;

public class PlaneTemplate
{
    //Stores location of 'invisible' 3x3 square which houses shape
    public Vector3 localPosition;
    //Location of each tile which forms the cut-out shape (with respect to localPosition)
    public List<Vector3> omittedTiles = new List<Vector3>();

    public PlaneTemplate() {}
    public PlaneTemplate(Vector3 localPos){
        localPosition = localPos;
    }

    public void AddTile(Vector3 newTile)
    {
        //Vector3 tt = new Vector3(newTile.x, newTile.y, newTile.z);
        omittedTiles.Add(newTile);
    }

    public void RotateClockwise()
    {
        //Rotates shape clockwise, using center of 3x3 as origin
        for (int i = 0; i < omittedTiles.Count; ++i)
        {
            //Starting from bottom-left, going counter-clockwise (center ignored)
            if (omittedTiles[i].y == 0.5f && omittedTiles[i].z == 0.5f)
            {
                omittedTiles[i] = new Vector3(0f, 2.5f, 0.5f);
            } else if (omittedTiles[i].y == 0.5f && omittedTiles[i].z == 1.5f)
            {
                omittedTiles[i] = new Vector3(0f, 1.5f, 0.5f);
            } else if (omittedTiles[i].y == 0.5f && omittedTiles[i].z == 2.5f)
            {
                omittedTiles[i] = new Vector3(0f, 0.5f, 0.5f);
            } else if (omittedTiles[i].y == 1.5f && omittedTiles[i].z == 2.5f)
            {
                omittedTiles[i] = new Vector3(0f, 0.5f, 1.5f);
            } else if (omittedTiles[i].y == 2.5f && omittedTiles[i].z == 2.5f)
            {
                omittedTiles[i] = new Vector3(0f, 0.5f, 2.5f);
            } else if (omittedTiles[i].y == 2.5f && omittedTiles[i].z == 1.5f)
            {
                omittedTiles[i] = new Vector3(0f, 1.5f, 2.5f);
            } else if (omittedTiles[i].y == 2.5f && omittedTiles[i].z == 0.5f)
            {
                omittedTiles[i] = new Vector3(0f, 2.5f, 2.5f);
            } else if (omittedTiles[i].y == 1.5f && omittedTiles[i].z == 0.5f)
            {
                omittedTiles[i] = new Vector3(0f, 2.5f, 1.5f);
            }
        }
    }
}

public class PlaneSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject tilePrefab;
    private bool validPos = true;
    private List<PlaneTemplate> cutoutShapes = new List<PlaneTemplate>();

    public float timeBetweenWaves = 5f;
    private float timeToSpawn = 1f;

    void Start()
    {
        //Create all shapes
        var tShape = new PlaneTemplate(new Vector3(0, 0, 0));
        tShape.AddTile(new Vector3(0f, 0.5f, 0.5f));
        tShape.AddTile(new Vector3(0f, 0.5f, 1.5f));
        tShape.AddTile(new Vector3(0f, 0.5f, 2.5f));
        tShape.AddTile(new Vector3(0f, 1.5f, 1.5f));
        cutoutShapes.Add(tShape);

        var lShape = new PlaneTemplate(new Vector3(0, 0, 0));
        lShape.AddTile(new Vector3(0f, 2.5f, 0.5f));
        lShape.AddTile(new Vector3(0f, 1.5f, 0.5f));
        lShape.AddTile(new Vector3(0f, 0.5f, 0.5f));
        lShape.AddTile(new Vector3(0f, 0.5f, 1.5f));
        cutoutShapes.Add(lShape);

        var boxShape = new PlaneTemplate(new Vector3(0, 0, 0));
        boxShape.AddTile(new Vector3(0f, 0.5f, 0.5f));
        boxShape.AddTile(new Vector3(0f, 1.5f, 0.5f));
        boxShape.AddTile(new Vector3(0f, 0.5f, 1.5f));
        boxShape.AddTile(new Vector3(0f, 1.5f, 1.5f));
        cutoutShapes.Add(boxShape);

        var zShape = new PlaneTemplate(new Vector3(0, 0, 0));
        zShape.AddTile(new Vector3(0f, 0.5f, 0.5f));
        zShape.AddTile(new Vector3(0f, 1.5f, 0.5f));
        zShape.AddTile(new Vector3(0f, 1.5f, 1.5f));
        zShape.AddTile(new Vector3(0f, 2.5f, 1.5f));
        cutoutShapes.Add(zShape);
    }

    void SpawnTiles()
    {
        //Select random shape (index)
        int randomIndex = (int)Random.Range(0, 3.99f);

        //Position and Rotation randomizer
        cutoutShapes[randomIndex].localPosition = new Vector3(0f, (float)((int)Random.Range(0, 1.99f)), (float)((int)Random.Range(0, 1.99f)));
        for (int i = 0; i < (int)Random.Range(0, 3.99f); ++i)
        {
            cutoutShapes[randomIndex].RotateClockwise();
        }

        for (int i = 0; i < spawnPoints.Length; ++i)
        {
            for (int j = 0; j < cutoutShapes[randomIndex].omittedTiles.Count; ++j)
            {
                if (spawnPoints[i].localPosition.y == (cutoutShapes[randomIndex].omittedTiles[j].y + cutoutShapes[randomIndex].localPosition.y)
                && spawnPoints[i].localPosition.z == (cutoutShapes[randomIndex].omittedTiles[j].z + cutoutShapes[randomIndex].localPosition.z))
                {
                    validPos = false;
                    break;
                }
            }
            if (validPos)
            {
                GameObject obj = Instantiate(tilePrefab, spawnPoints[i].position, Quaternion.identity);
                obj.GetComponent<Rigidbody>().velocity = new Vector3(20f, 0f, 0f);
            }
            validPos = true;
        }
    }

    void Update()
    {
        //Time.time tracks time since game started
        if (Time.time >= timeToSpawn)
        {
            SpawnTiles();
            timeToSpawn = Time.time + timeBetweenWaves;
        }
    }
}
