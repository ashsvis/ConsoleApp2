using Newtonsoft.Json;

class AddListJson
{
    private static List<Persone>? tomList = new();

    /// <summary>
    /// Метод записть в файл Json
    /// </summary>
    public void AddInList()
    {
        string patch = "jsonPersT.json";
        var settings = new JsonSerializerSettings  // Это задаем формат Json
        {
            Formatting = Formatting.Indented,
        };
        string output = JsonConvert.SerializeObject(tomList, settings);  // Создаем строку в формате Json      
        File.WriteAllText(patch, output);  // Записываем файл Json на диск
    }

    /// <summary>
    /// Чтение данных из файла "jsonPers.json"
    /// </summary>
    public void GetFileInList()
    {
        // Читаем файл Json с диска и перегоняем в формат List<Person> с помощью статического конструктора
        string patch = "jsonPersT.json";
        if (File.Exists(patch))
        {
            tomList = JsonConvert.DeserializeObject<List<Persone>>(File.ReadAllText(patch));
        }
        //Отправка в List для работы в Class GetDateJson
        if (tomList == null)
        {
            Console.WriteLine("Не найдено ни одной карточки сотрудника");
            AddInListJs();
        }
        //AddFullList(tom);       
    }

    /// <summary>
    /// Метод заполнения карты
    /// </summary>
    public void AddInListJs()
    {
        var tomAdd = new List<Persone>();
        bool activeAddList = true;
        while (activeAddList)
        {
            Console.WriteLine("Создать карту сотрудника");
            Console.Write("Фамилия:");
            string? lastName = Convert.ToString(Console.ReadLine());
            Console.Write("Имя:");
            string? firstName = Convert.ToString(Console.ReadLine());
            Console.Write("Возраст:");
            byte age = Convert.ToByte(Console.ReadLine());

            //Добавить в коллекцию
            tomAdd.Add(new Persone(lastName, firstName, age));

            Console.WriteLine("1. Создать еще карту\n2. Выйти из создания крты");
            try
            {
                int commandAddList = Convert.ToInt32(Console.ReadLine());
                switch (commandAddList)
                {
                    case 1:
                        activeAddList = true;
                        break;
                    case 2:
                        AddFullList(tomAdd);
                        activeAddList = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public void AddFullList(List<Persone> person)
    {
        tomList?.AddRange(new List<Persone>(person));
    }

    /// <summary>
    /// Метод для вывода списка сотрудников
    /// </summary>
    public void ShowList()
    {
        if (tomList == null)
        {
            Console.WriteLine("Не найдено ни одной карточки сотрудника");
            return;
        }
        foreach (var item in tomList.OrderBy(item => string.Concat(item.LastName, item.FirstName)))
        {
            Console.WriteLine($"{item.LastName} {item.FirstName}");
        }
    }
}
