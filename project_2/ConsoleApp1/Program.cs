using System;

class BasalMethabolicRate
{
    static void Main()
    {
        const int STORAGE = 100;

        BasalMethabolicRate q = new BasalMethabolicRate();

        string userName = null;
        char gender = ' ';

        int currentIndex = 0;

        int[] age = new int[STORAGE]; 
        int[] height = new int[STORAGE];
        double[] weight = new double[STORAGE];
        string[] date = new string[STORAGE];

        while (true)
        {
            Console.Write("> ");
            string command = Console.ReadLine();

            if (command == "add")
            {
                if (currentIndex < STORAGE)
                {
                    if (userName != null && gender != ' ')
                    {
                        q.AddData(age, height, weight, date, gender, currentIndex);

                    }else{           
                        Console.Write("Type your name: ");
                        userName = Console.ReadLine();

                        Console.Write("Type your gender (m/f): ");
                        gender = Convert.ToChar(Console.ReadLine());

                        q.AddData(age, height, weight, date, gender, currentIndex);
                    }
                }else {
                    Console.WriteLine("The space is full.");
                }

                currentIndex++;

            }else if (command == "show")
            {
                if (userName == null)
                {
                    Console.WriteLine("No data stored.");
                }else{
                    q.ShowData(userName, age, height, weight, date, gender, currentIndex);
                }

            }else if (command == "quit")
            {
                break;
            }else if (command == "search")
            {
                q.SearchData(userName, age, height, weight, currentIndex, gender, date);
            }

        }
    }

    public void AddData(int[] age, int[] height, double[] weight, string[] date,char gender, int index)
    {
        Console.Write("Type your age: ");
        age[index] = Convert.ToInt32(Console.ReadLine());

        Console.Write("Type your height (cm): ");
        height[index] = Convert.ToInt32(Console.ReadLine());

        Console.Write("Type your weight (kg): ");
        weight[index] = Convert.ToDouble(Console.ReadLine());

        Console.Write("Type current date (dd/mm/yyyy): ");
        date[index] = Convert.ToString(Console.ReadLine());

    }

    public void DataMessage(string name, int[] age, int[] height, double[] weight, string[] date, char gender, int variateIndex)
    {
        double bmrResult = BMRCalculation(age[variateIndex], weight[variateIndex], height[variateIndex], gender);

        Console.WriteLine("+++++++++++++++++++++++++++++++++");
        Console.WriteLine($"+ Name: {name}\t\t+");
        Console.WriteLine($"+ Age: {age[variateIndex]}\t\t\t+");
        Console.WriteLine($"+ Height: {height[variateIndex]} cm\t\t+");
        Console.WriteLine($"+ Weight: {weight[variateIndex]} kg\t\t\t+");
        Console.WriteLine($"+ BMR: {bmrResult.ToString("F3")} Kcal/day \t+");
        Console.WriteLine($"+ Date: {date[variateIndex]}\t\t+");
        Console.WriteLine("+++++++++++++++++++++++++++++++++");
    }

    public void ShowData(string name, int[] age, int[] height, double[] weight, string[] date, char gender, int index = 0)
    {
        for (int i = 0; i < index; i++)
        {
            DataMessage(name, age, height, weight, date, gender, i);
        }
    }

    // mean of user bmr

    // delete data

    public void SearchData(string name, int[] age, int[] height, double[] weight, int index, char gender, string[] date)
    {
        /*função que encontra os dados inseridos usando como base a data de adição.*/

        string userSearch;

        Console.Write("Type Date (dd/mm/yyyy)");
        userSearch = Convert.ToString(Console.ReadLine());

        for (int i = 0; i < index; i++)
        {
            if (date != null)
            {
                if (date[i] == userSearch)
                {
                    DataMessage(name, age, height, weight, date, gender, i);

                    break;
                }else{
                    Console.WriteLine("Data not found.");
                }
            }else{
                Console.WriteLine("No data stored.");
                break;
            }
        }

    }

    public double BMRCalculation(int age, double weight, int height, char gender) 
    {
        // Function that calculates the Herris Benedict equation for Basal Methabolic Rate (BMR) whitch takes four parameters
        // user age, gender, weight(kg), and height(cm).
        double bmrResult;

        if (gender == 'M' || gender == 'm')
        {
            bmrResult = 88.36 + (13.4 * weight) + (4.8 * height) - (5.7 * age);

            return bmrResult;

        }else if (gender == 'F' || gender == 'f')
        {
            bmrResult = 447.6 + (9.2 * weight) + (3.1 * height) - (4.3 * age);

            return bmrResult;
        }

        return 0;
    }
}