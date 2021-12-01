﻿using System;

namespace HelloOperatoren
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            Bruch result = new Bruch(1,2) * new Bruch(1,2);
        }
    }


    public class Bruch
    {
        public int Zähler { get; set; }
        public int Nenner { get; set; }

        public Bruch(int Zähler, int Nenner)
        {
            this.Zähler = Zähler;
            this.Nenner = Nenner;
        }


        #region == UND != Operator

        public static bool operator ==(Bruch left, Bruch right)
        {
            if (left.Nenner != right.Nenner)
                return false;

            if (left.Zähler != right.Zähler)
                return false;


            return true; 
        }

        public static bool operator !=(Bruch left, Bruch right)
        {
            if (left.Nenner == right.Nenner)
                return false;

            if (left.Zähler == right.Zähler)
                return false;

            return true;
        }


        #endregion


        #region < und >
        public static bool operator > (Bruch left, Bruch right)
        {
            return true;
        }
        public static bool operator < (Bruch left, Bruch right)
        {
            return true;
        }
        #endregion

        #region >= und <= 
        public static bool operator >=(Bruch left, Bruch right)
        {
            return true;
        }

        public static bool operator <=(Bruch left, Bruch right)
        {
            return true;
        }
        #endregion



        #region * Operator UND Operatoren kann manüberladen
        public static Bruch operator *(Bruch left, Bruch right)
            => new Bruch(left.Zähler * right.Zähler, left.Nenner * right.Nenner);

        public static Bruch operator *(Bruch left, int right)
        {
            return new Bruch(left.Zähler * right, left.Nenner);
        }


        //Es gibt weitere Operatoren für: +, -, /
        #endregion

    }
}
