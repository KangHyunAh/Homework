using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f;
    public float lowPosY = -1f;

    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;

    public Vector3 SetRandomPlace(Vector3 lastPosition,int obstacleCount) 
    { 
        float holesize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holesize / 2f;
        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }
    Game1GameManager game1GameManager;

    void Start()
    {
        game1GameManager = Game1GameManager.Instance;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Minigame1Player player = other.GetComponent<Minigame1Player>();
        if (player != null)
            game1GameManager.AddScore(1);
    }
}
