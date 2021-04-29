using AssetManagementDashboardInsideLogic.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementDashboardInsideLogic.Logic
{
    public class JobCardProcessor
    {
        JobCard jobCard;
        Processor processor = new Processor();
        public JobCardProcessor(JobCard jobCard)
        {
            this.jobCard = jobCard;
        }

        public void CreateJobCard()
        {
            try
            {
                processor.CreateJobCard(jobCard);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<JobCard> GetJobCards()
        {
            List<JobCard> jobCards = new List<JobCard>();
            try
            {
                DataTable dataTable = processor.GetJobCards();
                if (dataTable.Rows.Count>0)
                {
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        JobCard jobCard = new JobCard();
                        jobCard.actiontaken = dr["Actiontaken"].ToString();
                        jobCard.appby = dr["Approvedby"].ToString();
                        jobCard.blockmapno = dr["Blockmapno"].ToString();
                        jobCard.Callid = dr["CallId"].ToString();
                        jobCard.compdate = dr["Completiondate"].ToString();
                        jobCard.contractor = dr["Contractor"].ToString();
                        jobCard.contractornum = dr["Contractornum"].ToString();
                        jobCard.Dateassigned = dr["Dateassigned"].ToString();
                        jobCard.Datereported = dr["Datereported"].ToString();
                        jobCard.fixcond = dr["Fixcond"].ToString();
                        jobCard.fixturetype = dr["Fixturetype"].ToString();
                        jobCard.Informername = dr["Informername"].ToString();
                        jobCard.jobcategory = dr["Jobcategory"].ToString();
                        jobCard.Joblocation = dr["Joblocation"].ToString();
                        jobCard.jobname = dr["Jobname"].ToString();
                        jobCard.material = dr["Material"].ToString();
                        jobCard.Phnnumber = dr["Phnnumber"].ToString();
                        jobCard.prepby = dr["Preparedby"].ToString();
                        jobCard.reasonofdelay = dr["Reasonofdelay"].ToString();
                        jobCard.size = dr["Size"].ToString();
                        jobCard.Source = dr["Source"].ToString();
                        jobCard.storekeepername = dr["Storekeepername"].ToString();
                        jobCard.Timereported = dr["Timereported"].ToString();
                        jobCard.title = dr["Title"].ToString();
                        jobCard.xcordinates = dr["Xcordinates"].ToString();
                        jobCard.ycordinates = dr["Ycordinates"].ToString();
                        jobCard.RecordDate = dr["RecordDate"].ToString();
                        jobCards.Add(jobCard);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return jobCards;
        }
    }
}
