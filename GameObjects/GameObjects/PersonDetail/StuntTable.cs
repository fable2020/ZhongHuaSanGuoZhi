﻿namespace GameObjects.PersonDetail
{
    using GameObjects;
    using System;
    using System.Collections.Generic;

    public class StuntTable
    {
        public Dictionary<int, Stunt> Stunts = new Dictionary<int, Stunt>();

        public bool AddStunt(Stunt stunt)
        {
            if (this.Stunts.ContainsKey(stunt.ID))
            {
                return false;
            }
            this.Stunts.Add(stunt.ID, stunt);
            return true;
        }

        public void Clear()
        {
            this.Stunts.Clear();
        }

        public Stunt GetStunt(int stuntID)
        {
            Stunt stunt = null;
            this.Stunts.TryGetValue(stuntID, out stunt);
            return stunt;
        }

        public GameObjectList GetStuntList()
        {
            GameObjectList list = new GameObjectList();
            foreach (Stunt stunt in this.Stunts.Values)
            {
                list.Add(stunt);
            }
            return list;
        }

        public void LoadFromString(StuntTable allStunts, string stuntIDs)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = stuntIDs.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            Stunt stunt = null;
            for (int i = 0; i < strArray.Length; i++)
            {
                if (allStunts.Stunts.TryGetValue(int.Parse(strArray[i]), out stunt))
                {
                    this.AddStunt(stunt);
                }
            }
        }

        public string SaveToString()
        {
            string str = "";
            foreach (Stunt stunt in this.Stunts.Values)
            {
                str = str + stunt.ID.ToString() + " ";
            }
            return str;
        }

        public int Count
        {
            get
            {
                return this.Stunts.Count;
            }
        }
    }
}

