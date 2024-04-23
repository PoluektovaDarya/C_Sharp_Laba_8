using System;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Registration<string, int> user = new Registration<string, int>(5);
            user.UserRegistration("Григорий", 01234567);
            user.UserRegistration("Тимофей", 13371337);

            for (int i = 0; i < user.Length(); i++)
            {
                DataBase<string, int> database = user.Get((uint)i);
                Console.WriteLine("Username: " + database.Username + ", Password: " + database.Password);
            }
        }
    }

    public class ArrayG<T>
    {
        private int size;
        private T[] array;

        public ArrayG(uint size)
        {
            array = new T[size];
            this.size = 0;
        }
        public void Add(T item)
        {
            if (size < array.Length)
            {
                array[size] = item;
                size++;
            }
            else
                Console.WriteLine("Массив переполнен");
        }
        public void Remove(uint index)
        {
            if (index < size)
            {
                array[index] = default(T);
            }
            else
                Console.WriteLine("Некорректный индекс");
        }
        public T Get(uint index)
        {
            if (index < size)
                return array[index];
            else
                return default(T);
        }
        public string Get()
        {
            string str = "";
            return str = string.Join(", ", array);
        }
        public int Length()
        {
            return size;
        }
    }

    public class DataBase<TUsername, TPassword>
    {
        public TUsername Username { get; private set; }
        public TPassword Password { get; private set; }
        public DataBase(TUsername username, TPassword password)
        {
            Username = username;
            Password = password;
        }
    }
    public class Registration<TUsername, TPassword> : ArrayG<DataBase<TUsername, TPassword>>
    {
        public Registration(uint size) : base(size)
        {
        }
        public void UserRegistration(TUsername username, TPassword password)
        {
            DataBase<TUsername, TPassword> user = new DataBase<TUsername, TPassword>(username, password);
            Add(user);
        }
    }
}