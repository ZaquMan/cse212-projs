public static class MysteryStack1
{
    public static string Run(string text)
    {
        var stack = new Stack<char>();
        foreach (var letter in text)
            stack.Push(letter);

        var result = "";
        while (stack.Count > 0)
            result += stack.Pop();

        return result;
    }
}

// This is a stack, so Last-In, First-Out.
// Each letter in the input string is added to the stack, then removed to a new string.
// This function is reversing the input string and returning the reversed string.

// racecar -> racecar
// stressed -> desserts
// a nut for a jar of tuna -> anut fo raj a rof tun a (spaces are characters, so they get reversed too, even if it messes up the palindrome)