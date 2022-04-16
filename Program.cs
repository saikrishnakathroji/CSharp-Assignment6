/*1)	In Assignment 3 of previous session, print the details of Managers with the help of delegate
EmployeeDelegate. (UniCast Delegate)*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6
{
    public delegate double ManagerSal(double sal);
    public class Manager
    {
        public double Petrol;
        public double Food;
        public double Others;
        public double sal;
        public double Gross;
        public double Netsal;
        public double Pf;
        public double TDS;

        public double ManagerSalary(double sal)
        {
            Console.WriteLine(sal);
            return sal;
        }
        public double FoodDetails(double sal)
        {
            Food = sal * 0.13;
            Console.WriteLine(Food);
            return Food;

        }
        public double PetrolDetails(double sal)
        {
            Petrol = sal * 0.08;
            Console.WriteLine(Petrol);
            return Petrol;
        }
        public double OtherDetails(double sal)
        {
            Others = sal * 0.03;
            Console.WriteLine(Others);
            return Others;

        }
        public double GrossSalaryDetails(double sal)
        {
            Gross = sal + Food + Petrol + Others;
            Console.WriteLine(Gross);
            return Gross;

        }
        public double CalculateSalaryDetails(double sal)
        {
            Pf = (Gross * 0.10);
            TDS = (Gross * 0.18);
            Netsal = Gross - (Pf + TDS);
            Console.WriteLine(Netsal);
            return Netsal;
        }
    }
    class program
    {

        public static void Main(string[] args)
        {
            Manager m = new Manager();
            ManagerSal ms = new ManagerSal(m.ManagerSalary);
            ms += m.FoodDetails;
            ms += m.PetrolDetails;
            ms += m.OtherDetails;
            ms += m.GrossSalaryDetails;
            ms += m.CalculateSalaryDetails;
            ms(60000);

        }
    }
}