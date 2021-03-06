﻿namespace GameObjects.Animations
{
    using GameGlobal;
    using GameObjects;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;

    public class CombatNumberItemList
    {
        private double currentTime;
        public CombatNumberDirection Direction;
        public List<CombatNumberItem> Numbers = new List<CombatNumberItem>();
        private bool startDrawing;

        public CombatNumberItemList(CombatNumberDirection direction)
        {
            this.Direction = direction;
        }

        public void AddNumber(int number, CombatNumberKind kind, Point position)
        {
            CombatNumberItem item = new CombatNumberItem();
            item.Number = number;
            item.Kind = kind;
            item.Position = position;
            this.Numbers.Add(item);
            this.startDrawing = false;
        }

        public void Clear()
        {
            this.Numbers.Clear();
        }

        public void Draw(Screen screen, SpriteBatch spriteBatch, CombatNumberGenerator generator, GetDisplayRectangle positionMethod, int tileWidth, GameTime gameTime)
        {
            if (screen.PeekUndoneWork().Kind != UndoneWorkKind.None)
            {
                this.startDrawing = false;
            }
            else
            {
                if (!this.startDrawing)
                {
                    this.startDrawing = true;
                    this.currentTime = gameTime.TotalGameTime.TotalMilliseconds;
                }
                float scale = 1f;
                if (tileWidth < 40)
                {
                    this.Clear();
                }
                else
                {
                    int num2;
                    Rectangle rectangle;
                    if (tileWidth < 100)
                    {
                        scale = ((float) tileWidth) / 100f;
                        if (scale < 0.6)
                        {
                            scale = 0.6f;
                        }
                    }
                    switch (this.Direction)
                    {
                        case CombatNumberDirection.上:
                            num2 = 0;
                            while (num2 < this.Numbers.Count)
                            {
                                rectangle = positionMethod(this.Numbers[num2].Position);
                                this.Numbers[num2].DrawLeft(spriteBatch, generator, new Point(rectangle.Left, (rectangle.Top + (rectangle.Height / 2)) - ((int) ((generator.DigitHeight * num2) * scale))), scale);
                                num2++;
                            }
                            break;

                        case CombatNumberDirection.下:
                            for (num2 = 0; num2 < this.Numbers.Count; num2++)
                            {
                                rectangle = positionMethod(this.Numbers[num2].Position);
                                this.Numbers[num2].DrawRight(spriteBatch, generator, new Point(rectangle.Right, (rectangle.Top + (rectangle.Height / 2)) + ((int) ((generator.DigitHeight * num2) * scale))), scale);
                            }
                            break;
                    }
                    if ((gameTime.TotalGameTime.TotalMilliseconds - this.currentTime) >= 1200.0 / GlobalVariables.FastBattleSpeed)
                    {
                        this.Clear();
                    }
                }
            }
        }

        public bool IsEmpty
        {
            get
            {
                return (this.Numbers.Count == 0);
            }
        }
    }
}

