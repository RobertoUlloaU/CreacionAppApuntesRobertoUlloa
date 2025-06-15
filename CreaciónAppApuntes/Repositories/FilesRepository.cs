using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaciónAppApuntes.Repositories
{
    internal class FilesRepository
    {
        private string filePath = FileSystem.AppDataDirectory + "/archivo1.txt";
        public async Task<bool> GenerarArchivo(String texto)
        {
            

            try
            {
                await File.WriteAllTextAsync(filePath, texto);
                if (File.Exists(filePath))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al generar el archivo: {ex.Message}");
                return false;
            }
        }

        public async Task<string> DevuelveInformacionArchivo()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    return await File.ReadAllTextAsync(filePath);
                }
                else
                {
                    return "El archivo no existe.";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo: {ex.Message}");
                return "Error al leer el archivo.";
            }
        }
    }
}
