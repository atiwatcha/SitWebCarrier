using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITUtility;
using System.Data.SqlClient;
using System.Data;

namespace SitWebCarrier.Models
{
    public class dataAccess
    {
        public ProcessResult getTruck(out List<Truck> List_Trucks, Truck tru, string connetionString)
        {
            ProcessResult pr = new ProcessResult();
            List_Trucks = new List<Truck>();
            try
            {
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();
                string condition = "";
                if (tru != null)
                {
                    condition += " and vehicle=" + Utility.SQLValueString(tru.vehicle);
                }

                string sql = @"select *
                            from [WebCarrier].[dbo].[Truck]
                            where 1=1 " + condition;
                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List_Trucks = DataConvertor.Truck(dt);
 
                da.Dispose();
                dt.Dispose();
                command.Dispose();
                cnn.Close();
                pr.Successed = true;
            }
            catch (Exception ex)
            {
                pr.ErrorMessage = ex.Message;
                pr.Successed = false;
            }

            return pr;
        }

        public ProcessResult addTruck(Truck t, string connetionString)
        {
            ProcessResult pr = new ProcessResult();
            try
            {
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                string sql = @"INSERT INTO [WebCarrier].[dbo].[Truck]
                               ([vehicle]
                               ,[veh_text]
                               ,[veh_type]
                               ,[veh_status]
                               ,[carrier]
                               ,[veh_nrtus]
                               ,[vol_uom]
                               ,[wgt_uom]
                               ,[class_grp]
                               ,[rfid]
                               ,[cre_date]
                               ,[cre_name]
                               ,[cha_date]
                               ,[cha_name])
                         VALUES
                               (@vehicle
                               ,@veh_text
                               ,@veh_type
                               ,@veh_status
                               ,@carrier
                               ,@veh_nrtus
                               ,@vol_uom
                               ,@wgt_uom
                               ,@class_grp
                               ,@rfid
                               ,@cre_date
                               ,@cre_name
                               ,@cha_date
                               ,@cha_name)";
                SqlCommand command = new SqlCommand(sql, cnn);

                command.Parameters.Add(new SqlParameter("vehicle", t.vehicle ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("veh_text", t.veh_text ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("veh_type", t.veh_type ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("veh_status", t.veh_status ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("carrier", t.carrier ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("veh_nrtus", t.veh_nrtus ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("vol_uom", t.vol_uom ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("wgt_uom", t.wgt_uom ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("class_grp", t.class_grp ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("rfid", t.rfid ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("cre_date", t.cre_date ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("cre_name", t.cre_name ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("cha_date", t.cha_date ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("cha_name", t.cha_name ?? (object)DBNull.Value));
                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows <= 0)
                {
                    // Houston, we have a problem.
                    pr.Successed = false;
                }
                else
                {
                    pr.Successed = true;
                }

                command.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                pr.ErrorMessage = ex.Message;
                pr.Successed = false;
            }

            return pr;
        }

        public ProcessResult editTruck(Truck t, string connetionString)
        {
            ProcessResult pr = new ProcessResult();
            try
            {
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();
                string sql = @"UPDATE [WebCarrier].[dbo].[Truck]
                               SET [veh_text] = @veh_text
                                  ,[veh_type] = @veh_type
                                  ,[veh_status] = @veh_status
                                  ,[carrier] = @carrier
                                  ,[veh_nrtus] = @veh_nrtus
                                  ,[vol_uom] = @vol_uom
                                  ,[wgt_uom] = @wgt_uom
                                  ,[class_grp] = @class_grp
                                  ,[rfid] = @rfid
                                  ,[cre_date] = @cre_date
                                  ,[cre_name] = @cre_name
                                  ,[cha_date] = @cha_date
                                  ,[cha_name] = @cha_name
                             WHERE vehicle =  @vehicle
                            ";
                SqlCommand command = new SqlCommand(sql, cnn);
                command.Parameters.Add(new SqlParameter("vehicle", t.vehicle));
                command.Parameters.Add(new SqlParameter("veh_text", t.veh_text ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("veh_type", t.veh_type ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("veh_status", t.veh_status ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("carrier", t.carrier ?? (object)DBNull.Value)); ;
                command.Parameters.Add(new SqlParameter("veh_nrtus", t.veh_nrtus ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("vol_uom", t.vol_uom ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("wgt_uom", t.wgt_uom ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("class_grp", t.class_grp ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("rfid", t.rfid ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("cre_date", t.cre_date ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("cre_name", t.cre_name ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("cha_date", t.cha_date ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("cha_name", t.cha_name ?? (object)DBNull.Value));

                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows <= 0)
                {
                    // Houston, we have a problem.
                    pr.Successed = false;
                }
                else
                {
                    pr.Successed = true;
                }

                command.Dispose();
                cnn.Close();

            }
            catch (Exception ex)
            {
                pr.ErrorMessage = ex.Message;
                pr.Successed = false;
            }

            return pr;
        }

        public ProcessResult getDriver(out List<Driver> List_Driver, Driver dri, string connetionString)
        {
            ProcessResult pr = new ProcessResult();
            List_Driver = new List<Driver>();
            try
            {
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();
                string condition = "";
                if (dri != null)
                {
                    condition += " and driver_code=" + Utility.SQLValueString(dri.driver_code);
                }

                string sql = @"select *
                            from [WebCarrier].[dbo].[Driver]
                            where 1=1 " + condition;
                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List_Driver = DataConvertor.Driver(dt);
                da.Dispose();
                dt.Dispose();
                command.Dispose();
                cnn.Close();
                pr.Successed = true;
            }
            catch (Exception ex)
            {
                pr.ErrorMessage = ex.Message;
                pr.Successed = false;
            }

            return pr;
        }

        public ProcessResult addDriver(Driver d, string connetionString)
        {
            ProcessResult pr = new ProcessResult();
            try
            {
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                string sql = @"INSERT INTO [WebCarrier].[dbo].[Driver]
                               ([driver_code]
                               ,[pers_code]
                               ,[first_name]
                               ,[last_name]
                               ,[carrier]
                               ,[drv_status]
                               ,[license_type]
                               ,[valid_from]
                               ,[valid_to]
                             
                               ,[rfid])
                         VALUES
                               (@driver_code
                               ,@pers_code
                               ,@first_name
                               ,@last_name
                               ,@carrier
                               ,@drv_status
                               ,@license_type
                               ,@valid_from
                               ,@valid_to
                             
                               ,@rfid)";
                SqlCommand command = new SqlCommand(sql, cnn);
                command.Parameters.Add(new SqlParameter("driver_code", d.driver_code ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("pers_code", d.pers_code ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("first_name", d.first_name ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("last_name", d.last_name ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("carrier", d.carrier ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("drv_status", d.drv_status ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("license_type", d.license_type ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("valid_from", d.valid_from ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("valid_to", d.valid_to ?? (object)DBNull.Value));
               // command.Parameters.Add(new SqlParameter("status", d.status ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("rfid", d.rfid ?? (object)DBNull.Value));

                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows <= 0)
                {
                    // Houston, we have a problem.
                    pr.Successed = false;
                }
                else
                {
                    pr.Successed = true;
                }

                command.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                pr.ErrorMessage = ex.Message;
                pr.Successed = false;
            }

            return pr;
        }

        public ProcessResult editDriver(Driver d, string connetionString)
        {
            ProcessResult pr = new ProcessResult();
            try
            {
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                string sql = @"UPDATE [WebCarrier].[dbo].[Driver]
                               SET [pers_code] = @pers_code
                                  ,[first_name] = @first_name
                                  ,[last_name] = @last_name
                                  ,[carrier] = @carrier
                                  ,[drv_status] = @drv_status
                                  ,[license_type] = @license_type
                                  ,[valid_from] = @valid_from
                                  ,[valid_to] = @valid_to
                                 
                                  ,[rfid] = @rfid
                             WHERE  [driver_code] = @driver_code";
                SqlCommand command = new SqlCommand(sql, cnn);
                command.Parameters.Add(new SqlParameter("driver_code", d.driver_code ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("pers_code", d.pers_code ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("first_name", d.first_name ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("last_name", d.last_name ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("carrier", d.carrier ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("drv_status", d.drv_status ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("license_type", d.license_type ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("valid_from", d.valid_from ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("valid_to", d.valid_to ?? (object)DBNull.Value));
               // command.Parameters.Add(new SqlParameter("status", d.status ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("rfid", d.rfid ?? (object)DBNull.Value));

                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows <= 0)
                {
                    // Houston, we have a problem.
                    pr.Successed = false;
                }
                else
                {
                    pr.Successed = true;
                }

                command.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                pr.ErrorMessage = ex.Message;
                pr.Successed = false;
            }

            return pr;
        }

        public ProcessResult getUsers(out List<Employee> List_Users, Employee users, string connetionString)
        {
            ProcessResult pr = new ProcessResult();
            List_Users = new List<Employee>();
            try
            {
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();
                string condition = "";
                if (users != null)
                {
                    if (users.userid.IsNotNullOrEmpty())
                    {
                        condition += " and userid=" + Utility.SQLValueString(users.userid);
                    }
                    if (users.password.IsNotNullOrEmpty())
                    {
                        condition += " and password=" + Utility.SQLValueString(users.password);
                    }
                    if (users.carrier.IsNotNullOrEmpty())
                    {
                        condition += " and carrier=" + Utility.SQLValueString(users.carrier);
                    }
                    if (users.authorized.IsNotNullOrEmpty())
                    {
                        condition += " and authorized=" + Utility.SQLValueString(users.authorized);
                    }
                }
                string sql = @"select *
                                from [WebCarrier].[dbo].[Users]
                                where 1=1 " + condition;
                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                da.Fill(dt);
                List_Users = DataConvertor.Employee(dt);

                da.Dispose();
                dt.Dispose();
                command.Dispose();
                cnn.Close();
                pr.Successed = true;
            }
            catch (Exception ex)
            {
                pr.ErrorMessage = ex.Message;
                pr.Successed = false;
            }

            return pr;
        }

        public ProcessResult addUsers(Employee u, string connetionString)
        {
            ProcessResult pr = new ProcessResult();
            try
            {
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                string sql = @"INSERT INTO [WebCarrier].[dbo].[Users]
                                   ([userid]
                                   ,[password]
                                   ,[first_name]
                                   ,[last_name]
                                   ,[carrier]
                                   ,[authorized])
                             VALUES
                                   (@userid
                                   ,@password
                                   ,@first_name
                                   ,@last_name
                                   ,@carrier
                                   ,@authorized)";
                SqlCommand command = new SqlCommand(sql, cnn);
                command.Parameters.Add(new SqlParameter("userid", u.userid ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("password", u.password ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("first_name", u.first_name ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("last_name", u.last_name ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("carrier", u.carrier ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("authorized", u.authorized ?? (object)DBNull.Value));

                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows <= 0)
                {
                    // Houston, we have a problem.
                    pr.Successed = false;
                }
                else
                {
                    pr.Successed = true;
                }

                command.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                pr.ErrorMessage = ex.Message;
                pr.Successed = false;
            }

            return pr;
        }

        public ProcessResult editUsers(Employee u, string connetionString)
        {
            ProcessResult pr = new ProcessResult();
            try
            {
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                string sql = @"UPDATE [WebCarrier].[dbo].[Users]
                                   SET [password] = @password
                                      ,[first_name] = @first_name
                                      ,[last_name] = @last_name
                                      ,[carrier] = @carrier
                                      ,[authorized] = @authorized
                                 WHERE [userid] = @userid";
                SqlCommand command = new SqlCommand(sql, cnn);
                command.Parameters.Add(new SqlParameter("userid", u.userid ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("password", u.password ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("first_name", u.first_name ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("last_name", u.last_name ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("carrier", u.carrier ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("authorized", u.authorized ?? (object)DBNull.Value));

                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows <= 0)
                {
                    // Houston, we have a problem.
                    pr.Successed = false;
                }
                else
                {
                    pr.Successed = true;
                }

                command.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                pr.ErrorMessage = ex.Message;
                pr.Successed = false;
            }

            return pr;
        }

        public ProcessResult getCarrier(out List<Carriers> List_Carriers, Carriers ca, string connetionString)
        {
            ProcessResult pr = new ProcessResult();
            List_Carriers = new List<Carriers>();
            try
            {
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();
                string condition = "";
                if (ca != null)
                {
                    condition += " and carrier=" + Utility.SQLValueString(ca.carrier);
                }
                string sql = @"select *
                                from [WebCarrier].[dbo].[Carrier]
                                where 1=1 " + condition;
                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List_Carriers = DataConvertor.Carriers(dt);
                da.Dispose();
                dt.Dispose();
                command.Dispose();
                cnn.Close();

                pr.Successed = true;
            }
            catch (Exception ex)
            {
                pr.ErrorMessage = ex.Message;
                pr.Successed = false;
            }

            return pr;
        }


        public ProcessResult addCarrier(Carriers c, string connetionString)
        {
            ProcessResult pr = new ProcessResult();
            try
            {
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                string sql = @"INSERT INTO [WebCarrier].[dbo].[Carrier]
                                   ([carrier]
                                   ,[name])
                             VALUES
                                   (@carrier
                                   ,@name)";
                SqlCommand command = new SqlCommand(sql, cnn);
                command.Parameters.Add(new SqlParameter("carrier", c.carrier ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("name", c.name ?? (object)DBNull.Value));

                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows <= 0)
                {
                    // Houston, we have a problem.
                    pr.Successed = false;
                }
                else
                {
                    pr.Successed = true;
                }

                command.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                pr.ErrorMessage = ex.Message;
                pr.Successed = false;
            }

            return pr;
        }

        public ProcessResult editCarrier(Carriers c, string connetionString)
        {
            ProcessResult pr = new ProcessResult();
            try
            {
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                string sql = @"UPDATE [WebCarrier].[dbo].[Carrier]
                               SET [name] = @name
                             WHERE [carrier] = @carrier";
                SqlCommand command = new SqlCommand(sql, cnn);
                command.Parameters.Add(new SqlParameter("carrier", c.carrier ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("name", c.name ?? (object)DBNull.Value));

                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows <= 0)
                {
                    // Houston, we have a problem.
                    pr.Successed = false;
                }
                else
                {
                    pr.Successed = true;
                }

                command.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                pr.ErrorMessage = ex.Message;
                pr.Successed = false;
            }

            return pr;
        }

        public ProcessResult getsap_document(out List<sap_document> List_sap_document, sap_document sa, string connetionString)
        {
            ProcessResult pr = new ProcessResult();
            List_sap_document = new List<sap_document>();
            try
            {
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();
                string condition = "";
                if (sa != null)
                {
                    condition += " and sap_shipment=" + Utility.SQLValueString(sa.sap_shipment);
                }
                string sql = @"SELECT *
                                FROM WebCarrier.dbo.sap_document
                                where 1=1 " + condition;
                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List_sap_document = DataConvertor.sap_document(dt);

                da.Dispose();
                dt.Dispose();
                command.Dispose();
                cnn.Close();
                pr.Successed = true;
            }
            catch (Exception ex)
            {
                pr.ErrorMessage = ex.Message;
                pr.Successed = false;
            }

            return pr;
        }

        public ProcessResult getsap_document_assig(out List<sap_document> List_sap_document, sap_document sa, string connetionString)
        {
            ProcessResult pr = new ProcessResult();
            List_sap_document = new List<sap_document>();
            try
            {
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();
                string condition = "";
                if (sa != null)
                {
                    condition += " and d.sap_shipment=" + Utility.SQLValueString(sa.sap_shipment);
                }
                string sql = @"SELECT *
                                 FROM WebCarrier.dbo.sap_document
                                 where (Carriercode is null or Carriercode = '')" + condition;
                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List_sap_document = DataConvertor.sap_document(dt);

                da.Dispose();
                dt.Dispose();
                command.Dispose();
                cnn.Close();
                pr.Successed = true;
            }
            catch (Exception ex)
            {
                pr.ErrorMessage = ex.Message;
                pr.Successed = false;
            }

            return pr;
        }

        public ProcessResult getsap_document_confirm(out List<sap_document> List_sap_document, sap_document sa, string connetionString)
        {
            ProcessResult pr = new ProcessResult();
            List_sap_document = new List<sap_document>();
            try
            {
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();
                string condition = "";
                if (sa != null)
                {
                    condition += " and d.sap_shipment=" + Utility.SQLValueString(sa.sap_shipment);
                }
                string sql = @"SELECT *
                                 FROM WebCarrier.dbo.sap_document
                                 where  (Susr1 is null or Susr1 = '')
                                        and (Carriercode is not null and Carriercode !='')
                                        and (Drivername is not null and Drivername !='')
                                        and (Trailernumber is not null and Trailernumber !='')
                                " + condition;
                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List_sap_document = DataConvertor.sap_document(dt);

                da.Dispose();
                dt.Dispose();
                command.Dispose();
                cnn.Close();
                pr.Successed = true;
            }
            catch (Exception ex)
            {
                pr.ErrorMessage = ex.Message;
                pr.Successed = false;
            }

            return pr;
        }

        public ProcessResult getsend_carrier_assig(out List<sap_document> List_sap_document, sap_document sa, string connetionString)
        {
            ProcessResult pr = new ProcessResult();
            List_sap_document = new List<sap_document>();
            try
            {
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();
                string condition = "";
                if (sa != null)
                {
                    condition += " and Carriercode=" + Utility.SQLValueString(sa.Carriercode);
                }
                string sql = @"SELECT *
                                 FROM WebCarrier.dbo.sap_document
                                 where (Drivername is null or Drivername = '')" + condition;
                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List_sap_document = DataConvertor.sap_document(dt);

                da.Dispose();
                dt.Dispose();
                command.Dispose();
                cnn.Close();
                pr.Successed = true;
            }
            catch (Exception ex)
            {
                pr.ErrorMessage = ex.Message;
                pr.Successed = false;
            }

            return pr;
        }

        public ProcessResult addsap_document(sap_document s, string connetionString)
        {
            ProcessResult pr = new ProcessResult();
            try
            {
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                string sql = @"INSERT INTO [WebCarrier].[dbo].[sap_document]
                               ([sap_shipment]
                               ,[storerkey]
                               ,[sap_do]
                               ,[type_do]
                               ,[externalloadid]
                               ,[qty]
                               ,[c_shopto]
                               ,[c_billto]
                               ,[ordergroup]
                               ,[b_state]
                               ,[b_zip]
                               ,[containerqty]
                               ,[delivertplace]
                               ,[dischareplace]
                               ,[notes]
                               ,[notes2]
                               ,[appointmenttime]

                               ,[Carriercode]
                               ,[Susr1]
                               ,[Susr2]
                               ,[Susr3]
                               ,[Susr4]
                               ,[Susr5]
                               ,[Transportationmode]
                               ,[Transportationservice]
                               ,[Door]
                               ,[Itemlineno]
                               ,[Orderdate]
                               ,[LoadingDate]
                               ,[ArrivalDate]
                               ,[Drivername]
                               ,[Trailernumber]
                               ,[Packnotes]
                               ,[DO_Grade]
                               ,[DO_ItemNote]
                               ,[DO_PackingR]
                               ,[DO_FumigationR])
                         VALUES
                               (@sap_shipment
                               ,@storerkey
                               ,@sap_do
                               ,@type_do
                               ,@externalloadid
                               ,@qty
                               ,@c_shopto
                               ,@c_billto
                               ,@ordergroup
                               ,@b_state
                               ,@b_zip
                               ,@containerqty
                               ,@delivertplace                              
                               ,@dischareplace
                               ,@notes                               
                               ,@notes2                               
                               ,@appointmenttime

                               ,@Carriercode
                               ,@Sap_shipment
                               ,@Susr1
                               ,@Susr2
                               ,@Susr3
                               ,@Susr4
                               ,@Susr5
                               ,@Transportationmode
                               ,@Transportationservice
                               ,@Door
                               ,@Itemlineno
                               ,@Orderdate
                               ,@LoadingDate
                               ,@ArrivalDate
                               ,@Drivername
                               ,@Trailernumber
                               ,@Packnotes
                               ,@DO_Grade
                               ,@DO_ItemNote
                               ,@DO_PackingR
                               ,@DO_FumigationR)";
                SqlCommand command = new SqlCommand(sql, cnn);

                command.Parameters.Add(new SqlParameter("sap_shipment", s.sap_shipment ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("storerkey", s.storerkey ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("sap_do", s.sap_do ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("type_do", s.type_do ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("externalloadid", s.externalloadid ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("qty", s.qty ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("c_shopto", s.c_shopto ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("c_billto", s.c_billto ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("ordergroup", s.ordergroup ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("b_state", s.b_state ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("b_zip", s.b_zip ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("containerqty", s.containerqty ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("delivertplace", s.delivertplace ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("dischareplace", s.dischareplace ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("notes", s.notes ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("notes2", s.notes2 ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("appointmenttime", s.appointmenttime ?? (object)DBNull.Value));

                command.Parameters.Add(new SqlParameter("Carriercode", s.Carriercode ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Susr1", s.Susr1 ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Susr2", s.Susr2 ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Susr3", s.Susr3 ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Susr4", s.Susr4 ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Susr5", s.Susr5 ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Transportationmode", s.Transportationmode ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Transportationservice", s.Transportationservice ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Door", s.Door ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Itemlineno", s.Itemlineno ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Orderdate", s.Orderdate ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("LoadingDate", s.LoadingDate ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("ArrivalDate", s.ArrivalDate ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Drivername", s.Drivername ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Trailernumber", s.Trailernumber ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Packnotes", s.Packnotes ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("DO_Grade", s.DO_Grade ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("DO_ItemNote", s.DO_ItemNote ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("DO_PackingR", s.DO_PackingR ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("DO_FumigationR", s.DO_FumigationR ?? (object)DBNull.Value));
                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows <= 0)
                {
                    // Houston, we have a problem.
                    pr.Successed = false;
                }
                else
                {
                    pr.Successed = true;
                }

                command.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                pr.ErrorMessage = ex.Message;
                pr.Successed = false;
            }

            return pr;
        }

        public ProcessResult editsap_document(sap_document s, string connetionString)
        {
            ProcessResult pr = new ProcessResult();
            try
            {
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                string sql = @"UPDATE [WebCarrier].[dbo].[sap_document]
                               SET [storerkey] = @storerkey
                                  ,[sap_do] = @sap_do
                                  ,[type_do] = @type_do
                                  ,[externalloadid] = @externalloadid
                                  ,[qty] = @qty
                                  ,[c_shopto] = @c_shopto
                                  ,[c_billto] = @c_billto
                                  ,[ordergroup] = @ordergroup
                                  ,[b_state] = @b_state
                                  ,[b_zip] = @b_zip
                                  ,[containerqty] = @containerqty
                                  ,[delivertplace] = @delivertplace
                                  ,[dischareplace] = @dischareplace
                                  ,[notes] = @notes
                                  ,[notes2] = @notes2
                                  ,[appointmenttime] = @appointmenttime

                                      ,[Carriercode] = @Carriercode
                                      ,[Susr1] = @Susr1
                                      ,[Susr2] = @Susr2
                                      ,[Susr3] = @Susr3
                                      ,[Susr4] = @Susr4
                                      ,[Susr5] = @Susr5
                                      ,[Transportationmode] = @Transportationmode
                                      ,[Transportationservice] = @Transportationservice
                                      ,[Door] = @Door
                                      ,[Itemlineno] = @Itemlineno
                                      ,[Orderdate] = @Orderdate
                                      ,[LoadingDate] = @LoadingDate
                                      ,[ArrivalDate] = @ArrivalDate
                                      ,[Drivername] = @Drivername
                                      ,[Trailernumber] = @Trailernumber
                                      ,[Packnotes] = @Packnotes
                                      ,[DO_Grade] = @DO_Grade
                                      ,[DO_ItemNote] = @DO_ItemNote
                                      ,[DO_PackingR] = @DO_PackingR
                                      ,[DO_FumigationR] = @DO_FumigationR

                             WHERE [sap_shipment] = @sap_shipment";
                SqlCommand command = new SqlCommand(sql, cnn);
                command.Parameters.Add(new SqlParameter("sap_shipment", s.sap_shipment ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("storerkey", s.storerkey ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("sap_do", s.sap_do ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("type_do", s.type_do ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("externalloadid", s.externalloadid ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("qty", s.qty ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("c_shopto", s.c_shopto ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("c_billto", s.c_billto ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("ordergroup", s.ordergroup ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("b_state", s.b_state ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("b_zip", s.b_zip ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("containerqty", s.containerqty ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("delivertplace", s.delivertplace ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("dischareplace", s.dischareplace ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("notes", s.notes ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("notes2", s.notes2 ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("appointmenttime", s.appointmenttime ?? (object)DBNull.Value));

                command.Parameters.Add(new SqlParameter("Carriercode", s.Carriercode ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Susr1", s.Susr1 ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Susr2", s.Susr2 ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Susr3", s.Susr3 ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Susr4", s.Susr4 ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Susr5", s.Susr5 ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Transportationmode", s.Transportationmode ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Transportationservice", s.Transportationservice ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Door", s.Door ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Itemlineno", s.Itemlineno ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Orderdate", s.Orderdate ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("LoadingDate", s.LoadingDate ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("ArrivalDate", s.ArrivalDate ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Drivername", s.Drivername ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Trailernumber", s.Trailernumber ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Packnotes", s.Packnotes ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("DO_Grade", s.DO_Grade ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("DO_ItemNote", s.DO_ItemNote ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("DO_PackingR", s.DO_PackingR ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("DO_FumigationR", s.DO_FumigationR ?? (object)DBNull.Value));
                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows <= 0)
                {
                    // Houston, we have a problem.
                    pr.Successed = false;
                }
                else
                {
                    pr.Successed = true;
                }

                command.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                pr.ErrorMessage = ex.Message;
                pr.Successed = false;
            }

            return pr;
        }

        public ProcessResult getsend_carrier(out List<send_carrier> List_send_carrier, send_carrier sa, string connetionString)
        {
            ProcessResult pr = new ProcessResult();
            List_send_carrier = new List<send_carrier>();
            try
            {
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();
                string condition = "";
                if (sa != null)
                {
                    condition += " and id =" + Utility.SQLValueString(sa.id);
                }
                string sql = @"SELECT id
                                  ,Carriercode
                                  ,Sap_shipment
                                  ,Susr1
                                  ,Susr2
                                  ,Susr3
                                  ,Susr4
                                  ,Susr5
                                  ,Transportationmode
                                  ,Transportationservice
                                  ,Door
                                  ,Itemlineno
                                  ,Orderdate
                                  ,LoadingDate
                                  ,ArrivalDate
                                  ,Drivername
                                  ,Trailernumber
                                  ,Packnotes
                                  ,DO_Grade
                                  ,DO_ItemNote
                                  ,DO_PackingR
                                  ,DO_FumigationR
                                FROM [WebCarrier].[dbo].[send_carrier]
                                where 1=1 " + condition;
                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    send_carrier s = new send_carrier();
                    s.id = (int)dr["sap_shipment"];
                    s.Carriercode = dr["sap_shipment"].ToString();
                    s.Sap_shipment = dr["sap_shipment"].ToString();
                    s.Susr1 = dr["sap_shipment"].ToString();
                    s.Susr2 = dr["sap_shipment"].ToString();
                    s.Susr3 = dr["sap_shipment"].ToString();
                    s.Susr4 = dr["sap_shipment"].ToString();
                    s.Susr5 = dr["sap_shipment"].ToString();
                    s.Transportationmode = (DateTime?)dr["sap_shipment"];
                    s.Transportationservice = dr["sap_shipment"].ToString();
                    s.Door = dr["sap_shipment"].ToString();
                    s.Itemlineno = (DateTime?)dr["sap_shipment"];
                    s.Orderdate = (DateTime?)dr["sap_shipment"];
                    s.LoadingDate = (DateTime?)dr["sap_shipment"];
                    s.ArrivalDate = (DateTime?)dr["sap_shipment"];
                    s.Drivername = dr["sap_shipment"].ToString();
                    s.Trailernumber = dr["sap_shipment"].ToString();
                    s.Packnotes = dr["sap_shipment"].ToString();
                    s.DO_Grade = dr["sap_shipment"].ToString();
                    s.DO_ItemNote = dr["sap_shipment"].ToString();
                    s.DO_PackingR = dr["sap_shipment"].ToString();
                    s.DO_FumigationR = dr["sap_shipment"].ToString();

                    List_send_carrier.Add(s);
                }
                da.Dispose();
                dt.Dispose();
                command.Dispose();
                cnn.Close();
                pr.Successed = true;
            }
            catch (Exception ex)
            {
                pr.ErrorMessage = ex.Message;
                pr.Successed = false;
            }

            return pr;
        }


        
        public ProcessResult addsend_carrier(send_carrier s, string connetionString)
        {
            ProcessResult pr = new ProcessResult();
            try
            {
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                string sql = @"INSERT INTO [WebCarrier].[dbo].[send_carrier]
                               ([Carriercode]
                               ,[Sap_shipment]
                               ,[Susr1]
                               ,[Susr2]
                               ,[Susr3]
                               ,[Susr4]
                               ,[Susr5]
                               ,[Transportationmode]
                               ,[Transportationservice]
                               ,[Door]
                               ,[Itemlineno]
                               ,[Orderdate]
                               ,[LoadingDate]
                               ,[ArrivalDate]
                               ,[Drivername]
                               ,[Trailernumber]
                               ,[Packnotes]
                               ,[DO_Grade]
                               ,[DO_ItemNote]
                               ,[DO_PackingR]
                               ,[DO_FumigationR])
                         VALUES
                               (@Carriercode
                               ,@Sap_shipment
                               ,@Susr1
                               ,@Susr2
                               ,@Susr3
                               ,@Susr4
                               ,@Susr5
                               ,@Transportationmode
                               ,@Transportationservice
                               ,@Door
                               ,@Itemlineno
                               ,@Orderdate
                               ,@LoadingDate
                               ,@ArrivalDate
                               ,@Drivername
                               ,@Trailernumber
                               ,@Packnotes
                               ,@DO_Grade
                               ,@DO_ItemNote
                               ,@DO_PackingR
                               ,@DO_FumigationR)";
                SqlCommand command = new SqlCommand(sql, cnn);

                command.Parameters.Add(new SqlParameter("Carriercode", s.Carriercode ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Sap_shipment", s.Sap_shipment ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Susr1", s.Susr1 ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Susr2", s.Susr2 ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Susr3", s.Susr3 ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Susr4", s.Susr4 ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Susr5", s.Susr5 ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Transportationmode", s.Transportationmode ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Transportationservice", s.Transportationservice ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Door", s.Door ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Itemlineno", s.Itemlineno ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Orderdate", s.Orderdate ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("LoadingDate", s.LoadingDate ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("ArrivalDate", s.ArrivalDate ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Drivername", s.Drivername ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Trailernumber", s.Trailernumber ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Packnotes", s.Packnotes ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("DO_Grade", s.DO_Grade ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("DO_ItemNote", s.DO_ItemNote ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("DO_PackingR", s.DO_PackingR ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("DO_FumigationR", s.DO_FumigationR ?? (object)DBNull.Value));
                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows <= 0)
                {
                    // Houston, we have a problem.
                    pr.Successed = false;
                }
                else
                {
                    pr.Successed = true;
                }

                command.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                pr.ErrorMessage = ex.Message;
                pr.Successed = false;
            }

            return pr;
        }

        public ProcessResult editsend_carrier(send_carrier s, string connetionString)
        {
            ProcessResult pr = new ProcessResult();
            try
            {
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                string sql = @"UPDATE [WebCarrier].[dbo].[send_carrier]
                                   SET [Carriercode] = @Carriercode
                                      ,[Sap_shipment] = @Sap_shipment
                                      ,[Susr1] = @Susr1
                                      ,[Susr2] = @Susr2
                                      ,[Susr3] = @Susr3
                                      ,[Susr4] = @Susr4
                                      ,[Susr5] = @Susr5
                                      ,[Transportationmode] = @Transportationmode
                                      ,[Transportationservice] = @Transportationservice
                                      ,[Door] = @Door
                                      ,[Itemlineno] = @Itemlineno
                                      ,[Orderdate] = @Orderdate
                                      ,[LoadingDate] = @LoadingDate
                                      ,[ArrivalDate] = @ArrivalDate
                                      ,[Drivername] = @Drivername
                                      ,[Trailernumber] = @Trailernumber
                                      ,[Packnotes] = @Packnotes
                                      ,[DO_Grade] = @DO_Grade
                                      ,[DO_ItemNote] = @DO_ItemNote
                                      ,[DO_PackingR] = @DO_PackingR
                                      ,[DO_FumigationR] = @DO_FumigationR
                                 WHERE [id] = @id";
                SqlCommand command = new SqlCommand(sql, cnn);
                command.Parameters.Add(new SqlParameter("Carriercode", s.Carriercode ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Sap_shipment", s.Sap_shipment ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Susr1", s.Susr1 ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Susr2", s.Susr2 ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Susr3", s.Susr3 ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Susr4", s.Susr4 ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Susr5", s.Susr5 ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Transportationmode", s.Transportationmode ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Transportationservice", s.Transportationservice ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Door", s.Door ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Itemlineno", s.Itemlineno ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Orderdate", s.Orderdate ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("LoadingDate", s.LoadingDate ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("ArrivalDate", s.ArrivalDate ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Drivername", s.Drivername ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Trailernumber", s.Trailernumber ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("Packnotes", s.Packnotes ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("DO_Grade", s.DO_Grade ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("DO_ItemNote", s.DO_ItemNote ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("DO_PackingR", s.DO_PackingR ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("DO_FumigationR", s.DO_FumigationR ?? (object)DBNull.Value));

                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows <= 0)
                {
                    // Houston, we have a problem.
                    pr.Successed = false;
                }
                else
                {
                    pr.Successed = true;
                }

                command.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                pr.ErrorMessage = ex.Message;
                pr.Successed = false;
            }

            return pr;
        }

        private List<sap_document> ConvertDat_asap_document(DataTable dt)
        {
            List<sap_document> List_sap_document = new List<sap_document>();
            foreach (DataRow dr in dt.Rows)
            {
                sap_document s = new sap_document();
                s.sap_shipment = dr["sap_shipment"].ToString();
                s.storerkey = dr["storerkey"].ToString();
                s.sap_do = dr["sap_do"].ToString();
                s.type_do = dr["type_do"].ToString();
                s.externalloadid = dr["externalloadid"].ToString();
                s.qty = dr["qty"].ToString();
                s.c_shopto = dr["c_shopto"].ToString();
                s.c_billto = dr["c_billto"].ToString();
                s.ordergroup = dr["ordergroup"].ToString();
                s.b_state = dr["b_state"].ToString();
                s.b_zip = dr["b_zip"].ToString();
                s.containerqty = dr["containerqty"].ToString();
                s.delivertplace = dr["delivertplace"].ToString();
                s.dischareplace = dr["dischareplace"].ToString();
                s.notes = dr["notes"].ToString();
                s.notes2 = dr["notes2"].ToString();
                //s.appointmenttime = (DateTime?)dr["appointmenttime"];
                if (dr["appointmenttime"] != DBNull.Value)
                {
                    s.appointmenttime = (DateTime?)dr["appointmenttime"];
                }
                s.appointmenttime_ = dr["appointmenttime"].ToString(); ;

                s.Carriercode = dr["Carriercode"].ToString();

                s.Susr1 = dr["Susr1"].ToString();
                s.Susr2 = dr["Susr2"].ToString();
                s.Susr3 = dr["Susr3"].ToString();
                s.Susr4 = dr["Susr4"].ToString();
                s.Susr5 = dr["Susr5"].ToString();

                s.Transportationservice = dr["Transportationservice"].ToString();
                s.Door = dr["Door"].ToString();

                //s.Transportationmode = (DateTime?)dr["sap_shipment"];
                //s.Itemlineno = (DateTime?)dr["sap_shipment"];
                //s.Orderdate = (DateTime?)dr["sap_shipment"];
                //s.LoadingDate = (DateTime?)dr["sap_shipment"];
                //s.ArrivalDate = (DateTime?)dr["sap_shipment"];
                if (dr["Transportationmode"] != DBNull.Value)
                {
                    s.Transportationmode = (DateTime?)dr["Transportationmode"];
                }
                if (dr["Itemlineno"] != DBNull.Value)
                {
                    s.Itemlineno = (DateTime?)dr["Itemlineno"];
                }
                if (dr["Orderdate"] != DBNull.Value)
                {
                    s.Orderdate = (DateTime?)dr["Orderdate"];
                }
                if (dr["LoadingDate"] != DBNull.Value)
                {
                    s.LoadingDate = (DateTime?)dr["LoadingDate"];
                }
                if (dr["ArrivalDate"] != DBNull.Value)
                {
                    s.ArrivalDate = (DateTime?)dr["ArrivalDate"];
                }

                s.Drivername = dr["Drivername"].ToString();
                s.Trailernumber = dr["Trailernumber"].ToString();
                s.Packnotes = dr["Packnotes"].ToString();
                s.DO_Grade = dr["DO_Grade"].ToString();
                s.DO_ItemNote = dr["DO_ItemNote"].ToString();
                s.DO_PackingR = dr["DO_PackingR"].ToString();
                s.sap_shipment = dr["sap_shipment"].ToString();

                List_sap_document.Add(s);
            }

            return List_sap_document;
        }

        ////รับงาน monitor งานที่คนยังไม่มารับของ

        public ProcessResult getsap_document_additem(out List<sap_document> List_sap_document, sap_document sa, string connetionString)
        {
            ProcessResult pr = new ProcessResult();
            List_sap_document = new List<sap_document>();
            try
            {
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();
                string condition = "";
                if (sa != null)
                {
                    condition += " and d.sap_shipment=" + Utility.SQLValueString(sa.sap_shipment);
                }
                string sql = @"SELECT *
                                 FROM WebCarrier.dbo.sap_document
                                 where Susr1 = '1' and  (Susr2 is null or Susr2 = '')" + condition;
                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                //List_sap_document = ConvertDat_asap_document(dt);
                List_sap_document = DataConvertor.sap_document(dt);

                da.Dispose();
                dt.Dispose();
                command.Dispose();
                cnn.Close();
                pr.Successed = true;
            }
            catch (Exception ex)
            {
                pr.ErrorMessage = ex.Message;
                pr.Successed = false;
            }

            return pr;
        }

        public ProcessResult getRFID(out List<RFID_tmp> List_RFID_tmp, RFID_tmp sa, string connetionString)
        {
            ProcessResult pr = new ProcessResult();
            List_RFID_tmp = new List<RFID_tmp>();
            try
            {
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();
                string condition = "";
                if (sa != null)
                {
                    condition += " and d.sap_shipment=" + Utility.SQLValueString(sa.sap_shipment);
                }
                string sql = @"SELECT *
                                 FROM WebCarrier.dbo.RFID_tmp
                                 where status = 'Y' " + condition;
                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                //List_sap_document = ConvertDat_asap_document(dt);
                List_RFID_tmp = DataConvertor.RFID_tmp(dt);

                da.Dispose();
                dt.Dispose();
                command.Dispose();
                cnn.Close();
                pr.Successed = true;
            }
            catch (Exception ex)
            {
                pr.ErrorMessage = ex.Message;
                pr.Successed = false;
            }

            return pr;
        }

        public ProcessResult deleteRFID(RFID_tmp r, string connetionString)
        {
            ProcessResult pr = new ProcessResult();
            try
            {
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                string sql = @"delete [WebCarrier].[dbo].[RFID_tmp]
                                 WHERE [sap_shipment] = @sap_shipment";
                SqlCommand command = new SqlCommand(sql, cnn);
                command.Parameters.Add(new SqlParameter("sap_shipment", r.sap_shipment ?? (object)DBNull.Value));

                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows <= 0)
                {
                    // Houston, we have a problem.
                    pr.Successed = false;
                }
                else
                {
                    pr.Successed = true;
                }

                command.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                pr.ErrorMessage = ex.Message;
                pr.Successed = false;
            }

            return pr;
        }

        public ProcessResult getsap_document_confirmRFID(out List<sap_document> List_sap_document, sap_document sa, string connetionString)
        {
            ProcessResult pr = new ProcessResult();
            List_sap_document = new List<sap_document>();
            try
            {
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();
                string condition = "";
                if (sa != null)
                {
                    condition += " and d.sap_shipment=" + Utility.SQLValueString(sa.sap_shipment);
                }
                string sql = @"SELECT distinct d.*
                                 FROM WebCarrier.dbo.sap_document d
                                    left join WebCarrier.dbo.RFID_tmp r on d.sap_shipment=r.sap_shipment
                                 where r.status = 'Y'" + condition;
                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                //List_sap_document = ConvertDat_asap_document(dt);
                List_sap_document = DataConvertor.sap_document(dt);

                da.Dispose();
                dt.Dispose();
                command.Dispose();
                cnn.Close();
                pr.Successed = true;
            }
            catch (Exception ex)
            {
                pr.ErrorMessage = ex.Message;
                pr.Successed = false;
            }

            return pr;
        }
    }
}