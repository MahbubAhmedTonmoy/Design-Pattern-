using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Behavioral.ChainOfResponsibility
{
    class ChainOfResponsibility
    {
    }
    public class LoanRequest
    {
        public string NationalId { get; set; }
        public bool PreviousRecord { get; set; }
        public int LoanAmount { get; set; }
        public bool Approved { get; set; }
        public ILoanApprover ApprovedBy { get; set; }
    }

    public class LoanExecutive
    {
        public LoanRequest RequestForLoanApprove(string nationaId, bool previousRecordGood, int loanAmount)
        {
            var loanRequest = new LoanRequest
            {
                NationalId = nationaId,
                PreviousRecord = previousRecordGood,
                LoanAmount = loanAmount
            };
            ILoanApprover loanApprover = new BranchManagerApprover("Mr. X");
            loanApprover.Approve(loanRequest);
            return loanRequest;
        }
    }

    public interface ILoanApprover
    {
        public string GetApproverId();
        void Approve(LoanRequest loanRequest);
    }

    public class BranchManagerApprover : ILoanApprover
    {
        private const int MaxLoanApprovedAmount = 1000;
        private readonly ILoanApprover nextLoanApprover = new RegionallManagerApprover("Mr. Y");
        private readonly string managerId = null;
        public BranchManagerApprover(string managerId)
        {
            this.managerId = managerId;
        }
        public void Approve(LoanRequest loanRequest)
        {
            if(loanRequest.LoanAmount <= MaxLoanApprovedAmount)
            {
                loanRequest.Approved = true;
                loanRequest.ApprovedBy = this;
            }
            nextLoanApprover.Approve(loanRequest);
        }

        public string GetApproverId()
        {
            return managerId;
        }
    }
    
    public class RegionallManagerApprover : ILoanApprover
    {
        private const int MaxLoanApprovedAmount = 10000;
        private readonly ILoanApprover nextLoanApprover = new DevisionalManagerApprover("Mr. Z");
        private readonly string managerId = null;
        public RegionallManagerApprover(string managerId)
        {
            this.managerId = managerId;
        }
        public void Approve(LoanRequest loanRequest)
        {
            if (loanRequest.LoanAmount <= MaxLoanApprovedAmount)
            {
                loanRequest.Approved = true;
                loanRequest.ApprovedBy = this;
            }
            nextLoanApprover.Approve(loanRequest);
        }

        public string GetApproverId()
        {
            return managerId;
        }
    }
    public class DevisionalManagerApprover : ILoanApprover
    {
        private const int MaxLoanApprovedAmount = 100000;
        private readonly string managerId = null;
        public DevisionalManagerApprover(string managerId)
        {
            this.managerId = managerId;
        }
        public void Approve(LoanRequest loanRequest)
        {
            if (loanRequest.LoanAmount <= MaxLoanApprovedAmount && loanRequest.PreviousRecord)
            {
                loanRequest.Approved = true;
                loanRequest.ApprovedBy = this;
            }
        }
        public string GetApproverId()
        {
            return managerId;
        }
    }
}
