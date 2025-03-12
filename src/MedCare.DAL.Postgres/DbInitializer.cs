using MedCare.Common.Models.Users;
using MedCare.Common.Models.Users.Patient;
using MedCare.DAL.Context;
using MedCare.DAL.Entities;
using MedCare.DAL.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace MedCare.DAL;

public static class DbInitializer
{
    public static async Task Initialize(ApplicationDbContext context)
    {
        await context.Database.MigrateAsync();
        
        // база данных пуста
        if (
            !context.Patients.Any() &&
            !context.Workers.Any() &&
            !context.UserProfiles.Any() &&
            !context.Appointments.Any() &&
            !context.MedicalRecords.Any() &&
            !context.Services.Any() &&
            !context.Specializations.Any() &&
            !context.Branches.Any() &&
            !context.Addresses.Any() &&
            !context.Cities.Any()
            )
        {
            // города
            var city1 = new CityEntity
            {
                Id = Guid.NewGuid(),
                Name = "Гомель"
            };
            var city2 = new CityEntity
            {
                Id = Guid.NewGuid(),
                Name = "Речица"
            };
            await context.Cities.AddRangeAsync(city1, city2);
            
            // адреса
            var address1 = new AddressEntity // гомель
            {
                Id = Guid.NewGuid(),
                Street = "просп. Победы",
                BuildingNumber = 55,
                CityId = city1.Id
            };
            var address2 = new AddressEntity // мозырь
            {
                Id = Guid.NewGuid(),
                Street = "Советская",
                BuildingNumber = 110,
                CityId = city2.Id
            };
            await context.Addresses.AddRangeAsync(address1, address2);

            // филиалы
            var branch1 = new BranchEntity // мозырь
            {
                Id = Guid.NewGuid(),
                Name = "МЦ \"Свагушка\" в Гомеле",
                Phone = "+375295789364",
                AddressId = address1.Id
            };
            var branch2 = new BranchEntity // мозырь
            {
                Id = Guid.NewGuid(),
                Name = "МЦ \"Свагушка\" в Речице",
                Phone = "+375447899678",
                AddressId = address2.Id
            };
            await context.Branches.AddRangeAsync(branch1, branch2);
            
            // специализации
            var specialization1 = new SpecializationEntity
            {
                Id = Guid.NewGuid(),
                Name = "Аллергология"
            };
            var specialization2 = new SpecializationEntity
            {
                Id = Guid.NewGuid(),
                Name = "Гинекология"
            };
            var specialization3 = new SpecializationEntity
            {
                Id = Guid.NewGuid(),
                Name = "Кардиология"
            };
            var specialization4 = new SpecializationEntity
            {
                Id = Guid.NewGuid(),
                Name = "Косметология"
            };
            var specialization5 = new SpecializationEntity
            {
                Id = Guid.NewGuid(),
                Name = "Неврология"
            };
            var specialization6 = new SpecializationEntity
            {
                Id = Guid.NewGuid(),
                Name = "Оториноларингология"
            };
            var specialization7 = new SpecializationEntity
            {
                Id = Guid.NewGuid(),
                Name = "Офтальмология"
            };
            var specialization8 = new SpecializationEntity
            {
                Id = Guid.NewGuid(),
                Name = "Психологическая помощь"
            };
            var specialization9 = new SpecializationEntity
            {
                Id = Guid.NewGuid(),
                Name = "Терапия"
            };
            var specialization10 = new SpecializationEntity
            {
                Id = Guid.NewGuid(),
                Name = "Ультразвуковая диагностика"
            };
            var specialization11 = new SpecializationEntity
            {
                Id = Guid.NewGuid(),
                Name = "Лазерная эпиляция"
            };
            var specialization12 = new SpecializationEntity
            {
                Id = Guid.NewGuid(),
                Name = "Эндокринология"
            };
            
            await context.Specializations.AddRangeAsync(
                specialization1, specialization2, specialization3, specialization4,
                specialization5, specialization6, specialization7, specialization8,
                specialization9, specialization10, specialization11, specialization12
            );
            
            await InitServices(
                context, branch1, branch2, specialization1, specialization2, specialization3, 
                specialization4, specialization5, specialization6, specialization7, specialization8,
                specialization9, specialization10, specialization11, specialization12
            );

            // профили пользователей
            var user1 = new UserProfileEntity
            {
                Id = Guid.NewGuid(),
                FirstName = "Александр",
                LastName = "Иванов",
                Patronymic = "Сергеевич",
                BirthDate = new DateTime(1990, 5, 15).ToUniversalTime(),
                Gender = Gender.Male,
                Email = "ivanov@gmail.com",
                PhoneNumber = "+375291234567"
            };
            var user2 = new UserProfileEntity
            {
                Id = Guid.NewGuid(),
                FirstName = "Екатерина",
                LastName = "Петрова",
                Patronymic = "Викторовна",
                BirthDate = new DateTime(1985, 11, 23).ToUniversalTime(),
                Gender = Gender.Female,
                Email = "petrova@gmail.com",
                PhoneNumber = "+375333456789"
            };
            var user3 = new UserProfileEntity
            {
                Id = Guid.NewGuid(),
                FirstName = "Дмитрий",
                LastName = "Сидоров",
                Patronymic = "Андреевич",
                BirthDate = new DateTime(1995, 7, 30).ToUniversalTime(),
                Gender = Gender.Male,
                Email = "sidorov@gmail.com",
                PhoneNumber = "+375447890123"
            };
            var user4 = new UserProfileEntity
            {
                Id = Guid.NewGuid(),
                FirstName = "Анна",
                LastName = "Козлова",
                Patronymic = "Игоревна",
                BirthDate = new DateTime(2000, 2, 12).ToUniversalTime(),
                Gender = Gender.Female,
                Email = "kozlova@gmail.com",
                PhoneNumber = "+375293210987"
            };
            var user5 = new UserProfileEntity
            {
                Id = Guid.NewGuid(),
                FirstName = "Максим",
                LastName = "Васильев",
                Patronymic = "Олегович",
                BirthDate = new DateTime(1988, 9, 5).ToUniversalTime(),
                Gender = Gender.Male,
                Email = "vasiliev@gmail.com",
                PhoneNumber = "+375336543210"
            };
            await context.UserProfiles.AddRangeAsync(user1, user2, user3, user4, user5);
            
            // сотрудники
            // password: 123
            const string passwordHash = "$2a$11$dqWSehl3tqJ5QRlE5zxpKeF2ulVPv.4NyU9m5FziPz9IUWwecUjxu";
            
            // гомель
            var admin = new WorkerEntity
            {
                Id = Guid.NewGuid(),
                Login = "admin",
                PasswordHash = passwordHash,
                UserRole = UserRole.Admin,
                UserProfileId = user1.Id,
                SpecializationId = null,
                BranchId = branch1.Id,
            };
            var receptionist = new WorkerEntity
            {
                Id = Guid.NewGuid(),
                Login = "register",
                PasswordHash = passwordHash,
                UserRole = UserRole.Receptionist,
                UserProfileId = user2.Id,
                SpecializationId = null,
                BranchId = branch1.Id,
            };
            var doctor1 = new WorkerEntity // Аллергология
            {
                Id = Guid.NewGuid(),
                Login = "doc1",
                PasswordHash = passwordHash,
                UserRole = UserRole.Doctor,
                UserProfileId = user3.Id,
                SpecializationId = specialization1.Id,
                BranchId = branch1.Id,
            };
            var doctor2 = new WorkerEntity // Аллергология
            {
                Id = Guid.NewGuid(),
                Login = "doc2",
                PasswordHash = passwordHash,
                UserRole = UserRole.Doctor,
                UserProfileId = user4.Id,
                SpecializationId = specialization2.Id,
                BranchId = branch1.Id,
            };
            var doctor3 = new WorkerEntity // Аллергология
            {
                Id = Guid.NewGuid(),
                Login = "doc3",
                PasswordHash = passwordHash,
                UserRole = UserRole.Doctor,
                UserProfileId = user5.Id,
                SpecializationId = specialization3.Id,
                BranchId = branch1.Id,
            };
            await context.Workers.AddRangeAsync(admin, receptionist, doctor1, doctor2, doctor3);
            
            // пациентов создавать при первый заявке на запись!
            
            await context.SaveChangesAsync();
        }
    }

    // услуги
    private static async Task InitServices(
        ApplicationDbContext context, BranchEntity branch1, BranchEntity branch2, 
        SpecializationEntity specialization1, SpecializationEntity specialization2, SpecializationEntity specialization3, 
        SpecializationEntity specialization4, SpecializationEntity specialization5, SpecializationEntity specialization6, 
        SpecializationEntity specialization7, SpecializationEntity specialization8, SpecializationEntity specialization9, 
        SpecializationEntity specialization10, SpecializationEntity specialization11, SpecializationEntity specialization12
        )
    {
        // Аллергология (только в Гомеле)
        var service1 = new ServiceEntity 
        {
            Id = Guid.NewGuid(),
            Name = "Консультация врача-аллерголога-иммунолога второй квалификационной категории",
            Price = 34,
            SpecializationId = specialization1.Id
        };
        var service2 = new ServiceEntity
        {
            Id = Guid.NewGuid(),
            Name = "Консультация врача-аллерголога-иммунолога первой квалификационной категории",
            Price = 36,
            SpecializationId = specialization1.Id
        };
        var service3 = new ServiceEntity
        {
            Id = Guid.NewGuid(),
            Name = "Консультация врача-аллерголога-иммунолога высшей квалификационной категории",
            Price = 38,
            SpecializationId = specialization1.Id
        };
        
        // связи услуг с филиалами, в которых они могут оказываться (записи в связующей таблице)
        branch1.Services.Add(service1);
        branch1.Services.Add(service2);
        branch1.Services.Add(service3);
        service1.Branches.Add(branch1);
        service2.Branches.Add(branch1);
        service3.Branches.Add(branch1);
        
        // Гинекология (service4, service5 - в обоих филиалах, service6 - только в Гомельском филиале)
        var service4 = new ServiceEntity 
        {
            Id = Guid.NewGuid(),
            Name = "Консультация врача-акушера-гинеколога первой квалификационной категории без одноразового инструмента",
            Price = 36,
            SpecializationId = specialization2.Id
        };
        var service5 = new ServiceEntity 
        {
            Id = Guid.NewGuid(),
            Name = "Кольпоскопия расширенная",
            Price = (decimal)29.30,
            SpecializationId = specialization2.Id
        };
        var service6 = new ServiceEntity 
        {
            Id = Guid.NewGuid(),
            Name = "Консультация врача-акушера-гинеколога второй квалификационной категории с использованием одноразового инструмента",
            Price = (decimal)36.63,
            SpecializationId = specialization2.Id
        };
        
        // в гомеле
        branch1.Services.Add(service4);
        branch1.Services.Add(service5);
        branch1.Services.Add(service6);
        service4.Branches.Add(branch1);
        service5.Branches.Add(branch1);
        service6.Branches.Add(branch1);
        
        // в речице
        branch2.Services.Add(service4);
        branch2.Services.Add(service5);
        service4.Branches.Add(branch2);
        service5.Branches.Add(branch2);
        
        // Кардиология (service7, service8 - в обоих филиалах, service9 - только в Гомеле)
        var service7 = new ServiceEntity 
        {
            Id = Guid.NewGuid(),
            Name = "Консультация врача-кардиолога второй квалификационной категории",
            Price = (decimal)34.00,
            SpecializationId = specialization3.Id
        };
        var service8 = new ServiceEntity 
        {
            Id = Guid.NewGuid(),
            Name = "Электрокардиограмма в 12 отведениях без функциональных проб",
            Price = (decimal)34.00,
            SpecializationId = specialization3.Id
        };
        var service9 = new ServiceEntity 
        {
            Id = Guid.NewGuid(),
            Name = "Консультация врача-кардиолога первой квалификационной категории",
            Price = (decimal)36.00,
            SpecializationId = specialization3.Id
        };
        
        // гомель
        branch1.Services.Add(service7);
        branch1.Services.Add(service8);
        branch1.Services.Add(service9);
        service7.Branches.Add(branch1);
        service8.Branches.Add(branch1);
        service9.Branches.Add(branch1);
        
        // речица
        branch2.Services.Add(service7);
        branch2.Services.Add(service8);
        service7.Branches.Add(branch2);
        service8.Branches.Add(branch2);

        // Косметология (только в гомеле)
        var service10 = new ServiceEntity 
        {
            Id = Guid.NewGuid(),
            Name = "Поверхностно-срединный пилинг",
            Price = (decimal)93.69,
            SpecializationId = specialization4.Id
        };
        var service11 = new ServiceEntity 
        {
            Id = Guid.NewGuid(),
            Name = "Консультация врача-косметолога высшей квалификационной категории",
            Price = (decimal)38.00,
            SpecializationId = specialization4.Id
        };
        
        // гомель
        branch1.Services.Add(service10);
        branch1.Services.Add(service11);
        service10.Branches.Add(branch1);
        service11.Branches.Add(branch1);
        
        // Неврология (service12 - в обоих, service13 - только в речице)
        var service12 = new ServiceEntity 
        {
            Id = Guid.NewGuid(),
            Name = "Консультация врача-невролога первой квалификационной категории",
            Price = (decimal)33.03,
            SpecializationId = specialization5.Id
        };
        var service13 = new ServiceEntity 
        {
            Id = Guid.NewGuid(),
            Name = "Блокада передней лестничной мышцы",
            Price = (decimal)24.84,
            SpecializationId = specialization5.Id
        };

        // гомель
        branch1.Services.Add(service12);
        service12.Branches.Add(branch1);
        
        // речица
        branch2.Services.Add(service12);
        branch2.Services.Add(service13);
        service12.Branches.Add(branch2);
        service13.Branches.Add(branch2);
        
        // Оториноларингология (все услуги в обоих филиалах)
        var service14 = new ServiceEntity 
        {
            Id = Guid.NewGuid(),
            Name = "Удаление серной пробки",
            Price = (decimal)12.77,
            SpecializationId = specialization6.Id
        };
        var service15 = new ServiceEntity 
        {
            Id = Guid.NewGuid(),
            Name = "Обработка слизистой глотки, гортани лекарственными препаратами",
            Price = (decimal)7.17,
            SpecializationId = specialization6.Id
        };
        
        // гомель
        branch1.Services.Add(service14);
        branch1.Services.Add(service15);
        service14.Branches.Add(branch1);
        service15.Branches.Add(branch1);
        
        // речица
        branch2.Services.Add(service14);
        branch2.Services.Add(service15);
        service14.Branches.Add(branch2);
        service15.Branches.Add(branch2);
        
        // Офтальмология
        var service16 = new ServiceEntity 
        {
            Id = Guid.NewGuid(),
            Name = "Подбор контактных линз",
            Price = (decimal)23.96,
            SpecializationId = specialization7.Id
        };
        var service17 = new ServiceEntity 
        {
            Id = Guid.NewGuid(),
            Name = "Офтальмоскопия (исследование глазного дна)",
            Price = (decimal)13.10,
            SpecializationId = specialization7.Id
        };
        
        // гомель
        branch1.Services.Add(service16);
        branch1.Services.Add(service17);
        service16.Branches.Add(branch1);
        service17.Branches.Add(branch1);
        
        // речица
        branch2.Services.Add(service16);
        branch2.Services.Add(service17);
        service16.Branches.Add(branch2);
        service17.Branches.Add(branch2);
        
        // Психологическая помощь (только в гомеле)
        var service18 = new ServiceEntity 
        {
            Id = Guid.NewGuid(),
            Name = "Консультация психолога",
            Price = 70,
            SpecializationId = specialization8.Id
        };
        var service19 = new ServiceEntity 
        {
            Id = Guid.NewGuid(),
            Name = "Сеанс индивидуальной терапии для подростков (10+)",
            Price = (decimal)120.00,
            SpecializationId = specialization8.Id
        };
        
        // гомель
        branch1.Services.Add(service18);
        branch1.Services.Add(service19);
        service18.Branches.Add(branch1);
        service19.Branches.Add(branch1);

        // Терапия (в обоих филиалах)
        var service20 = new ServiceEntity 
        {
            Id = Guid.NewGuid(),
            Name = "Консультация врача-терапевта первой квалификационной категории",
            Price = (decimal)34.65,
            SpecializationId = specialization9.Id
        };
        
        // гомель
        branch1.Services.Add(service20);
        service20.Branches.Add(branch1);
        
        // речица
        branch2.Services.Add(service20);
        service20.Branches.Add(branch2);
        
        // Ультразвуковая диагностика
        var service21 = new ServiceEntity 
        {
            Id = Guid.NewGuid(),
            Name = "Диагностическая пункция щитовидной железы",
            Price = (decimal)52.19,
            SpecializationId = specialization10.Id
        };
        var service22 = new ServiceEntity 
        {
            Id = Guid.NewGuid(),
            Name = "УЗИ органов брюшной полости: поджелудочная железа с ЦДК.",
            Price = (decimal)18.44,
            SpecializationId = specialization10.Id
        };
        
        // гомель
        branch1.Services.Add(service21);
        branch1.Services.Add(service22);
        service21.Branches.Add(branch1);
        service22.Branches.Add(branch1);
        
        // речица
        branch2.Services.Add(service22);
        service22.Branches.Add(branch2);
        
        // Лазерная эпиляция (только в гомеле)
        var service23 = new ServiceEntity 
        {
            Id = Guid.NewGuid(),
            Name = "Виски",
            Price = (decimal)17.56,
            SpecializationId = specialization11.Id
        };
        var service24 = new ServiceEntity 
        {
            Id = Guid.NewGuid(),
            Name = "Живот(полностью)",
            Price = (decimal)60.56,
            SpecializationId = specialization11.Id
        };
        
        // гомель
        branch1.Services.Add(service23);
        branch1.Services.Add(service24);
        service23.Branches.Add(branch1);
        service24.Branches.Add(branch1);
        
        // Эндокринология (service25, service26 - в гомеле, service26 - в речице)
        var service25 = new ServiceEntity 
        {
            Id = Guid.NewGuid(),
            Name = "Консультация врача-эндокринолога высшей квалификационной категории",
            Price = (decimal)33.48,
            SpecializationId = specialization12.Id
        };
        var service26 = new ServiceEntity 
        {
            Id = Guid.NewGuid(),
            Name = "УЗ- контроль диагностической пункции",
            Price = (decimal)13.17,
            SpecializationId = specialization12.Id
        };
        
        // гомель
        branch1.Services.Add(service25);
        branch1.Services.Add(service26);
        service25.Branches.Add(branch1);
        service26.Branches.Add(branch1);
        
        // речица
        branch2.Services.Add(service25);
        service25.Branches.Add(branch2);
        
        await context.Services.AddRangeAsync(
          service1, service2, service3, service4, service5, service6, service7, service8, service9,
          service10, service11, service12, service13, service14, service15, service16, service17,
          service18, service19, service20, service21, service22, service23, service24, service25, service26
        );
    }
}