using Microsoft.ML.OnnxRuntimeGenAI;
using Phi3MiniOnnxConsole.Utils;

// Show the header
ConsoleHelper.ShowHeader();

// Get the model path from the user
string modelPath = ConsoleHelper.GetFolderPath(Statics.ModelInputPrompt);

// Show the header
ConsoleHelper.ShowHeader();
ConsoleHelper.WriteToConsole(Statics.ModelLoadingMessage);

// Load the model and tokenizer
using Model model = new(modelPath);
using Tokenizer tokenizer = new(model);

// Specify the generator parameters
using GeneratorParams generatorParams = new(model);
generatorParams.SetSearchOption("max_length", 2048);

// Show the header
ConsoleHelper.ShowHeader();

// Simulate the chat loop
while (true)
{
    // Get the user input
    ConsoleHelper.WriteToConsole(Environment.NewLine);
    ConsoleHelper.WriteToConsole(Statics.InputPrompt);

    string? input = Console.ReadLine();
    if (string.IsNullOrEmpty(input))
    {
        continue;
    }

    // Generate the response
    ConsoleHelper.WriteToConsole(Environment.NewLine);
    ConsoleHelper.WriteToConsole(Statics.OutputPrompt);

    string fullPrompt
        = $"<|system|>{Statics.SystemPrompt}<|end|>" +
          $"<|user|>{input}<|end|>" +
          $"<|assistant|>";

    using Sequences tokens = tokenizer.Encode(fullPrompt);
    generatorParams.SetInputSequences(tokens);

    using Generator generator = new(model, generatorParams);

    while (!generator.IsDone())
    {
        generator.ComputeLogits();
        generator.GenerateNextToken();

        string output = tokenizer.Decode(generator.GetSequence(0)[^1..]);
        Console.Write(output);
    }

    ConsoleHelper.WriteToConsole(Environment.NewLine);
    ConsoleHelper.WriteToConsole(Environment.NewLine);
}