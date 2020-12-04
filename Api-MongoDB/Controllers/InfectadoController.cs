using Api_MongoDB.Data.Collections;
using Api_MongoDB.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Api_MongoDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectadoController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infectado> _infectadosCollection;

        public InfectadoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectadoDto dto)
        {
            var infectado = new Infectado(dto.Id, dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);
            _infectadosCollection.InsertOne(infectado);

            return StatusCode(201, "Infectado adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();

            return Ok(infectados);
        }

        [HttpPut]
        public ActionResult AtualizarInfectados([FromBody] InfectadoDto dto)
        {
            var infectado = new Infectado(dto.Id, dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);
            _infectadosCollection.UpdateOne(Builders<Infectado>.Filter.Where(_ => _.Id == dto.Id), Builders<Infectado>.Update
                .Set("Sexo", dto.Sexo)
                .Set("DataNascimento", dto.DataNascimento)
                .Set("latidude", dto.Latitude)
                .Set("longitude", dto.Longitude));
            return Ok("Atualizado com Sucesso");
        }

        [HttpDelete("{Id}")]
        public ActionResult DeletarInfectados(string Id)
        {
            _infectadosCollection.DeleteOne(Builders<Infectado>.Filter.Where(_ => _.Id == Id));
            return Ok("Deletado com Sucesso");
        }
    }
}
