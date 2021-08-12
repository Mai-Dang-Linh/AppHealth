#pragma once
#include "Employees.h"
#include <iomanip>
#include <iostream>
class Developer :public Employees
{

public:
	Developer();
	Developer(string account, string name, string department, string jobTitle, string projectName);
	~Developer();
	void inputInfor();
	void showInfromation();
	void displayDailyWork();
	void setProjectName(string projectName) { mProjectName = projectName; }

	string getProjectName() { return mProjectName; }

private:
	string mProjectName;
};
