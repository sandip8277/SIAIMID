using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using MIDCodeGenerator.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MIDCodeGenerator.Repository
{
    public class MIDCodeGeneratorRepository : IMIDCodeGeneratorRepository
    {
        private IConfiguration Configuration;
        private string _connectionString;
        public MIDCodeGeneratorRepository(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public async Task<MIDCodeDetails> GenerareMIDCodes(string xml)
        {
            _connectionString = this.Configuration.GetConnectionString("ConnectionString");
            string sql = "spGenerateMIDDerivation";
            MIDCodeDetails details = new MIDCodeDetails();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    DataTable dt = new DataTable();
                  
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@xmlInput", xml);
                    connection.Open();
                    using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                    {
                        dt.Load(dataReader);
                        var DriverData = dt.AsEnumerable().ToList().Where(x => x.Field<string>("Component") == "Driver").FirstOrDefault();
                        var Coupling1Data = dt.AsEnumerable().ToList().Where(x => x.Field<string>("Component") == "Coupling1").FirstOrDefault();
                        var Coupling2Data = dt.AsEnumerable().ToList().Where(x => x.Field<string>("Component") == "Coupling2").FirstOrDefault();
                        var IntermediateData = dt.AsEnumerable().ToList().Where(x => x.Field<string>("Component") == "Intermediate").FirstOrDefault();
                        var DrivenData = dt.AsEnumerable().ToList().Where(x => x.Field<string>("Component") == "Driven").FirstOrDefault();

                        if (DriverData != null)
                        {
                            details.Driver = new Codes() { ComponentCode = DriverData[1].ToString(), PickupCode = DriverData[2].ToString(),FaultCode = DriverData[3].ToString() };
                            //details.Driver.ComponentCode = DriverData[1].ToString();
                            //details.Driver.PickupCode = DriverData[2].ToString();
                            //details.Driver.FaultCode = DriverData[3].ToString();
                        }

                        if (Coupling1Data != null)
                        {
                            details.Coupling1 = new Codes() { ComponentCode = Coupling1Data[1].ToString(), PickupCode = Coupling1Data[2].ToString(), FaultCode = Coupling1Data[3].ToString() };

                            //details.Coupling1.ComponentCode = Coupling1Data[1].ToString();
                            //details.Coupling1.PickupCode = Coupling1Data[2].ToString();
                            //details.Coupling1.FaultCode = Coupling1Data[3].ToString();
                        }

                        if (Coupling2Data != null)
                        {
                            details.Coupling2 = new Codes() { ComponentCode = Coupling2Data[1].ToString(), PickupCode = Coupling2Data[2].ToString(), FaultCode = Coupling2Data[3].ToString() };

                            //details.Coupling2.ComponentCode = Coupling2Data[1].ToString();
                            //details.Coupling2.PickupCode = Coupling2Data[2].ToString();
                            //details.Coupling2.FaultCode = Coupling2Data[3].ToString();
                        }

                        if (IntermediateData != null)
                        {
                            details.Intermediate = new Codes() { ComponentCode = IntermediateData[1].ToString(), PickupCode = IntermediateData[2].ToString(), FaultCode = IntermediateData[3].ToString() };

                            //details.Intermediate.ComponentCode = IntermediateData[1].ToString();
                            //details.Intermediate.PickupCode = IntermediateData[2].ToString();
                            //details.Intermediate.FaultCode = IntermediateData[3].ToString();
                        }

                        if (DrivenData != null)
                        {
                            details.Driven = new Codes() { ComponentCode = DrivenData[1].ToString(), PickupCode = DrivenData[2].ToString(), FaultCode = DrivenData[3].ToString() };

                            //details.Driven.ComponentCode = DrivenData[1].ToString();
                            //details.Driven.PickupCode = DrivenData[2].ToString();
                            //details.Driven.FaultCode = DrivenData[3].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
            return details;
        }
    }
}
