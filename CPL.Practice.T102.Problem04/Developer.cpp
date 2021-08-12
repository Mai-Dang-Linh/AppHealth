#include "Developer.h"


using namespace std;

Developer::Developer() {}
Developer::Developer(string account, string name, string department, string jobTitle, string projectName) :Employees(account, name, department, jobTitle)
{
	mProjectName = projectName;
}
Developer::~Developer() {
	cout << " Delete Developer" << endl;
}

// fuction inputInfor: input information of object Developer
void Developer::inputInfor()
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
	cout << "Enter project name: ";
	cin >> this->mProjectName;
	cout << "------------------------------------------------" << endl;

}

//fuction showInfromation: show all info of Developer
void Developer::showInfromation()
{
	cout << "------------------------------------------------" << endl;
	cout << "Account:" << this->getAccount() << endl;
	cout << "Name: " << this->getName() << endl;
	cout << "Department: " << this->getDepartment() << endl;
	cout << "Job Title: " << this->getJobTitle() << endl;
	cout << "Project Name: " << this->getProjectName() << endl;
	cout << "------------------------------------------------" << endl;
}

//fuction displayDailyWork: show project's name
void Developer::displayDailyWork()
{
	cout << "Coding in project: [" << getProjectName() << "]" << endl;
}
