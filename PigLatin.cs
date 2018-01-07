using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("What's the word?");
        string word = Console.ReadLine().ToLower();
        // Console.WriteLine(TranslateSimpleWord(word));
        Console.WriteLine(TranslateComplexWord(word));
        Console.ReadLine();
    }

    // 1 - Translate simple word
    public static string TranslateSimpleWord(string word)
    {
        return $"The word {word} in Pig Latin is: {word.Substring(1)}{word.Substring(0, 1)}ay";
    }

    // 2 - Translate a more complex word
    public static string TranslateComplexWord(string word)
    {
        int vowelIndex = -1;

        if ((word.IndexOf('a') > -1 && word.IndexOf('a') < vowelIndex) || vowelIndex == -1)
        {
            vowelIndex = word.IndexOf('a');
        }

        if ((word.IndexOf('e') > -1 && word.IndexOf('e') < vowelIndex) || vowelIndex == -1)
        {
            vowelIndex = word.IndexOf('e');
        }

        if ((word.IndexOf('i') > -1 && word.IndexOf('i') < vowelIndex) || vowelIndex == -1)
        {
            vowelIndex = word.IndexOf('i');
        }

        if ((word.IndexOf('o') > -1 && word.IndexOf('o') < vowelIndex) || vowelIndex == -1)
        {
            vowelIndex = word.IndexOf('o');
        }

        if ((word.IndexOf('u') > -1 && word.IndexOf('u') < vowelIndex) || vowelIndex == -1)
        {
            vowelIndex = word.IndexOf('u');
        }

        if ((word.IndexOf('y') > -1 && word.IndexOf('y') < vowelIndex) || vowelIndex == -1)
        {
            vowelIndex = word.IndexOf('y');
        }

        if(vowelIndex == 0) // word start with a vowel
        {
            return $"{word}yay";
        }

        return $"{word.Substring(vowelIndex)}{word.Substring(0, vowelIndex)}yay";
    }
}