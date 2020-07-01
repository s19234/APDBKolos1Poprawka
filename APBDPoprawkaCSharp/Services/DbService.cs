using APBDPoprawkaCSharp.Models;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APBDPoprawkaCSharp.Services
{
    public class DbService : IDbService
    {
        private string con = "Data Source=db-mssql;Initial Catalog=s19234;Integrated Security=True";

        
        public TeamMember GetMember(int id)
        {
            TeamMember member = new TeamMember();
            try
            {
                
                using (var connection = new SqlConnection(con))
                {
                    connection.Open();
                    using (var command = new SqlCommand("SELECT * FROM TeamMember Where IdTeamMember = @id", connection))
                    {
                        command.Parameters.AddWithValue("id", id);
                        using (var reader = command.ExecuteReader())
                        {
                            if(!reader.Read())
                            {
                                return null;
                            }

                            member.IdTeamMember = (int)reader["IdTeamMember"];
                            member.FirstName = reader["FirstName"].ToString();
                            member.LastName = reader["LastName"].ToString();
                            member.Email = reader["E-mail"].ToString();
                        }
                    }
                    using(var command = new SqlCommand("SELECT * FROM Task Where IdTeam = @idAssignedTo", connection))
                    {
                        command.Parameters.AddWithValue("idAssignedTo", member.IdTeamMember);
                        using (var reader = command.ExecuteReader())
                        {
                            if(!reader.Read())
                            {
                                return null;
                            }
                            member.TaskIdCreatorNavigation = new List<Models.Task>();
                            member.TaskIdCreatorNavigation.Add(new Models.Task
                            {
                                IdTask = (int)reader["IdTask"],
                                Name = reader["Name"].ToString(),
                                Description = reader["Description"].ToString(),
                                Deadline = (DateTime)reader["Deadline"],
                                IdTeam = (int)reader["IdProject"],
                                IdTaskType = (int)reader["IdTaskType"],
                                IdAssignedTo = (int)reader["IdAsig"],
                                IdCreator = (int)reader["IdCreator"]
                            });
                        }
                    }
                }
            } catch(SqlException)
            {
                return null;
            }
            member.TaskIdCreatorNavigation.OrderBy(o => o.Deadline).ToList();
            return member;
        }

        public String DeleteProject(int id)
        {
            try
            {
                using(var connection = new SqlConnection(con))
                {
                    connection.Open();
                    using (var command = new SqlCommand("DELETE * FROM Task Where IdTeam = @id", connection))
                    {
                        command.Parameters.AddWithValue("id", id);
                        using (var reader = command.ExecuteReader())
                        {
                            if (!reader.Read())
                                return default;
                        }
                    }
                }
            } catch(SqlException)
            {
                return default;
            }
            return "deleted";
        }
    }
}
