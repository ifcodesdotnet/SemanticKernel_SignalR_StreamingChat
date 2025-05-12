using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace SemanticKernel_SignalR.Plugins;
public class CalculatorPlugin
{
    [KernelFunction("add")]
    [Description("Performs addition on two numeric values.")]
    [return: Description("Returns the sum of the values.")]
    public int Add(int number1, int number2)
            => number1 + number2;
}
