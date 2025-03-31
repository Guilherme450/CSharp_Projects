// O projeto consiste em desenvolver um sistema de lista de tarefas (ToDo List) utilizando a linguagem C#.
// O sistema deve permitir que o usuário adicione, visualize, edite e exclua tarefas.

namespace TodoList
{
    public class Program
    {
        private List<string> tasks = new List<string>();// Lista de tarefas
        static void Main(string[] args)
        {
            Program classInstance = new Program();// Instância da classe Program
            classInstance.ShowMenu();// Exibe o menu
            
            while (true)
            {
                Console.Write("command: ");
                int option = Convert.ToInt32(Console.ReadLine());// Opção escolhida pelo usuário
                switch (option)
                {
                    case 1:
                        classInstance.AddTask();
                        break;
                    case 2:
                        classInstance.ViewTasks();
                        break;
                    case 3:
                        classInstance.EditTask();
                        break;
                    case 4:
                        classInstance.DeleteTask();
                        break;
                    case 5:
                        Console.Clear();
                        classInstance.ShowMenu();
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        public void AddTask()
        {
            try
            {
                /* Adiciona uma tarefa na lista de tarefas */
                Console.Write("Digite a tarefa que deseja adicionar: ");
                string task = Console.ReadLine();
                tasks.Add(task);// Adiciona a tarefa na lista
            }
            catch (Exception)
            {
                Console.WriteLine("Erro ao adicionar tarefa!");
            }
        }

        public void ViewTasks()
        {
            int index = 1;

            Console.WriteLine("Tarefas:");
            foreach (string task in tasks)
            {
                Console.WriteLine($"{index} - {task}");
                index++;
            }
        }

        public void EditTask()
        {
            try
            {
                /* Edita uma tarefa da lista de tarefas */
                ViewTasks();
                Console.Write("Digite o número da tarefa que deseja editar: ");
                int taskNumber = int.Parse(Console.ReadLine());
                Console.Write("Digite a nova descrição da tarefa: ");
                string newTask = Console.ReadLine();
                tasks[taskNumber - 1] = newTask;// Edita a tarefa na lista
            }
            catch (Exception)
            {
                Console.WriteLine("Número inválido!");
            }
        }

        public void DeleteTask()
        {
            try
            {
                /* Exclui uma tarefa da lista de tarefas */
                ViewTasks();
                Console.Write("Digite o número da tarefa que deseja excluir: ");
                int taskNumber = int.Parse(Console.ReadLine());
                tasks.RemoveAt(taskNumber - 1);// Exclui a tarefa da lista
            }
            catch (Exception)
            {
                Console.WriteLine("Número inválido!");
            }
        }

        public void ShowMenu()
        {
            /* Exibe o menu e retorna a opção escolhida */
            Console.WriteLine("1 - Adicionar tarefa");
            Console.WriteLine("2 - Visualizar tarefas");
            Console.WriteLine("3 - Editar tarefa");
            Console.WriteLine("4 - Excluir tarefa");
            Console.WriteLine("5 - Limpar tela");
            Console.WriteLine("0 - Sair");
        }
    }
}