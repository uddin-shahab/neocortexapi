using Microsoft.AspNetCore.Mvc;
using NeoCortexApiSample;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}





app.MapGet("GetSdr", (string fname ) =>
{
    //file.trace
    string fileName = "file.trace";
    if (!File.Exists(fileName))
        throw new FileNotFoundException();

    string[] data = File.ReadAllLines(fileName);

    return data;

})
.WithName("GetSdr")
.WithOpenApi();

app.MapPost("/testing", ([FromBody] List<Sequence> requests) =>
{
    if (requests == null)
        throw new ArgumentNullException(nameof(requests));

    Dictionary<string, List<double>> sequences = new Dictionary<string, List<double>>();
    foreach (var request in requests)
    {
        sequences.Add(request.Key, request.Values);
    }
})
.WithName("Demo")
.WithOpenApi();


app.MapGet("/SpatialPatternLearning", () =>
{
    SpatialPatternLearning experiment = new SpatialPatternLearning();
    experiment.Run();
})
.WithName("SpatialPatternLearning")
.WithOpenApi();


app.MapPost("/RunMultiSimpleSequenceLearningExperiment", ([FromBody] List<Sequence> requests, string outputFileName) =>
{
    if (requests == null)
        throw new ArgumentNullException(nameof(requests));

    var myListener = new MyTraceListener();
    myListener.ShouldWriteToFile = true;
    myListener.TraceOutputFileName = outputFileName;
    Trace.Listeners.Add(myListener);

    Dictionary<string, List<double>> sequences = new Dictionary<string, List<double>>();
    foreach (var request in requests)
    {
        sequences.Add(request.Key, request.Values);
    }

    Experiments.RunMultiSimpleSequenceLearningExperiment(sequences);
    myListener.ShouldWriteToFile = false;
    Trace.Listeners.Remove(myListener);
})
.WithName("RunMultiSimpleSequenceLearningExperiment")
.WithOpenApi();



app.MapPost("/RunMultiSequenceLearningExperiment", ([FromBody] List<Sequence> requests) =>
{
    if (requests == null)
        throw new ArgumentNullException(nameof(requests));

    Dictionary<string, List<double>> sequences = new Dictionary<string, List<double>>();
    foreach (var request in requests)
    {
        sequences.Add(request.Key, request.Values);
    }

    Experiments.RunMultiSequenceLearningExperiment(sequences);
})
.WithName("RunMultiSequenceLearningExperiment")
.WithOpenApi();

app.Run();