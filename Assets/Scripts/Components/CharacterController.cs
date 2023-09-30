﻿using Assets.Scripts.Models;
using Assets.Scripts.Models.Abstract;
using System;
using UnityEngine;

namespace Assets.Scripts.Components
{
    [Serializable]
    public class PlayerData : SaveableData
    {
        public Vector3 playerLocation;
        public int health;
        public int xp;
        public bool isAlive = true;

        public PlayerData(Vector3 playerLocation, int health, int xp, bool isAlive)
        {
            this.playerLocation = playerLocation;
            this.health = health;
            this.xp = xp;
            this.isAlive = isAlive;
        }
    }

    public class CharacterController : SaveableMonoBehaviour<PlayerData>
    {
        public Vector3 playerLocation;
        public int health = 100;
        public int xp = 0;
        public bool isAlive = true;

        private void Start()
        {
            playerLocation = this.transform.position;
            health = 0;
            isAlive = false;
        }

        private void Update()
        {
            xp++;
            xp*= 2;
            health++;
        }

        public override PlayerData SaveData()
        {
            var temp = new PlayerData(playerLocation, health, xp, isAlive);
            temp.Guid = this.Guid;
            return temp;
        }

        public override void LoadData(PlayerData saveData)
        {
            if (saveData != null)
            {
                playerLocation = saveData.playerLocation;
                health = saveData.health;
                xp = saveData.xp;
                isAlive = saveData.isAlive;

                // Move the player to the saved location
                transform.position = playerLocation;
            }
            else
            {
                Debug.LogError("No data to load!");
            }
        }
    }
}