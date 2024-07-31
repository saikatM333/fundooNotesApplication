using Microsoft.EntityFrameworkCore;
using RepositoryLayer.FundooDbContext;
using RepositoryLayer.Interfaces.EmailAction;
using RepositoryLayer.Services.EmailServices;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using RepositoryLayer.Interfaces.CollaboratorAction;
using RepositoryLayer.Services.CollaboratorAction;
using BuisnessLayer.Interfaces.CollaboratorAction;
using BuisnessLayer.Services.CollaboratorAction;
using RepositoryLayer.Interfaces.LabelAction;
using RepositoryLayer.Services.LabelAction;
using BuisnessLayer.Interfaces.LabelAction;
using BuisnessLayer.Services.LabelAction;
using RepositoryLayer.Interfaces.Notes;
using RepositoryLayer.Services.NotesActions;
using BuisnessLayer.Interfaces.Notes;
using BuisnessLayer.Services.Notes;
using BuisnessLayer.Services.User;
using BuisnessLayer.Interfaces.User;
using RepositoryLayer.Interfaces.Users;
using RepositoryLayer.Services.Users;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(

    options => {
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Description = "Bearer",
            Type = SecuritySchemeType.Http

        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                new List<string>()
            }
        });
    });

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options => options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

    }
    );

builder.Services.AddAuthorization();

builder.Services.AddDbContext<FundooNotesDBContext>(opts => {
    opts.UseSqlServer(builder.Configuration.GetConnectionString("FundooNotesDB"),
    b => b.MigrationsAssembly("FundooNotes"));
});

builder.Services.AddTransient<IemailServices, SmtpEmailService>(provider =>
{
    var smtpClient = new SmtpClient("smtp.ethereal.email")
    {
        Port = 587,
        Credentials = new NetworkCredential("jamarcus.goyette@ethereal.email", "g2XbKn9Juwf1GmC9SW"),
        EnableSsl = true,
    };
    return new SmtpEmailService(smtpClient, "jamarcus.goyette@ethereal.email");
});

builder.Services.AddTransient<ICollaboratorServicesRL, CollaboratorServices>();
builder.Services.AddTransient<ICollaboratorServicesBL, CollaboratorServicesBL>();

builder.Services.AddTransient<Ilabel, LabelServicesRL>();
builder.Services.AddTransient<ILabelBL, LabelServicesBL>();

builder.Services.AddTransient<INoteServicesRL , NotesServicesRL>();
builder.Services.AddTransient<InoteServicesBL , NotesServicesBL>();

builder.Services.AddTransient<IloginBL, LoginBL>();
builder.Services.AddTransient<IloginRL , LoginRL>();

builder.Services.AddTransient<IregisterBL, RegisterBL>();
builder.Services.AddTransient<IregisterRL , RegisterRL>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
