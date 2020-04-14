using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a simple script where the core logic of loot prize / reward 
/// are randomly selected. The presentation of the loot is left empty for
/// the various styles of showcasing the loot to the player.
/// </summary>

public class LootGenerator : MonoBehaviour {
    [SerializeField] LootProperties[] LootTable = null;

    int MaxLootNumberPool = 1;

    // Creating a object container for a loot table
    [System.Serializable]
    class LootProperties {
        public string LootCatagory = null;
        [AbsoluteValue()] public int LootChance = 0;
        public GameObject[] Rewards = null;
    }

    // Start is called before the first frame update
    void Start() {
        // Creating a pool of numbers for the total chance of winning anything
        for (int i = 0; i < LootTable.Length; i++) {
            MaxLootNumberPool += LootTable[i].LootChance;
        }
    }

    // Update is called once per frame
    void Update() {

    }

    // Choosing the reward
    public void LootReward(int NumberOfRewards) {
        for (int x = 0; x < NumberOfRewards; x++) {
            int TierNumber = Random.Range(0, MaxLootNumberPool);
            int SelectedCatagory = 0;
            int LastMinNumber = 0;
            int LastMaxNumber = 0;

            for (int y = 0; y < LootTable.Length; y ++) {
                LastMinNumber = LastMaxNumber;
                LastMaxNumber += LootTable[y].LootChance;

                if (TierNumber > LastMinNumber && TierNumber <= LastMaxNumber) {
                    SelectedCatagory = y;
                    break;
                }
            }

            int SelectedReward = Random.Range(0, LootTable[SelectedCatagory].Rewards.Length);
            Debug.Log("The selected reward is: " + LootTable[SelectedCatagory].Rewards[SelectedReward] + ", which is a " + LootTable[SelectedCatagory].LootCatagory + " reward catagory");
            ShowReward(SelectedCatagory, SelectedReward);
        }
    }

    // Showcasing the reward
    void ShowReward(int Catagory, int Reward) {
        GameObject RewardObj = Instantiate(LootTable[Catagory].Rewards[Reward], transform.position, Quaternion.Euler(-90, 180, 0)) as GameObject;
    }
}
