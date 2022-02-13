//libreria contexto
using apiFutbolistas.Context;
//libreria modelo
using apiFutbolistas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiFutbolistas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FutbolistaController : ControllerBase
    {
        //mando a llamar a mi contexto, importo la libreria para el contexto
        private readonly AppDbContext context;
        //creo un constructor para este controlador
        public FutbolistaController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<FutbolistaController>
        [HttpGet]
        public ActionResult Get()
        {
            //manejo de errores con try
            try
            {
                //regreso al cliente con todos los registros
                return Ok(context.futbolistas.ToList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<FutbolistaController>/5
        //como el get id se va reutilziar en otros metodos le agrego el nombre GetFutbolista
        [HttpGet("{id}", Name ="GetFutbolista")]
        public ActionResult Get(int id)
        {
            try
            {
                //declaro una variable donde busco el id atraves de contexto con una expresion lamda
                var futbolista = context.futbolistas.FirstOrDefault(f => f.id == id);
                //retorno con el metodo OK
                return Ok(futbolista);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<FutbolistaController>
        [HttpPost]
        //              el cuerpo que recibo es de tipo Futbolista asi que importo su modelo
        public ActionResult Post([FromBody] Futbolista futbolista)
        {
            try
            {
                //agrego mi contexto de datos
                context.futbolistas.Add(futbolista);
                //guardo los cambios
                context.SaveChanges();
                //retorno el objeto(todos los datos recien ingresados) recien insertado
                //para obtener el id del registro recien ingresado utilizo la funcion GetFutbolista
                return CreatedAtRoute("GetFutbolista", new { id = futbolista.id},futbolista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<FutbolistaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Futbolista futbolista)
        {
            try
            {
                //valido si existe un id en la base de datos con el que se ingreso
                //id de parametro con el del body
                if (futbolista.id == id)
                {
                    //modifico el registro
                    context.Entry(futbolista).State = EntityState.Modified;
                    //guardo los cambios
                    context.SaveChanges();
                    //retorno el objeto llamado la funcion GetFutbolista
                    return CreatedAtRoute("GetFutbolista", new { id = futbolista.id }, futbolista);
                }else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<FutbolistaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                //creo una variable y le asigno el valor del resultado de la busqueda por id con expresion lamda
                var futbolista = context.futbolistas.FirstOrDefault(f => f.id == id);
                //si  existe resultado donde se encuentre el id
                if (futbolista != null)
                {
                    //remuevo el registro
                    context.futbolistas.Remove(futbolista);
                    //guardo los cambios
                    context.SaveChanges();
                    //retorno el id solo para confirmar el registro borrado
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
