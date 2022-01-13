﻿using snake_game;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake_game
{
    class Point
    {
        public int x;
        public int y;
        public char symb;

        public Point(int _x, int _y, char _symb)
        {
            x = _x;
            y = _y;
            symb = _symb;
        }

        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            symb = p.symb;
        }

        public void Move(int offset, Direction direction)
        {
            if (direction == Direction.RIGHT)
            {
                x = x + offset;
            }
            else if (direction == Direction.LEFT)
            {
                x = x - offset;
            }
            else if (direction == Direction.Down)
            {
                y = y + offset;
            }
            else if (direction == Direction.UP)
            {
                y = y - offset;
            }
        }

        internal void Move(int i, object direstion)
        {
            throw new NotImplementedException();
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symb);
        }

        public void Clear()
        {
            symb = ' ';
            Draw();
        }

        public bool IsHit(Point p)
        {
            return p.x == x && p.y == y;
        }

    }
}