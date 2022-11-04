﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        public IEnumerable<Evento> _eventos = new Evento[]{
            new Evento(){
                EventoId = 1,
                Tema = "Angular 11 e .Net 5",
                Local = "Caucaia",
                Lote = "1º Lote",
                QtdPessoas = 250,
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                ImagemURL = "Foto.png"
            },
            new Evento(){
                EventoId = 2,
                Tema = "Angular 12 e .Net 5",
                Local = "Caucaia",
                Lote = "2º Lote",
                QtdPessoas = 200,
                DataEvento = DateTime.Now.AddDays(4).ToString("dd/MM/yyyy"),
                ImagemURL = "Foto2.png"
            },
        };

        private readonly DataContext context;

        public EventosController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return this.context.Eventos;
        }

        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
            return this.context.Eventos.FirstOrDefault(evento => evento.EventoId == id);
        }

        [HttpPost]
        public string Post()
        {
            return "Exemplo de Post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de Put com id = {id}";
        }


        [HttpDelete("{id}")]
        public string Deletet(int id)
        {
            return $"Exemplo de Delete com id = {id}";
        }
    }
}