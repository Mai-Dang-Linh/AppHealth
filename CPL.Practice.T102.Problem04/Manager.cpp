#include "Manager.h"
#include <iomanip>

Manager::Manager() {}
Manager::Manager(string account, string name, string department, string jobTitle, string customerName) :Employees(account, name, department, jobTitle)
{
	mCustomerName = customerName;
}
Manager::~Manager() {
	cout << " Delete class Manager" << endl;
}
// fuction inputInfor: input information of object Manager
void Manager::inputInfor()
{
	cout << "Enter account employee: ";
	cin >> mAccount;
	cout << "Enter name employee: ";
	cin.ignore();
	getline(cin, mName);
	cout << "Enter department of employee: ";
	cin >> mDepartment;
	cout << "Enter job title: ";
	cin >> mJobTitle;
	cout << "Enter Customer name: ";
	cin >> this->mCustomerName;
	cout << "------------------------------------------------" << endl;
}

//fuction showInfromation: show all info of Developer
void Manager::showInfromation()
{
	cout << "------------------------------------------------" << endl;
	cout << "Account:" << this->getAccount() << endl;
	cout << "Name: " << this->getName() << endl;
	cout << "Department: " << this->getDepartment() << endl;
	cout << "Job Title: " << this->getJobTitle() << endl;
	cout << "Customer Name:" << this->getCustomerName() << endl;
	cout << "------------------------------------------------" << endl;
}

//fuction displayDailyWork: show customer's name
void Manager::displayDailyWork()
{
	cout << "Working with customer: [" << getCustomerName() << "]" << endl;
}
