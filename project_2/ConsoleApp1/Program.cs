using System.Globalization;

class TaxaMetabolicaBasal
{
    static void Main()
    {
        /*
        CLI para calcular a taxa metabólica basal do usuário com base no peso(kg), idade e altura(cm);
        O programa deve armazenar, modificar e mostrar os dados do usuário;
        o usuário pode calcular novamente seu TMB adicionando o dia (método AdicionarDados);
        O usuário pode encerrar o programa (método Quit)
        */
        const int STORAGE = 100;

        TaxaMetabolicaBasal q = new TaxaMetabolicaBasal();

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
                if (userName != null && gender != ' ')
                {
                    q.AdicionarDados(age, height, weight, date, gender, currentIndex);

                }else{           
                    Console.Write("Type your name: ");
                    userName = Console.ReadLine();

                    Console.Write("Type your gender (m/f): ");
                    gender = Convert.ToChar(Console.ReadLine());

                    q.AdicionarDados(age, height, weight, date, gender, currentIndex);
                }

                currentIndex++;

            }else if (command == "show")
            {
                q.MostrarDados(age, height, weight, date, gender, currentIndex);

            }else if (command == "quit")
            {
                break;
            }

        }
    }

    public void AdicionarDados(int[] age, int[] height, double[] weight, string[] date,char gender, int index)
    {
        Console.Write("Type your age: ");
        age[index] = Convert.ToInt32(Console.ReadLine());

        Console.Write("Type your height: ");
        height[index] = Convert.ToInt32(Console.ReadLine());

        Console.Write("Type your weight: ");
        weight[index] = Convert.ToDouble(Console.ReadLine());

        Console.Write("Type current date (dd/mm/yyyy): ");
        date[index] = Convert.ToString(Console.ReadLine());

    }

    public void MostrarDados(int[] age, int[] height, double[] weight, string[] date, char gender,int index)
    {
        for (int i = 0; i < index; i++)
        {
            double tmbResult = TMBCalculation(age[i], weight[i], height[i], gender);

            Console.WriteLine("+++++++++++++++++++++++++++++++++");
            Console.WriteLine($"+ Age: {age[i]}\t\t\t+");
            Console.WriteLine($"+ Height: {height[i]} cm\t\t+");
            Console.WriteLine($"+ Weight: {weight[i]} kg\t\t\t+");
            Console.WriteLine($"+ TMB: {tmbResult.ToString("F3")} Kcal/day \t+");
            Console.WriteLine($"+ Date: {date[i]}\t\t+");
            Console.WriteLine("+++++++++++++++++++++++++++++++++");

        }
    }

    public double TMBCalculation(int idade, double peso, int altura, char gender) 
    {
        // Function that calculates the Herris Benedict equation for Basal Methabolic Rate (BMR) whitch takes four parameters
        // user age, gender, weight(kg), and height(cm).
        double tmbResult;

        if (gender == 'M' || gender == 'm')
        {
            tmbResult = 88.36 + (13.4 * peso) + (4.8 * altura) - (5.7 * idade);

            return tmbResult;

        }else if (gender == 'F' || gender == 'f')
        {
            tmbResult = 447.6 + (9.2 * peso) + (3.1 * altura) - (4.3 * idade);

            return tmbResult;
        }

        return 0;
    }
}