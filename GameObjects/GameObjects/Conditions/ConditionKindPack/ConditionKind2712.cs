﻿namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind2712 : ConditionKind
    {
        public override bool CheckConditionKind(Architecture a)
        {
            int hostile = 0;
            int friendly = 0;
            foreach (Microsoft.Xna.Framework.Point point in a.LongViewArea.Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if (troopByPosition != null)
                {
                    if (troopByPosition.IsFriendly(a.BelongedFaction))
                    {
                        friendly++;
                    }
                    else
                    {
                        hostile++;
                    }
                }
            }
            return friendly > 0 && hostile > 0 && friendly >= hostile;
        }

    }
}

