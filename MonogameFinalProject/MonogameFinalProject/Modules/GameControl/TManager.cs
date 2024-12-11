using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameFinalProject.Modules.Game;
using MonogameFinalProject.Modules.Global;
using MonogameFinalProject.Modules.Sprites;

namespace MonogameFinalProject.Modules.GameControl
{
    public  class TManager<T> where T : GameManager
    {
        private List<T> _objectList = new List<T>();
        private List<Int32> _killList = new List<Int32>();

        public int ID {  get; set; }
        public Int32 ObjectCount 
        { 
            get{ return _objectList.Count; } 
        }
        public T this[Int32 ID]
        {
            get { return _objectList[ID]; }
            set { _objectList[ID] = value; }
        }

        public TManager() { }
        public TManager(T obj) 
        {
            _objectList = new List<T>();
            ID = 0;
        }
        public Int32 Add(T obj)
        {
            obj.BaseId = ID++;
            _objectList.Add(obj);

            return obj.BaseId;
        }

        public void Kill(Int32 id) 
        {
            _killList.Add(id);
        }

        public int CheckWinner()
        {
            int countEnemy = 0;
            countEnemy = _objectList.Count;
            return countEnemy;
        }

        public virtual void Update(GameTime gameTime) 
        {
            //add objects to the list
            if (_objectList.Count > 0) 
            {
                foreach (T obj in _objectList) 
                {
                obj.Update(gameTime);
                }
            }
            //remove killed objects
            if (_killList.Count > 0)
            {
                foreach( Int32 KillId in _killList)
                {
                    Remove(KillId); 
                }
                _killList.Clear();
            }
        }

        public virtual void Draw(GameTime gameTime)
        {   //call draw function for all objects 
            if (_objectList.Count > 0)
            {
                foreach (T obj in _objectList)
                {
                    obj.Draw(gameTime);
                }
            }
            
        }

        private bool Remove(Int32 KillId)
        {
            bool check = true;
            try
            {
                foreach (T obj in _objectList)
                {
                    if (obj.BaseId == KillId)
                    {
                        _objectList.Remove(obj);
                    }

                }
                return check;
            }
            catch
            {
                check = false; 
                return check;
            }

        }
    }
}
