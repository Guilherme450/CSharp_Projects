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
        double[] bmr = new double[STORAGE];

        q.HelpMessage();

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
                        q.AddData(age, height, weight, date, gender, currentIndex, bmr);

                    }else{           
                        Console.Write("Type your name: ");
                        userName = Console.ReadLine();

                        Console.Write("Type your gender (m/f): ");
                        gender = Convert.ToChar(Console.ReadLine());

                        q.AddData(age, height, weight, date, gender, currentIndex, bmr);
                    }
                }else {
                    Console.WriteLine("The space is full. Cannot add more data.");
                    break;
                }

                currentIndex++;

            }else if (command == "show")
            {
                if (userName == null)
                {
                    Console.WriteLine("No data stored.");
                }else{
                    q.ShowData(userName, age, height, weight, date, gender, bmr, currentIndex);
                }

            }else if (command == "quit")
            {
                Console.WriteLine("Program exited.");
                break;
            }else if (command == "search")
            {
                q.SearchData(userName, age, height, weight, currentIndex, gender, date, bmr);
            }else if (command == "help")
            {
                q.HelpMessage();
            }else if (command == "average")
            {
                if (currentIndex > 0)
                {
                    Console.WriteLine($"BMR Average: {q.BMRAverage(bmr, currentIndex):N2} Kcal");
                }else{
                    Console.WriteLine("There is no data stored!");
                }

            }else if (command == "delete")
            {
                Console.WriteLine("Sorry! We are still working on this.");
            }

        }
    }

    public void AddData(int[] age, int[] height, double[] weight, string[] date,char gender, int index, double[] bmr)
    {
        Console.Write("Type your age: ");
        age[index] = Convert.ToInt32(Console.ReadLine());

        Console.Write("Type your height (cm): ");
        height[index] = Convert.ToInt32(Console.ReadLine());

        Console.Write("Type your weight (kg): ");
        weight[index] = Convert.ToDouble(Console.ReadLine());

        Console.Write("Type current date (dd/mm/yyyy): ");
        date[index] = Convert.ToString(Console.ReadLine());
        bmr[index] = BMRCalculation(age[index], weight[index], height[index], gender);

    }

    public void DataMessage(string name, int[] age, int[] height, double[] weight, string[] date, int variateIndex, double[] bmr)
    {
        Console.WriteLine("+++++++++++++++++++++++++++++++++");
        Console.WriteLine($"+ Name: {name}\t\t+");
        Console.WriteLine($"+ Age: {age[variateIndex]}\t\t\t+");
        Console.WriteLine($"+ Height: {height[variateIndex]} cm\t\t+");
        Console.WriteLine($"+ Weight: {weight[variateIndex]:N} kg\t\t+");
        Console.WriteLine($"+ BMR: {bmr[variateIndex]:N2} Kcal/day \t+");
        Console.WriteLine($"+ Date: {date[variateIndex]}\t\t+");
        Console.WriteLine("+++++++++++++++++++++++++++++++++");
    }

    public void ShowData(string name, int[] age, int[] height, double[] weight, string[] date, char gender, double[] bmr, int index = 0)
    {
        for (int i = 0; i < index; i++)
        {
            DataMessage(name, age, height, weight, date, i, bmr);
        }
    }

    // mean of user bmr
    public double BMRAverage(double[] bmr, int index)
    {
        double totalBMR = 0;
        int amountBMRData = 0;
        double meanBMR;

        for (int i = 0; i < index; i++)
        {
            totalBMR += bmr[i];
            amountBMRData++;
        }

        meanBMR = totalBMR / amountBMRData;

        return meanBMR;
    }

    // delete data
    /*
    public void DeleteData(string userDate, string[] date, string name, int[] age, int[] height, double[] weight, char gender, double[] bmr)
    {
        int element_index = 0;
        //int index_del_element;

        foreach (string item in date)
        {
            if (userDate == item)
            {
                Console.WriteLine($"Index: {element_index}");
                DataMessage(name, age, height, weight, date, gender, element_index, bmr);
            }

            element_index++;
        }

        //Console.Write("Which data do you want to delete: ");
        //index_del_element = Convert.ToInt32(Console.ReadLine());

        

        return;
    }
    */

    public void SearchData(string name, int[] age, int[] height, double[] weight, int index, char gender, string[] date, double[] bmr)
    {

        string userSearch;

        Console.Write("Type Date (dd/mm/yyyy)");
        userSearch = Convert.ToString(Console.ReadLine());

        for (int i = 0; i < index; i++)
        {
            if (date != null)
            {
                if (date[i] == userSearch)
                {
                    DataMessage(name, age, height, weight, date, i, bmr);

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

    public void HelpMessage()
    {
        Console.WriteLine("####### WELLCOME BACK #######");
        Console.WriteLine("\tBMR Tracker");
        Console.WriteLine("\t--commands--");
        Console.WriteLine("add: Add data");
        Console.WriteLine("show: Show the data stored");
        Console.WriteLine("search: Searchs for a specific data");
        Console.WriteLine("help: Show all the commands");
        Console.WriteLine("quit: Stops the program");
        Console.WriteLine("delete: Delete a Cell");
        Console.WriteLine("average: Mean of BMR");
        Console.WriteLine("#############################");
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