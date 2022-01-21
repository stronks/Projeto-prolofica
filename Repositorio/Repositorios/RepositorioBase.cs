using Dapper;
using Repositorio.Entidades;
using Repositorio.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace Repositorio.Repositorios
{
    /// <summary>
    /// CENTRALIZADO NUMA UNICA CLASSE PARA ESSE EXEMPLO, POR TER UM ESCOPO BEM RESTRITO.
    /// NUM ESCOPO MAIOR TORNARIA ESTA UMA CLASSE ABSTRATA E OS METODOS VIRTUAIS PARA USO GERAL EM CLASSES MAIS ESPECIALIZADAS
    /// </summary>
    /// <typeparam name="TEntidade"></typeparam>


    public class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade> where TEntidade : EntidadeBase
    {
        private readonly string connectionString = "Data Source = localhost; Initial Catalog = teste; Integrated Security = True";

        private IDbConnection CreateConnection()
        {
            var connection = new SqlConnection(connectionString);
            return connection;
        }


        public void Atualiza(TEntidade entidade)
        {
            try
            {
                entidade.DataAtualizacao = System.DateTime.Now;
                using (var connection = CreateConnection())
                {
                    connection.Update(entidade);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public void Deleta(long id)
        {
            try
            {
         
                using (var connection = CreateConnection())
                {
                  var remove =   connection.Get<TEntidade>(id);
                    connection.Delete(remove);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public void Insere(TEntidade entidade)
        {
            try
            {
                entidade.DataCriacao = System.DateTime.Now;
                using (var connection = CreateConnection())
                {
                    connection.Insert(entidade);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public TEntidade ObtemPeloId(long id)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    return connection.Get<TEntidade>(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public IEnumerable<TEntidade> RecuperaTodos()
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    return connection.GetList<TEntidade>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }


        public IEnumerable<ConsultaAgendadas> RecuperaTodasConsultaAgendadas()
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    return connection.Query<ConsultaAgendadas>(@"select A.id, CONCAT(CONVERT(varchar,A.[DataHoraMarcada],11),' ', CONVERT(varchar,A.[DataHoraMarcada],8))  as DataHoraMarcada   ,b.nome as Medico ,C.nome as Paciente,D.nome as Consultorio, A.DataHoraMarcada ,A.[DataCriacao] ,A.[DataAtualizacao]
                          from[HorarioAgenda] A
                          inner join Medico B on A.[IdMedico] = B.Id
                          inner join Paciente C on A.[IdPaciente] = C.Id
                          inner join Consultorio D on A.[IdConsultorio] = D.Id");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }


    }
}
