using System;
using System.Globalization;

class ChoiceGame
{
    static void Main()
    {
        // Se eu quiser usar os métodos criados na minha classe, terei que instanciar essa classe.
        ChoiceGame p = new ChoiceGame();

        double[] minhasNotas = new double[3]; // Array para armazenar 3 notas

        for (int index = 0; index < minhasNotas.Length; index++)
        {
            Console.Write($"Digite o valor da nota {index + 1}: ");
            // O método InvariantCulture é um método da classe Globalization.CultureInfo
            minhasNotas[index] = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
        }

        foreach (double value in minhasNotas)
        {
            Console.WriteLine($"Nota: {value.ToString(CultureInfo.InvariantCulture)}");
        }

        double mean = p.Mean(minhasNotas);
        Console.WriteLine($"Sua média foi: {mean.ToString(CultureInfo.InvariantCulture)}");

        p.StudentSituation(minhasNotas);
    }

    // Método para calcular a média de um array de notas
    public double Mean(double[] array)
    {
        double sum = 0;
        int arrayLength = array.Length;

        foreach (var item in array)
        {
            sum += item;
        }

        return sum / arrayLength;
    }

    // Método para verificar a situação do aluno
    public void StudentSituation(double[] array)
    {
        double mean = Mean(array);

        if (mean > 4 && mean < 7)
        {
            Console.WriteLine("Recuperação");
        }
        else if (mean >= 7)
        {
            Console.WriteLine("Aprovado");
        }
        else
        {
            Console.WriteLine("Reprovado");
        }
    }
}
