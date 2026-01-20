using WebApplication1.Models;
using System;
using System.Diagnostics;
using System.Linq;
using WebApplication1.Data;

namespace WebApplication1.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CompaniesDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Companies.Any())
            {
                return;   // DB has been seeded
            }

            var companies = new Company[]
            {
            new Company{NameFull="ИП Карапетян",NameShort="ИП Карапетян",Inn=123456,Ogrn="12345678",ChangeDate=DateOnly.Parse("2022-10-21"),CreationDate=DateOnly.Parse("2022-10-21")},
            new Company{NameFull="ООО Рога и копыта",NameShort="Рога и копыта",Inn=223456,Ogrn="22345678",ChangeDate=DateOnly.Parse("2021-10-21"),CreationDate=DateOnly.Parse("2019-10-21")},
            new Company{NameFull="ООО Проект-Труд",NameShort="Проект-Труд",Inn=133456,Ogrn="13345678",ChangeDate=DateOnly.Parse("2022-12-21"),CreationDate=DateOnly.Parse("2021-10-21")},
            new Company { NameFull = "ЗАО Уход", NameShort = "Уход", Inn = 124456, Ogrn = "12445678", ChangeDate = DateOnly.Parse("2020-11-10"), CreationDate = DateOnly.Parse("2019-10-21") },
            new Company { NameFull="ОАО Мыши и Кактусы",NameShort="Мыши и кактусы",Inn=123556,Ogrn="12355678",ChangeDate=DateOnly.Parse("2025-10-21"),CreationDate=DateOnly.Parse("2023-10-21")},
            new Company { NameFull="МК жизнь",NameShort="Жизнь",Inn=123466,Ogrn="12346678",ChangeDate=DateOnly.Parse("2022-04-12"),CreationDate=DateOnly.Parse("2022-10-21")},
            new Company { NameFull="ООО Мы",NameShort="Мы",Inn=123457,Ogrn="12345778",ChangeDate=DateOnly.Parse("2021-10-21"),CreationDate=DateOnly.Parse("2012-10-21")},
            new Company { NameFull="ООО Моя Оборона",NameShort="Моя Оборона",Inn=323456,Ogrn="12345688",ChangeDate=DateOnly.Parse("2024-10-21"),CreationDate=DateOnly.Parse("2020-10-21")},
            };
            foreach (Company s in companies)
            {
                context.Companies.Add(s);
            }
            context.SaveChanges();
        }
    }
}