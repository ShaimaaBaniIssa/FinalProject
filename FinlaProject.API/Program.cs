using FinalProject.Core.Common;
using FinalProject.Core.Repository;
using FinalProject.Core.Services;
using FinalProject.Core.Utility;
using FinalProject.Infra.Common;
using FinalProject.Infra.Repository;
using FinalProject.Infra.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDbContext, DbContext>();

builder.Services.AddCors(corsOptions =>
{
    corsOptions.AddPolicy("policy",
    builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// Repository
builder.Services.AddScoped<ITrainRepository, TrainRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ITrainRepository, TrainRepository>();
builder.Services.AddScoped<ISeatRepository, SeatRepository>();
builder.Services.AddScoped<ITestimonialRepository, TestimonialRepository>();
builder.Services.AddScoped<IStationRepository, StationRepository>();
builder.Services.AddScoped<ITripRepository, TripRepository>();
builder.Services.AddScoped<ITripScheduleRepository, TripScheduleRepository>();
builder.Services.AddScoped<IBankCardRepository, BankCardRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IContactuspageRepository, ContactuspageRepository>();
builder.Services.AddScoped<IFeedbackRepository,FeedbackRepository>();

// db services
builder.Services.AddScoped<ITrainServices, TrainServices>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ITrainServices, TrainServices>();
builder.Services.AddScoped<ISeatServices, SeatServices>();
builder.Services.AddScoped<ITestimonialServices, TestimonialServices>();
builder.Services.AddScoped<IStationService, StationService>();
builder.Services.AddScoped<ITripService, TripService>();
builder.Services.AddScoped<ITripScheduleService, TripScheduleService>();
builder.Services.AddScoped<IBankCardService, BankCardService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IReservationService,ReservationService>();
builder.Services.AddScoped<IContactuspageServices, ContactuspageServices>();
builder.Services.AddScoped<IFeedbackServices, FeedbackServices>();
// services
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IPdfGenerator, PdfGenerator>();

// mail configuration
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKey@FinalProject123456"))
    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors("policy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
