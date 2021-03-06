﻿namespace RoutewayEditorPlugin
{
    using GameFreeText;
    using GameGlobal;
    using GameObjects;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using PluginInterface;
    using PluginInterface.BaseInterface;
    using System;
    using System.Drawing;
    using System.Xml;

    public class RoutewayEditorPlugin : GameObject, IRoutewayEditor, IBasePlugin, IPluginXML, IPluginGraphics, IScreenDisableRects
    {
        private string author = "clip_on";
        private const string DataPath = @"GameComponents\RoutewayEditor\Data\";
        private string description = "粮道编辑器";
        private GraphicsDevice graphicsDevice;
        private const string Path = @"GameComponents\RoutewayEditor\";
        private string pluginName = "RoutewayEditorPlugin";
        private RoutewayEditor routewayEditor = new RoutewayEditor();
        private string version = "1.0.0";
        private const string XMLFilename = "RoutewayEditorData.xml";

        public void AddDisableRects()
        {
            this.routewayEditor.AddDisableRects();
        }

        public void Dispose()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.routewayEditor.IsShowing)
            {
                this.routewayEditor.Draw(spriteBatch);
            }
        }

        public void Initialize()
        {
        }

        public void LoadDataFromXMLDocument(string filename)
        {
            Font font;
            Microsoft.Xna.Framework.Graphics.Color color;
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            XmlNode nextSibling = document.FirstChild.NextSibling;
            XmlNode node = nextSibling.ChildNodes.Item(0);
            this.routewayEditor.BackgroundTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.routewayEditor.BackgroundSize = new Microsoft.Xna.Framework.Point(int.Parse(node.Attributes.GetNamedItem("Width").Value), int.Parse(node.Attributes.GetNamedItem("Height").Value));
            node = nextSibling.ChildNodes.Item(1);
            this.routewayEditor.CommentBackgroundTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.routewayEditor.CommentClientWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            node = nextSibling.ChildNodes.Item(2);
            this.routewayEditor.Comment.ClientWidth = this.routewayEditor.CommentClientWidth;
            this.routewayEditor.Comment.RowMargin = int.Parse(node.Attributes.GetNamedItem("RowMargin").Value);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.routewayEditor.Comment.Builder.SetFreeTextBuilder(this.graphicsDevice, font);
            this.routewayEditor.Comment.DefaultColor = color;
            node = nextSibling.ChildNodes.Item(3);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.routewayEditor.TitleText = new FreeText(this.graphicsDevice, font, color);
            this.routewayEditor.TitleText.Position = StaticMethods.LoadRectangleFromXMLNode(node);
            this.routewayEditor.TitleText.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            this.routewayEditor.TitleText.Text = node.Attributes["Text"].Value;
            node = nextSibling.ChildNodes.Item(4);
            this.routewayEditor.ExtendButtonPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            this.routewayEditor.ExtendButtonTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.routewayEditor.ExtendButtonSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.routewayEditor.ExtendButtonDownTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("Down").Value);
            this.routewayEditor.ExtendButtonDisabledTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("Disabled").Value);
            node = nextSibling.ChildNodes.Item(5);
            this.routewayEditor.CutButtonPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            this.routewayEditor.CutButtonTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.routewayEditor.CutButtonSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.routewayEditor.CutButtonDownTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("Down").Value);
            this.routewayEditor.CutButtonDisabledTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("Disabled").Value);
            node = nextSibling.ChildNodes.Item(6);
            this.routewayEditor.DirectionSwitchPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            this.routewayEditor.DirectionSwitchTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.routewayEditor.DirectionSwitchSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.routewayEditor.DirectionSwitchDisabledTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("Disabled").Value);
            node = nextSibling.ChildNodes.Item(7);
            this.routewayEditor.BuildButtonPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            this.routewayEditor.BuildButtonTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.routewayEditor.BuildButtonSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.routewayEditor.BuildButtonDownTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("Down").Value);
            node = nextSibling.ChildNodes.Item(8);
            this.routewayEditor.EndButtonPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            this.routewayEditor.EndButtonTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.routewayEditor.EndButtonSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.routewayEditor.EndButtonDownTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("Down").Value);
            node = nextSibling.ChildNodes.Item(9);
            this.routewayEditor.ExtendMouseArrowSize = new Microsoft.Xna.Framework.Point(int.Parse(node.Attributes.GetNamedItem("Width").Value), int.Parse(node.Attributes.GetNamedItem("Height").Value));
            this.routewayEditor.ExtendMouseArrowTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.routewayEditor.ExtendDisabledMouseArrowTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("Disabled").Value);
            node = nextSibling.ChildNodes.Item(10);
            this.routewayEditor.CutMouseArrowSize = new Microsoft.Xna.Framework.Point(int.Parse(node.Attributes.GetNamedItem("Width").Value), int.Parse(node.Attributes.GetNamedItem("Height").Value));
            this.routewayEditor.CutMouseArrowTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.routewayEditor.CutDisabledMouseArrowTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("Disabled").Value);
            node = nextSibling.ChildNodes.Item(11);
            this.routewayEditor.ExtendPointTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.routewayEditor.ExtendPointEndTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("End").Value);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            TextAlign align = (TextAlign) Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            for (int i = 0; i < 4; i++)
            {
                FreeText item = new FreeText(this.graphicsDevice, font, color) {
                    Align = align
                };
                this.routewayEditor.ExtendPointTexts.Add(item);
            }
        }

        public void RemoveDisableRects()
        {
            this.routewayEditor.RemoveDisableRects();
        }

        public void SetGraphicsDevice(GraphicsDevice device)
        {
            this.graphicsDevice = device;
            this.LoadDataFromXMLDocument(@"GameComponents\RoutewayEditor\RoutewayEditorData.xml");
        }

        public void SetRouteway(object routeway)
        {
            this.routewayEditor.SetRouteway(routeway as Routeway);
        }

        public void SetScreen(object screen)
        {
            this.routewayEditor.Initialize(screen as Screen);
        }

        public void Update(GameTime gameTime)
        {
            if (this.routewayEditor.IsShowing)
            {
                this.routewayEditor.Update();
            }
        }

        public string Author
        {
            get
            {
                return this.author;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
        }

        public object Instance
        {
            get
            {
                return this;
            }
        }

        public bool IsShowing
        {
            get
            {
                return this.routewayEditor.IsShowing;
            }
            set
            {
                this.routewayEditor.IsShowing = value;
            }
        }

        public string PluginName
        {
            get
            {
                return this.pluginName;
            }
        }

        public string Version
        {
            get
            {
                return this.version;
            }
        }
    }
}

