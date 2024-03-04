using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Practica
{

    internal class Program
    {
        static void Main(string[] args)
        {
            // Примеры работы с классом Fraction
            Fraction fraction1 = new Fraction(1, 2);
            Fraction fraction2 = new Fraction(3, 4);

            Console.WriteLine($"Дробь 1: {fraction1}");
            Console.WriteLine($"Дробь 2: {fraction2}");

            // Сложение дробей
            Console.WriteLine($"Сумма: {fraction1 + fraction2}");

            // Вычитание дробей
            Console.WriteLine($"Разность: {fraction1 - fraction2}");

            // Деление дробей
            Console.WriteLine($"Деление: {fraction1 / fraction2}");

            // Умножение дробей
            Console.WriteLine($"Умножение: {fraction1 * fraction2}");

            // Инкремент дроби
            Console.WriteLine($"Инкремент: {fraction1++}");

            // Декремент дроби
            Console.WriteLine($"Декремент: {fraction1--}");

            // Изменение знака дроби
            Console.WriteLine($"Изменение знака: {-fraction1}");

            // Получение целой части дроби
            Console.WriteLine($"Целая часть: {Fraction.GetWholePart(fraction1)}");

            // Получение числителя и знаменателя по индексу
            Console.WriteLine($"Числитель дроби 1: {fraction1[0]}");
            Console.WriteLine($"Знаменатель дроби 2: {fraction1[1]}");

            // Сравнение дробей
            Console.WriteLine($"Равны ли дробь 1 и дробь 2? {fraction1.Equals(fraction2)}");


            // Примеры работы с классом Complex
            Complex complex1 = new Complex(2, 3);
            Complex complex2 = new Complex(1, 4);

            Console.WriteLine($"\n\nКомплексное число 1: {complex1}");
            Console.WriteLine($"Комплексное число 2: {complex2}");

            // Сложение комплексных чисел
            Console.WriteLine($"Сумма: {complex1 + complex2}");

            // Вычитание комплексных чисел
            Console.WriteLine($"Разность: {complex1 - complex2}");

            // Умножение комплексных чисел
            Console.WriteLine($"Умножение: {complex1 * complex2}");

            // Деление комплексных чисел
            Console.WriteLine($"Деление: {complex1 / complex2}");

            // Изменение знака комплексного числа
            Console.WriteLine($"Изменение знака: {-complex1}");

            // Инкремент комплексного числа
            Console.WriteLine($"Инкремент: {++complex1}");

            // Декремент комплексного числа
            Console.WriteLine($"Декремент: {--complex1}");

            // Получение модуля комплексного числа
            Console.WriteLine($"Модуль комплексного числа: {complex1.GetMagnitude()}");

            // Получение действительной части комплексного числа
            Console.WriteLine($"Действительная часть: {complex1["Re"]}");

            // Получение мнимой части комплексного числа
            Console.WriteLine($"Мнимая часть: {complex1["Im"]}");

            // Сравнение комплексных чисел
            Console.WriteLine($"Равны ли комплексное число 1 и комплексное число 2? {complex1.Equals(complex2)}");
        }
    }


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

        //сложениe двух дробей
        public static Fraction operator +(Fraction f1, Fraction fr2)
        {
            int newNumerator = f1.numerator * fr2.denominator + fr2.numerator * f1.denominator;
            int newDenominator = f1.denominator * fr2.denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        // Subtract - Вычитаниe двух дробей
        public static Fraction operator -(Fraction f1, Fraction f2)
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



    /*Комплексное число.
        Реализовать класс Complex для работы с комплексными числами. 
        Реализовать методы операций:
        	сложения, вычитания, умножения, деления двух комплексных чисел
        	перегрузить эти методы для комплексного числа и действительного числа (double)
        	изменение знака комплексного числа
        	инкремент/декремент
        	получение модуля комплексного числа
        	Equals, GetHashCode, CompareTo
        	получение действительной части по индексу “Re”, получение мнимой части по индексу “Im”
        */

    internal class Complex
    {
        // Автосвойства для комплексных чисел
        public double Real { get; set; }      // Действительная часть
        public double Imaginary { get; set; } // Мнимая часть

        // Конструкторы
        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public Complex(double value)
        {
            Real = value;
            Imaginary = 0;
        }

        public Complex()
        {
            Real = 0;
            Imaginary = 0;
        }

        // Перегрузка оператора сложения для комплексных чисел
        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
        }

        // Перегрузка оператора вычитания для комплексных чисел
        public static Complex operator -(Complex c1, Complex c2)
        {
            return new Complex(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);
        }

        // Перегрузка оператора умножения для комплексных чисел
        public static Complex operator *(Complex c1, Complex c2)
        {
            return new Complex(c1.Real * c2.Real - c1.Imaginary * c2.Imaginary,
                               c1.Real * c2.Imaginary + c1.Imaginary * c2.Real);
        }

        // Перегрузка оператора деления для комплексных чисел
        public static Complex operator /(Complex c1, Complex c2)
        {
            double denominator = c2.Real * c2.Real + c2.Imaginary * c2.Imaginary;
            double realPart = (c1.Real * c2.Real + c1.Imaginary * c2.Imaginary) / denominator;
            double imaginaryPart = (c1.Imaginary * c2.Real - c1.Real * c2.Imaginary) / denominator;
            return new Complex(realPart, imaginaryPart);
        }

        // Перегрузка оператора изменения знака для комплексных чисел
        public static Complex operator -(Complex c)
        {
            return new Complex(-c.Real, -c.Imaginary);
        }

        // Перегрузка оператора инкремента для комплексных чисел
        public static Complex operator ++(Complex c)
        {
            return new Complex(c.Real + 1, c.Imaginary);
        }

        // Перегрузка оператора декремента для комплексных чисел
        public static Complex operator --(Complex c)
        {
            return new Complex(c.Real - 1, c.Imaginary);
        }

        // Метод получения модуля комплексного числа
        public double GetMagnitude()
        {
            return Math.Sqrt(Real * Real + Imaginary * Imaginary);
        }

        // Перегрузка метода Equals
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Complex))
                return false;

            Complex other = (Complex)obj;
            return Real == other.Real && Imaginary == other.Imaginary;
        }

        // Перегрузка метода GetHashCode
        public override int GetHashCode()
        {
            return Real.GetHashCode() ^ Imaginary.GetHashCode();
        }

        // Перегрузка метода CompareTo
        public int CompareTo(Complex other)
        {
            double thisMagnitude = this.GetMagnitude();
            double otherMagnitude = other.GetMagnitude();

            if (thisMagnitude < otherMagnitude)
                return -1;
            else if (thisMagnitude > otherMagnitude)
                return 1;
            else
                return 0;
        }

        // Индексатор для получения действительной и мнимой части
        public double this[string part]
        {
            get
            {
                if (part == "Re")
                    return Real;
                else if (part == "Im")
                    return Imaginary;
                else
                    throw new ArgumentException("Неверное наименование части. Используйте \"Re\" для действительной части или \"Im\" для мнимой части.");
            }
        }

        // Перегрузка метода ToString для красивого вывода комплексного числа
        public override string ToString()
        {
            if (Imaginary >= 0)
                return $"{Real} + {Imaginary}i";
            else
                return $"{Real} - {-Imaginary}i";
        }
    }
}



