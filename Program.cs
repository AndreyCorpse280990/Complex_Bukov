using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Practica
{
    /*Дробь.
    Реализовать класс Fraction для работы с обыкновенными дробями. 
    Реализовать методы операций:
    сложения, вычитания, умножения, деления двух дробей
    перегрузить эти методы для дроби и действительного числа (double, int)
    изменение знака дроби
    инкремент/декремент
    получение целой части дроби
    Equals, GetHashCode, CompareTo
    получение числителя по индексу 0, получение знаменателя по индексу 1*/
    internal class Fraction
    {
        private int numerator = 0;
        private int denominator = 0;

        // конструкторы
        public Fraction() { }
        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        // Add - сложениe двух дробей
        public Fraction Add(Fraction f1, Fraction fr2)
        {
            int newNumerator = f1.numerator * fr2.denominator + fr2.numerator * f1.denominator;
            int newDenominator = f1.denominator * fr2.denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        // Subtract - Вычитаниe двух дробей
        public Fraction Subtract(Fraction f1, Fraction f2)
        {
            int newNumerator = f1.numerator * f2.denominator - f2.numerator * f1.denominator;
            int newDenominator = f1.denominator * f2.denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        // делениe двух дробей
        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            int newNumerator = f1.numerator * f2.denominator;
            int newDenominator = f1.denominator * f2.numerator;
            return new Fraction(newNumerator, newDenominator);
        }

        // Умножение дробей
        public static Fraction operator *(Fraction fr1, Fraction fr2)
        {
            int newNumerator = fr1.numerator * fr2.numerator;
            int newDenominator = fr1.denominator * fr2.denominator;
            return new Fraction(newNumerator, newDenominator);
        }


        //изменение знака дроби
        public static Fraction operator -(Fraction fr)
        {
            fr.numerator = -fr.numerator;
            return fr;
        }


        // Инкремент (постфиксная форма)
        public static Fraction operator ++(Fraction fr)
        {
            Fraction originalFraction = new Fraction(fr.numerator, fr.denominator);
            fr.numerator += fr.denominator;
            return originalFraction;
        }

        //  декремент (постфиксная форма)
        public static Fraction operator --(Fraction fr)
        {
            Fraction originalFraction = new Fraction(fr.numerator, fr.denominator);
            fr.numerator -= fr.denominator;
            return originalFraction;
        }


        // получение целой части дроби
        public static Fraction GetWholePart(Fraction fr)
        {
            int wholePart = fr.numerator / fr.denominator;
            return new Fraction(wholePart, 1);
        }


        // получение числителя по индексу 0, получение знаменателя по индексу 1
        public int this[int index]
        {
            get
            {
                if (index == 0)
                    return numerator;
                else if (index == 1)
                    return denominator;
                else
                    return 0;
            }
        }

        //Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) // сравнение типов
            {
                return false;
            }
            Fraction other = (Fraction)obj;
            return numerator == other.numerator && denominator == other.denominator;
        }


        // геттеры\сетеры к числителю
        public int Numerator
        {
            get { return numerator; }
            set { numerator = value; }
        }

        // геттеры\сетеры к знаменателю
        public int Denominator
        {
            get { return denominator; }
            set { denominator = value; }
        }


        // печать
        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            Fraction fraction1 = new Fraction(1, 2);
            Fraction fraction2 = new Fraction(3, 4);

            Console.WriteLine($"Дробь 1: {fraction1}");
            Console.WriteLine($"Дробь 2: {fraction2}");

            // Сложение дробей
            Console.WriteLine($"сумма: {fraction1.Add(fraction1, fraction2)}");

            // Вычитание дробей
            Console.WriteLine($"Вычитание: {fraction1.Subtract(fraction1, fraction2)}");

            // Деление дробей
            Console.WriteLine($"Деление: {fraction1 / fraction2}");

            // Умножение дробей
            Console.WriteLine($"Умножение: {fraction1 * fraction2}");

            // Инкремент дроби
            Console.WriteLine($"Инкремент: {fraction1++}");

            // Декремент дроби
            Console.WriteLine($"Декремент дроби: {fraction1--}");

            // Изменение знака дроби
            Console.WriteLine($"Изменение знака дроби 1: {-fraction1}");

            // Получение целой части дроби
            Console.WriteLine($"Целая часть : {Fraction.GetWholePart(fraction1)}");

            // Получение числителя и знаменателя по индексу
            Console.WriteLine($"числитель дроби 1: {fraction1[0]}");
            Console.WriteLine($"знаменатель дроби 2: {fraction1[1]}");

            // Сравнение дробей
            Console.WriteLine($"Равны ли дробь 1 и дробь 2? {fraction1.Equals(fraction2)}");
        }
    }
}


