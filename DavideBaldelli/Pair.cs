﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP20bdefender.DavideBaldelli
{
    public class Pair<T1, T2>
    {
        private readonly T1 x;
        private readonly T2 y;

        public T1 X
        {
            get { return x; }
        }

        public T2 Y
        {
            get { return this.y; }
        }

        public Pair(T1 x, T2 y)
        {
            this.x = x;
            this.y = y;
        }
    }
}