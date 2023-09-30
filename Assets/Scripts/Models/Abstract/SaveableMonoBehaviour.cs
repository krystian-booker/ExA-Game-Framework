﻿using Assets.Scripts.Managers;
using Assets.Scripts.Models.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Models.Abstract
{
    public abstract class SaveableMonoBehaviour<T> : MonoBehaviour, ISaveable where T : SaveableData
    {
        [HideInInspector] public string Guid = System.Guid.NewGuid().ToString();

        private void Awake()
        {
            SaveManager.Instance.RegisterSaveableObject(Guid, this);
        }

        public abstract T SaveData();
        public abstract void LoadData(T saveData);

        public SaveableData Save()
        {
            return SaveData();
        }

        public void Load(SaveableData data)
        {
            LoadData((T)data);
        }

        public string GetGuid() => Guid;
    }
}