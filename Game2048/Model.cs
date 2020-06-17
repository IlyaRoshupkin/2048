using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    public class Model
    {
        Map map;
        static Random rnd = new Random();
        public int size 
        {    
            get { return map.size; } 
        }
       
        public bool isGameOver;

        public Model(int size)
        {
            map = new Map(size);
        }

        public bool IsGameOver()
        {
            return isGameOver;
        }

        public int GetMap(int x, int y)
        {
            return map.Get(x,y);
        }

        void Lift(int x, int y, int sx, int sy)
        {
            if (map.Get(x, y) > 0)
                while (map.Get(x +sx, y + sy) == 0)
                {
                    map.Set(x + sx, y + sy, map.Get(x, y));
                    map.Set(x, y, 0);
                    x += sx;
                    y += sy;
                }
        }

        public void Left()
        {
            for (int y = 0; y < map.size; y++)
                for (int x = 0; x < map.size; x++)
                    Lift(x, y, -1, 0);
            AddRandomNumber();
        }

        public void Right()
        {
            for (int y = 0; y < map.size; y++)
                for (int x = map.size-2; x >= 0; x--)
                    Lift(x, y, +1, 0);
            AddRandomNumber();
        }

        public void Up()
        {
            throw new NotImplementedException();
        }

        public void Down()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    map.Set(x, y, 0);
            AddRandomNumber();
            AddRandomNumber();
            AddRandomNumber();
            AddRandomNumber();
            AddRandomNumber();
            AddRandomNumber();
        }

        private void AddRandomNumber()
        {
            if (isGameOver) return;
            for(int j = 0; j < 100;j++)
            {
                int x = rnd.Next(0, map.size);
                int y = rnd.Next(0, map.size);
                if (map.Get(x, y) == 0)
                {
                    map.Set(x, y, rnd.Next(1, 3) * 2);
                    return;
                }
            }
        }
    }
}
