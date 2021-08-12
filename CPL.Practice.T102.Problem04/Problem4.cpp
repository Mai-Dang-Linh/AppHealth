#include "Employees.h"
#include "Developer.h"
#include "Manager.h"
#include <vector>
#include <iomanip>
#include <iostream>
using namespace std;

#define INPUTEMP 1
#define SHOWINFO 2
#define EXIT 0

int main()
{
	vector<Employees*> listData;
	int numberEmp = 0;
	Employees* employee;
	int count = 0;	// count amount numberEmp
	int select = 0;	// save number employees
	int key = 0;
	do {
		system("cls");
		cout << "\t\t 1:Enter infor of employee					" << endl;
		cout << "\t\t 2:Show infor of employee					" << endl;
		cout << "\t\t 0:Exit the program						" << endl;
		cout << "Enter key(0-2):";
		cin >> key;
		while (cin.fail())
		{
			cout << "Invalid input value";
			cin.clear();
			cin.ignore(256, '\n');
			cout << "\nPlease re-enter value: ";
			cin >> key;
		}
		switch (key)
		{
		case INPUTEMP:
		{
			cout << "Enter number employee: ";
			cin >> numberEmp;
			while (count < numberEmp)
			{
				cout << "Input Developer (1) or Manager(2): ";
				cin >> select;
				if (select == 1)
				{
					employee = new Developer();
					employee->inputInfor();
					listData.push_back(employee);
				}
				else
				{
					employee = new Manager();
					employee->inputInfor();
					listData.push_back(employee);
				}
				count++;
			}
			system("pause");
			break;
		}
		case SHOWINFO:
		{
			if (listData.empty())
			{
				cout << " No data in list" << endl;
			}
			else
			{
				for (size_t i = 0; i < listData.size();i++)
				{
					listData[i]->showInfromation();
					listData[i]->displayDailyWork();
				}
			}
			system("pause");
			break;
		}
		case EXIT:
		{
			key = 0;
			system("pause");
			break;
		}
		default:
		{
			cout << "Invalid input value,please re-enter" << endl;
			system("pause");
			break;
		}
		}
	} while (key != 0);

	//delete listData type Employee*
	for (size_t i = 0; i < listData.size();i++)
	{
		delete listData[i];
	}

	return 0;
}