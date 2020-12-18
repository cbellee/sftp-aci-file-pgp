using PgpCore;
using System;
using System.IO;
using Kurukuru;
using System.Text;

namespace PGPEncryptConsoleApp
{
	class Program
	{
		static int Main(string[] args)
		{
			string password = String.Empty;
			string filePath = String.Empty;

			using (PGP pgp = new PGP())
			{
				if (args.Length == 0 || args.Length < 2)
				{
					Console.WriteLine("Please supply a password value as the first argument and a valid output path as the second argument to this command");
					return 1;
				}

				if (args[0].Length == 0)
				{
					Console.WriteLine("Please enter a password between 3 and 15 characters");
					return 1;
				}
				else if (args[0].Length >= 3 && args[0].Length <= 15)
				{
					password = args[0];
				}
				else
				{
					Console.WriteLine("Please enter a password between 3 and 15 characters");
					return 1;
				}

				if (args[1].Length == 0)
				{
					Console.WriteLine("Please provide an output path");
					return 1;
				}
				else
				{
					filePath = args[1];
				}

				string outputPath = System.IO.Path.GetFullPath(filePath);

				if (!System.IO.Directory.Exists(outputPath))
				{
					Console.WriteLine($"directory path '{outputPath}' doesn't exist!");
					return 1;
				}

				Console.WriteLine($"Welcome to PGPEncryptConsoleApp!");

				string publicKeyFilePath = Path.Combine(outputPath, "public.asc");
				string publicKeyBase64FilePath = Path.Combine(outputPath, "public_base64.asc");
				string privateKeyFilePath = Path.Combine(outputPath, "private.asc");
				string privateKeyBase64FilePath = Path.Combine(outputPath, "private_base64.asc");
				string username = null;
				int strength = 4096;
				int certainty = 8;

				// Generate keys
				try
				{
					Spinner.Start("Generating keys...", () =>
					{
						pgp.GenerateKey(publicKeyFilePath, privateKeyFilePath, username, password, strength, certainty);
					});
					string publicKey = File.ReadAllText(publicKeyFilePath);
					File.WriteAllText(publicKeyBase64FilePath, Convert.ToBase64String(Encoding.UTF8.GetBytes(publicKey)));

					Console.WriteLine($"Created public key: {publicKeyFilePath}");
					Console.WriteLine($"Converted public key to base64: {publicKeyBase64FilePath}");
					Console.WriteLine($"Created private key: {privateKeyFilePath}");

					string privateKey = File.ReadAllText(privateKeyFilePath);
					File.WriteAllText(privateKeyBase64FilePath, Convert.ToBase64String(Encoding.UTF8.GetBytes(privateKey)));

					Console.WriteLine($"Created private key: {privateKeyFilePath}");
					Console.WriteLine($"Converted private key to base64: {privateKeyBase64FilePath}");
					return 0;
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
					return 1;
				}
			}
		}
	}
}
