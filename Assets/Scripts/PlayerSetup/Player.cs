using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHp = 1000;
    public int currentHp = 1000;
    [SerializeField] private StatusBar hpBar;
    [HideInInspector] public bool isAlive;

    
    [SerializeField] ExperienceBar experienceBar;
    [SerializeField] private int experience = 0;
    public int level = 1;

    [SerializeField] private List<UpgradesData> upgrades;

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float moveSpeed;

    [HideInInspector] public Vector2 movement;
    [HideInInspector] public Vector2 lastMovement; 

    private int toLevelUp{
        get{
            return level*1000;
        }
    }
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        hpBar = GameObject.Find("HPBarBase").GetComponent<StatusBar>();
        lastMovement.x = 1f;
        isAlive = true;
        experienceBar.UpdateExperienceSlider(experience, toLevelUp);
        experienceBar.SetLevelText(level, GetUpgrades(4));
    }

    private void Update()
    {
        if(isAlive){
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if(movement.x != 0)
            {
                lastMovement.x = movement.x;
                lastMovement.y = 0f;
            }
            else if(movement.y != 0)
            {
                lastMovement.y = movement.y;
                lastMovement.x = 0f;
            }
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        if(currentHp <= 0){
            isAlive = false;
            gameObject.SetActive(false);
        }
        hpBar.SetState(currentHp, maxHp);
    }

    public void Heal(int amount){
        if(currentHp > 0){
            currentHp += amount;
            if(currentHp > maxHp){
                currentHp = maxHp;
            }
        }
    }

    public void AddExperience(int amount){
        experience += amount;
        CheckLevelUp();
        experienceBar.UpdateExperienceSlider(experience, toLevelUp);
    }

    public void CheckLevelUp(){
        if(experience >= toLevelUp){
            experience -= toLevelUp;
            level++;
            experienceBar.SetLevelText(level, GetUpgrades(4));
        }
    }

    public List<UpgradesData> GetUpgrades(int count){
        List<UpgradesData> upgradeList = new List<UpgradesData>();
        
        if(count > upgrades.Count){
            count = upgrades.Count;
        }
        
        for (int i = 0; i < count; i++)
        {
            upgradeList.Add(upgrades[Random.Range(0, upgrades.Count)]);
        }

        return upgradeList;
    }
}
