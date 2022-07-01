﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Analysis
{
    public class Exercise
    {

        
        public static string Greeting()
        {
            return "Hello you";
        }

        public static string Greeting(string name)
        {
            return "Hello" + name + "!";
        }

        public static string Greeting1(string name = null)
        {
            if (name == null)
            {
                return "Hello you";
            }
            return "Hello" + name + "!";
        }
    }
}
