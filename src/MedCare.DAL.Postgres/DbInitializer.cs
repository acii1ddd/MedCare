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
            !context.Users.Any() &&
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
                Name = "МЦ 'Свагушка' в Гомеле",
                Phone = "+375295789364",
                AddressId = address1.Id
            };
            var branch2 = new BranchEntity // мозырь
            {
                Id = Guid.NewGuid(),
                Name = "МЦ 'Свагушка' в Речице",
                Phone = "+375447899678",
                AddressId = address2.Id
            };
            await context.Branches.AddRangeAsync(branch1, branch2);
            
            // специализации
            var specialization1 = new SpecializationEntity
            {
                Id = Guid.NewGuid(),
                Name = "Аллергология",
                Description = "Аллергология - это область медицины, изучающая аллергические реакции и заболевания, причины их возникновения, " +
                              "механизмы развития и проявления, методы их диагностики, профилактики и лечения."
            };
            var specialization2 = new SpecializationEntity
            {
                Id = Guid.NewGuid(),
                Name = "Гинекология",
                Description = "Гинекология - это область медицины, изучающая заболевания, характерные только для организма женщины, " +
                              "прежде всего — заболевания женской репродуктивной системы."
            };
            var specialization3 = new SpecializationEntity
            {
                Id = Guid.NewGuid(),
                Name = "Кардиология",
                Description = "Кардиология - это раздел медицины, занимающийся изучением сердечно-сосудистой системы человека: строения и развития сердца и " +
                              "сосудов, их функций, а также заболеваний, включая изучение причин их возникновения, механизмов развития, " +
                              "клинических проявлений, вопросов диагностики."
            };
            var specialization4 = new SpecializationEntity
            {
                Id = Guid.NewGuid(),
                Name = "Косметология",
                
                Description = "Косметология - это отрасль медицины, изучающая эстетические проблемы организма человека, их этиологии, " +
                              "проявления и методы коррекции, также — свод методик, направленных на коррекцию эстетических " +
                              "проблем внешности человека."
            };
            var specialization5 = new SpecializationEntity
            {
                Id = Guid.NewGuid(),
                Name = "Неврология",
                Description = "Невролог – специалист, занимающийся диагностикой и лечением заболеваний периферической и " +
                              "центральной нервной системы."
            };
            var specialization6 = new SpecializationEntity
            {
                Id = Guid.NewGuid(),
                Name = "Оториноларингология",
                Description = "Оториноларингология — это раздел медицины, которая специализируется на " +
                              "диагностике, лечении и профилактике патологий уха, горла, носа."
            };
            var specialization7 = new SpecializationEntity
            {
                Id = Guid.NewGuid(),
                Name = "Офтальмология",
                Description = "Офтальмология — это область медицины, которая занимается диагностикой и лечением заболеваний глаз."
            };
            var specialization8 = new SpecializationEntity
            {
                Id = Guid.NewGuid(),
                Name = "Психологическая помощь",
                Description = "Психолог - специалист, у которого достаточно знаний и умений, чтобы работать с эмоциональными " +
                              "(психологическими) аспектами, не требующими медикаментозного лечения."
            };
            var specialization9 = new SpecializationEntity
            {
                Id = Guid.NewGuid(),
                Name = "Терапия",
                Description = "Терапия — область медицины, изучающая внутренние болезни и занимающаяся диагностикой, " +
                              "профилактикой и лечением заболеваний практически всех органов и систем."
            };
            var specialization10 = new SpecializationEntity
            {
                Id = Guid.NewGuid(),
                Name = "Ультразвуковая диагностика",
                Description = "Ультразвуковая диагностика - это безопасный и малоинвазивный метод исследования, основанный на отражении " +
                              "звуковых волн от структур организма с различной плотностью " +
                              "с последующим анализом при помощи специализированного программного обеспечения."
            };
            var specialization11 = new SpecializationEntity
            {
                Id = Guid.NewGuid(),
                Name = "Лазерная эпиляция",
                Description = "Лазерная эпиляция - это безопасный и безболезненный способ удаления волос на долгий период " +
                              "времени с помощью воздействия импульсов лазерного излучения"
            };
            var specialization12 = new SpecializationEntity
            {
                Id = Guid.NewGuid(),
                Name = "Эндокринология",
                Description = "Эндокринология — раздел физиологии и медицины, изучающий строение " +
                              "и функции эндокринных желёз и разрабатывающий " +
                              "методы лечения заболеваний, вызванных нарушением их деятельности."
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

            // В Гомеле
            var user1 = new UserProfileEntity
            {
                Id = Guid.NewGuid(),
                Image = null,
                FirstName = "Александр",
                LastName = "Иванов",
                Patronymic = "Сергеевич",
                BirthDate = new DateTime(1990, 5, 15).ToUniversalTime(),
                Gender = Gender.Male,
                Email = "ivanov@gmail.com",
                PhoneNumber = "+375291234567",
                PassportSeries = "HB",
                PassportNumber = "5678903"
            };
            var user2 = new UserProfileEntity
            {
                Id = Guid.NewGuid(),
                Image = null,
                FirstName = "Екатерина",
                LastName = "Петрова",
                Patronymic = "Викторовна",
                BirthDate = new DateTime(1985, 11, 23).ToUniversalTime(),
                Gender = Gender.Female,
                Email = "petrova@gmail.com",
                PhoneNumber = "+375333456789",
                PassportSeries = "HB",
                PassportNumber = "7896543"
            };
            var user3 = new UserProfileEntity
            {
                Id = Guid.NewGuid(),
                Image = await File.ReadAllBytesAsync("../../static/img2.png"),
                FirstName = "Дмитрий",
                LastName = "Сидоров",
                Patronymic = "Андреевич",
                BirthDate = new DateTime(1995, 7, 30).ToUniversalTime(),
                Gender = Gender.Male,
                Email = "sidorov@gmail.com",
                PhoneNumber = "+375447890123",
                PassportSeries = "HB",
                PassportNumber = "7896543"
            };
            var user4 = new UserProfileEntity
            {
                Id = Guid.NewGuid(),
                Image = await File.ReadAllBytesAsync("../../static/img2.png"),
                FirstName = "Анна",
                LastName = "Козлова",
                Patronymic = "Игоревна",
                BirthDate = new DateTime(2000, 2, 12).ToUniversalTime(),
                Gender = Gender.Female,
                Email = "kozlova@gmail.com",
                PhoneNumber = "+375293210987",
                PassportSeries = "HB",
                PassportNumber = "9090909"
            };
            var user5 = new UserProfileEntity
            {
                Id = Guid.NewGuid(),
                Image = await File.ReadAllBytesAsync("../../static/img2.png"),
                FirstName = "Мария",
                LastName = "Захарова",
                Patronymic = "Анатольевна",
                BirthDate = new DateTime(1992, 4, 20).ToUniversalTime(),
                Gender = Gender.Female,
                Email = "maria@gmail.com",
                PhoneNumber = "+375293450987",
                PassportSeries = "HB",
                PassportNumber = "8765409"
            };
            var user6 = new UserProfileEntity
            {
                Id = Guid.NewGuid(),
                Image = await File.ReadAllBytesAsync("../../static/img2.png"),
                FirstName = "Сергей",
                LastName = "Васильев",
                Patronymic = "Олегович",
                BirthDate = new DateTime(1982, 12, 14).ToUniversalTime(),
                Gender = Gender.Male,
                Email = "vasilyev.sergey@gmail.com",
                PhoneNumber = "+375297890123",
                PassportSeries = "GH",
                PassportNumber = "8901234"
            };
            var user7 = new UserProfileEntity
            {
                Id = Guid.NewGuid(),
                Image = await File.ReadAllBytesAsync("../../static/img2.png"),
                FirstName = "Игорь",
                LastName = "Кузнецов",
                Patronymic = "Анатольевич",
                BirthDate = new DateTime(1984, 1, 29).ToUniversalTime(),
                Gender = Gender.Male,
                Email = "kuznetsov.igor@gmail.com",
                PhoneNumber = "+375291234568",
                PassportSeries = "XZ",
                PassportNumber = "3456789"
            };
            var user8 = new UserProfileEntity
            {
                Id = Guid.NewGuid(),
                Image = await File.ReadAllBytesAsync("../../static/img2.png"),
                FirstName = "Максим",
                LastName = "Орлов",
                Patronymic = "Петрович",
                BirthDate = new DateTime(1996, 7, 12).ToUniversalTime(),
                Gender = Gender.Male,
                Email = "orlov.maxim@gmail.com",
                PhoneNumber = "+375292345678",
                PassportSeries = "MN",
                PassportNumber = "4567891"
            };
            var user9 = new UserProfileEntity
            {
                Id = Guid.NewGuid(),
                Image = await File.ReadAllBytesAsync("../../static/img2.png"),
                FirstName = "Елена",
                LastName = "Зайцева",
                Patronymic = "Викторовна",
                BirthDate = new DateTime(1998, 5, 20).ToUniversalTime(),
                Gender = Gender.Female,
                Email = "zaitseva.elena@mail.ru",
                PhoneNumber = "+375293456789",
                PassportSeries = "ZA",
                PassportNumber = "5678902"
            };
            var user10 = new UserProfileEntity
            {
                Id = Guid.NewGuid(),
                Image = await File.ReadAllBytesAsync("../../static/img2.png"),
                FirstName = "Андрей",
                LastName = "Козлов",
                Patronymic = "Сергеевич",
                BirthDate = new DateTime(1985, 7, 5).ToUniversalTime(),
                Gender = Gender.Male,
                Email = "kozlov.andrey@gmail.com",
                PhoneNumber = "+375295678901",
                PassportSeries = "CK",
                PassportNumber = "4567890"
            };
            var user11 = new UserProfileEntity
            {
                Id = Guid.NewGuid(),
                Image = await File.ReadAllBytesAsync("../../static/img2.png"),
                FirstName = "Ольга",
                LastName = "Фёдорова",
                Patronymic = "Николаевна",
                BirthDate = new DateTime(2000, 4, 18).ToUniversalTime(),
                Gender = Gender.Female,
                Email = "fedorova.olga@outlook.com",
                PhoneNumber = "+375296789012",
                PassportSeries = "DF",
                PassportNumber = "6789012"
            };
            var user12 = new UserProfileEntity
            {
                Id = Guid.NewGuid(),
                Image = await File.ReadAllBytesAsync("../../static/img2.png"),
                FirstName = "Константин",
                LastName = "Фролов",
                Patronymic = "Алексеевич",
                BirthDate = new DateTime(1993, 2, 28).ToUniversalTime(),
                Gender = Gender.Male,
                Email = "frolov.konstantin@yandex.ru",
                PhoneNumber = "+375294567890",
                PassportSeries = "FR",
                PassportNumber = "6789013"
            };
            var user13 = new UserProfileEntity
            {
                Id = Guid.NewGuid(),
                Image = await File.ReadAllBytesAsync("../../static/img2.png"),
                FirstName = "Анастасия",
                LastName = "Мельникова",
                Patronymic = "Денисовна",
                BirthDate = new DateTime(2001, 10, 15).ToUniversalTime(),
                Gender = Gender.Female,
                Email = "melnikova.anastasia@outlook.com",
                PhoneNumber = "+375295678901",
                PassportSeries = "ME",
                PassportNumber = "7890124"
            };
            var user14 = new UserProfileEntity
            {
                Id = Guid.NewGuid(),
                Image = await File.ReadAllBytesAsync("../../static/img2.png"),
                FirstName = "Николай",
                LastName = "Борисов",
                Patronymic = "Сергеевич",
                BirthDate = new DateTime(1987, 9, 5).ToUniversalTime(),
                Gender = Gender.Male,
                Email = "borisov.nikolay@gmail.com",
                PhoneNumber = "+375296789012",
                PassportSeries = "BO",
                PassportNumber = "8901235"
            };
            
            await context.UserProfiles.AddRangeAsync(user1, user2, user3, user4, user5, user6, 
                user7, user8, user9, user10, user11, user12, user13, user14);
            
            // сотрудники
            // password: 123
            const string passwordHash = "$2a$11$dqWSehl3tqJ5QRlE5zxpKeF2ulVPv.4NyU9m5FziPz9IUWwecUjxu";
            
            // Гомель
            var director1 = new UserEntity
            {
                Id = Guid.NewGuid(),
                Login = "director1",
                PasswordHash = passwordHash,
                UserRole = UserRole.Director,
                UserProfileId = user1.Id,
                SpecializationId = null,
                BranchId = branch1.Id
            };
            var receptionist1 = new UserEntity
            {
                Id = Guid.NewGuid(),
                Login = "register1",
                PasswordHash = passwordHash,
                UserRole = UserRole.Receptionist,
                UserProfileId = user2.Id,
                SpecializationId = null,
                BranchId = branch1.Id
            };
            var doctor1 = new UserEntity // Аллергология
            {
                Id = Guid.NewGuid(),
                Login = "doc1",
                PasswordHash = passwordHash,
                UserRole = UserRole.Doctor,
                UserProfileId = user3.Id,
                SpecializationId = specialization1.Id,
                BranchId = branch1.Id
            };
            var doctor2 = new UserEntity // Аллергология
            {
                Id = Guid.NewGuid(),
                Login = "doc2",
                PasswordHash = passwordHash,
                UserRole = UserRole.Doctor,
                UserProfileId = user4.Id,
                SpecializationId = specialization2.Id,
                BranchId = branch1.Id
            };
            var doctor3 = new UserEntity // Кардиология
            {
                Id = Guid.NewGuid(),
                Login = "doc3",
                PasswordHash = passwordHash,
                UserRole = UserRole.Doctor,
                UserProfileId = user5.Id,
                SpecializationId = specialization3.Id,
                BranchId = branch1.Id
            };
            var doctor4 = new UserEntity // Косметология
            {
                Id = Guid.NewGuid(),
                Login = "doc4",
                PasswordHash = passwordHash,
                UserRole = UserRole.Doctor,
                UserProfileId = user6.Id,
                SpecializationId = specialization4.Id,
                BranchId = branch1.Id
            };
            var doctor5 = new UserEntity // Неврология
            {
                Id = Guid.NewGuid(),
                Login = "doc5",
                PasswordHash = passwordHash,
                UserRole = UserRole.Doctor,
                UserProfileId = user7.Id,
                SpecializationId = specialization5.Id,
                BranchId = branch1.Id
            };
            var doctor6 = new UserEntity // Оториноларингология
            {
                Id = Guid.NewGuid(),
                Login = "doc6",
                PasswordHash = passwordHash,
                UserRole = UserRole.Doctor,
                UserProfileId = user8.Id,
                SpecializationId = specialization6.Id,
                BranchId = branch1.Id
            };
            var doctor7 = new UserEntity // Офтальмология
            {
                Id = Guid.NewGuid(),
                Login = "doc7",
                PasswordHash = passwordHash,
                UserRole = UserRole.Doctor,
                UserProfileId = user9.Id,
                SpecializationId = specialization7.Id,
                BranchId = branch1.Id
            };
            var doctor8 = new UserEntity // Психологическая помощь
            {
                Id = Guid.NewGuid(),
                Login = "doc8",
                PasswordHash = passwordHash,
                UserRole = UserRole.Doctor,
                UserProfileId = user10.Id,
                SpecializationId = specialization8.Id,
                BranchId = branch1.Id
            };
            var doctor9 = new UserEntity // Терапия
            {
                Id = Guid.NewGuid(),
                Login = "doc9",
                PasswordHash = passwordHash,
                UserRole = UserRole.Doctor,
                UserProfileId = user11.Id,
                SpecializationId = specialization9.Id,
                BranchId = branch1.Id
            };
            var doctor10 = new UserEntity // Ультразвуковая диагностика
            {
                Id = Guid.NewGuid(),
                Login = "doc10",
                PasswordHash = passwordHash,
                UserRole = UserRole.Doctor,
                UserProfileId = user12.Id,
                SpecializationId = specialization10.Id,
                BranchId = branch1.Id
            };
            var doctor11 = new UserEntity // Лазерная эпиляция
            {
                Id = Guid.NewGuid(),
                Login = "doc11",
                PasswordHash = passwordHash,
                UserRole = UserRole.Doctor,
                UserProfileId = user13.Id,
                SpecializationId = specialization11.Id,
                BranchId = branch1.Id
            };
            var doctor12 = new UserEntity // Эндокринология
            {
                Id = Guid.NewGuid(),
                Login = "doc12",
                PasswordHash = passwordHash,
                UserRole = UserRole.Doctor,
                UserProfileId = user14.Id,
                SpecializationId = specialization12.Id,
                BranchId = branch1.Id
            };
            await context.Users.AddRangeAsync(director1, receptionist1, doctor1, doctor2, doctor3, 
                doctor4, doctor5, doctor6, doctor7, doctor8, doctor9, doctor10, doctor11, doctor12);
            
            // В Речице
            var user15 = new UserProfileEntity
            {
                Id = Guid.NewGuid(),
                Image = await File.ReadAllBytesAsync("../../static/img2.png"),
                FirstName = "Мария",
                LastName = "Петрова",
                Patronymic = "Александровна",
                BirthDate = new DateTime(1995, 8, 22).ToUniversalTime(),
                Gender = Gender.Female,
                Email = "petrova.maria@gmail.com",
                PhoneNumber = "+375292345678",
                PassportSeries = "MP",
                PassportNumber = "3456789"
            };
            var user16 = new UserProfileEntity
            {
                Id = Guid.NewGuid(),
                Image = await File.ReadAllBytesAsync("../../static/img2.png"),
                FirstName = "Дмитрий",
                LastName = "Смирнов",
                Patronymic = "Игоревич",
                BirthDate = new DateTime(1988, 2, 10).ToUniversalTime(),
                Gender = Gender.Male,
                Email = "smirnov.dmitriy@yandex.ru",
                PhoneNumber = "+375293456789",
                PassportSeries = "AB",
                PassportNumber = "1234567"
            };
            var user17 = new UserProfileEntity
            {
                Id = Guid.NewGuid(),
                Image = await File.ReadAllBytesAsync("../../static/img2.png"),
                FirstName = "Екатерина",
                LastName = "Сидорова",
                Patronymic = "Владимировна",
                BirthDate = new DateTime(1993, 11, 30).ToUniversalTime(),
                Gender = Gender.Female,
                Email = "sidorova.katya@mail.ru",
                PhoneNumber = "+375294567890",
                PassportSeries = "KV",
                PassportNumber = "7890123"
            };
            var user18 = new UserProfileEntity
            {
                Id = Guid.NewGuid(),
                Image = await File.ReadAllBytesAsync("../../static/img2.png"),
                FirstName = "Татьяна",
                LastName = "Беляева",
                Patronymic = "Геннадьевна",
                BirthDate = new DateTime(1991, 3, 8).ToUniversalTime(),
                Gender = Gender.Female,
                Email = "belyaeva.tanya@outlook.com",
                PhoneNumber = "+375290123456",
                PassportSeries = "OP",
                PassportNumber = "2345678"
            };
            
            await context.UserProfiles.AddRangeAsync(user15, user16, user17, user18);
            
            var director2 = new UserEntity
            {
                Id = Guid.NewGuid(),
                Login = "director2",
                PasswordHash = passwordHash,
                UserRole = UserRole.Director,
                UserProfileId = user15.Id,
                SpecializationId = null,
                BranchId = branch2.Id
            };
            var receptionist2 = new UserEntity
            {
                Id = Guid.NewGuid(),
                Login = "register2",
                PasswordHash = passwordHash,
                UserRole = UserRole.Receptionist,
                UserProfileId = user16.Id,
                SpecializationId = null,
                BranchId = branch2.Id
            };
            var doctor13 = new UserEntity // Кардиология
            {
                Id = Guid.NewGuid(),
                Login = "doc13",
                PasswordHash = passwordHash,
                UserRole = UserRole.Doctor,
                UserProfileId = user17.Id,
                SpecializationId = specialization3.Id,
                BranchId = branch2.Id
            };
            var doctor14 = new UserEntity // Неврология
            {
                Id = Guid.NewGuid(),
                Login = "doc11",
                PasswordHash = passwordHash,
                UserRole = UserRole.Doctor,
                UserProfileId = user18.Id,
                SpecializationId = specialization5.Id,
                BranchId = branch2.Id
            };

            await context.Users.AddRangeAsync(director2, receptionist2, doctor13, doctor14);

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