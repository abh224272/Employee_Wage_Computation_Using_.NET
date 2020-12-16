﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Wage_Computation
{
    class EmpWageBuiderArray
    {
        const int IS_FULL_TIME = 1;
        const int IS_PART_TIME = 2;

        private int numOfCompany = 0;
        private CompanyEmpWage[] companyEmpWageArray;

        public EmpWageBuiderArray()
        {
            this.companyEmpWageArray = new CompanyEmpWage[5];
        }
        
        public void AddCompanyEmpWage(string company, int empRatePerHour, int numOfWorkingDays, int maxHoursPerMonth)
        {
            companyEmpWageArray[this.numOfCompany] = new CompanyEmpWage(company, empRatePerHour, numOfWorkingDays, maxHoursPerMonth);
            numOfCompany++;
        }

        public void ComputeEmpWage()
        {
            for(int i=0; i<numOfCompany; i++)
            {
                companyEmpWageArray[i].SetTotalEmpWage(this.ComputeEmpWage(this.companyEmpWageArray[i]));
                Console.WriteLine(this.companyEmpWageArray[i].toString());

            }
        }
        public int ComputeEmpWage(CompanyEmpWage companyEmpWage)
        {
            int empHrs = 0, empWage, totalEmpHours = 0, totalWorkingDays = 0;
            Random random = new Random();

            while (totalWorkingDays < companyEmpWage.numOfWorkingDays && totalEmpHours < companyEmpWage.maxHoursPerMonth)
            {
                totalWorkingDays++;
                int empCheck = random.Next(0, 3);
                switch (empCheck)
                {
                    case IS_FULL_TIME:
                        empHrs = 8;
                        totalEmpHours += 8;
                        break;
                    case IS_PART_TIME:
                        empHrs = 4;
                        totalEmpHours += 4;
                        break;
                    default:
                        empHrs = 0;
                        break;
                }
                //empWage = empHrs * empRatePerHour;
                //totalEmpWage += empWage;
                Console.WriteLine("Day= " + totalWorkingDays + "  Wage= " + empHrs);
            }
            return totalEmpHours * companyEmpWage.empRatePerHour;
        }
      
    }
}