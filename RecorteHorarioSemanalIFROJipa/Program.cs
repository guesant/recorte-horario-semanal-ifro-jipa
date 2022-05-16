void logUsageMsg(TextWriter textWriter)
{
    textWriter.WriteLine("uso inválido! tente:");
    textWriter.WriteLine("$ <executavel> horario-geral.pdf payload.json horario-recortado.png");
}

void Main(string[] args)
{
    if (args.Length != 3)
    {
        logUsageMsg(Console.Error);
        Environment.Exit(1);
        return;
    }

    var originalPDFFileName = args[0];
    var payloadFileName = args[1];
    var outputImageFileName = args[2];

    var payload = Payload.FromFile(payloadFileName);

    ImageGenerator.Generate(payload, originalPDFFileName, outputImageFileName);
}

Main(args);