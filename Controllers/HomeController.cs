using ExEstacionamento.Models;
using ExEstacionamento.Repositorios;
using ExEstacionamento.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExEstacionamento.Controllers
{
    public class HomeController : Controller
    {
        ModeloRepositorio modeloRepositorio = new ModeloRepositorio();
        MarcaRepositorio marcaRepositorio = new MarcaRepositorio();
        RegistroRepositorio registroRepositorio = new RegistroRepositorio();

        [HttpGet]
        public IActionResult Index(){
            var listaDeModelos = modeloRepositorio.ListarModelos();
            var listaDeMarcas = marcaRepositorio.ListarMarcas();

            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.Modelos = listaDeModelos;
            homeViewModel.Marca = listaDeMarcas;

            return View(homeViewModel);

        }

        [HttpPost]
        public IActionResult RegistrarEntrada(IFormCollection form){
            RegistroModel registro = new RegistroModel();

            registro.Nome = form["nome"];

            var modelo = new ModeloModel();// preciso instanciar meus objetos não nativos
            modelo.Nome = form["modelo"];
            registro.Modelo = modelo;

            var marca = new MarcaModel();
            marca.Nome = form["marca"];
            registro.Marca = marca;

            registro.Placa = form["placa"];

            registroRepositorio.RegistrarNoCSV(registro);

            return RedirectToAction("Index");



        }
    }
}