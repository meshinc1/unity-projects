using System.Collections.Generic;
using UnityEngine;

public class GamePieceTemplate
{
    public Vector3 localPosition;
    public List<Vector3> spawnedPieces = new List<Vector3>();

    public GamePieceTemplate() {}
    public GamePieceTemplate(Vector3 localPos)
    {
        localPosition = localPos;
    }

    public void AddPiece(Vector3 newPiece)
    {
        spawnedPieces.Add(newPiece);
    }

    public void RotateClockwise()
    {
        //Rotates shape clockwise, using center of 3x3 as origin
        for (int i = 0; i < spawnedPieces.Count; ++i)
        {
            //Starting from bottom-left, going counter-clockwise (center ignored)
            if (spawnedPieces[i].y == 0.5f && spawnedPieces[i].z == 0.5f)
            {
                spawnedPieces[i] = new Vector3(0f, 2.5f, 0.5f);
            }
            else if (spawnedPieces[i].y == 0.5f && spawnedPieces[i].z == 1.5f)
            {
                spawnedPieces[i] = new Vector3(0f, 1.5f, 0.5f);
            }
            else if (spawnedPieces[i].y == 0.5f && spawnedPieces[i].z == 2.5f)
            {
                spawnedPieces[i] = new Vector3(0f, 0.5f, 0.5f);
            }
            else if (spawnedPieces[i].y == 1.5f && spawnedPieces[i].z == 2.5f)
            {
                spawnedPieces[i] = new Vector3(0f, 0.5f, 1.5f);
            }
            else if (spawnedPieces[i].y == 2.5f && spawnedPieces[i].z == 2.5f)
            {
                spawnedPieces[i] = new Vector3(0f, 0.5f, 2.5f);
            }
            else if (spawnedPieces[i].y == 2.5f && spawnedPieces[i].z == 1.5f)
            {
                spawnedPieces[i] = new Vector3(0f, 1.5f, 2.5f);
            }
            else if (spawnedPieces[i].y == 2.5f && spawnedPieces[i].z == 0.5f)
            {
                spawnedPieces[i] = new Vector3(0f, 2.5f, 2.5f);
            }
            else if (spawnedPieces[i].y == 1.5f && spawnedPieces[i].z == 0.5f)
            {
                spawnedPieces[i] = new Vector3(0f, 2.5f, 1.5f);
            }
        }
        correctPosition();
    }

    public void RotateCounterClockwise()
    {
        //Rotates shape counter-clockwise, using center of 3x3 as origin
        for (int i = 0; i < spawnedPieces.Count; ++i)
        {
            //Starting from bottom-left, going counter-clockwise (center ignored)
            if (spawnedPieces[i].y == 0.5f && spawnedPieces[i].z == 0.5f)
            {
                spawnedPieces[i] = new Vector3(0f, 0.5f, 2.5f);
            }
            else if (spawnedPieces[i].y == 0.5f && spawnedPieces[i].z == 1.5f)
            {
                spawnedPieces[i] = new Vector3(0f, 1.5f, 2.5f);
            }
            else if (spawnedPieces[i].y == 0.5f && spawnedPieces[i].z == 2.5f)
            {
                spawnedPieces[i] = new Vector3(0f, 2.5f, 2.5f);
            }
            else if (spawnedPieces[i].y == 1.5f && spawnedPieces[i].z == 2.5f)
            {
                spawnedPieces[i] = new Vector3(0f, 2.5f, 1.5f);
            }
            else if (spawnedPieces[i].y == 2.5f && spawnedPieces[i].z == 2.5f)
            {
                spawnedPieces[i] = new Vector3(0f, 2.5f, 0.5f);
            }
            else if (spawnedPieces[i].y == 2.5f && spawnedPieces[i].z == 1.5f)
            {
                spawnedPieces[i] = new Vector3(0f, 1.5f, 0.5f);
            }
            else if (spawnedPieces[i].y == 2.5f && spawnedPieces[i].z == 0.5f)
            {
                spawnedPieces[i] = new Vector3(0f, 0.5f, 0.5f);
            }
            else if (spawnedPieces[i].y == 1.5f && spawnedPieces[i].z == 0.5f)
            {
                spawnedPieces[i] = new Vector3(0f, 0.5f, 1.5f);
            }
        }
        correctPosition();
    }

    public void MoveUp()
    {
        if(topmostPiece() <= 2.5f)
        {
            ++localPosition.y;
        }
    }

    public void MoveDown()
    {
        if(bottommostPiece() > 0.5f)
        {
            --localPosition.y;
        }
    }

    public void MoveLeft()
    {
        if(leftmostPiece() > 0.5f)
        {
            --localPosition.z;
        }
    }

    public void MoveRight()
    {
        if(rightmostPiece() <= 2.5f)
        {
            ++localPosition.z;
        }
    }

    public float leftmostPiece()
    {
        float leftmost = spawnedPieces[0].z;
        for(int i = 1; i < spawnedPieces.Count; ++i)
        {
            if(spawnedPieces[i].z < leftmost)
            {
                leftmost = spawnedPieces[i].z;
            }
        }
        return leftmost + localPosition.z;
    }

    public float rightmostPiece()
    {
        float rightmost = spawnedPieces[0].z;
        for(int i = 1; i < spawnedPieces.Count; ++i)
        {
            if(spawnedPieces[i].z > rightmost)
            {
                rightmost = spawnedPieces[i].z;
            }
        }
        return rightmost + localPosition.z;
    }

    public float topmostPiece()
    {
        float topmost = spawnedPieces[0].y;
        for(int i = 1; i < spawnedPieces.Count; ++i)
        {
            if(spawnedPieces[i].y > topmost)
            {
                topmost = spawnedPieces[i].y;
            }
        }
        return topmost + localPosition.y;
    }

    public float bottommostPiece()
    {
        float bottommost = spawnedPieces[0].y;
        for(int i = 1; i < spawnedPieces.Count; ++i)
        {
            if(spawnedPieces[i].y < bottommost)
            {
                bottommost = spawnedPieces[i].y;
            }
        }
        return bottommost + localPosition.y;
    }

    public void correctPosition()
    {
        while(leftmostPiece() < 0.5f)
        {
            MoveRight();
        }
        while(rightmostPiece() > 3.5f)
        {
            MoveLeft();
        }
        while(topmostPiece() > 3.5f)
        {
            MoveDown();
        }
        while(bottommostPiece() < 0.5f)
        {
            MoveUp();
        }
    }
}

public class GamePieceSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject gamePiecePrefab;
    private bool validPos = false;
    private List<GamePieceTemplate> gamePieceShapes = new List<GamePieceTemplate>();
    private int selectedShapeIndex = 0;

    void Start()
    {
        //Create all game-piece shapes
        var tShape = new GamePieceTemplate(new Vector3(0, 0, 0));
        tShape.AddPiece(new Vector3(0f, 0.5f, 0.5f));
        tShape.AddPiece(new Vector3(0f, 0.5f, 1.5f));
        tShape.AddPiece(new Vector3(0f, 0.5f, 2.5f));
        tShape.AddPiece(new Vector3(0f, 1.5f, 1.5f));
        gamePieceShapes.Add(tShape);

        var lShape = new GamePieceTemplate(new Vector3(0, 0, 0));
        lShape.AddPiece(new Vector3(0f, 2.5f, 0.5f));
        lShape.AddPiece(new Vector3(0f, 1.5f, 0.5f));
        lShape.AddPiece(new Vector3(0f, 0.5f, 0.5f));
        lShape.AddPiece(new Vector3(0f, 0.5f, 1.5f));
        gamePieceShapes.Add(lShape);

        /*
        var iShape = new GamePieceTemplate(new Vector3(0, 0, 0));
        iShape.AddPiece(new Vector3(0f, 2.5f, 0.5f));
        iShape.AddPiece(new Vector3(0f, 1.5f, 0.5f));
        iShape.AddPiece(new Vector3(0f, 0.5f, 0.5f));
        gamePieceShapes.Add(iShape);
        */

        var boxShape = new GamePieceTemplate(new Vector3(0, 0, 0));
        boxShape.AddPiece(new Vector3(0f, 0.5f, 0.5f));
        boxShape.AddPiece(new Vector3(0f, 1.5f, 0.5f));
        boxShape.AddPiece(new Vector3(0f, 0.5f, 1.5f));
        boxShape.AddPiece(new Vector3(0f, 1.5f, 1.5f));
        gamePieceShapes.Add(boxShape);

        var zShape = new GamePieceTemplate(new Vector3(0, 0, 0));
        zShape.AddPiece(new Vector3(0f, 0.5f, 0.5f));
        zShape.AddPiece(new Vector3(0f, 1.5f, 0.5f));
        zShape.AddPiece(new Vector3(0f, 1.5f, 1.5f));
        zShape.AddPiece(new Vector3(0f, 2.5f, 1.5f));
        gamePieceShapes.Add(zShape);

        SpawnPieces();
    }

    void SpawnPieces()
    {
        for(int i = 0; i < spawnPoints.Length; ++i)
        {
            for(int j = 0; j < gamePieceShapes[selectedShapeIndex].spawnedPieces.Count; ++j)
            {
               if (spawnPoints[i].localPosition.y == (gamePieceShapes[selectedShapeIndex].spawnedPieces[j].y + gamePieceShapes[selectedShapeIndex].localPosition.y)
               && spawnPoints[i].localPosition.z == (gamePieceShapes[selectedShapeIndex].spawnedPieces[j].z + gamePieceShapes[selectedShapeIndex].localPosition.z))
               {
                   validPos = true;
                   break;
               }
            }
            if (validPos)
            {
                Instantiate(gamePiecePrefab, spawnPoints[i].position, Quaternion.identity);
            }
            validPos = false;
        }
    }
       
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            gamePieceShapes[selectedShapeIndex].MoveUp();
            SpawnPieces();
        }
        else if (Input.GetKeyDown("a"))
        {
            gamePieceShapes[selectedShapeIndex].MoveLeft();
            SpawnPieces();
        }
        else if (Input.GetKeyDown("s"))
        {
            gamePieceShapes[selectedShapeIndex].MoveDown();
            SpawnPieces();
        }
        else if (Input.GetKeyDown("d"))
        {
            gamePieceShapes[selectedShapeIndex].MoveRight();
            SpawnPieces();
        }
        else if (Input.GetKeyDown("q"))
        {
            gamePieceShapes[selectedShapeIndex].RotateCounterClockwise();
            SpawnPieces();
        }
        else if (Input.GetKeyDown("e"))
        {
            gamePieceShapes[selectedShapeIndex].RotateClockwise();
            SpawnPieces();
        }
        else if (Input.GetKeyDown("r"))
        {
            if(selectedShapeIndex > 0)
            {
                --selectedShapeIndex;
            }
            else
            {
                selectedShapeIndex = gamePieceShapes.Count - 1;
            }
            SpawnPieces();
        }
        else if (Input.GetKeyDown("f"))
        {
            if(selectedShapeIndex == gamePieceShapes.Count - 1)
            {
                selectedShapeIndex = 0;
            }
            else
            {
                ++selectedShapeIndex;
            }
            SpawnPieces();
        }
    }
}