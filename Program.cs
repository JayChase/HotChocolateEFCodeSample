using CodeSample.Data;
using CodeSample.Types;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(o =>
        o.AddDefaultPolicy(b =>
        b.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin()));

builder.Services.AddGraphQLServer()
        .AddProjections()
        .AddFiltering()
        .AddSorting()
        .AddQueryType<Query>()
        .AddMutationType<Mutation>()
        .AddType<ThingType>();

builder.Services.AddPooledDbContextFactory<TestDbContext>(
            options => options.UseSqlServer("Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=CodeSample")
                                .EnableSensitiveDataLogging()
                                .LogTo(Console.WriteLine)
                                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

var app = builder.Build();


app.UseCors();

app.MapGraphQL("/graphql");

app.Run();

