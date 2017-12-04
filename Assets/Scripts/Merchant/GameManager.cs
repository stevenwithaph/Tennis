using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Merchant.Characters;
using Merchant.Characters.Abilities;
using Merchant.Controllers.Base;
using Merchant.Controllers.Players;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isTimeFrozen = false;

    public enum EnemyTypes
    {
        Tank,
        Bot
    };

    public GameObject tank;
    public GameObject tankController;

    public GameObject bot;
    public GameObject botController;

    public GameObject player;
    public GameObject playerController;

    public GameObject enemyDrop;

    public float tankSpawnInterval = 10.0f;

    public PlayerCamera playerCamera;

    public Vector3 minimumPosition = Vector3.zero;
    public Vector3 maximumPosition = Vector3.zero;

    public GameObject gameOverPanel;

    public Slider health;
    public Text scoreText;
    public int score = 0;

    void Awake()
    {
        GameManager.instance = this;
    }
    // Use this for initialization
    void Start()
    {
        TrashMan.recycleBinForGameObject(tank);
        TrashMan.recycleBinForGameObject(tankController);

        TrashMan.recycleBinForGameObject(bot);
        TrashMan.recycleBinForGameObject(botController);

        this.AddScore(0);

        this.SpawnPlayer();
        this.StartCoroutine(this.EnemySpawner());
    }

    public void FreezeTime()
    {
        this.StartCoroutine(this.FreezeTimeCoroutine());
    }

    IEnumerator FreezeTimeCoroutine()
    {
        Time.timeScale = 0.0f;
        yield return new WaitForSecondsRealtime(0.05f);
        Time.timeScale = 1.0f;
    }

    void SpawnRandomEnemy()
    {
        GameObject newEnemy = TrashMan.spawn(enemyDrop);
        newEnemy.GetComponent<EnemyDrop>().enemyType = EnemyTypes.Tank;
        newEnemy.GetComponent<EnemyDrop>().OnDrop += SpawnEnemy;

        newEnemy.transform.position = this.RandomPosition();
    }

    void SpawnEnemy(EnemyDrop enemyDrop)
    {
        Vector3 position = enemyDrop.transform.position;

        switch(enemyDrop.enemyType)
        {
            case EnemyTypes.Tank:
                this.SpawnTank(position);
                break;
        }

        enemyDrop.OnDrop -= SpawnEnemy;
    }

    void SpawnTank(Vector3 position)
    {
        GameObject newTank = TrashMan.spawn(tank);
        GameObject newController = TrashMan.spawn(tankController);

        Character tankCharacter = newTank.GetComponent<Character>();
        AIController aiController = newController.GetComponent<AIController>();
        
        tankCharacter.GetComponent<CharacterHealth>().OnDeath += HandleEnemyDeath;
        aiController.Posses(tankCharacter);

        tankCharacter.transform.position = position;
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
        playerCharacter.GetComponent<CharacterHealth>().OnHurt += HandlePlayerHurt;
        controller.Posses(playerCharacter);

        //this.playerCamera.target = playerCharacter.transform;
    }

    IEnumerator EnemySpawner()
    {
        while(true)
        {
            this.SpawnRandomEnemy();
            yield return new WaitForSecondsRealtime(this.tankSpawnInterval);
        }
    }

    Vector3 RandomPosition()
    {
        float x = Random.Range(minimumPosition.x, maximumPosition.x);
        float z = Random.Range(minimumPosition.z, maximumPosition.z);

        return new Vector3(x, 0, z);
    }

    void AddScore(int increase)
    {
        this.score += increase;
        this.scoreText.text = this.score.ToString().PadLeft(4, '0');
    }

    void HandleEnemyDeath(Character character)
    {
        Controller controller = character.owner;
        character.GetComponent<CharacterHealth>().OnDeath -= HandleEnemyDeath;

        controller.Unposses();

        TrashMan.despawn(character.gameObject);
        TrashMan.despawn(controller.gameObject);

        this.AddScore(100);
    }

    void HandlePlayerHurt(Character character)
    {
        int health = character.GetComponent<CharacterHealth>().health;
        int maxHealth = character.GetComponent<CharacterHealth>().maxHealth;
        
        float percent = (float)health/(float)maxHealth;

        this.health.value = percent;
    }

    void HandlePlayerDeath(Character character)
    {
        this.StopAllCoroutines();

        this.health.value = 0;
        character.owner.gameObject.SetActive(false);
        character.gameObject.SetActive(false);

        this.isTimeFrozen = false;
        Time.timeScale = 1.0f;

        this.gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
}
