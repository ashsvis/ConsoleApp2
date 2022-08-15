// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
AddListJson addList = new();
addList.GetFileInList();

bool active = true;
while (active)
{
    Console.WriteLine("1. Создать карту для нового сотрудника \n2. Поиск карты сотрудника \n3. Добавить на счет");
    Console.WriteLine("4. Выйти из программы");
    Console.Write("Введите номер пункта: ");

    try
    {
        int command = Convert.ToInt32(Console.ReadLine());
        switch (command)
        {
            case 1:
                addList.AddInListJs();
                break;
            case 4:
                addList.AddInList();
                active = false;
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
