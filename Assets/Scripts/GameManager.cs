using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public ConceptsList ConceptsList = new ConceptsList();

    [SerializeField] private string url;
    [SerializeField] private List<GamePiece> masteryLevels;

    void Start()
    {
        string onlineContent = APILoader.ReadFile(url, "Concepts") as string;
        if (onlineContent != null)
        {
            Debug.Log($"{ onlineContent}");

            ConceptsList = JsonUtility.FromJson<ConceptsList>(onlineContent);
            GenerateStacks();
        }
        else
        {
            Debug.Log("Asset is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // check to see if a piece has been selected
    }

    private void GenerateStacks()
    {

        int positionIndexStack1 = 0;
        int positionIndexStack2 = 0;
        int positionIndexStack3 = 0;

        foreach (Concepts concept in ConceptsList.Concepts)
        {
            Vector3 piecePlacement;
            Quaternion pieceRotation;

            if (concept.grade == "6th Grade")
            {
                piecePlacement = GetNextPosition(positionIndexStack1, 1);
                pieceRotation = GetNextRotation(positionIndexStack1);
                positionIndexStack1++;
            }
            else if (concept.grade == "7th Grade")
            {
                piecePlacement = GetNextPosition(positionIndexStack2, 2);
                pieceRotation = GetNextRotation(positionIndexStack2);
                positionIndexStack2++;
            }
            else
            {
                piecePlacement = GetNextPosition(positionIndexStack3, 3);
                pieceRotation = GetNextRotation(positionIndexStack3);
                positionIndexStack3++;
            }

            GamePiece piece = Instantiate(masteryLevels[concept.mastery], piecePlacement, pieceRotation);
            piece.conceptID = concept.id;
        }

    }

    private Vector3 GetNextPosition(int positionIndex, int stack)
    {
        float xposition;
        float yposition;
        float zposition;

        int layer = (positionIndex / 3) + 1;
        yposition = (float)layer * 0.2f;

        int line = (positionIndex % 3);
        if (layer % 2 == 0)
        {
            // rotated
            xposition = (float)((stack - 2) * -1.5) + ((line - 1) * 0.4f);
            zposition = 0.4f;
        }
        else
        {
            // not rotated
            xposition = (float)((stack - 2) * -1.5);
            zposition = (float)line * 0.4f;
        }

        return new Vector3(xposition, yposition, zposition);
    }

    private Quaternion GetNextRotation(int positionIndex)
    {
        int layer = (positionIndex / 3) + 1;
        if (layer % 2 == 0)
        {
            return Quaternion.Euler(0, 90, 0);
        }
        else
        {
            return new Quaternion();
        }
        
    }
}
