using System;
using System.IO;
using ExEstacionamento.Models;

namespace ExEstacionamento.Repositorios
{
    public class RegistroRepositorio
    {
        private const string PATH = "DataBases/Registros.csv";
        public void RegistrarNoCSV(RegistroModel registro){

            if(File.Exists(PATH)){
                registro.Id = File.ReadAllLines(PATH).Length + 1; //vai contar quantas linhas o PATH tem, masi 1
            }else{
                registro.Id = 1;
            }

            StreamWriter sw = new StreamWriter(PATH, true);//true- se ele não tiver criado ele cria; se estiver criado, não vai recriar; vai adicionar no final
            sw.WriteLine($"{registro.Id};{registro.Nome};{registro.Marca.Nome};{registro.Modelo.Nome};{registro.Placa};{DateTime.Now}");
            sw.Close();

        }//fim Registrar no csv
    }
}