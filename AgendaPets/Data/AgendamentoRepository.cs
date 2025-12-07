using System;
using System.Collections.Generic;
using AgendaPets.Models;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace AgendaPets.Data
{
    public class AgendamentoRepository
    {
        private readonly string? _conn;

        public AgendamentoRepository(IConfiguration config)
        {
            _conn = config.GetConnectionString("DefaultConnection");
        }

        public void Inserir(Agendamento model)
        {
            const string sql = @"
                INSERT INTO Agendamento (NOMPET, ESPECIE, NOMTUTOR, SERVICO, DAT_AGENDAMENTO, DAT_INCLUSAO)
                VALUES (@nomePet, @especie, @nomeTutor, @servico, @datAgendamento, NOW());";

            using var c = new MySqlConnection(_conn);
            using var cmd = new MySqlCommand(sql, c);
            cmd.Parameters.AddWithValue("@nomePet", model.NomePet ?? string.Empty);
            cmd.Parameters.AddWithValue("@especie", model.Especie ?? string.Empty);
            cmd.Parameters.AddWithValue("@nomeTutor", model.NomeTutor ?? string.Empty);
            cmd.Parameters.AddWithValue("@servico", model.Servico ?? string.Empty);
            cmd.Parameters.AddWithValue("@datAgendamento", model.DataAgendamento == DateTime.MinValue ? (object)DBNull.Value : model.DataAgendamento);
            c.Open();
            cmd.ExecuteNonQuery();
        }

        public List<Agendamento> ObterTodos()
        {
            var list = new List<Agendamento>();
            const string sql = @"
                SELECT ID_AGENDAMENTO, NOMPET, ESPECIE, NOMTUTOR, SERVICO, DAT_AGENDAMENTO
                FROM Agendamento
                WHERE DAT_EXCLUSAO IS NULL
                ORDER BY DAT_AGENDAMENTO;";

            using var c = new MySqlConnection(_conn);
            using var cmd = new MySqlCommand(sql, c);
            c.Open();
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                list.Add(new Agendamento
                {
                    Id = Convert.ToInt32(rdr["ID_AGENDAMENTO"]),
                    NomePet = rdr["NOMPET"] as string,
                    Especie = rdr["ESPECIE"] as string,
                    NomeTutor = rdr["NOMTUTOR"] as string,
                    Servico = rdr["SERVICO"] as string,
                    DataAgendamento = rdr["DAT_AGENDAMENTO"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(rdr["DAT_AGENDAMENTO"])
                });
            }
            return list;
        }

        public Agendamento? ObterPorId(int id)
        {
            const string sql = @"
                SELECT ID_AGENDAMENTO, NOMPET, ESPECIE, NOMTUTOR, SERVICO, DAT_AGENDAMENTO
                FROM Agendamento
                WHERE ID_AGENDAMENTO = @id AND DAT_EXCLUSAO IS NULL;";

            using var c = new MySqlConnection(_conn);
            using var cmd = new MySqlCommand(sql, c);
            cmd.Parameters.AddWithValue("@id", id);
            c.Open();
            using var rdr = cmd.ExecuteReader();
            if (!rdr.Read()) return null;
            return new Agendamento
            {
                Id = Convert.ToInt32(rdr["ID_AGENDAMENTO"]),
                NomePet = rdr["NOMPET"] as string,
                Especie = rdr["ESPECIE"] as string,
                NomeTutor = rdr["NOMTUTOR"] as string,
                Servico = rdr["SERVICO"] as string,
                DataAgendamento = rdr["DAT_AGENDAMENTO"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(rdr["DAT_AGENDAMENTO"])
            };
        }

        public void Atualizar(Agendamento model)
        {
            const string sql = @"
                UPDATE Agendamento
                SET NOMPET=@nomePet, ESPECIE=@especie, NOMTUTOR=@nomeTutor, SERVICO=@servico, DAT_AGENDAMENTO=@datAgendamento, DAT_ALTERACAO=NOW()
                WHERE ID_AGENDAMENTO = @id;";

            using var c = new MySqlConnection(_conn);
            using var cmd = new MySqlCommand(sql, c);
            cmd.Parameters.AddWithValue("@id", model.Id);
            cmd.Parameters.AddWithValue("@nomePet", model.NomePet ?? string.Empty);
            cmd.Parameters.AddWithValue("@especie", model.Especie ?? string.Empty);
            cmd.Parameters.AddWithValue("@nomeTutor", model.NomeTutor ?? string.Empty);
            cmd.Parameters.AddWithValue("@servico", model.Servico ?? string.Empty);
            cmd.Parameters.AddWithValue("@datAgendamento", model.DataAgendamento == DateTime.MinValue ? (object)DBNull.Value : model.DataAgendamento);
            c.Open();
            cmd.ExecuteNonQuery();
        }

        public void Deletar(int id)
        {
            const string sql = "UPDATE Agendamento SET DAT_EXCLUSAO = NOW() WHERE ID_AGENDAMENTO = @id;";
            using var c = new MySqlConnection(_conn);
            using var cmd = new MySqlCommand(sql, c);
            cmd.Parameters.AddWithValue("@id", id);
            c.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
