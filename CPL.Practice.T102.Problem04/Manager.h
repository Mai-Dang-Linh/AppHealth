#pragma once
#include "Employees.h"
#include "iostream"

using namespace std;

class Manager :public Employees
{
public:
	Manager();
	Manager(string account, string name, string department, string jobTitle, string customerName);
	~Manager();
	string getCustomerName() { return mCustomerName; }
	void setCustomerName(string customerName) { mCustomerName = customerName; }
	void inputInfor();
	void showInfromation();
	void displayDailyWork();
private:
	string mCustomerName;
};
