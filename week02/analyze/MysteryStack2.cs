public static class MysteryStack2
{
    private static bool IsFloat(string text)
    {
        return float.TryParse(text, out _);
        // This just checks if the string it receives is a valid float (ie 1.5)
    }

    public static float Run(string text)
    {
        var stack = new Stack<float>(); //LIFO
        foreach (var item in text.Split(' '))
        { // Break stack up by "words," then iterate over each "word".
            if (item == "+" || item == "-" || item == "*" || item == "/")
            { // If "word" is a mathematical operator...
                if (stack.Count < 2) // ...and if there is LESS than two "words" on the stack...
                    throw new ApplicationException("Invalid Case 1!"); // ...throw the error "Invalid case 1"

                var op2 = stack.Pop(); //... remove the last two words to be added...
                var op1 = stack.Pop();
                float res;
                if (item == "+")
                { //... and apply the mathematical operator to them.
                    res = op1 + op2;
                }
                else if (item == "-")
                {
                    res = op1 - op2;
                }
                else if (item == "*")
                {
                    res = op1 * op2;
                }
                else
                {
                    if (op2 == 0) // ...unless the first "word" pulled from the stack is a 0, then throw an error because you can't divide by 0
                        throw new ApplicationException("Invalid Case 2!");

                    res = op1 / op2;
                }

                stack.Push(res); // Put the result back on the stack
            }
            else if (IsFloat(item))
            { // If the "word" is a float, put it on the stack
                stack.Push(float.Parse(item));
            }
            else if (item == "")
            { // If the "word" is an empty string, do nothing
            }
            else
            { // If the "word" is anything else, throw an error
                throw new ApplicationException("Invalid Case 3!");
            }
        }

        if (stack.Count != 1) // After iterating, there is not exactly one "word" left on the stack, throw an error
            throw new ApplicationException("Invalid Case 4!");

        return stack.Pop(); // Return that one thing from the stack
    }
}

// This function takes a string of numbers (floats, so decimals are ok) and mathematical operators,
// and processes the numbers according to the operators.

// 5 3 7 + * ->
//  Loop 1 (5): Stack - 5.0
//  Loop 2 (3): Stack - 5.0, 3.0
//  Loop 3 (7): Stack - 5.0, 3.0, 7.0
//  Loop 4 (+): Stack - 5.0, 10.0
//  Loop 5 (*): Stack - 50.0
//  RETURN: 50.0

// 6 2 + 5 3 - / ->
//  Loop 1 (6): Stack - 6.0
//  Loop 2 (2): Stack - 6.0, 2.0
//  Loop 3 (+): Stack - 8.0
//  Loop 4 (5): Stack - 8.0, 5.0
//  Loop 5 (3): Stack - 8.0, 5.0, 3.0
//  Loop 6 (-): Stack - 8.0, 2.0
//  Loop 7 (/): Stack - 4.0
//  RETURN: 4.0

// Invalid Case 1 - Less than 2 numbers
// 5 +

// Invalid Case 2 - Divide by 0
// 10 0 /

// Invalid Case 3 - Invalid Input
// 5 cat +

// Invalid Case 4 - Too many numbers
// 5 4 3 +