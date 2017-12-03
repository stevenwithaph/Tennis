using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Merchant.Characters;

public class GameManager : MonoBehaviour
{
    public GameObject tank;
    public GameObject tankController;

    public GameObject bot;
    public GameObject botController;
    // Use this for initialization
    void Start()
    {
        TrashMan.recycleBinForGameObject(tank);
        TrashMan.recycleBinForGameObject(tankController);

        TrashMan.recycleBinForGameObject(bot);
        TrashMan.recycleBinForGameObject(botController);

        this.SpawnTank();
    }

    void SpawnTank()
    {
        GameObject newTank = TrashMan.spawn(tank);
        GameObject newController = TrashMan.spawn(tankController);

        Character tankCharacter = newTank.GetComponent<Character>();
        AIController aiController = newController.GetComponent<AIController>();
        Debug.Log(tankCharacter);
        aiController.Posses(tankCharacter);
    }

    void SpawnBot()
    {

    }
}
