using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string script = "int x\nint y\nset x 10\nset y 20\nadd x y\nsub y 5\nprint x\nprint y";
        ExecuteScript(script);
    }

    static void ExecuteScript(string script)
    {
        Dictionary<string, int> variables = new Dictionary<string, int>();
        string[] lines = script.Split('\n');

        foreach (string line in lines)
        {
            ExecuteInstruction(line, variables);
        }
    }

    static void DeclareVariable(string variableName, Dictionary<string, int> variables)
    {
        // Define a new variable
        variables[variableName] = 0; // Initialize to 0
    }

    static void SetVariable(string variableName, int value, Dictionary<string, int> variables)
    {
        // Set the value of a variable
        variables[variableName] = value;
    }

    static void AddVariables(string targetVariable, string sourceVariable, Dictionary<string, int> variables)
    {
        // Add the value of one variable to another
        int value = (variables.ContainsKey(sourceVariable)) ? variables[sourceVariable] : int.Parse(sourceVariable);
        variables[targetVariable] += value;
    }

    static void SubtractFromVariable(string targetVariable, int value, Dictionary<string, int> variables)
    {
        // Subtract the value from a variable
        variables[targetVariable] -= value;
    }

    static void PrintVariable(string variableName, Dictionary<string, int> variables)
    {
        // Print the value of a variable
        Console.WriteLine(variables[variableName]);
    }

    static void ExecuteInstruction(string instruction, Dictionary<string, int> variables)
    {
        string[] parts = instruction.Split(' ');

        switch (parts[0])
        {
            case "int":
                DeclareVariable(parts[1], variables);
                break;
            case "set":
                SetVariable(parts[1], int.Parse(parts[2]), variables);
                break;
            case "add":
                AddVariables(parts[1], parts[2], variables);
                break;
            case "sub":
                SubtractFromVariable(parts[1], int.Parse(parts[2]), variables);
                break;
            case "print":
                PrintVariable(parts[1], variables);
                break;
            default:
                Console.WriteLine($"Unknown instruction: {instruction}");
                break;
        }
    }
}
