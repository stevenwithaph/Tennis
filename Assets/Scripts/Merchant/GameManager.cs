using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

using Merchant.Characters;
using Merchant.Characters.Abilities;
using Merchant.Controllers.Base;
using Merchant.Controllers.Players;

public class GameManager : MonoBehaviour
{
    public GameObject tank;
    public GameObject tankController;

    public GameObject bot;
    public GameObject botController;

    public GameObject player;
    public GameObject playerController;

    public float tankSpawnInterval = 10.0f;

    public Vector3 minimumPosition = Vector3.zero;
    public Vector3 maximumPosition = Vector3.zero;
    // Use this for initialization
    void Start()
    {
        TrashMan.recycleBinForGameObject(tank);
        TrashMan.recycleBinForGameObject(tankController);

        TrashMan.recycleBinForGameObject(bot);
        TrashMan.recycleBinForGameObject(botController);

        this.SpawnPlayer();
        this.StartCoroutine(this.TankSpawner());
    }

    void SpawnTank()
    {
        GameObject newTank = TrashMan.spawn(tank);
        GameObject newController = TrashMan.spawn(tankController);

        Character tankCharacter = newTank.GetComponent<Character>();
        AIController aiController = newController.GetComponent<AIController>();
        
        tankCharacter.GetComponent<CharacterHealth>().OnDeath += HandleEnemyDeath;
        aiController.Posses(tankCharacter);

        tankCharacter.transform.position = this.RandomPosition();
    }

    void SpawnBot()
    {

    }

    void SpawnPlayer()
    {
        GameObject newPlayer = TrashMan.spawn(player);
        GameObject newController = TrashMan.spawn(playerController);

        Character playerCharacter = newPlayer.GetComponent<Character>();
        PlayerController controller = newController.GetComponent<PlayerController>();
        
        playerCharacter.GetComponent<CharacterHealth>().OnDeath += HandlePlayerDeath;
        controller.Posses(playerCharacter);
    }

    IEnumerator TankSpawner()
    {
        while(true)
        {
            this.SpawnTank();
            yield return new WaitForSecondsRealtime(this.tankSpawnInterval);
        }
    }

    Vector3 RandomPosition()
    {
        float x = Random.Range(minimumPosition.x, maximumPosition.x);
        float z = Random.Range(minimumPosition.z, maximumPosition.z);

        return new Vector3(x, 0, z);
    }

    void HandleEnemyDeath(Character character)
    {
        Controller controller = character.owner;
        character.GetComponent<CharacterHealth>().OnDeath -= HandleEnemyDeath;

        controller.Unposses();

        TrashMan.despawn(character.gameObject);
        TrashMan.despawn(controller.gameObject);
    }

    void HandlePlayerDeath(Character character)
    {
        SceneManager.LoadScene(0);
    }
}
