using System;
using PassiveComponents;


public static class Program
{
    public static void Main()
    {
        Console.Write("Enter component type (R, L, C): ");

        string type = Console.ReadLine().ToUpper();

        switch (type)
        {
            case "R":
                Console.Write("Enter resistance in ohms: ");
                break;

            case "L":
                Console.Write("Enter inductance in henries: ");
                break;

            case "C":
                Console.Write("Enter capacitance in farads: ");
                break;

            default:
                Console.Write("Bad component type");
                return;
        }

        double value = 0;

        try
        {
            value = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
        }
        catch (InvalidCastException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        Component cmp = default;

        switch (type)
        {
            case "R":
                cmp = new Resistor(value);
                break;

            case "L":
                cmp = new Inductor(value);
                break;

            case "C":
                cmp = new Capacitor(value);
                break;
        }

        double freq = 0;

        Console.Write("Enter frequency in hertz: ");

        try
        {
            freq = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
        }
        catch (InvalidCastException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        Console.WriteLine();
        Console.WriteLine(cmp);
        Console.WriteLine($"Impedance at f = {freq} Hz");
        Console.WriteLine($"equals {cmp.GetImpedance(freq)} ohms");
    }
}
