using CsvLogParser.Database.Entities;
using CsvLogParser.Model;
using CsvParser.Database;
using Microsoft.EntityFrameworkCore;

namespace CsvLogParser.Services
{
    public class DatabaseServices
    {
        private readonly CsvLogParserDbContext _context;

        public DatabaseServices(CsvLogParserDbContext context)
        {
            _context = context;
        }

        public bool CheckIfExistsInDb(CsvLog log)
        {
            var logList = _context.Logs.Where(dl => dl.DeviceVendor == log.DeviceVendor && dl.DeviceProduct == log.DeviceProduct && dl.DeviceVersion == log.DeviceVersion &&
                                                   dl.SignatureId == log.SignatureId && dl.Severity == log.Severity && dl.Name == log.Name && dl.Start == log.Start &&
                                                   dl.Rt == log.Rt && dl.Msg == log.Msg && dl.Shost == log.Shost && dl.Smac == log.Smac && dl.Dhost == log.Dhost &&
                                                   dl.Dmac == log.Dmac && dl.Suser == log.Suser && dl.SuId == log.SuId && dl.ExternalId == log.ExternalId &&
                                                   dl.Cs1Label == log.Cs1Label && dl.Cs1 == log.Cs1);
            bool existsInDb = false;

            if (logList.Any())
            {
                existsInDb = true;
            }
            return (existsInDb);
        }

        public void SaveToDb(CsvLog log)
        {
            var dbLog = new Log();
            {
                dbLog.DeviceVendor = log.DeviceVendor;
                dbLog.DeviceProduct = log.DeviceProduct;
                dbLog.DeviceVersion = log.DeviceVersion;
                dbLog.SignatureId = log.SignatureId;
                dbLog.Severity = log.Severity;
                dbLog.Name = log.Name;
                dbLog.Start = log.Start;
                dbLog.Rt = log.Rt;
                dbLog.Msg = log.Msg;
                dbLog.Shost = log.Shost;
                dbLog.Smac = log.Smac;
                dbLog.Dhost = log.Dhost;
                dbLog.Dmac = log.Dmac;
                dbLog.Suser = log.Suser;
                dbLog.SuId = log.SuId;
                dbLog.ExternalId = log.ExternalId;
                dbLog.Cs1Label = log.Cs1Label;
                dbLog.Cs1 = log.Cs1;
            }

            _context.Logs.Add(dbLog);
            _context.SaveChanges();
        }

        public List<Log> SearchLogList(string column, string searchTerm)
        {
            string sqlSearchTerm = searchTerm.Replace('*', '%');

            switch (column.ToLower())
            {
                case "devicevendor":
                    return _context.Logs.Where(l => EF.Functions.Like(l.DeviceVendor, sqlSearchTerm)).ToList();

                case "deviceproduct":
                    return _context.Logs.Where(l => EF.Functions.Like(l.DeviceProduct, sqlSearchTerm)).ToList();

                case "deviceversion":
                    return _context.Logs.Where(l => EF.Functions.Like(l.DeviceVersion.ToString(), sqlSearchTerm)).ToList();

                case "signatureid":
                    return _context.Logs.Where(l => EF.Functions.Like(l.SignatureId, sqlSearchTerm)).ToList();

                case "severity":
                    return _context.Logs.Where(l => EF.Functions.Like(l.Severity.ToString(), sqlSearchTerm)).ToList();

                case "name":
                    return _context.Logs.Where(l => EF.Functions.Like(l.Name, sqlSearchTerm)).ToList();

                case "start":
                    return _context.Logs.Where(l => EF.Functions.Like(l.Start.ToString(), sqlSearchTerm)).ToList();

                case "rt":
                    return _context.Logs.Where(l => EF.Functions.Like(l.Rt.ToString(), sqlSearchTerm)).ToList();

                case "msg":
                    return _context.Logs.Where(l => EF.Functions.Like(l.Msg, sqlSearchTerm)).ToList();

                case "shost":
                    return _context.Logs.Where(l => EF.Functions.Like(l.Shost, sqlSearchTerm)).ToList();

                case "smac":
                    return _context.Logs.Where(l => EF.Functions.Like(l.Smac, sqlSearchTerm)).ToList();

                case "dhost":
                    return _context.Logs.Where(l => EF.Functions.Like(l.Dhost, sqlSearchTerm)).ToList();

                case "dmac":
                    return _context.Logs.Where(l => EF.Functions.Like(l.Dmac, sqlSearchTerm)).ToList();

                case "suser":
                    return _context.Logs.Where(l => EF.Functions.Like(l.Suser, sqlSearchTerm)).ToList();

                case "suid":
                    return _context.Logs.Where(l => EF.Functions.Like(l.SuId, sqlSearchTerm)).ToList();

                case "externalid":
                    return _context.Logs.Where(l => EF.Functions.Like(l.ExternalId.ToString(), sqlSearchTerm)).ToList();

                case "cs1label":
                    return _context.Logs.Where(l => EF.Functions.Like(l.Cs1Label, sqlSearchTerm)).ToList();

                case "cs1":
                    return _context.Logs.Where(l => EF.Functions.Like(l.Cs1, sqlSearchTerm)).ToList();

                default:
                    throw new ArgumentException("Invalid column name specified");
            }
        }
    }
}