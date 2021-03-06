﻿using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;

namespace Devisioona.Harvest.CLI.Commands {
	public static class Project_List {
		public static Command GetCommand() {
			var show = new Command("list", "List projects") {
			};

			show.Handler = CommandHandler.Create(Execute);

			return show;
		}

		private static async Task Execute() {
			var client = Program.GetHarvestClient();

			var resp = await client.GetAllProjects(activeOnly: false);

			foreach (var p in resp.Projects) {
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.Write($"{p.Id} - ");
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write(p.Client.Name);
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write(" / ");
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.Write(p.Name);
				Console.ResetColor();
				Console.WriteLine();
			}
		}
	}
}
