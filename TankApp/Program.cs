using System;
using System.Collections.Generic;
using System.Linq;
using TankApp.Models;
using TankApp.Services;
using TankApp.Interfaces;
using TankApp.Extensions;

namespace TankApp
{
	class Program
	{
		static void Main(string[] args)
		{
			

			try
			{
				// --- Загрузка данных из JSON ---
				var tanks = DataLoader.LoadTanks();
				var units = DataLoader.LoadUnits();
				var factories = DataLoader.LoadFactories();

				Console.WriteLine($"\nКоличество резервуаров: {tanks.Count}, установок: {units.Count}");

				// --- Вывод информации о резервуарах ---
				foreach (var tank in tanks)
				{
					var unit = tanks.FindUnit(units);
					var factory = unit?.FindFactory(factories);
					Console.WriteLine($"Резервуар: {tank.Name}, Установка: {unit?.Name}, Завод: {factory?.Name}");
				}

				// --- Общий объем резервуаров ---
				var totalVolume = tanks.GetTotalVolume();
				Console.WriteLine($"Общий объем резервуаров: {totalVolume}");

				// --- Добавление нового резервуара и сохранение в JSON ---
				tanks.Add(new Tank { Name = "Новый резервуар", Capacity = 6000, UnitName = "Установка 1" });
				JsonService<Tank>.Save("Data/tanks.json", tanks);

				// --- Чтение и запись Excel ---
				ExcelService.WriteTanksToExcel("output/tanks.xlsx", tanks);
				var excelTanks = ExcelService.ReadTanksFromExcel("output/tanks.xlsx");

				Console.WriteLine("\nДанные из Excel:");
				foreach (var t in excelTanks)
				{
					Console.WriteLine($"{t.Name}, {t.Capacity}, {t.UnitName}");
				}

				// --- Парсинг сделок из JSON ---
				var deals = DataLoader.LoadDeals();

				var topDeals = GetNumbersOfDeals(deals);
				Console.WriteLine($"\nСделки ≥100 руб (последние 5 по дате): {topDeals.Count}");
				Console.WriteLine("Идентификаторы: " + string.Join(", ", topDeals));

				var sumsByMonth = GetSumsByMonth(deals);
				Console.WriteLine("\nСуммы сделок по месяцам:");
				foreach (var item in sumsByMonth)
				{
					Console.WriteLine($"{item.Month:MMMM yyyy}: {item.Sum} руб.");
				}
			}
			catch (InvalidOperationException ex)
			{
				Console.WriteLine("Ошибка: " + ex.Message);
				Environment.Exit(1);
			}
		}

		public static IList<string> GetNumbersOfDeals(IEnumerable<Deal> deals)
		{
			return deals
				.Where(d => d.Sum >= 100)
				.OrderBy(d => d.Date)
				.Take(5)
				.OrderByDescending(d => d.Sum)
				.Select(d => d.Id)
				.ToList();
		}

		public static IList<SumByMonth> GetSumsByMonth(IEnumerable<Deal> deals)
		{
			return deals
				.GroupBy(d => new DateTime(d.Date.Year, d.Date.Month, 1))
				.Select(g => new SumByMonth(g.Key, g.Sum(d => d.Sum)))
				.ToList();
		}
	}
}