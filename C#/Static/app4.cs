using System;

namespace ConsoleApp4
{
    public static class StringExtension
    {
        public static string StringSubstring(this string str, int start, int end)
        {            
            string result = "";
            if (start == end && start == 0) return result;
            for (int i = start; i <= end; i++) 
            {
                result += str[i];
            }
                return result;
        }

        public static int StringIndexOf(this string str, string substr)
        {
            int result = -1;
            char[] arrStr = new char [str.Length];
            char[] arrSubstr = new char[substr.Length];
            for (int i = 0; i < str.Length; i++) { arrStr[i] = str[i]; }
            for (int i = 0; i < substr.Length; i++) { arrSubstr[i] = substr[i]; }

            for (int i = 0; i < str.Length - substr.Length; i++)
            {
                if (arrStr[i] == arrSubstr[0])
                {   result = i;                    
                    for (int j = 1; j < substr.Length; j++)
                    {                       
                        if (arrStr[i + j] != arrSubstr[j]) { result = -1; break; }                        
                    }   
                }
                if (result != -1) break;
            }
            return result;
        }

        public static string StringReplace(this string str, string target, string insert)
        {
            string result = "";
            int indexOfBeginChange = str.StringIndexOf(target);
            int indexOfEndChange = indexOfBeginChange + insert.Length;
            if (indexOfBeginChange == -1) { result = str; }
                else
            {
                string beforeChange = str.StringSubstring(0, indexOfBeginChange);               
                string afterChange = str.StringSubstring(indexOfBeginChange + target.Length, str.Length - 1);
                result = beforeChange + insert + afterChange;
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Хороший день!";            
            string text1 = text.StringSubstring(0, 8);
            Console.WriteLine($"Исходный текст - {text}");
            Console.WriteLine($"Substring: текст обрезан от 0 до 8 символа - {text1}");
            Console.WriteLine($"IndexOf: вхождение подстроки 'оши' - {text.StringIndexOf("оши")}");
            Console.WriteLine($"IndexOf: нет вхождения подстроки 'ошк' - {text.StringIndexOf("ошк")}");
            string textChange1 = text.StringReplace("плохой", "еще хуже");
            Console.WriteLine($"Replace: не найдена подстрока для замены - {textChange1}");
            string textChange2 = text.StringReplace("Хороший", "Плохой");
            Console.WriteLine($"Replace: замена 'Хороший' на 'Плохой' - {textChange2}");
            
            Console.ReadLine();
        }
    }
}