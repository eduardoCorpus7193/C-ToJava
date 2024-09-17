String line, text = "", sintax = "", skipSintax = "";

Dictionary<string, string> sintaxisJava= new Dictionary<string, string>()
{
    {"public class ", "Public class "},
    {"public static void main (String[] args)", "public static void Main(string[] args)"},
    {"{", "{" },
    {"}", "}" },
    {"(", "(" },
    {")", ")" },
    {";", ";" },
    {"System.out.println(", "Console.WriteLine(" }
};

try
{
    //Find the document with the java code
    StreamReader sr = new StreamReader("C:\\Users\\Eduardo Corpus\\Documents\\NTTData\\C# to Java\\Sample.txt");
    //StreamReader sr = new StreamReader("___"); <--- add the path to your file
    //Read the first line of text
    line = sr.ReadLine();
    //While there still being lines to read, it keeps reading
    while (line != null)
    {
        text += line;
        //Write the line to console window
        Console.WriteLine(line);
        //Read the next line
        line = sr.ReadLine();
    }
    //close the file
    sr.Close();
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
finally
{
    //Printing if the code were read
    Console.WriteLine("\nDocument read succesfully, printing code in C#");
    //Looping through string
    for (int i = 0; i < text.Length; i++)
    {
        sintax += text[i];
        if (sintaxisJava.TryGetValue(sintax, out string result))
        {
            Console.Write(result);
            if (sintax == "public class ")
            {
                sintax = "";
                string character = "";
                int j = i + 1;
                while (character != " ")
                {
                    character = "";
                    character += text[j];
                    sintax += character;
                    j++;
                    i += 1;
                }
                Console.Write(sintax);
                sintax = "";
            }
        }
    }
}