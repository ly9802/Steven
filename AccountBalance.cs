using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
This program is used to track several customers who have owed.this is an assignment of fuundamentals of programming
there are several requirement as follow:
1. the customer name should be between 6 and 14 characters
2. the account number should be 6 digitals and begin with 4
3.the overpayment is not allowed.
4.the account number should be used for once
*/
namespace Account_balance
{//create a class named Customer as template
    class Customer
    {   //declare private data members
        private string name;
        private int numberOfAccount;
        private double owingAccount;
        private double  totalPurchase;
        private double totalPayment;
        public Customer() {
            //create default constructor
        }
        public Customer(string n, int id, double oAccount, double totalP, double totalPay)
        {
            name = n;
            numberOfAccount = id;
            owingAccount = oAccount;
            totalPurchase = totalP;
            totalPayment = totalPay;
        }//create constructor to initiate all private variables.
        //properities of all data members
        public string Name{
            get{ return name;}
            set{ name = value; }
         }
        public int NumberOfAccount {
        get { return numberOfAccount; }
            set { numberOfAccount = value; }
        }
        public double OwingAccount {
        get { return owingAccount; }
            set { owingAccount = value; }
        }
        public double TotalPurchase {
        get { return totalPurchase; }
            set { totalPurchase = value; }
        }
        public double TotalPayment
        {
        get { return totalPayment; }
            set { totalPayment = value; }
        }
        public double TotalOwing() {
            return owingAccount + totalPurchase - totalPayment;
          }
        //ToString() method
        public override string ToString()
        {
            return "The balance at the end of this particular month is "+TotalOwing().ToString();
        }
    }
    //end class
    class Program
    {
        static void Main()
        {
            DisplayInstruction();//output instrucion about use of this program
            int numberOfCustomer = 0;
            Console.WriteLine("How many customers do you want to track?");// input how many customer need to be inputed
            do {
                while (int.TryParse(Console.ReadLine(), out numberOfCustomer) == false) {
                    Console.WriteLine("Error!Please input an integer number.");
                }
                if (numberOfCustomer<1) { Console.WriteLine("Error!The number of customers should be greater than zero,please try again."); }
            } while (numberOfCustomer<1);//make sure the nubmer of customers should be greater than zero.
            Customer[] client = new Customer[numberOfCustomer];//declare an array named client, each element is an object.
            int count = 0;//declare count as index of client array.
            double shouldPay = 0.0;//shouldPay is the sum of owing amount plus total purchases. 
            bool flag = false;
            while (count < numberOfCustomer)
            {
                Console.WriteLine();
                client[count] = new Customer();//use default constructor to instantiate each object, which is also the element of client array.
                client[count].Name = GetName(count);//use a method named GetName to ask user to input the customer's name.
                //make sure the Account Number has never been used before. 
                do {
                    client[count].NumberOfAccount = GetID(count);//GetID is a method which is used to ask user to input Account Number.
                    flag = false;
                    for (int i = 0; i < count; i++) {
                        if (client[i].NumberOfAccount == client[count].NumberOfAccount) {
                            flag = true;
                            Console.WriteLine("Error!The Account Number you input has been used.Please try again.");
                            break;
                        }
                    }
                } while (flag==true);//if flag value is true, it means the Account Number has been inputed before.
                client[count].OwingAccount = GetOwing(count);//GetOwing is a method which is used to ask user to input owing amount at the beginning of a particular month.
                client[count].TotalPurchase = GetPurchase(count);//GetPurchase is a method which is used to ask user to input total purchase amount during this particular month.
                shouldPay = client[count].OwingAccount + client[count].TotalPurchase;
                client[count].TotalPayment = GetPayment(count);//GetPayment is a method is to ask user to input total payment.
                while (shouldPay < client[count].TotalPayment)
                {
                    Console.WriteLine("Error!The total payment you input should be not great than owing account plus total purchase");
                    client[count].TotalPayment = GetPayment(count);
                }//make sure no overpayment occurs.
                count++;
            }//end while 
            //declare constant variable
            const double limit = 600.00;
            const string message = "Credit limit exceeded.";
            const string title1 = "Account Number";
            const string title2 = "Account Balance($)";
            const string titel3 = "Message";
            Console.Clear();
            Console.WriteLine("{0,-20}\t{1,-20}\t{2,-20}",title1,title2,titel3);
            Console.WriteLine("--------------------------------------------------------------------------------");
            foreach( Customer ct in client){
                if (ct.TotalOwing() > limit)
                {
                    Console.WriteLine("{0,-20}\t{1,-20:C}\t{2,-20}", ct.NumberOfAccount, ct.TotalOwing(), message);
                }
                else {
                    Console.WriteLine("{0,-20}\t{1,-20:C}",ct.NumberOfAccount,ct.TotalOwing());
                 }
            }
            Console.ReadKey();
        }//end main method
        //define GetName Method
        static string GetName(int c) {
            string name;
            do{
                Console.WriteLine("Please input the No.{0} customer's name(The name must be between 6 and 14 characters):", c+1);
                name = Console.ReadLine();
                if ((name.Length < 6) || (name.Length > 14)) {
                    Console.WriteLine("Error!The name you have entered must be between 6 and 14 characters.");
                }
            }while ((name.Length < 6) || (name.Length > 14)) ;
            return name;
        }
        //define GetID method
        static int GetID(int c) {
            int id;
            do {
                Console.WriteLine("Please input the No.{0} Customer's Account Number(The Account Number must be 6 digits and start with 4):", c+1);
                while (int.TryParse(Console.ReadLine(), out id) == false) {
                    Console.WriteLine("Error!  Please input the No.{0} Customer's Account Number:", c + 1); 
                }
                if ((id < 400000) || (id > 499999)) {
                    Console.WriteLine("Error!The Account Number must be 6 digits and start with 4.");
                }
            }while ((id < 400000) || (id > 499999)) ;
            return id;
        }
        //define GetOwing method
        static double GetOwing(int c) {
            double currentOwing;
            do
            {
                Console.WriteLine("Please input the amount owed by No.{0} customer to Target:", c+1);
                while (double.TryParse(Console.ReadLine(), out currentOwing) == false)
                {
                    Console.WriteLine("Your input should be a number.\nPlease input the amount owed by No.{0} customer to Target:", c + 1);
                }
                if (currentOwing<0) {
                    Console.WriteLine("The owing amount should be greater than or equal zero.");
                }
            } while (currentOwing<0);//make sure owing amount is never less than zero.
            return currentOwing;
        }
        //define GetPurchase method
        static double GetPurchase(int c)
        {
            double currentPurchase;
            do
            {
                Console.WriteLine("Please input the total purchases this month by the No.{0} customer:", c + 1);
                while (double.TryParse(Console.ReadLine(), out currentPurchase) == false)
                {
                    Console.WriteLine("Your input should be a number.\nPlease input the total purchase this month by the No.{0} customer:", c + 1);
                }
                if (currentPurchase<0) {
                    Console.WriteLine("The total purchase should be greater than or equal zero.");
                }
            } while (currentPurchase<0);//guarantee the total purchase is never less than zero.
            return currentPurchase;
        }
        //define GetPayment method
        static double GetPayment(int c) {
            double currentPayment;
            do
            {
                Console.WriteLine("Please input the total payment made by No.{0} customer:", c + 1);
                while (double.TryParse(Console.ReadLine(), out currentPayment) == false)
                {
                    Console.WriteLine("Your input should be a number.\nPlease input the total payment made by No.{0} customer:", c + 1);
                }
                if (currentPayment<0) {
                    Console.WriteLine("The total payment should be greater than or equal zero.");
                }
            } while (currentPayment<0);
            return currentPayment;
        }//make sure the total payment is never less than zero.
        //define DisplayInstrucition method
        static void DisplayInstruction() {
            Console.WriteLine("This program is to identify the customers who owe Target more than $600." +
                "\nA user needs to input the customer's name and Account Number." +
                "Then he or she needs to input owing amount at the beginning of a particular month,total purchase amount during this month and total payment for this month." +
                "\nThis program will calculate and ouput this customer's balance at the end of this particular month based on the data inputed by the user." +
                "\nPlease enter data according to the questions generated by this program.");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
        }
    }
}
