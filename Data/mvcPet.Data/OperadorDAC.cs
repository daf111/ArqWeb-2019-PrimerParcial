using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using mvcPet.Entities;

namespace mvcPet.Data
{
    public partial class OperadorDAC : DataAccessComponent, IRepository<Operador>
    {
        public Operador Create(Operador entity)
        {

            const string SQL_STATEMENT = "INSERT INTO [Operador] ([Apellido],[Nombre],[Email],[Telefono],[Url],[Edad],[Domicilio]) VALUES (@Apellido,@Nombre,@Email,@Telefono,@Url,@Edad,@Domicilio); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Apellido", DbType.AnsiString, entity.Apellido);
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, entity.Nombre);
                db.AddInParameter(cmd, "@Email", DbType.AnsiString, entity.Email);
                db.AddInParameter(cmd, "@Telefono", DbType.AnsiString, entity.Telefono);
                db.AddInParameter(cmd, "@Url", DbType.AnsiString, entity.Url);
                db.AddInParameter(cmd, "@Edad", DbType.Int32, entity.Edad);
                db.AddInParameter(cmd, "@Domicilio", DbType.AnsiString, entity.Domicilio);
                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return entity;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Operador WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Operador> Read()
        {
            const string SQL_STATEMENT = "SELECT * FROM Operador ";

            List<Operador> result = new List<Operador>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Operador operador = LoadOperador(dr);
                        result.Add(operador);
                    }
                }
            }
            return result;
        }

        public Operador ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT * FROM Operador WHERE Id = @id";

            Operador result = new Operador();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        result = LoadOperador(dr);
                    }
                }
            }
            return result;
        }

        public void Update(Operador entity)
        {
            const string SQL_STATEMENT = "UPDATE [Operador] SET [Apellido] = @Apellido, [Nombre] = @Nombre, [Email] = @Email, [Telefono] = @Telefono, [Url] = @Url, [Edad] = @Edad, [Domicilio] = @Domicilio WHERE Id = @Id";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.AnsiString, entity.Id);
                db.AddInParameter(cmd, "@Apellido", DbType.AnsiString, entity.Apellido);
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, entity.Nombre);
                db.AddInParameter(cmd, "@Email", DbType.AnsiString, entity.Email);
                db.AddInParameter(cmd, "@Telefono", DbType.AnsiString, entity.Telefono);
                db.AddInParameter(cmd, "@Url", DbType.AnsiString, entity.Url);
                db.AddInParameter(cmd, "@Edad", DbType.Int32, entity.Edad);
                db.AddInParameter(cmd, "@Domicilio", DbType.AnsiString, entity.Domicilio);
                db.ExecuteNonQuery(cmd);
            }
        }

        private Operador LoadOperador(IDataReader dr)
        {
            Operador operador = new Operador();

            operador.Id = GetDataValue<int>(dr, "Id");
            operador.Apellido = GetDataValue<string>(dr, "Apellido");
            operador.Nombre = GetDataValue<string>(dr, "Nombre");
            operador.Email = GetDataValue<string>(dr, "Email");
            operador.Telefono = GetDataValue<string>(dr, "Telefono");
            operador.Url = GetDataValue<string>(dr, "Url");
            operador.Edad = GetDataValue<int>(dr, "Edad");
            operador.Domicilio = GetDataValue<string>(dr, "Domicilio");

            return operador;
        }
    }
}

