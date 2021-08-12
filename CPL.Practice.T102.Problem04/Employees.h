#pragma once
#include <string>
using namespace std;

class Employees
{
public:
	Employees();
	Employees(string account, string name, string department, string jobTitle);
	virtual ~Employees() {};
	virtual void showInfromation();
	virtual void displayDailyWork() = 0;
	virtual void inputInfor() = 0;
	void setAccount(const string& account) { mAccount = account; }
	void setName(const string& name) { mName = name; }
	void setDeparment(const string& deparment) { mDepartment = deparment; }
	void setJobTitle(const string& jobTitle) { mJobTitle = jobTitle; }
	string getAccount() { return mAccount; }
	string getName() { return mName; }
	string getDepartment() { return mDepartment; }
	string getJobTitle() { return mJobTitle; }

protected:
	string mAccount;
	string mName;
	string mDepartment;
	string mJobTitle;//

};
