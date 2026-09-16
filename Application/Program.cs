using Application;

Console.WriteLine("Type input (then press enter):");
string input = Console.ReadLine() ?? string.Empty;
var result = new StringProcessor().Process(input);
Console.WriteLine("Result: {0}", result);

// Stop console from closing
Console.WriteLine("Press enter to exit");
Console.ReadLine();
