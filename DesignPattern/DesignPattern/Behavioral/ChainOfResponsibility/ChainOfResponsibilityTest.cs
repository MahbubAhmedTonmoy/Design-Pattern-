using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPattern.Behavioral.ChainOfResponsibility
{
    public class ChainOfResponsibilityTest
    {
        [Fact]
        public void ShouldApproveLoanAmount()
        {
            var loanExecutive = new LoanExecutive();

            LoanRequest loanRequest1 = loanExecutive.RequestForLoanApprove("123", false, 100);
            LoanRequest loanRequest2 = loanExecutive.RequestForLoanApprove("234", true, 100000);

            loanRequest1.Approved.Should().BeTrue();
            loanRequest1.ApprovedBy.GetApproverId().Should().NotBeNullOrEmpty();

            loanRequest2.Approved.Should().BeTrue();
            loanRequest2.ApprovedBy.GetApproverId().Should().NotBeNullOrEmpty();
        }
    }
}
