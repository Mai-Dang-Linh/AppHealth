#include "Employees.h"
#include <iostream>
#include <iomanip>

using namespace std;
Employees::Employees()
{
	string mAccount = "";
	string mName = "";
	string mDepartment = "";
	string mJobTitle = "";
}
Employees::Employees(string account, string name, string department, string jobTitle)
{
	mAccount = account;
	mName = name;
	mDepartment = department;
	mJobTitle = jobTitle;
}


//fuction showInfromation: show all info of employess
void Employees::showInfromation()
{
	cout << "------------------------------------------------" << endl;
	cout << "Account" << this->getAccount() << endl;
	cout << "Name" << this->getName() << endl;
	cout << "Department" << this->getDepartment() << endl;
	cout << "Job Title" << this->getJobTitle() << endl;
	cout << "------------------------------------------------" << endl;
}
