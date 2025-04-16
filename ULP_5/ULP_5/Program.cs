using System.Text;
using System.Text.Json;
using System.Xml;

string XML_path = @"C:\Users\popov\source\repos\XMLFile.xml";

XmlDocument xmlDoc = new XmlDocument();
xmlDoc.Load(XML_path); // Загрузка файла

string[] chess_Pieces = { "пешка", "король", "слон", "ладья" };
string[] alternative_names = { "солдат", "монарх", "офицер", "тура" };
string[] wight_status = { "нет", "нет", "легкая фигура", "тяжелая фигура" };
int[] piece_values = { 1, 0, 3, 5 };
string[] color_piece = { "белый", "черный" };
string[] status_piece = { "жив", "мертв" };
Random random = new Random();

try
{
    for (int i = 0; i < 4; i++)
    {
        XmlElement chess_piece = xmlDoc.CreateElement("ChessPiece"); // создание нового эелемента - шахматная фигура

        XmlElement name = xmlDoc.CreateElement("name");
        name.InnerText = chess_Pieces[i];

        XmlElement color = xmlDoc.CreateElement("color");
        color.InnerText = color_piece[random.Next(2)];

        XmlElement status = xmlDoc.CreateElement("status");
        status.InnerText = status_piece[random.Next(2)];

        XmlElement second_name = xmlDoc.CreateElement("second_name");
        second_name.InnerText = alternative_names[i];

        XmlElement class_weight = xmlDoc.CreateElement("class");
        class_weight.InnerText = wight_status[i];

        XmlElement weight = xmlDoc.CreateElement("weight");
        weight.InnerText = piece_values[i].ToString();

        // Добавление дочерних элементов к chess_piece
        chess_piece.AppendChild(name);
        chess_piece.AppendChild(color);
        chess_piece.AppendChild(status);
        chess_piece.AppendChild(second_name);
        chess_piece.AppendChild(class_weight);
        chess_piece.AppendChild(weight);

        XmlNode root = xmlDoc.DocumentElement;
        root.AppendChild(chess_piece);

        Console.WriteLine($"Элемента {chess_Pieces[i]} записан!");
    }

    xmlDoc.Save(XML_path);
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}


Console.Write("Введите название фигуры: ");
string name_figura = Console.ReadLine();

find_piece(XML_path, name_figura);

Console.Write("Введите название фигуры для удаления: ");
string name_figura_remove = Console.ReadLine();

remove_piece(XML_path, name_figura);


static void find_piece(string path, string name)
{
    try
    {
        // считывание XML
        XmlDocument doc = new XmlDocument();
        doc.Load(path);

        XmlNodeList piece = doc.SelectNodes("/Library/ChessPiece"); // выбор всех узлов ChessPiece

        foreach (XmlNode elem in piece)
        {
            string name_piece = elem.SelectSingleNode("name")?.InnerText;

            if (name_piece != null && name_piece == name)
            {
                Console.WriteLine($"Фигура: {name}\n" +
                    $"цвет: {elem.SelectSingleNode("color")?.InnerText}\n" +
                    $"статус: {elem.SelectSingleNode("status")?.InnerText}\n" +
                    $"второе имя: {elem.SelectSingleNode("second_name")?.InnerText}\n" +
                    $"тип фигуры: {elem.SelectSingleNode("class")?.InnerText}\n" +
                    $"вес фигуры: {elem.SelectSingleNode("weight")?.InnerText}\n");
                return;
            }
        }
        Console.WriteLine("Фигура не найдена!");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }


}

static void remove_piece(string path, string name)
{
    try
    {
        // считывание XML
        XmlDocument doc = new XmlDocument();
        doc.Load(path);

        XmlNodeList piece = doc.SelectNodes("/Library/ChessPiece"); // выбор всех узлов ChessPiece

        foreach (XmlNode elem in piece)
        {
            string name_piece = elem.SelectSingleNode("name")?.InnerText;

            if (name_piece != null && name_piece == name)
            {
                XmlNode root = doc.DocumentElement;
                root.RemoveChild(elem);
                Console.WriteLine($"фигура {name} - удалена!");
                return;
            }
        }
        Console.WriteLine("Фигура не найдена!");
        doc.Save(path);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }

}


//using System.Text.Json;
//using System.Text;
//using System.Text.Encodings.Web;
//using System.Diagnostics;

//string json_path = @"C:\Users\popov\source\repos\ULP_5\ULP_5\bin\Debug\net8.0\json_text.json";

//string[] chess_Pieces = { "пешка", "король", "слон", "ладья" };
//string[] alternative_names = { "солдат", "монарх", "офицер", "тура" };
//string[] wight_status = { "нет", "нет", "легкая фигура", "тяжелая фигура" };
//int[] piece_values = { 1, 0, 3, 5 };
//string[] color_piece = { "белый", "черный" };
//string[] status_piece = { "жив", "мертв" };
//Random random = new Random();

//Encoding selected_encoding = Encoding.Unicode;
//List_object lst_obj = new List_object();

//try
//{
//    for (int i = 0; i < 4; i++)
//    {
//        lst_obj.chesss.Add(new Chess
//        {
//            name = chess_Pieces[i],
//            color = color_piece[random.Next(2)],
//            status = status_piece[random.Next(2)],
//            second_name = alternative_names[i],
//            class_figure = wight_status[i],
//            weight = piece_values[i].ToString()
//        });

//    }

//    string json_string = JsonSerializer.Serialize(lst_obj, new JsonSerializerOptions
//    {
//        WriteIndented = true,
//        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
//    });
//    File.WriteAllText(json_path, json_string);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.ToString());
//}



//Console.Write("Введите имя фигуры: ");
//string name_figura = Console.ReadLine();
//find_cheise(json_path, name_figura);

//Console.Write("Введите имя фигуры для удаления: ");
//string name_figura_remove = Console.ReadLine();
//remove_cheice(json_path, name_figura_remove);


//static void find_cheise(string file_path, string name_cheise)
//{
//    try
//    {
//        string json_string = File.ReadAllText(file_path);

//        List_object lst_obj = JsonSerializer.Deserialize<List_object>(json_string);

//        foreach (var item in lst_obj.chesss)
//        {
//            if (item.name == name_cheise)
//            {
//                Console.WriteLine("имя: " + item.name);
//                Console.WriteLine("цвет:" + item.color);
//                Console.WriteLine("статус: " + item.status);
//                Console.WriteLine("второе имя: " + item.second_name);
//                Console.WriteLine("класс фигуры: " + item.class_figure);
//                Console.WriteLine("вес фигуры: " + item.weight);
//                return;
//            }

//        }
//        Console.WriteLine("Объект не найден!");
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.ToString());
//    }
//}

//static void remove_cheice(string file_path, string name_piece)
//{
//    try
//    {
//        string json_string = File.ReadAllText(file_path);

//        List_object lst_obj = JsonSerializer.Deserialize<List_object>(json_string);

//        for (int i = 0; i < 4; i++)
//        {
//            if (lst_obj.chesss[i].name == name_piece)
//            {
//                lst_obj.chesss.Remove(lst_obj.chesss[i]);

//                string json_string_remove = JsonSerializer.Serialize(lst_obj, new JsonSerializerOptions
//                {
//                    WriteIndented = true,
//                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
//                });
//                File.WriteAllText(file_path, json_string_remove);

//                Console.WriteLine("Объект удален!");
//                return;
//            }
//        }
//        Console.WriteLine("Объект не найден!");
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.ToString());
//    }

//}

//class Chess
//{
//    public string name { get; set; }
//    public string color { get; set; }
//    public string status { get; set; }
//    public string second_name { get; set; }
//    public string class_figure { get; set; }
//    public string weight { get; set; }

//}

//class List_object
//{
//    public List<Chess> chesss { get; set; } = new List<Chess>();
//}