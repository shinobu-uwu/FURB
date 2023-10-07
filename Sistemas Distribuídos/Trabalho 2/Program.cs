namespace SD;

class Program
{
    static int _coordinatorId = 1; // ID do coordenador
    static int _nextProcessId = 1; // Próximo ID de processo disponível

    static readonly Queue<int> RequestQueue = new(); // Fila de solicitações
    static int _currentResourceHolder; // ID do processo que detém o recurso atualmente
    private static List<int> _processes = new();

    static readonly Random Random = new();

    static void Main()
    {
        Task.Run(() => Coordinator());

        while (true)
        {
            Thread.Sleep(40000);
            CreateProcess();
        }
    }

    static void Coordinator()
    {
        while (true)
        {
            Thread.Sleep(60000);

            Console.WriteLine("Coordenador morreu.");

            lock (RequestQueue)
            {
                RequestQueue.Clear();
                _currentResourceHolder = 0;
            }

            _coordinatorId = _nextProcessId;
            _nextProcessId++;
            Console.WriteLine("Novo coordenador (ID: " + _coordinatorId + ") foi eleito.");
        }
    }

    static void CreateProcess()
    {
        var processId = _nextProcessId;
        _nextProcessId++;
        _processes.Add(processId);
        Console.WriteLine($"Processo criado\nProcessos: [{string.Join(", ", _processes)}]");

        Task.Run(() => ConsumeResource(processId));
    }

    static void ConsumeResource(int processId)
    {
        while (true)
        {
            var resourceUsageTime = Random.Next(5, 16) * 1000;
            var waitTime = Random.Next(10, 26) * 1000;

            Thread.Sleep(waitTime);

            Console.WriteLine($"Processo {processId} está tentando adquirir o recurso.");

            lock (RequestQueue)
            {
                RequestQueue.Enqueue(processId);

                Console.WriteLine($"Fila: [{string.Join(", ", RequestQueue)}]");
                Console.WriteLine($"Coordenador: {_coordinatorId}");
                var atual = _currentResourceHolder != 0 ? _currentResourceHolder.ToString() : "nenhum";
                Console.WriteLine($"Recurso atualmente detido por: {atual}");

                if (RequestQueue.Peek() == processId && _currentResourceHolder == 0)
                {
                    Console.WriteLine($"Processo {processId} obteve o recurso.");
                    _currentResourceHolder = processId;

                    Thread.Sleep(resourceUsageTime);

                    _currentResourceHolder = 0;
                    RequestQueue.Dequeue();
                    Console.WriteLine($"Processo {processId} liberou o recurso.");
                }
            }
        }
    }
}