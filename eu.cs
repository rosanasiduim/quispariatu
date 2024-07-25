using System;

class Program {
    static void Main() {
        string sentence = "Splits it into words.";
        string[] words = sentence.Split(' ');
        foreach (string word in words) {
            Console.WriteLine(word);
        }
        // Output:
        // Splits
        // it
        // into
        // words.
    }
}
