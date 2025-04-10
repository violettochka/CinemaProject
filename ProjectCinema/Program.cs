
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProjectCinema.BLL.DTO.Cinema;
using ProjectCinema.BLL.DTO.Halls;
using ProjectCinema.BLL.DTO.Movie;
using ProjectCinema.BLL.DTO.MovieScreening;
using ProjectCinema.BLL.DTO.Payment;
using ProjectCinema.BLL.DTO.Promocode;
using ProjectCinema.BLL.DTO.Row;
using ProjectCinema.BLL.DTO.Seat;
using ProjectCinema.BLL.Interfaces;
using ProjectCinema.BLL.Interfaces.IMovieScreeningServices;
using ProjectCinema.BLL.Services;
using ProjectCinema.DAL.Interfaces;
using ProjectCinema.Data;
using ProjectCinema.Repositories.Classes;
using ProjectCinema.Repositories.Interfaces;
using ProjectCinema.Validations.CinemaValidation;
using ProjectCinema.Validations.HallValidation;
using ProjectCinema.Validations.MovieScreeningValidation;
using ProjectCinema.Validations.MovieValidation;
using ProjectCinema.Validations.PaymentValidation;
using ProjectCinema.Validations.PromocodeValidation;
using ProjectCinema.Validations.RowValidation;
using ProjectCinema.Validations.SeatValidation;

namespace ProjectCinema
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //add DbContext conteiner into dependencies
            builder.Services.AddDbContext<AplicationDBContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //Add repositories
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();
            builder.Services.AddScoped<ICinemaRepository, CinemaRepository>();
            builder.Services.AddScoped<IHallRepository, HallRepository>();
            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            builder.Services.AddScoped<IMovieScreeningRepository, MovieScreeningRepository>();
            builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
            builder.Services.AddScoped<IPromocodeRepository, PromocodeRepository>();
            builder.Services.AddScoped<ISeatRepository, SeatRepository>();
            builder.Services.AddScoped<IShowTimeRepository, ShowTimeRepository>();
            builder.Services.AddScoped<ITicketRepository, TicketRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();


            //Add services
            builder.Services.AddScoped<IBookingService, BookingService>();
            builder.Services.AddScoped<ICinemaService, CinemaService>();
            builder.Services.AddScoped<IHallService, HallService>();
            builder.Services.AddScoped<IMovieService, MovieService>();

            builder.Services.AddScoped<IMovieScreeningCrudService, MovieScreeningService>();
            builder.Services.AddScoped<IMovieScreeningCrudService, MovieScreeningService>();
            builder.Services.AddScoped<IMovieScreeningValidationService, MovieScreeningService>();

            builder.Services.AddScoped<IPaymentService,  PaymentService>();
            builder.Services.AddScoped<IPromocodeService, PromocodeService>();
            builder.Services.AddScoped<ISeatService,  SeatService>();
            builder.Services.AddScoped<IShowTimeService,  ShowTimeService>();
            builder.Services.AddScoped<ITicketService, TicketService>();
            builder.Services.AddScoped<IUserService, UserService>();



            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            //Add fluent validations
            builder.Services.AddScoped<IValidator<MovieCreateDTO>, MovieCreateDTOValidator>();
            builder.Services.AddScoped<IValidator<MovieUpdateDTO>, MovieUpdateDTOValidator>();

            builder.Services.AddScoped<IValidator<CinemaCreateDTO>, CinemaCreateDTOValidator>();
            builder.Services.AddScoped<IValidator<CinemaUpdateDTO>, CinemaUpdateValidator>();

            builder.Services.AddScoped<IValidator<PromocodeCreateDTO>, PromocodeCreateDTOValidator>();
            builder.Services.AddScoped<IValidator<PromocodeUpdateDTO>, PromocodeUpdateValidator>();

            builder.Services.AddScoped<IValidator<HallCreateDTO>, HallCreateDTOValidator>();
            builder.Services.AddScoped<IValidator<HallUpdateDTO>, HallUpdateDTOValidator>();

            builder.Services.AddScoped<IValidator<MovieScreeningCreateDTO>, MovieScreeningCreateDTOValidator>();
            builder.Services.AddScoped<IValidator<MovieScreeningUpdateDTO>, MovieScreeningUpdateDTOValidator>();

            builder.Services.AddScoped<IValidator<PaymentCreateDTO>, PaymentCreateDTOValidator>();
            builder.Services.AddScoped<IValidator<PaymentUpdateDTO>,  PaymentUpdateDTOValidator>();

            builder.Services.AddScoped<IValidator<RowCreateDTO>, RowCreateDTOValidator>();
            builder.Services.AddScoped<IValidator<RowUpdateDTO>,  RowUpdateDTOValidator>();

            builder.Services.AddScoped<IValidator<SeatCreateDTO>, SeatCreateDTOValidator>();
            builder.Services.AddScoped<IValidator<SeatUpdateDTO>, SeatUpdateDTOValidator>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
